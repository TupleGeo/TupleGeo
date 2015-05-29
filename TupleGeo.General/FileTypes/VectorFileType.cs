
#region Header
// Title Name       : VectorFileTypes
// Member of        : TupleGeo.General.dll
// Description      : Vector file types enumeration.
// Created by       : 07/02/2009, 06:01, Vasilis Vlastaras.
// Updated by       : 19/02/2009, 00:46, Vasilis Vlastaras.
//                    1.0.1 - Moved class from another assembly.
//                  : 26/03/2009, 19:40, Vasilis Vlastaras.
//                    1.0.2 - Added System.Xml.Serialization namespace / Cleaned up file.
//                  : 22/02/2011, 22:16, Vasilis Vlastaras.
//                    1.0.3 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.3
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
  [XmlTypeAttribute(AnonymousType=false)]
  public enum VectorFileType {

    /// <summary>
    /// Acorn Draw file format.
    /// </summary>
    [XmlEnumAttribute("acorn")]
    [DescriptionAttribute("Acorn Draw file format")]
    [DescriptionAttribute("Μορφότυπος αρχείου Acorn Draw", "el-GR")]
    Acorn,
    
    /// <summary>
    /// Adobe Illustrator graphics file format.
    /// </summary>
    [XmlEnumAttribute("ai")]
    [DescriptionAttribute("Adobe Illustrator graphics file format")]
    [DescriptionAttribute("Μορφότυπος αρχείου γραφικών Adobe Illustrator", "el-GR")]
    AI,
    
    /// <summary>
    /// Adobe Illustrator template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ait")]
    [XmlEnumAttribute("ait")]
    [DescriptionAttribute("Adobe Illustrator template file format")]
    Ait,
    
    /// <summary>
    /// Adobe Illustrator graphics file format.
    /// </summary>
    [XmlEnumAttribute("art")]
    [DescriptionAttribute("Adobe Illustrator graphics file format")]
    Art,
    
    /// <summary>
    /// Ability Draw file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Awg")]
    [XmlEnumAttribute("awg")]
    [DescriptionAttribute("Ability Draw file format")]
    Awg,
    
    /// <summary>
    /// CorelDRAW vector image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdr")]
    [XmlEnumAttribute("cdr")]
    [DescriptionAttribute("CorelDRAW vector image file format")]
    Cdr,

    /// <summary>
    /// CorelDRAW 3 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdr")]
    [XmlEnumAttribute("cdr3")]
    [DescriptionAttribute("CorelDRAW 3 drawing file format")]
    Cdr3,
    
    /// <summary>
    /// CorelDRAW 4 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdr")]
    [XmlEnumAttribute("cdr4")]
    [DescriptionAttribute("CorelDRAW 4 drawing file format")]
    Cdr4,
    
    /// <summary>
    /// CorelDRAW 5 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdr")]
    [XmlEnumAttribute("cdr5")]
    [DescriptionAttribute("CorelDRAW 5 drawing file format")]
    Cdr5,
    
    /// <summary>
    /// CorelDRAW 6 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdr")]
    [XmlEnumAttribute("cdr6")]
    [DescriptionAttribute("CorelDRAW 6 drawing file format")]
    Cdr6,
    
    /// <summary>
    /// CorelDRAW file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdrw")]
    [XmlEnumAttribute("cdrw")]
    [DescriptionAttribute("CorelDRAW file format")]
    Cdrw,
    
    /// <summary>
    /// CorelDRAW Template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cdt")]
    [XmlEnumAttribute("cdt")]
    [DescriptionAttribute("CorelDRAW Template file format")]
    Cdt,
    
    /// <summary>
    /// Computer graphics metafile file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cgm")]
    [XmlEnumAttribute("cgm")]
    [DescriptionAttribute("Computer graphics metafile file format")]
    Cgm,
    
    /// <summary>
    /// SeeYou vector maps file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cit")]
    [XmlEnumAttribute("cit")]
    [DescriptionAttribute("SeeYou vector maps file format")]
    Cit,
    
    /// <summary>
    /// CorelDRAW vector image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cmx")]
    [XmlEnumAttribute("cmx")]
    [DescriptionAttribute("CorelDRAW vector image file format")]
    Cmx,

    /// <summary>
    /// Adobe Photoshop shapes file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Csh")]
    [XmlEnumAttribute("csh")]
    [DescriptionAttribute("Adobe Photoshop shapes file format")]
    Csh,

    /// <summary>
    /// Corel symbol library file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Csl")]
    [XmlEnumAttribute("csl")]
    [DescriptionAttribute("Corel symbol library file format")]
    Csl,

    /// <summary>
    /// Cadterns Sloper File file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ctn")]
    [XmlEnumAttribute("ctn")]
    [DescriptionAttribute("Cadterns Sloper File file format")]
    Ctn,

    /// <summary>
    /// Intergraph design file file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dgn")]
    [XmlEnumAttribute("dgn")]
    [DescriptionAttribute("Intergraph design file file format")]
    Dgn,

    /// <summary>
    /// Digital Line Graph vector image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dlg")]
    [XmlEnumAttribute("dlg")]
    [DescriptionAttribute("Digital Line Graph vector image file format")]
    Dlg,
    
    /// <summary>
    /// Digital Line Graph optional vector data file format.
    /// </summary>
    [XmlEnumAttribute("do")]
    [DescriptionAttribute("Digital Line Graph optional vector data file format")]
    DO,

    /// <summary>
    /// Vector file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Drw")]
    [XmlEnumAttribute("drw")]
    [DescriptionAttribute("Vector file format")]
    Drw,

    /// <summary>
    /// Autocad drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dwg")]
    [XmlEnumAttribute("dwg")]
    [DescriptionAttribute("Autocad drawing file format")]
    Dwg,
    
    /// <summary>
    /// AutoCAD drawing exchange file format (Binary).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dxb")]
    [XmlEnumAttribute("dxb")]
    [DescriptionAttribute("AutoCAD drawing exchange file format (Binary)")]
    Dxb,
    
    /// <summary>
    /// AutoCAD drawing exchange file format (AScII).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Dxf")]
    [XmlEnumAttribute("dxf")]
    [DescriptionAttribute("AutoCAD drawing exchange file format (AScII)")]
    Dxf,

    /// <summary>
    /// 2-dimensional vector graphics file format (Used by the editor which is included in JFire).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "d")]
    [XmlEnumAttribute("e2d")]
    [DescriptionAttribute("2-dimensional vector graphics file format (Used by the editor which is included in JFire)")]
    E2d,
    
    /// <summary>
    /// EGT Universal Document file format, (EGT Vector Draw images are used to draw vector to a website).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Egt")]
    [XmlEnumAttribute("egt")]
    [DescriptionAttribute("EGT Universal Document file format, (EGT Vector Draw images are used to draw vector to a website)")]
    Egt,
    
    /// <summary>
    /// Orchida Embroidery System embroidery pattern file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Emb")]
    [XmlEnumAttribute("emb")]
    [DescriptionAttribute("Orchida Embroidery System embroidery pattern file format")]
    Emb,
    
    /// <summary>
    /// Enhanced Windows MetaFile format.
    /// </summary>
    [XmlEnumAttribute("emf")]
    [DescriptionAttribute("Enhanced Windows MetaFile format")]
    Emf,
    
    /// <summary>
    /// Encapsulated Postscript file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Eps")]
    [XmlEnumAttribute("eps")]
    [DescriptionAttribute("Encapsulated Postscript file format")]
    Eps,
    
    /// <summary>
    /// Image file format.
    /// </summary>
    [XmlEnumAttribute("fh")]
    [DescriptionAttribute("Image file format")]
    FH,

    /// <summary>
    /// Adobe FreeHand 10 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Fh")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Fh")]
    [XmlEnumAttribute("fh10")]
    [DescriptionAttribute("Adobe FreeHand 10 drawing file format")]
    Fh10,

    /// <summary>
    /// Adobe FreeHand 11 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Fh")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Fh")]
    [XmlEnumAttribute("fh11")]
    [DescriptionAttribute("Adobe FreeHand 11 drawing file format")]
    Fh11,

    /// <summary>
    /// Adobe FreeHand 8 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Fh")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Fh")]
    [XmlEnumAttribute("fh8")]
    [DescriptionAttribute("Adobe FreeHand 8 drawing file format")]
    Fh8,

    /// <summary>
    /// Adobe FreeHand 9 drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Fh")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Fh")]
    [XmlEnumAttribute("fh9")]
    [DescriptionAttribute("Adobe FreeHand 9 drawing file format")]
    Fh9,
    
    /// <summary>
    /// Adobe FreeHand 10 template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ft")]
    [XmlEnumAttribute("ft10")]
    [DescriptionAttribute("Adobe FreeHand 10 template file format")]
    Ft10,
    
    /// <summary>
    /// Adobe FreeHand 11 template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ft")]
    [XmlEnumAttribute("ft11")]
    [DescriptionAttribute("Adobe FreeHand 11 template file format")]
    Ft11,

    /// <summary>
    /// Adobe FreeHand 8 template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ft")]
    [XmlEnumAttribute("ft8")]
    [DescriptionAttribute("Adobe FreeHand 8 template file format")]
    Ft8,
    
    /// <summary>
    /// Adobe FreeHand 9 template file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Ft")]
    [XmlEnumAttribute("ft9")]
    [DescriptionAttribute("Adobe FreeHand 9 template file format")]
    Ft9,

    /// <summary>
    /// Generic CADD Drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gcd")]
    [XmlEnumAttribute("gcd")]
    [DescriptionAttribute("Generic CADD Drawing file format")]
    Gcd,
    
    /// <summary>
    /// Ventura Publisher GEM vector picture file format.
    /// </summary>
    [XmlEnumAttribute("gem")]
    [DescriptionAttribute("Ventura Publisher GEM vector picture file format")]
    Gem,
    
    /// <summary>
    /// Hewlett Packard Graphics Language plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Gl")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Gl")]
    [XmlEnumAttribute("gl2")]
    [DescriptionAttribute("Hewlett Packard Graphics Language plotter file format")]
    Gl2,
    
    /// <summary>
    /// Hewlett Packard Graphics Language plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hpg")]
    [XmlEnumAttribute("hpg")]
    [DescriptionAttribute("Hewlett Packard Graphics Language plotter file format")]
    Hpg,
    
    /// <summary>
    /// Hewlett Packard Graphics Language plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hpgl")]
    [XmlEnumAttribute("hpgl")]
    [DescriptionAttribute("Hewlett Packard Graphics Language plotter file format")]
    Hpgl,
    
    /// <summary>
    /// Hewlett Packard Graphics Language 2 plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hpgl")]
    [XmlEnumAttribute("hpgl2")]
    [DescriptionAttribute("Hewlett Packard Graphics Language 2 plotter file format")]
    Hpgl2,
    
    /// <summary>
    /// EGO - Chart - Autumn Mirage vector graphics file fomrat.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ima")]
    [XmlEnumAttribute("ima")]
    [DescriptionAttribute("Mapinfo graphics file format")]
    Ima,

    /// <summary>
    /// Mapinfo graphics file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mif")]
    [XmlEnumAttribute("mif")]
    [DescriptionAttribute("EGO - Chart - Autumn Mirage vector graphics file fomrat")]
    Mif,

    /// <summary>
    /// OpenOffice Draw graphic file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Odg")]
    [XmlEnumAttribute("odg")]
    [DescriptionAttribute("OpenOffice Draw graphic file format")]
    Odg,
    
    /// <summary>
    /// Corel vector pattern file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
    [XmlEnumAttribute("patCorel")]
    [DescriptionAttribute("Corel vector pattern file format")]
    PatCorel,
    
    /// <summary>
    /// Pattern Maker Cross-Stitch Pattern file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PatternMaker")]
    [XmlEnumAttribute("patPatternMaker")]
    [DescriptionAttribute("Pattern Maker Cross-Stitch Pattern file format")]
    PatPatternMaker,
    
    /// <summary>
    /// PatternSmith Cutting Pattern file format.
    /// </summary>
    [XmlEnumAttribute("patPatternSmith")]
    [DescriptionAttribute("PatternSmith Cutting Pattern file format")]
    PatPatternSmith,
    
    /// <summary>
    /// Polygon Attribute Table file format.
    /// </summary>
    [XmlEnumAttribute("patArcInfo")]
    [DescriptionAttribute("Polygon Attribute Table file format")]
    PatArcInfo,
    
    /// <summary>
    /// Vector Pattern file format.
    /// </summary>
    [XmlEnumAttribute("patVectorPattern")]
    [DescriptionAttribute("Vector Pattern file format")]
    PatVectorPattern,
    
    /// <summary>
    /// Corel Paint Shop Pro Pattern Image File.
    /// </summary>
    [XmlEnumAttribute("patPaintShop")]
    [DescriptionAttribute("Corel Paint Shop Pro Pattern Image File")]
    PatPaintShop,
    
    /// <summary>
    /// PCStitch Pattern file format.
    /// </summary>
    [XmlEnumAttribute("patPCStitch")]
    [DescriptionAttribute("PCStitch Pattern file format")]
    PatPCStitch,
    
    /// <summary>
    /// Smash Simulator Test Pattern file format.
    /// </summary>
    [XmlEnumAttribute("patSmashSimulator")]
    [DescriptionAttribute("Smash Simulator Test Pattern file format")]
    PatSmashSimulator,
    
    /// <summary>
    /// Cadterns Sloper file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Cadterns")]
    [XmlEnumAttribute("patCadterns")]
    [DescriptionAttribute("Cadterns Sloper file format")]
    PatCadterns,
    
    /// <summary>
    /// Orchida Embroidery System file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Orchida")]
    [XmlEnumAttribute("patOrchida")]
    [DescriptionAttribute("Orchida Embroidery System file format")]
    PatOrchida,
    
    /// <summary>
    /// Apple Macintosh QuickDraw/PICT bitmap graphics file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pct")]
    [XmlEnumAttribute("pct")]
    [DescriptionAttribute("Apple Macintosh QuickDraw/PICT bitmap graphics file format")]
    Pct,
    
    /// <summary>
    /// Vector image GDF file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pif")]
    [XmlEnumAttribute("pif")]
    [DescriptionAttribute("Vector image GDF file format")]
    Pif,
    
    /// <summary>
    /// Image Systems vector file format.
    /// </summary>
    [XmlEnumAttribute("pixImageSystems")]
    [DescriptionAttribute("Image Systems vector file format")]
    PixImageSystems,
    
    /// <summary>
    /// Inset Systems raster and vector file format.
    /// </summary>
    [XmlEnumAttribute("pixInsetSystems")]
    [DescriptionAttribute("Inset Systems raster & vector file format")]
    PixInsetSystems,
    
    /// <summary>
    /// Hewlett Packard Graphics Language plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plo")]
    [XmlEnumAttribute("plo")]
    [DescriptionAttribute("Hewlett Packard Graphics Language plotter file format")]
    Plo,

    /// <summary>
    /// Vector graphics file format.
    /// </summary>
    [XmlEnumAttribute("plot")]
    [DescriptionAttribute("Vector graphics file format")]
    Plot,
    
    /// <summary>
    /// Autodesk AutoCAD HPGL vector graphic plotter file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plt")]
    [XmlEnumAttribute("plt")]
    [DescriptionAttribute("Autodesk AutoCAD HPGL vector graphic plotter file format")]
    Plt,
    
    /// <summary>
    /// PostScript file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ps")]
    [XmlEnumAttribute("ps")]
    [DescriptionAttribute("PostScript file format")]
    PS,

    /// <summary>
    /// Amidraw vector image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sdw")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Amidraw")]
    [XmlEnumAttribute("sdwAmidraw")]
    [DescriptionAttribute("Amidraw vector image file format")]
    SdwAmidraw,
    
    /// <summary>
    /// WordPro drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sdw")]
    [XmlEnumAttribute("sdwWordPro")]
    [DescriptionAttribute("WordPro drawing file format")]
    SdwWordPro,
    
    /// <summary>
    /// ESRI Shapefile format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Shp")]
    [XmlEnumAttribute("shp")]
    [DescriptionAttribute("ESRI Shapefile format")]
    Shp,
    
    /// <summary>
    /// SolidWorks drawing 2D file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Slddwg")]
    [XmlEnumAttribute("slddwg")]
    [DescriptionAttribute("SolidWorks drawing 2D file format")]
    Slddwg,
    
    /// <summary>
    /// SignPlot output file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sp")]
    [XmlEnumAttribute("sp")]
    [DescriptionAttribute("SignPlot output file format")]
    SP,
    
    /// <summary>
    /// FutureSplash Movie file format.
    /// </summary>
    [XmlEnumAttribute("spa")]
    [DescriptionAttribute("FutureSplash Movie file format")]
    Spa,
    
    /// <summary>
    /// Stereo Lithographic data file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Stl")]
    [XmlEnumAttribute("stl")]
    [DescriptionAttribute("Stereo Lithographic data file format")]
    Stl,
    
    /// <summary>
    /// Simple Vector file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Svf")]
    [XmlEnumAttribute("svf")]
    [DescriptionAttribute("Simple Vector file format")]
    Svf,
    
    /// <summary>
    /// Scalable Vector Graphics file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Svg")]
    [XmlEnumAttribute("svg")]
    [DescriptionAttribute("Scalable Vector Graphics file format")]
    Svg,

    /// <summary>
    /// Vector file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sxd")]
    [XmlEnumAttribute("sxd")]
    [DescriptionAttribute("Vector file format")]
    Sxd,
    
    /// <summary>
    /// Top Draw vector graphic file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Tdr")]
    [XmlEnumAttribute("tdr")]
    [DescriptionAttribute("Top Draw vector graphic file format")]
    Tdr,
    
    /// <summary>
    /// Voucher design file format (Used by the voucher management included in JFire).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "d")]
    [XmlEnumAttribute("v2d")]
    [DescriptionAttribute("Voucher design file format (Used by the voucher management included in JFire)")]
    V2d,
    
    /// <summary>
    /// Virtual Reality Modeling Language file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vrml")]
    [XmlEnumAttribute("vrml")]
    [DescriptionAttribute("Virtual Reality Modeling Language file format")]
    Vrml,

    /// <summary>
    /// Windows metafile format.
    /// </summary>
    [XmlEnumAttribute("wmf")]
    [DescriptionAttribute("Windows metafile format")]
    Wmf,

    /// <summary>
    /// Virtual Reality Modeling Language file format (vrml).
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Wrl")]
    [XmlEnumAttribute("wrl")]
    [DescriptionAttribute("Virtual Reality Modeling Language file format (vrml)")]
    Wrl,

    /// <summary>
    /// Corel Xara drawing file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Xar")]
    [XmlEnumAttribute("xar")]
    [DescriptionAttribute("Corel Xara drawing file format")]
    Xar,

  }

}
