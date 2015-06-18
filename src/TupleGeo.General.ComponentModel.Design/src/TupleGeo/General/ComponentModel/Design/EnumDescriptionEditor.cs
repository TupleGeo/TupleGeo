
#region Header
// Title Name       : EnumDescriptionEditor
// Member of        : TupleGeo.General.ComponentModel.Design.dll
// Description      : Provides an editor for enumerations that is displaying value descriptions.
// Created by       : 03/03/2010, 17:23, Vasilis Vlastaras.
// Updated by       : 23/02/2010, 16:57, Vasilis Vlastaras.
//                    1.0.1 - Added preprocessor directives to make the source file compatible with .NET Framework 2.0.
//                  : 23/05/2015, 07:44, Vasilis Vlastaras.
//                    1.0.2 - Changed the code to make the editor behaving better.
// Version          : 1.0.2
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2010 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#if NET35
using System.Security.Permissions;
#endif

#endregion

namespace TupleGeo.General.ComponentModel.Design {

  /// <summary>
  /// Provides an editor for enumerations that is displaying value descriptions.
  /// </summary>
#if NET35
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
  public sealed class EnumDescriptionEditor : UITypeEditor, IDisposable {

    #region Member Variables

    private IWindowsFormsEditorService _windowsFormsEditorService;
    private EnumDescriptionEditorControl _enumDescriptionControl = null;
    private string _lastCultureUsed;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="EnumDescriptionEditor"/>.
    /// </summary>
    public EnumDescriptionEditor() {
      if (_enumDescriptionControl == null) {
        _enumDescriptionControl = new EnumDescriptionEditorControl();
      }
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when the user clicks the enumeration description control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The MouseEventArgs.</param>
    private void _enumDescriptionControl_MouseClick(object sender, MouseEventArgs e) {
      _windowsFormsEditorService.CloseDropDown();
    }

    /// <summary>
    /// Occurs when the user presses a key on the enumeration description control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The KeyEventArgs.</param>
    private void _enumDescriptionControl_KeyDown(object sender, KeyEventArgs e) {
      _windowsFormsEditorService.CloseDropDown();
    }

    #endregion

    #region UITypeEditor

    /// <summary>
    /// Edits a <see cref="string"/> value.
    /// </summary>
    /// <param name="context">The ITypeDescriptorContext.</param>
    /// <param name="provider">The IServiceProvider.</param>
    /// <param name="value">The value to be edited.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="value"/> or <paramref name="provider"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="value"/> is not an <see cref="Enum"/> value.
    /// </exception>
    /// <returns>An object storing the edited <see cref="string"/>.</returns>
#if NET35
    [PermissionSet(SecurityAction.LinkDemand, Name="FullTrust")]
#endif
    public override object EditValue(
      ITypeDescriptorContext context,
      IServiceProvider provider,
      object value
    ) {

      if (value == null) {
        throw new ArgumentNullException("value");
      }
      
      if (!value.GetType().IsEnum) {
        throw new ArgumentException("Invalid value type.", "value");
      }

      if (provider == null) {
        throw new ArgumentNullException("provider");
      }
      
      // Set the windows service.
      this._windowsFormsEditorService =
        (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

      // Unsubscribe / Subscribe to enumeration description control events.
      _enumDescriptionControl.MouseClick -= new System.Windows.Forms.MouseEventHandler(_enumDescriptionControl_MouseClick);
      _enumDescriptionControl.MouseClick += new System.Windows.Forms.MouseEventHandler(_enumDescriptionControl_MouseClick);

      _enumDescriptionControl.KeyDown -= new System.Windows.Forms.KeyEventHandler(_enumDescriptionControl_KeyDown);
      _enumDescriptionControl.KeyDown += new System.Windows.Forms.KeyEventHandler(_enumDescriptionControl_KeyDown);

      if (_enumDescriptionControl.EnumDescriptionsCollection != null) {
        // Load descriptions in the control.
        if (Application.CurrentCulture.ToString() != _lastCultureUsed) {
          _enumDescriptionControl.EnumDescriptionsCollection.Clear();

          _lastCultureUsed = Application.CurrentCulture.ToString();

          // Get the enumeration value.
          Enum enumValue = (Enum)value;

          // Get the enumeration names.
          string[] names = Enum.GetNames(value.GetType());

          // Try to get the enumeration descriptions for the current application culture.
          string[] descriptions = EnumDescriptionConverter.GetEnumDescriptions(enumValue, _lastCultureUsed);

          // Test if names and descriptions are the same.
          // If this is the case then descriptions in current culture where not found.
          bool areTheSame = true;
          for (int i = 0; i < names.Length; i++) {
            if (names[i] != descriptions[i]) {
              areTheSame = false;
              break;
            }
          }
          
          if (areTheSame) {
            // Since no descriptions found for the current culture, try to get the neutral culture descriptions.
            descriptions = EnumDescriptionConverter.GetEnumDescriptions(enumValue);
          }
          
          // Ending up here either the current culture descriptions,
          // neutral culture descriptions or enumeration named value have been retrieved.
          for (int i = 0; i < descriptions.Length; i++) {
            _enumDescriptionControl.EnumDescriptionsCollection.Add(new EnumNameDescriptionPair(names[i], descriptions[i]));
          }

          // Sort the collection and bind the data to the control.
          _enumDescriptionControl.SortEnumDescriptionsCollection();
          _enumDescriptionControl.DataBind();
          
          // Set the selected item on the control.
          _enumDescriptionControl.SetSelectedEnumValueName(enumValue.ToString());
          
        }

        // Show the enumeration editing control.
        _enumDescriptionControl.Show();
        this._windowsFormsEditorService.DropDownControl(_enumDescriptionControl);

        if (_enumDescriptionControl.SelectedEnumValueName != null) {
          // Return the enumerated value once the user has selected one.
          return Enum.Parse(value.GetType(), (string)_enumDescriptionControl.SelectedEnumValueName);
        }
        else {
          return null;
        }
      }
      else {
        return null;
      }
      
    }

    /// <summary>
    /// Gets the <see cref="UITypeEditorEditStyle">edit style</see> of the editor window.
    /// </summary>
    /// <param name="context">The ITypeDescriptorContext.</param>
    /// <returns>The UITypeEditorEditStyle.</returns>
#if NET35
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
      return UITypeEditorEditStyle.DropDown;
    }

    /// <summary>
    /// Gets whether the paint value is supported or not.
    /// </summary>
    /// <param name="context">The ITypeDescriptorContext.</param>
    /// <returns>
    /// A value indicating whether the paint value is supported or not.
    /// </returns>
#if NET35
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
    public override bool GetPaintValueSupported(ITypeDescriptorContext context) {
      return false;
    }

    /// <summary>
    /// Indicates whether the dropdown window is resizable or not.
    /// </summary>
    public override bool IsDropDownResizable {
      get {
        return true;
      }
    }

    #endregion

    #region IDisposable Members

    /// <summary>
    /// Disposes the <see cref="EnumDescriptionEditor"/> which subsequently
    /// disposes its associated <see cref="EnumDescriptionEditorControl"/>. 
    /// </summary>
    public void Dispose() {
      _enumDescriptionControl.Dispose();
    }

    #endregion

  }

}
