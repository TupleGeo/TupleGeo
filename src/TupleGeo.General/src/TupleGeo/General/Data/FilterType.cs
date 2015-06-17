
#region Header
// Title Name       : FilterType
// Member of        : TupleGeo.General.dll
// Description      : Specifies the types of filter queries.
// Created by       : 13/05/2009, 05:53, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 23:00, Vasilis Vlastaras.
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

namespace TupleGeo.General.Data {

  /// <summary>
  /// Specifies the types of filter queries.
  /// </summary>
  public enum FilterType {

    /// <summary>
    /// The filter specifies that the like operator should be used and
    /// that the filter string should be matched inside the target string.
    /// </summary>
    Contains = 0,

    /// <summary>
    /// The filter specifies that the like operator should be used and
    /// that the filter string should be matched from the beginning of
    /// the target string.
    /// </summary>
    StartsWith = 1,
    
    /// <summary>
    /// The filter specifies that the like operator should be used and
    /// that the filter string should be matched at the end of
    /// the target string.
    /// </summary>
    EndsWith = 2,
    
    /// <summary>
    /// The filter is used in conjunction with the equals operator.
    /// </summary>
    Exact = 3,
    
  }

}
