
#region Header
// Title Name       : EsriFileTypes
// Member of        : TupleGeo.General.dll
// Description      : Vector file types enumeration.
// Created by       : 19/05/2009, 03:55, Vasilis Vlastaras
// Updated by       : 22/02/2011, 22:12, Vasilis Vlastaras.
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
using TupleGeo.General.Attributes;

#endregion

namespace TupleGeo.General.FileTypes {

  /// <summary>
  /// Types of vector files.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  public enum EsriFileTypes {

    /// <summary>
    /// ESRI ArcMap map document file format.
    /// </summary>
    [XmlEnumAttribute("mxd")]
    [DescriptionAttribute("ESRI ArcMap map document file format")]
    [DescriptionAttribute("Μορφότυπος αρχείου χάρτη ArcMap.", "el-GR")]
    Mxd,

    /// <summary>
    /// Adobe Illustrator graphics file format.
    /// </summary>
    [XmlEnumAttribute("mxt")]
    [DescriptionAttribute("ESRI ArcMap map document template file format")]
    [DescriptionAttribute("Μορφότυπος φόρμας χάρτη ArcMap.", "el-GR")]
    Mxt,

    /// <summary>
    /// Polygon Attribute Table file format.
    /// </summary>
    [XmlEnumAttribute("pat_ArcInfo")]
    [DescriptionAttribute("Polygon Attribute Table file format")]
    Pat_ArcInfo,
    
    /// <summary>
    /// ESRI Shapefile format.
    /// </summary>
    [XmlEnumAttribute("shp")]
    [DescriptionAttribute("ESRI Shapefile format")]
    Shp,

  }

}
