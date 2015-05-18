
#region Header
// Title Name       : EnumDescriptionControl
// Member of        : TupleGeo.General.ComponentModel.Design.dll
// Description      : A control providing a list having the descriptions of enumerated values.
// Created by       : 12/03/2009, 15:02, Vasilis Vlastaras.
// Updated by       : 23/02/2011, 00:58, Vasilis Vlastaras.
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
  /// A control providing a list having the descriptions of enumerated values.
  /// </summary>
  public partial class EnumDescriptionEditorControl : UserControl {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the EnumDescriptionControl.
    /// </summary>
    public EnumDescriptionEditorControl() {
      InitializeComponent();
    }

    #endregion

    #region Public Properties

    private List<EnumNameDescriptionPair> _enumDescriptionsList = new List<EnumNameDescriptionPair>();

    /// <summary>
    /// The list of <see cref="EnumNameDescriptionPair">EnumNameDescriptionPairs</see>
    /// used to provide the descriptions displayed in the control.
    /// </summary>
    public List<EnumNameDescriptionPair> EnumDescriptionsList {
      get {
        return _enumDescriptionsList;
      }
      set {
        _enumDescriptionsList = value;
      }
    }

    private object _selectedEnumValueName;

    /// <summary>
    /// The selected name of the enumerated value.
    /// </summary>
    public object SelectedEnumValueName {
      get {
        return _selectedEnumValueName;
      }
      set {
        //_selectedEnumValueName = value;
        
        ////EnumNameDescriptionPair p = _enumDescriptionsList.Where(e => e.Name == _selectedEnumValueName.ToString()).First();

        ////this.EnumDescriptionsListBox.SelectionMode = SelectionMode.One;
        ////this.EnumDescriptionsListBox.

        //this.EnumDescriptionsListBox.SelectedValue = value;
          
      }
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs upon loading the control.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/>.</param>
    private void EnumDescriptionControl_Load(object sender, EventArgs e) {
      this.EnumDescriptionsListBox.DisplayMember = "Description";
      this.EnumDescriptionsListBox.ValueMember = "Name";
      this.EnumDescriptionsListBox.DataSource = _enumDescriptionsList;
    }

    /// <summary>
    /// Occurs upon clicking the <see cref="EnumDescriptionsListBox"/> with the mouse.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/>.</param>
    private void EnumDescriptionsListBox_MouseClick(object sender, MouseEventArgs e) {
      if (this.EnumDescriptionsListBox != null) {
        _selectedEnumValueName = this.EnumDescriptionsListBox.SelectedValue;
      }
      else {
        _selectedEnumValueName = null;
      }
      this.OnMouseClick(new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta));
    }

    /// <summary>
    /// Occurs when the selected value of the <see cref="EnumDescriptionsListBox"/> has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/>.</param>
    private void EnumDescriptionsListBox_SelectedValueChanged(object sender, EventArgs e) {
      if (this.EnumDescriptionsListBox != null) {
        _selectedEnumValueName = this.EnumDescriptionsListBox.SelectedValue;
      }
    }

    #endregion
    
  }

}
