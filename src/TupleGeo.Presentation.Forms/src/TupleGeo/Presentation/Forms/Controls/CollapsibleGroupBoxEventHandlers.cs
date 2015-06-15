
#region Header
// Title Name       : CollapsibleGroupBoxEventHandlers
// Member of        : TupleGeo.Presentation.Forms.dll
// Description      : A file containing the delegates used as EventHandlers related to CollapsibleGroupBox.
// Created by       : 17/07/2009, 19:49, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace TupleGeo.Presentation.Forms.Controls {

  /// <summary>
  /// The delegate with the event handler signature used by
  /// events signaling the click of the collapse box in
  /// <see cref="CollapsibleGroupBox"/> controls.
  /// </summary>
  /// <param name="sender">The sender of the event.</param>
  /// <param name="e">The event arguments.</param>
  public delegate void CollapseBoxClickedEventHandler(object sender, EventArgs e);

}
