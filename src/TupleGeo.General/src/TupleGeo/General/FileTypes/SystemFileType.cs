
#region Header
// Title Name       : SystemFileTypes
// Member of        : TupleGeo.General.dll
// Description      : System file types enumeration.
// Created by       : 10/02/2009, 15:09, Vasilis Vlastaras.
// Updated by       : 19/02/2009, 00:48, Vasilis Vlastaras.
//                    1.0.1 - Moved class from another assembly.
//                  : 26/03/2009, 19:33, Vasilis Vlastaras.
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
  /// Types of system files.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  public enum SystemFileType {
    

//.adm	Administrative Template File	 	No

    /// <summary>
    /// Windows Animated Cursor file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ani")]
    [XmlEnumAttribute("ani")]
    [DescriptionAttribute("Windows Animated Cursor file format")]
    Ani,
    
//.ann	Help Annotations	 	No
//.bmk	Help Bookmarks	 	No

    /// <summary>
    /// Windows Cabinet file format.
    /// </summary>
    [XmlEnumAttribute("cab")]
    [DescriptionAttribute("Windows Cabinet file format")]
    Cab,
    
//.cnt	Help Contents File	 	No
//.cpl	Windows Control Panel	 	Yes
    	
    /// <summary>
    /// Windows Cursor file format.
    /// </summary>
    [XmlEnumAttribute("cur")]
    [DescriptionAttribute("Windows Cursor file format")]
    Cur,

//.desklink	Desktop Shortcut	 	No
//.dev	Windows Device Driver File	 	No
//.dmp	Windows Memory Dump	 	Yes
//.drv	Device Driver	 	Yes
//.dss	DCC Active Designer File	 	No
//.dvd	DOS Device Driver	 	No
//.ffa	Find Fast Status File	 	No
//.ffl	Find Fast Document List	 	No
//.ffo	Find Fast Document Properties Cache	 	No
//.ffx	Microsoft Find Fast Index	 	No
//.fpbf	Mac OS X Burn Folder	 	No
//.ftg	Full Text Group	 	No
//.fts	Full Text Search	 	No
//.grp	Windows Program Manager Group	 	No
//.hdmp	Windows Heap Dump	 	No
//.hhc	HTML Help Table of Contents	 	No
//.hhk	HTML Help Index	 	No
//.hlp	Windows Help File	 	No
//.hpj	Help Project File	 	No
//.htt	Hypertext Template File	 	No
//.icl	Windows Icon Library File	 	No
//.icns	Mac OS X Icon Resource File	 	No

    /// <summary>
    /// Icon file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ico")]
    [XmlEnumAttribute("ico")]
    [DescriptionAttribute("Icon file format")]
    Ico,
    
//.idx	Index File	 	No
//.ins	Internet Naming Service File	 	No
//.ion	4DOS File Description	 	No
//.its	Internet Document Set	 	No
//.kbd	Keyboard Layout Script	 	No
//.kext	Mac OS X Kernel Extension	 	No
//.key	Security Key	 	Yes
//.lnk	File Shortcut	 	Yes
//.manifest	Windows Visual Styles File	 	No
//.mapimail	Send To Mail Recipient	 	No
//.mdmp	Windows Minidump	 	No
//.msc	Microsoft Management Console Snap-in Control File	 	No
//.msp	Windows Installer Patch	 	No
//.msstyles	Windows XP Style	 	No
//.mui	MultiLanguage Resource File	 	No
//.mum	Windows Vista Update Package	 	No
//.mydocs	Send To My Documents	 	No
//.nfo	System Information File	 	No
//.nt	Windows NT Startup File	 	No
//.p7b	PKCS #7 Certificate File	 	No
//.pdr	Windows Port Driver	 	No
//.pfx	PKCS #12 Certificate File	 	No
//.pid	Creative Driver File	 	No
//.pk2	Silkroad Online Game Data File	 	No
//.pol	Windows Policy File	 	No
//.ppd	PostScript Printer Description File	 	No
//.prefpane	Mac OS X System Preference Pane	 	No
//.prf	Windows System File	 	No
//.prt	Printer Driver File	 	No
//.pwl	Windows Password List	 	No
//.reg	Registry File	 	No
//.savedsearch	Spotlight Saved Search	 	No
//.saver	Mac OS X Screen Saver	 	No
//.scf	Windows Explorer Command	 	No
//.scr	Windows Screensaver	 	No
//.sdb	Custom Application Compatibility Database	 	No
//.str	Windows Screensaver File	 	No
//.swp	Swap File	 	No
//.sys	Windows System File	 	Yes
//.sys	Motorola Driver File	 	No
//.theme	Desktop Theme	 	No
//.vga	VGA Display Driver	 	No
//.vgd	Generic CADD VGA Driver	 	No
//.vxd	Virtual Device Driver	 	No
//.wdgt	Dashboard Widget	 	No
//.wpx	Printer Description File	 	No

  }

}
