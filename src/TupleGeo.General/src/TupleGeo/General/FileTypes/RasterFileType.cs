
#region Header
// Title Name       : RasterFileTypes
// Member of        : TupleGeo.General.dll
// Description      : Raster file types enumeration.
// Created by       : 10/02/2009, 15:22, Vasilis Vlastaras.
// Updated by       : 19/02/2009, 00:49, Vasilis Vlastaras.
//                    1.0.1 - Moved class from another assembly.
//                  : 26/03/2009, 19:32, Vasilis Vlastaras.
//                    1.0.2 - Added System.Xml.Serialization namespace / Cleaned up file.
//                  : 22/02/2011, 22:13, Vasilis Vlastaras.
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
  /// Types of raster files.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  public enum RasterFileType  {

    /// <summary>
    /// Bitmap image file format.
    /// </summary>
    [XmlEnumAttribute("bmp")]
    [DescriptionAttribute("Bitmap image file format")]
    [DescriptionAttribute("Μορφότυπος αρχείου bitmap.", "el-GR")]
    Bmp,

    


 //file extension .bmp	Windows BitMap image or Mac File Type
 //file extension 001	Hayes JT FAX fax
 //file extension 24b	Bitmap graphics (24-bit data)
 //file extension 73i	TI bitmap file
 //file extension 82i	TI bitmap file
 //file extension 83i	TI bitmap file
 //file extension 85i	TI bitmap file
 //file extension 86i	TI bitmap file
 //file extension 89i	TI bitmap file
 //file extension 92i	TI bitmap file
 //file extension acr	Bitmap graphics
 //file extension acr	Dicom medicine image file format
 //file extension adc	Bitmap graphics (16 colors)
 //file extension alias	Alias image file
 //file extension als	Alias fmage file
 //file extension apng	Animated portable network graphics
 //file extension apt	APT encoded bitmap file
 //file extension arf	Flexible image transport system bitmap
 //file extension arw	Sony Digital Camera Raw Image File
 //file extension atk	Andrew Toolkit raster object file
 //file extension att	AT&T Group 4 bitmap graphics
 //file extension avs	Bitmap image format
 //file extension avs	Stardent AVS X image file
 //file extension b&w	Bitmap image (atari - mac)
 //file extension bfl	BFLI image format
 //file extension bfli	BFLI image format
 //file extension bga	OS/2 graphic array
 //file extension bif	byLight image format
 //file extension bif	Image Capture board bitmap image
 //file extension bip	ArcView image file (band interleaved by pixel)
 //file extension bmf	Corel Flow image format
 //file extension bmp	Standard Windows Bitmap image (also OS/2)
 //file extension bob	BOB Raytracer bitmap image
 //file extension btn	JustButtons animated bitmap image format
 //file extension bw	Silicon Graphics image file
 //file extension c4	JEDMICS bitmap image
 //file extension cal	CALS Raster Goup 1 image format
 //file extension cal	CALS Raster Group 4 fax compressed bitmap
 //file extension cam	Casio QV digital CAMera image
 //file extension cbm	XLib compiled bitmap picture
 //file extension cbm	Fuzzy bitmap image format
 //file extension cdr	Corel Draw bitmap (preview) image format
 //file extension ce	Digital Vision IFF bitmap file
 //file extension ce1	Computer Eyes Raw image format
 //file extension ce2	Computer Eyes Raw image format
 //file extension cel	Autodesk Animator, 3D Studio cel bitmap animation
 //file extension cel	Lumena CEL bitmap image
 //file extension cfp	bitmap native format for CoverFactory
 //file extension cg4	CALS Group IV bitmap graphics file
 //file extension cin	Kodak Cineon image format
 //file extension cin	Digital Moving Picture Exchange Bitmap
 //file extension clp	Bitmap image file
 //file extension cmp	Leadview bitmap file
 //file extension cmu	CMU Window Manager bitmap image
 //file extension cpi	Bitmap image (Colorlab processed image)
 //file extension cr2	Canon digital camera RAW image format version 2.0
 //file extension crf	Bitmap image
 //file extension crw	Canon digital camera RAW image format
 //file extension ct	IRIS CT image format
 //file extension ct	SciTex continuous Tone bitmap image (32bit CMYK)
 //file extension cut	Dr Halo bitmap picture
 //file extension dat	Mitsubishi DJ-1000 and Photorun native format
 //file extension dc3	Medicine image file format
 //file extension dcm	Dicom medicine image file format
 //file extension dcr	RIF picture
 //file extension dcr	Kodak Digital Camera Raw Image Format
 //file extension dcx	Zsoft PC Publisher's Paintbrush image (multi-pcx file)
 //file extension ddb	Device dependent bitmap graphics file
 //file extension dds	Direct Draw surface
 //file extension dib	Device-Independent Bitmap graphic
 //file extension dic	Medicine image file format
 //file extension dicm	Medicine image file format
 //file extension dicom	Medicine image file format
 //file extension dip	Windows bitmap format
 //file extension djvu	DjVu file bitmap image AT&T
 //file extension dng	Digital Negative
 //file extension dpx	Kodak Cineon image format
 //file extension dpx	Digital Moving Picture Exchange bitmap file
 //file extension drs	BMP bitmap file
 //file extension dsf	DriveSurf picture
 //file extension ecw	Enhanced Compressed Wavelet image format
 //file extension eidi	Bitmap image (Electric Image EIDI file)
 //file extension emf	Enhanced Windows Metafile picture
 //file extension emz	Microsoft Windows enhanced compressed metafile
 //file extension eps	EPS Tiff preview
 //file extension exf	Exchangeable Image File Format
 //file extension exr	OpenEXR Image Format
 //file extension fac	UNIX FaceSaver bitmap image
 //file extension fbm	Fuzzy bitmap image
 //file extension fff	Maggi Hairstyles & Cosmetics image format
 //file extension fido	Kodak Cineon image format
 //file extension fif	Fractal Image Format file
 //file extension fits	Flexible Image Transport System
 //file extension fpx	Kodak FlashPiX bitmap image
 //file extension gg	Koala Paint compressed image format

    /// <summary>
    /// Graphics interchange file format.
    /// </summary>
    [XmlEnumAttribute("gif")]
    [DescriptionAttribute("Graphics interchange file format")]
    Gif,

 
 //file extension gif87	Gif(87) file
 //file extension gif89a	Gif 89a image file
 //file extension giff	CompuServe bitmap image (Graphics Interchange Format)
 //file extension gif_	Graphics Interchange Format - Mac File Type
 //file extension gm	Autologic bitmap image
 //file extension gm2	Autologic bitmap image
 //file extension gm4	Autologic bitmap image
 //file extension grb	HP-48sx GROB bitmap image
 //file extension gro	HP-48/49 grob graphic image format
 //file extension hdp	HD Photo
 //file extension hpi	Hemera Photo Image image format
 //file extension hta	Hemera thumbs
 //file extension ica	Citrix image object content architecture file
 //file extension icb	Truevision Targa format
 //file extension ico	Icon file
 //file extension idc	Core Software tech IDC file
 //file extension idx	Header information file
 //file extension iff	Amiga bitmap image file
 //file extension iff	Bitmap image
 //file extension iff	Electronic Arts bitmap image
 //file extension iff	DESR VFF greyscale bitmap image
 //file extension iff	Autodesk Maya image format
 //file extension ilbm	Amiga Interleaved bitmap format
 //file extension ilbm	Deluxe Paint graphic file
 //file extension im	Sun raster grey bitmap graphics file
 //file extension img	Bitmap Graphic (several programs)
 //file extension img	ADEX Corporation bitmap graphics
 //file extension img	ERDAS Imagine image file
 //file extension img	Img software set bitmap
 //file extension img	Planetary Data System image format
 //file extension img	Radiance picture format
 //file extension img	Bitmap graphics VDI image format
 //file extension img	Whatnot image file
 //file extension img	Microtek Eyestar image
 //file extension img	Vicar file
 //file extension int	Silicon Graphics Image File Format
 //file extension inta	Silicon Graphics Image File Format
 //file extension ioca	IBM Image Object Content Architecture (IOCA) bitmap graphics
 //file extension ipg	Mindjongg Format image format
 //file extension ism	Image System (Multicolor) image format
 //file extension iso	CALS ISO 8613 bitmap graphics file
 //file extension itg	Intergraph format bitmap graphics
 //file extension iw4	DjVu image format
 //file extension iw44	DjVu Format
 //file extension j	JPEG/JFIF image
 //file extension j2c	JPEG2000 image format
 //file extension j2k	JPEG2000 code stream image
 //file extension j6i	Ricoh Digital Camera image format
 //file extension jas	Bitmap graphics
 //file extension jfif	JPEG bitmap image file format
 //file extension jif	Jeff's Image Format image format
 //file extension jif	JPEG/JIFF image
 //file extension jls	JPEG-LS image format
 //file extension jng	JPEG Network Graphic file
 //file extension jp2	JPEG2000 image format
 //file extension jpc	Japan Picture bitmap graphic format
 //file extension jpc	JPEG2000 code stream image format
 //file extension jpe	JPEG Image
 //file extension jpeg	JPEG image, picture file format (Mac file type)
 //file extension jpeg	Joint Photographic Experts Group
 //file extension jpf	JPEG2000 image format

    /// <summary>
    /// JPEG image file format.
    /// </summary>
    [XmlEnumAttribute("jpg")]
    [DescriptionAttribute("JPEG image file format")]
    Jpg,

    /// <summary>
    /// JPEG image file format.
    /// </summary>
    [XmlEnumAttribute("jpeg")]
    [DescriptionAttribute("JPEG image file format")]
    Jpeg,
    

 //file extension jpg	CompactDRAW e-JPG graphic file
 //file extension jpg_t	Jpg images file
 //file extension jpm	JPEG 2000 jpm file format (common name)
 //file extension jpx	JPEG-2000 JP2 file format
 //file extension jtf	JPEG Tagged Interchange Format image
 //file extension jtf	TIFF 6.0 bitmap image JPEG compression
 //file extension k25	Kodak DC25 digital camera file
 //file extension kfx	Kofax Group 4 bitmap graphics
 //file extension koa	Koala paint C64 format
 //file extension kps	IBM KIPS bitmap image graphics
 //file extension kqp	Konica camera file
 //file extension lbm	Amiga Deluxe Paint bitmap
 //file extension lbm	Bitmap image file
 //file extension lbm	XLib linear bitmap graphic
 //file extension ldf	LuraDocument Format image format
 //file extension ljp	Lossless JPEG bitmap image
 //file extension mac	MacPaint bitmap image
 //file extension mac	MacPaint
 //file extension macp	Apple Macintosh MacPaint bitmap image
 //file extension map	Fenix map
 //file extension mbfavs	Stardent AVS X bitmap image file
 //file extension mbfs	Stardent AVS X bitmap image file
 //file extension mbm	EPOC multi-bitmap file
 //file extension mf	Metafont text file
 //file extension mgr	MGR bitmap image
 //file extension miff	Magick image file format
 //file extension mng	Multiple Network Graphics animation
 //file extension mng	Multiple Network Graphics bitmap image
 //file extension mos	Mamiya Digital Camera Raw Image File
 //file extension mpnt	MacPaint image format
 //file extension mrw	Minolta Dimage Raw Image File
 //file extension msp	Microsoft Paint bitmap picture
 //file extension nef	Nikon Digital SLR camera RAW image file
 //file extension ngg	Nokia Group Graphics image format
 //file extension nif	NIFF Navy Image File Format (bitmap) graphics interchange format
 //file extension niff	Bitmap image (Navy Interchange File Format)
 //file extension nlm	Nokia Logo file image format
 //file extension nol	Nokia Operator Logo image format
 //file extension otb	Nokia OTA bitmap file
 //file extension pac	Photo-CD multi-resolution image file
 //file extension paint	Apple Macintosh MacPaint bitmap file
 //file extension pam	Portable arbitrary map
 //file extension pattern	PhotoLine 5 Default File
 //file extension pbf	Portable bitmap format file
 //file extension pbm	Portable Bitmap file
 //file extension pbm	UNIX Portable bitmap graphic
 //file extension pbm	Xlib bitmap graphics
 //file extension pc1	Atari Degas image
 //file extension pc2	Atari Degas image
 //file extension pc3	Atari Degas bitmap image
 //file extension pcc	ZSoft PC Paintbrush format
 //file extension pcd	Kodak Picture CD multiresolution image
 //file extension pcd	Photo CD format
 //file extension pct	NIST ihdr image
 //file extension pct	Apple Macintosh QuickDraw/PICT bitmap graphics format
 //file extension pct	PC Paint bitmap file
 //file extension pcx	PC Paintbrush bitmap graphics
 //file extension pdb	MonkeyCard image format
 //file extension pdd	Corel Paint Shop Pro bitmap graphics
 //file extension pdf	ED-Scan graphics file
 //file extension pef	Pentax Digital Camera Raw Image Format
 //file extension pfm	Portable bitmap file
 //file extension pfn	Portable Bitmap File
 //file extension pgm	Portable graymap file format
 //file extension pgx	Portable graphics format
 //file extension pi1	Atari Degas bitmap image
 //file extension pi2	Atari Degas image
 //file extension pi3	Atari Degas image
 //file extension pi4	Atari Degas image file
 //file extension pi5	Atari Degas image file
 //file extension pi6	Atari Degas image file
 //file extension pic	Autodesk Animator PIC/CEL file
 //file extension pic	General picture extension
 //file extension pic	IBM Storyboard bitmap file
 //file extension pic	Pixar PIC file
 //file extension pic	Psion Series 3 image format
 //file extension pic	Radiance image file
 //file extension picio	PIXAR picture file
 //file extension pict	Macintosh PICT image
 //file extension pict	Bitmap graphics file format
 //file extension pict2	Apple Macintosh QuickDraw/PICT bitmap graphics format
 //file extension pix	Inset Systems raster & vector format
 //file extension pix	Truevision Targa bitmap image
 //file extension pix	PABX background bitmap
 //file extension pixar	PIXAR picture file
 //file extension plt	BioWare Infinity game engine bitmap graphic
 //file extension pm	Presentation Manager bitmap graphics file
 //file extension pm	X Window PixelMap bitmap graphics

    /// <summary>
    /// Portable network graphic file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Png")]
    [XmlEnumAttribute("png")]
    [DescriptionAttribute("Portable network graphic file format")]
    Png,

 
 //file extension pnm	Portable anymap bitmap graphic file
 //file extension pnt	Apple MacPaint format graphic file
 //file extension pntg	Apple Macintosh MacPaint bitmap graphics
 //file extension pp4	Micrografix Picture Publisher bitmap graphics
 //file extension pp5	Micrografix Picture Publisher bitmap file
 //file extension ppm	Portable pixelmap graphic
 //file extension pps	Paint Shop Pro image
 //file extension pr	Sun icon file
 //file extension prf	Fastgraph bitmap graphics
 //file extension prn	Calcomp Raster bitmap graphics

    /// <summary>
    /// Photoshop Document.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Psd")]
    [XmlEnumAttribute("psd")]
    [DescriptionAttribute("Photoshop Document file format.")]
    Psd,
    
 //file extension pse	IBM Printer Page Segment bitmap graphics

    /// <summary>
    /// Paintshop Pro image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Psp")]
    [XmlEnumAttribute("psp")]
    [DescriptionAttribute("Paintshop Pro image file format.")]
    Psp,

 //file extension pzl	Unix Puzzle bitmap graphics
 //file extension q0	Japanese Q0 bitmap image
 //file extension qdv	Random Dot QDV bitmap image
 //file extension qrt	Qrt Ray-Tracer ray-traced bitmap image
 //file extension raf	Fuji CCD-RAW graphic file
 //file extension ras	Sun raster bitmap image
 //file extension rast	Sun Raster bitmap image
 //file extension raw	Digital Camera Image Format (Panasonic)
 //file extension raw	HSI temporary raw bitmap image format
 //file extension raw	Generally a digital camera's image raw file format
 //file extension rdi	Device independent bitmap file
 //file extension rf	Sun bitmap image (raster file)
 //file extension rgb	SGI RGB bitmap file
 //file extension rgb	Japanese Q0 bitmap image
 //file extension rgba	Silicon Graphics Image File Format
 //file extension rif	Resource Interchange File Format bitmap image
 //file extension rif	Fractal Painter bitmap file
 //file extension riff	Resource Interchange File Format bitmap image
 //file extension rix	ColoRIX bitmap image
 //file extension rle	Bitmap graphics - 4bit or 8bit ADEX file
 //file extension rle	Run Length Encoded bitmap image
 //file extension rle	Raster bitmap image
 //file extension rpbm	Portable Bitmap image format
 //file extension rpgm	Portable greyscale image
 //file extension rpnm	Portable Image image format
 //file extension rppm	Portable Image image format
 //file extension rs	Sun Raster bitmap image format
 //file extension rsb	Red Storm bitmap file
 //file extension sc2	Msx 2 screen image format
 //file extension sc?	ColoRix bitmap image
 //file extension scc	Microsoft eXtended home computer bitmap image (MSX)
 //file extension scd	Matrix/Imapro/Agfa SCODL film recorder bitmap image
 //file extension sci	ColoRIX bitmap image
 //file extension scr	Sun Raster bitmap image format
 //file extension scr	bitmap file
 //file extension sct	Scitex CT bitmap image file
 //file extension scx	ColoRIX bitmap image
 //file extension sd2	Dali Raw image
 //file extension sdpx	Kodak Cineon image format
 //file extension sdw	MrSID header file (ESRI picture file)
 //file extension seq	ATARI STAD image format
 //file extension sfw	Seattle Film Works graphics   

    /// <summary>
    /// LizardTech MrSID image file format.
    /// </summary>
    [XmlEnumAttribute("sid")]
    [DescriptionAttribute("LizardTech MrSID image file format")]
    Sid,
    
