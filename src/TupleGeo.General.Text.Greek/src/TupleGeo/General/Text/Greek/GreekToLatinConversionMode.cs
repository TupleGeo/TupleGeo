
#region Header
// Title Name       : GreekToLatinConversionMode
// Member of        : TupleGeo.General.Text.Greek.dll
// Description      : The Greek to Latin conversion mode enumeration.
// Created by       : 06/04/2010, 14:14, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 21:43, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2010 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace TupleGeo.General.Text.Greek {
  
  /// <summary>
  /// The Greek to Latin conversion mode enumeration.
  /// </summary>
  public enum GreekToLatinConversionMode {

    /// <summary>
    /// Upper case mode.
    /// </summary>
    Uppercase = 0,

    /// <summary>
    /// Lower case mode.
    /// </summary>
    Lowercase = 1,

    /// <summary>
    /// Mixed case conversion mode.
    /// </summary>
    Mixedcase = 2,

  }

}
