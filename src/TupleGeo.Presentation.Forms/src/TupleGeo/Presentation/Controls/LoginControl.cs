
#region Header
// Title Name       : LoginControl
// Member of        : TupleGeo.Presentation.dll
// Description      : Provides forms and controls.
// Created by       : 11/02/2009, 09:52, Vasilis Vlastaras.
// Updated by       : 29/04/2009, 22:21, Vasilis Vlastaras. - Changed class for COM interop.
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
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#endregion

namespace TupleGeo.Presentation.Controls {

  /// <summary>
  /// The Login Control provides login functionality in an abstract way.
  /// </summary>
  [GuidAttribute("EA028556-3230-453f-A2CC-A22CDCA86615")]
  [ClassInterfaceAttribute(ClassInterfaceType.None)]
  [ProgIdAttribute("TupleGeo.Presentation.Controls.LoginControl")]
  public partial class LoginControl : UserControl {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="LoginControl"/>.
    /// </summary>
    public LoginControl() {
      InitializeComponent();
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the user names <see cref="ComboBox"/>.
    /// </summary>
    public ComboBox UserNamesComboBox {
      get {
        return this.cboUsername;
      }
    }

    /// <summary>
    /// Gets the password <see cref="TextBox"/>.
    /// </summary>
    public TextBox PasswordTextBox {
      get {
        return this.txtPassword;
      }
    }

    /// <summary>
    /// Gets the remember password <see cref="CheckBox"/>.
    /// </summary>
    public CheckBox RememberPasswordCheckBox {
      get {
        return this.chkRememberPassword;
      }
    }

    /// <summary>
    /// Gets the warning <see cref="Label"/>.
    /// </summary>
    public Label WarningLabel {
      get {
        return this.lblWarning;
      }
    }

    /// <summary>
    /// Gets the OK <see cref="Button"/>.
    /// </summary>
    public Button OkButton {
      get {
        return this.btnOK;
      }
    }

    /// <summary>
    /// Gets the Cancel <see cref="Button"/>.
    /// </summary>
    public Button CancelButton {
      get {
        return this.btnCancel;
      }
    }

    #endregion

    #region Public Methods
    
    #endregion

    #region Events

    #endregion

    #region Private Procedures
    
    #endregion
    
  }

}
