
#region Header
// Title Name       : GeneralObjectEditorControl
// Member of        : TupleGeo.General.ComponentModel.Design.dll
// Description      : A control providing a way to add or remove new objects.
// Created by       : 14/04/2009, 16:54, Vasilis Vlastaras.
// Updated by       : 23/02/2011, 00:59, Vasilis Vlastaras.
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#endregion

namespace TupleGeo.General.ComponentModel.Design {

  /// <summary>
  /// A control providing a way to add or remove new objects.
  /// </summary>
  public partial class GeneralObjectEditorControl : UserControl {

    #region Member Variables

    /// <summary>
    /// Notifies listeners about a click on a button.
    /// </summary>
    public event EventHandler ButtonClick;

    #endregion

    #region Consructors - Destructors

    /// <summary>
    /// Initializes the GeneralObjectEditorControl.
    /// </summary>
    public GeneralObjectEditorControl() {
      InitializeComponent();
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs upon clicking the <see cref="NewObjectToolStripButton"/>
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/>.</param>
    private void NewObjectToolStripButton_Click(object sender, EventArgs e) {
      if (ButtonClick != null) {
        ButtonClick(sender, e);
      }
    }

    /// <summary>
    /// Occurs upon clicking the <see cref="DeleteObjectToolStripButton"/>
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/>.</param>
    private void DeleteObjectToolStripButton_Click(object sender, EventArgs e) {
      if (ButtonClick != null) {
        ButtonClick(sender, e);
      }
    }

    #endregion

  }

}