// file extension sim	Aurora image format
// file extension sir	Bitmap image (Solitaire file)
// file extension snx	Second Nature screensaver image
// file extension spc	Atari compressed Spectrum bitmap file
// file extension sprite	Acorn - Bitmap file
// file extension sps	Atari Spectrum 512 smooshed bitmap image
// file extension spu	Atari Spectrum bitmap image
// file extension sr	Sun raster bitmap graphics
// file extension sr2	Sony Digital Camera Raw Image File
// file extension srf	Sony Digital Camera Raw Image File
// file extension ss	Splash bitmap graphics
// file extension sun	Sun raster bitmap image
// file extension suniff	Bitmap image (Sun TAAC Image File Format)
// file extension syn	Bitmap image (Synthetic Universe image file)
// file extension syn	SDSC image tool file
// file extension synu	Bitmap image (SDSC Synu image file)
// file extension synu	Synthetic Universe image format
// file extension taac	Sun TAAC bitmap image
// file extension tdi	Alias Wavefront image
// file extension tex	Corel Paint Shop Pro texture image format
// file extension tga	Truevision TarGA bitmap image
// file extension thm	Tmumbnail bitmap image
// file extension thm	Olympus digital image thumbnail
// file extension thm	Canon G3 digital camera thumbnail

    /// <summary>
    /// Tagged image file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Tif")]
    [XmlEnumAttribute("tif")]
    [DescriptionAttribute("Tagged image file format")]
    Tif,

