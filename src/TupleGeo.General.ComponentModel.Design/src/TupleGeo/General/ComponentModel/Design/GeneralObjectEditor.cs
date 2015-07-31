
#region Header
// Title Name       : GeneralObjectEditor
// Member of        : TupleGeo.General.ComponentModel.Design.dll
// Description      : A general editor used to edit an object using a property grid.
// Created by       : 12/03/2010, 15:51, Vasilis Vlastaras.
// Updated by       : 23/02/2011, 01:00, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

#if NET350
using System.Security.Permissions;
#endif

using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace TupleGeo.General.ComponentModel.Design {
  
  /// <summary>
  /// A general editor used to edit an object using a property grid.
  /// </summary>
#if NET350
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
  public sealed class GeneralObjectEditor : UITypeEditor, IDisposable {

    #region Member Variables

    private IWindowsFormsEditorService _windowsFormsEditorService;
    private GeneralObjectEditorControl _generalObjectEditorControl = null;

    private ToolStripButton _button = null;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="GeneralObjectEditor"/>.
    /// </summary>
    public GeneralObjectEditor() {
      if (_generalObjectEditorControl == null) {
        _generalObjectEditorControl = new GeneralObjectEditorControl();
        _button = null;
      }
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when a button has been clicked on the <see cref="GeneralObjectEditor"/> control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The EventArgs.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="sender"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="sender"/> is not of the expected <see cref="Type"/>.
    /// </exception>
    private void _generalObjectEditorControl_ButtonClick(object sender, EventArgs e) {
      if (sender != null) {
        if (sender.GetType() == typeof(ToolStripButton)) {
          _button = (ToolStripButton)sender;
        }
        else {
          throw new ArgumentException("Sender object was not of the expected type.", "sender");
        }
      }
      else {
        throw new ArgumentNullException("sender", "Sender button was null. Expected ToolStripButton.");
      }

      _windowsFormsEditorService.CloseDropDown();
    }

    #endregion

    #region UITypeEditor

    /// <summary>
    /// Edits any object.
    /// </summary>
    /// <param name="context">The ITypeDescriptorContext.</param>
    /// <param name="provider">The IServiceProvider.</param>
    /// <param name="value">The value to be edited.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="context"/> or <paramref name="provider"/> or <paramref name="value"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="value"/> is not of the expected <see cref="Type"/>.
    /// </exception>
    /// <returns>The edited object.</returns>
#if NET350
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
    public override object EditValue(
      ITypeDescriptorContext context,
      IServiceProvider provider,
      object value
    ) {

      if (context == null) {
        throw new ArgumentNullException("context");
      }

      if (provider == null) {
        throw new ArgumentNullException("provider");
      }

      if (value == null) {
        throw new ArgumentNullException("value");
      }

      if (!value.GetType().IsEnum) {
        throw new ArgumentException("Invalid value type.", "value");
      }

      try {

        _button = null;

        // Set the windows service.
        this._windowsFormsEditorService =
          (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

        // Unsubscribe / Subscribe to general object editor control events.
        _generalObjectEditorControl.ButtonClick -= new EventHandler(_generalObjectEditorControl_ButtonClick);
        _generalObjectEditorControl.ButtonClick += new EventHandler(_generalObjectEditorControl_ButtonClick);

        _generalObjectEditorControl.Show();
        _windowsFormsEditorService.DropDownControl(_generalObjectEditorControl);

        if (_button != null) {
          if (_button.Name == "NewObjectToolStripButton") {
            object o = context.PropertyDescriptor.PropertyType.Assembly.CreateInstance(
              context.PropertyDescriptor.PropertyType.FullName
            );
            return o;
          }
          else if (_button.Name == "DeleteObjectToolStripButton") {
            return null;
          }
          else {
            return value;
          }
        }
        else {
          return value;
        }
  
      }
      catch {
        // Swallow the exception.
        _windowsFormsEditorService.CloseDropDown();
        return value;
      }
      
    }

    /// <summary>
    /// Gets the <see cref="UITypeEditorEditStyle">edit style</see> of the editor window.
    /// </summary>
    /// <param name="context">The ITypeDescriptorContext.</param>
    /// <returns>The UITypeEditorEditStyle.</returns>
#if NET350
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
#if NET350
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
#endif
    public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context) {
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
    /// disposes its associated <see cref="GeneralObjectEditorControl"/>. 
    /// </summary>
    public void Dispose() {
      _generalObjectEditorControl.Dispose();
    }

    #endregion

  }

}
