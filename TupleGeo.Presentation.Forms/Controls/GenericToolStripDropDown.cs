
#region Header
// Title Name       : GenericToolStripDropDown
// Member of        : TupleGeo.Presentation.dll
// Description      : The GenericToolStripDropDown is a generic control to provide hosting for toolstrip items.
// Created by       : 29/04/2009, 22:37, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#endregion

namespace TupleGeo.Presentation.Controls {

  /// <summary>
  /// The GenericToolStripDropDown is a generic control to provide
  /// hosting for <see cref="ToolStripItem">toolstrip items</see>.
  /// </summary>
  [GuidAttribute("6A65E0CF-18E9-4d8f-A026-ECDB5E3EE0B8")]
  [ClassInterfaceAttribute(ClassInterfaceType.None)]
  [ProgIdAttribute("TupleGeo.Presentation.Controls.GenericToolStripDropDown")]
  public partial class GenericToolStripDropDown : ToolStripDropDown {

    #region Constructors - Destructors

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public GenericToolStripDropDown() {
      InitializeComponent();
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs upon painting the control.
    /// </summary>
    /// <param name="pe">The <see cref="PaintEventArgs"/>.</param>
    protected override void OnPaint(PaintEventArgs pe) {
      base.OnPaint(pe);
    }

    #endregion

  }

}
