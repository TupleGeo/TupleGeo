
#region Header
// Title Name       : CodePage
// Member of        : TupleGeo.General.dll
// Description      : The codepage enumeration.
// Created by       : 21/07/2009, 16:54, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 21:44, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
//                  : 29/05/2015, 06:51, Vasilis Vlastaras.
//                    1.0.2 - Changed Enumeration name from plural to singular.
// Version          : 1.0.2
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
  public enum CodePage {

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
