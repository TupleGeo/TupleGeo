
#region Header
// Title Name       : CodePages
// Member of        : TupleGeo.General.dll
// Description      : The codepages enumeration.
// Created by       : 21/07/2009, 16:54, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 21:44, Vasilis Vlastaras.
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
using System.Text;

#endregion

namespace TupleGeo.General.Text {

  /// <summary>
  /// The codepages enumeration.
  /// </summary>
  public enum CodePages {

    /// <summary>
    /// The Windows latin 1252 codepage.
    /// </summary>
    Windows1252 = 1252,

    /// <summary>
    /// The Greek codepage.
    /// </summary>
    Greek = 1253

  }

}
