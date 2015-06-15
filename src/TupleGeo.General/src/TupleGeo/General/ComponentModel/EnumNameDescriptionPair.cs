
#region Header
// Title Name       : EnumNameDescription
// Member of        : TupleGeo.General.dll
// Description      : An object containing an enumeration name and an enumeration description.
// Created by       : 03/03/2010, 15:19, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 22:49, Vasilis Vlastaras.
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

namespace TupleGeo.General.ComponentModel {
  
  /// <summary>
  /// An object containing an enumeration name and an enumeration description.
  /// </summary>
  public sealed class EnumNameDescriptionPair {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="EnumNameDescriptionPair"/>.
    /// </summary>
    /// <param name="name">The name of the enumeration value.</param>
    /// <param name="description">The description of the enumeration value.</param>
    public EnumNameDescriptionPair(string name, string description) {
      _name = name;
      _description = description;
    }

    #endregion

    #region Public Properties

    string _name;

    /// <summary>
    /// Gets / Sets the name of the enumerated value.
    /// </summary>
    public string Name {
      get {
        return _name;
      }
      set {
        _name = value;
      }
    }

    string _description;

    /// <summary>
    /// Gets / Sets the description of the enumerated value.
    /// </summary>
    public string Description {
      get {
        return _description;
      }
      set {
        _description = value;
      }
    }

    #endregion

  }

}