// file extension tif	BigTIFF image file
// file extension tiff	Aldus Tagged Image File Format (TIFF) bitmap image
// file extension tiff	Tagged Image File Format
// file extension tim	Sony PlayStation bitmap image
// file extension tim	Tagged Image file format
// file extension tn1	Tiny image format
// file extension tn2	Tiny image format
// file extension tn3	Tiny image format
// file extension tny	TiNY bitmap image
// file extension tpic	TrueVision TARGA
// file extension u	Subsampled raw YUV bitmap image
// file extension ufo	Ulead object file
// file extension ufp	Ulead photo project file
// file extension v	Subsampled raw YUV bitmap image
// file extension vda	Truevision Targa bitmap image
// file extension vff	DESR VFF greyscale bitmap image
// file extension vff	Sun TAAC bitmap image file
// file extension vi	Jovian Logic VI bitmap image
// file extension vic	Graphics
// file extension vif	Verity 1bit CCITT Group 4 bitmap image
// file extension vif	Khoros Visualization bitmap image
// file extension viff	Khoros Visualization bitmap image
// file extension vst	Vista Truevision Targa bitmap image
// file extension wbm	Wireless Bitmap image format
// file extension wbmp	Wireless Bitmap image format
// file extension wdp	HD Photo
// file extension wic	J Wavelet Image Codec image format
// file extension win	Truevision Targa bitmap image
// file extension wlm	CompW image format
// file extension x	Stardent AVS X bitmap image
// file extension x3f	Sigma Camera RAW Picture File
// file extension xbm	X Windows system bitmap image
// file extension xcf	Gimp bitmap image format
// file extension xpm	Image file
// file extension xv	Khoros Visualization bitmap image
// file extension xwd	X Windows window screen dump or bitmap
// file extension y	Subsampled raw YUV bitmap image
// file extension zgm	Zenographics bitmap image file
// file extension zif	Zooming Interface Format

  }

}
