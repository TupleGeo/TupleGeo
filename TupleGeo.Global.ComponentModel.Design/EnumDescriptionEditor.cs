
#region Header
// Title Name       : EnumDescriptionEditor
// Member of        : TupleGeo.Global.ComponentModel.Design.dll
// Description      : Provides an editor for enumerations that is displaying value descriptions.
// Created by       : 03/03/2010, 17:23, Vasilis Vlastaras.
// Updated by       : 23/02/2010, 16:57, Vasilis Vlastaras.
//                    1.0.1 - Added preprocessor directives to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.1
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

#if !NET20
using System.Linq;
#endif

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace TupleGeo.Global.ComponentModel.Design {

  /// <summary>
  /// Provides an editor for enumerations that is displaying value descriptions.
  /// </summary>
  public class EnumDescriptionEditor : UITypeEditor {

    #region Member Variables

    private IWindowsFormsEditorService _windowsFormsEditorService;
    private EnumDescriptionEditorControl _enumDescriptionControl = null;

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

    #region UITypeEditor

    /// <summary>
    /// Edits a <see cref="string"/> value.
    /// </summary>
    /// <param name="context">The <see cref="ITypeDescriptorContext"/>.</param>
    /// <param name="provider">The <see cref="IServiceProvider"/>.</param>
    /// <param name="value">The value to be edited.</param>
    /// <returns>An <see cref="object"/> storing the edited <see cref="string"/>.</returns>
    public override object EditValue(
      ITypeDescriptorContext context,
      IServiceProvider provider,
      object value
    ) {

      // Set the windows service.
      this._windowsFormsEditorService =
        (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

      // Unsubscribe / Subscribe to enumeration description control events.
      _enumDescriptionControl.MouseClick -= new System.Windows.Forms.MouseEventHandler(_enumDescriptionControl_MouseClick);
      _enumDescriptionControl.MouseClick += new System.Windows.Forms.MouseEventHandler(_enumDescriptionControl_MouseClick);

      _enumDescriptionControl.KeyDown -= new System.Windows.Forms.KeyEventHandler(_enumDescriptionControl_KeyDown);
      _enumDescriptionControl.KeyDown += new System.Windows.Forms.KeyEventHandler(_enumDescriptionControl_KeyDown);

      if (_enumDescriptionControl.EnumDescriptionsList != null) {
        // Load descriptions in the control.
        if (_enumDescriptionControl.EnumDescriptionsList.Count <= 0) {
          string[] sNames = Enum.GetNames(value.GetType());
          string[] sDescriptions = EnumDescriptionConverter.GetEnumDescriptions((Enum)value);

          for (int i = 0; i < sDescriptions.Length; i++) {
            _enumDescriptionControl.EnumDescriptionsList.Add(new EnumNameDescriptionPair(sNames[i], sDescriptions[i]));
          }

#if NET20
          // Use a Comparison<T> delegate for the Sort method on EnumDescriptionList in order to provide a
          // custom sorting according to enumeration descriptions.
          _enumDescriptionControl.EnumDescriptionsList.Sort(delegate(EnumNameDescriptionPair pair1, EnumNameDescriptionPair pair2) {
            return string.Compare(pair1.Description, pair2.Description);
          });
#else
          // Sort the descriptions and display them on the control.
          _enumDescriptionControl.EnumDescriptionsList = _enumDescriptionControl.EnumDescriptionsList.OrderBy(e => e.Description).ToList();
#endif

          // Set the selected value. -- // TODO: For some reason it is not possible to set the value !!!
          //_enumDescriptionControl.SelectedEnumValueName = value;
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
    /// <param name="context">The <see cref="ITypeDescriptorContext"/>.</param>
    /// <returns>The <see cref="UITypeEditorEditStyle"/>.</returns>
    public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
      return UITypeEditorEditStyle.DropDown;
    }

    /// <summary>
    /// Gets whether the paint value is supported or not.
    /// </summary>
    /// <param name="context">The <see cref="ITypeDescriptorContext"/>.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the paint value is supported or not.
    /// </returns>
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

    #region Event Procedures

    /// <summary>
    /// Occurs when the user clicks the enumeration description control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/>.</param>
    private void _enumDescriptionControl_MouseClick(object sender, MouseEventArgs e) {
      _windowsFormsEditorService.CloseDropDown();
    }

    /// <summary>
    /// Occurs when the user presses a key on the enumeration description control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="KeyEventArgs"/>.</param>
    private void _enumDescriptionControl_KeyDown(object sender, KeyEventArgs e) {
      _windowsFormsEditorService.CloseDropDown();
    }
    
    #endregion

  }

}
