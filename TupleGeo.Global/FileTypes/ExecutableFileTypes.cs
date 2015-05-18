
#region Header
// Title Name       : ExecutableFileTypes
// Member of        : TupleGeo.Global.dll
// Description      : Executable file types enumeration
// Created by       : 26/03/2009, 19:43, Vasilis Vlastaras.
// Updated by       : 23/02/2011, 22:16, Vasilis Vlastaras.
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
using System.Xml.Serialization;
using TupleGeo.Global.Attributes;

#endregion

namespace TupleGeo.Global.FileTypes {

  /// <summary>
  /// Types of executable files.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  public enum ExecutableFileTypes {

    /// <summary>
    /// Dynamic link library file type.
    /// </summary>
    [XmlEnumAttribute("dll")]
    [DescriptionAttribute("Dynamic link library file type")]
    [DescriptionAttribute("Μορφότυπος αρχείου βιβλιοθήκης δυναμικής διασύνδεσης.", "el-GR")]
    Dll,

    /// <summary>
    /// Executable file type.
    /// </summary>
    [XmlEnumAttribute("exe")]
    [DescriptionAttribute("Executable file type")]
    [DescriptionAttribute("Μορφότυπος εκτελέσιμου αρχείου.", "el-GR")]
    Exe,

  }

}
