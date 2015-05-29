
#region Header
// Title Name       : TextFileTypes
// Member of        : TupleGeo.General.dll
// Description      : Text file types enumeration.
// Created by       : 10/02/2009, 15:20, Vasilis Vlastaras
// Updated by       : 19/02/2009, 00:47, Vasilis Vlastaras.
//                    1.0.1 - Moved class from another assembly.
//                  : 26/03/2009, 19:34, Vasilis Vlastaras.
//                    1.0.2 - Added System.Xml.Serialization namespace / Cleaned up file.
//                  : 22/02/2011, 22:15, Vasilis Vlastaras.
//                    1.0.3 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.3
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
//
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
  /// Types of text files.
  /// </summary>
  public enum TextFileType {
    
//.1st	Readme File	 	No
//.abw	AbiWord Document	 	No
//.act	FoxPro Documenting Wizard Action Diagram	 	No
//.aim	AIMMS ASCII Model File	 	No
//.ans	ANSI Text File	 	No
//.asc	ASCII Text File	 	No
//.asc	Autodesk ASCII Export File	 	No
//.ascii	ASCII Text File	 	No
//.ase	Autodesk ASCII Scene Export File	 	No
//.aty	Association Type Placeholder	 	No
//.bad	Exchange Badmail File	 	No
//.bbs	Bulletin Board System Text	 	No
//.bdp	Exchange Diagnostic Message	 	No
//.bdr	Exchange Non-Delivery Report Body File	 	No
//.bean	Bean Rich Text Document	 	No
//.bib	BibTeX Bibliography Database	 	No
//.bib	Bibliography Document	 	No
//.bna	Barna Word Processor Document	 	No
//.boc	EasyWord Big Document	 	No
//.charset	Character Set	 	No
//.chord	Song Chords File	 	No
//.crd	Guitar Tabs	 	No
//.crwl	Windows Crawl File	 	No

    /// <summary>
    /// Comma separated value file format.
    /// </summary>
    [XmlEnumAttribute("csv")]
    [DescriptionAttribute("Comma separated value file format")]
    [DescriptionAttribute("Αρχείο κειμένου διαχωριζόμενου με κόμμα", "el-GR")]
    Csv,

//.cyi	Clustify Input File	 	No
//.dbt	Database Text File	 	No
//.dct	FoxPro Database Memo	 	No
//.dgs	Dagesh Pro Document	 	No
//.diz	Description in Zip File	 	No
//.dne	Netica Text File	 	No

    /// <summary>
    /// Microsoft Word Document file format.
    /// </summary>
    [XmlEnumAttribute("doc")]
    [DescriptionAttribute("Microsoft Word Document file format")]
    [DescriptionAttribute("Αρχείο κειμένου microsoft word", "el-GR")]
    Doc,

//.doc	WordPad Document	 	No
//.docm	Word 2007 Macro-Enabled Document	 	No
//.docx	Microsoft Word Open XML Document	 	No
//.dot	Microsoft Word Template	 	No
//.dotm	Word 2007 Macro-Enabled Document Template	 	No
//.dotx	Word 2007 Document Template	 	No
//.dvi	Device Independent Format File	 	No
//.dx	DEC WPS Plus File	 	No
//.email	Outlook Express Email Message	 	No
//.emlx	Mail Message	 	No
//.epp	EditPad Pro Project	 	No
//.err	Error Log File	 	No
//.err	FoxPro Compilation Error	 	No
//.etf	ENIGMA Transportable File	 	No
//.etx	Structure Enhanced Text (Setext) File	 	No
//.euc	Extended Unix Code	 	No
//.faq	Frequently Asked Questions Document	 	No
//.fb2	FictionBook 2.0 File	 	No
//.fbl	CADfix Command Level Log File	 	No
//.fdf	Acrobat Forms Data Format	 	No
//.fdr	Final Draft Document	 	No
//.fds	Final Draft Secure Copy	 	No
//.fes	Fileless Occurrence Placeholder	 	No
//.fpt	FileMaker Pro Database Memo File	 	No
//.fpt	FoxPro Table Memo	 	No
//.frt	FoxPro Report Memo	 	No
//.fxc	FilePackager Configuration	 	No
//.gio	Adagio Score	 	No
//.gio	Nyquist MIDI File	 	No
//.gpn	GlidePlan Map Document	 	No
//.gsd	Generic Station Description File	 	No
//.gthr	Gather Log File	 	No
//.gv	GraphcViz DOT File	 	No
//.hht	Help and Support Center HHT File	 	No

    /// <summary>
    /// Hypertext markup language file format.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Htm")]
    [XmlEnumAttribute("htm")]
    [DescriptionAttribute("Hypertext markup language file format")]
    [DescriptionAttribute("Αρχείο υπερκειμένου", "el-GR")]
    Htm,

    /// <summary>
    /// Hypertext markup language file format.
    /// </summary>
    [XmlEnumAttribute("html")]
    [DescriptionAttribute("Hypertext markup language file format")]
    [DescriptionAttribute("Αρχείο υπερκειμένου", "el-GR")]
    Html,

//.hs	Java HelpSet File	 	No
//.hwp	Hangul (Korean) Text Document	 	No
//.hz	Chinese (Hanzi) Text	 	No
//.idx	Outlook Express Mailbox Index File	 	No
//.iil	CleanSweep Installation Log	 	No
//.imapmbox	IMAP Mailbox	 	No
//.ipf	OS/2 Help File	 	No
//.jis	Japanese Industry Standard Text	 	No
//.jp1	Japanese (Romaji) Text File	 	No
//.klg	Log File	 	No
//.klg	KOFIA Log	 	No
//.kml	Keyhole Markup Language	 	No
//.knt	KeyNote Note File	 	No
//.kon	Yahoo! Widget XML File	 	No
//.kwd	KWord Document	 	No
//.latex	LaTeX Document	 	No
//.lbt	FoxPro Label Memo	 	No
//.lis	SQR Output File	 	No
//.lit	eBook File	 	No
//.lnt	Laego Note Taker File	 	No
//.log	Log File	 	Yes
//.lp2	iLEAP Word Processing Document	 	No
//.lrc	Lyrics File	 	No
//.lst	Data List	 	No
//.lst	FoxPro Documenting Wizard List	 	No
//.ltr	Letter File	 	No
//.luf	Lipikar Uniform Format File	 	No
//.lwp	Lotus Word Pro Document	 	No
//.lxfml	LEGO Digital Designer XML File	 	No
//.lyt	TurboTax Install Log File	 	No
//.lyx	LyX Document	 	No
//.man	Unix Manual	 	No
//.map	Image Map	 	No
//.mbox	E-mail Mailbox File	 	No
//.mell	Mellel Word Processing File	 	No
//.mellel	Mellel Word Processing Document	 	No
//.mnt	FoxPro Menu Memo	 	No
//.msg	Mail Message	 	Yes
//.mw	MacWrite Text Document	 	No
//.mwp	Lotus Word Pro SmartMaster File	 	No
//.nfo	Warez Information File	 	No
//.notes	Memento Notes File	 	No
//.now	Readme File	 	No
//.nwctxt	NoteWorthy Composer Text File	 	No
//.nzb	NewzBin File	 	No
//.ocr	FAXGrapper Fax Text File	 	No
//.odm	OpenDocument Master Document	 	No
//.odt	OpenDocument Text Document	 	No
//.ofl	Ots File List	 	No
//.oft	Outlook File Template	 	No
//.opml	OPML File	 	No
//.ott	OpenDocument Text Document Template	 	No
//.p7s	Digitally Signed Message	 	No
//.pages	Pages Document	 	No

    /// <summary>
    /// Adobe portable file format.
    /// </summary>
    [XmlEnumAttribute("pdf")]
    [DescriptionAttribute("Adobe portable file format")]
    [DescriptionAttribute("Αρχείο Adobe portable", "el-GR")]
    Pdf,

//.pfx	First Choice Word Processing Document	 	No
//.pjt	FoxPro Project Memo	 	No
//.prt	Printer Output File	 	No
//.psw	Pocket Word Document	 	No
//.pvm	Photo Video Manifest File	 	No
//.pwi	Pocket Word Document	 	No
//.qdl	QDL Program	 	No
//.rad	Radar ViewPoint Radar Data	 	No
//.readme	Readme File	 	No
//.rng	RELAX NG File	 	No
//.rpt	Generic Report	 	No
//.rst	reStructuredText File	 	No
//.rt	RealText Streaming Text File	 	No
//.rtd	RagTime Document	 	No

    /// <summary>
    /// Rich text file format.
    /// </summary>
    [XmlEnumAttribute("rtf")]
    [DescriptionAttribute("Rich text file format.")]
    [DescriptionAttribute("Αρχείο Rich text.", "el-GR")]
    Rtf,

//.rtfd	Rich Text Format Directory File	 	No
//.rtx	Rich Text Document	 	No
//.run	Runscanner Scan File	 	No
//.rzk	File Crypt Password File	 	No
//.rzn	Red Zion Notes File	 	No
//.saf	SafeText File	 	No
//.safetext	SafeText File	 	No
//.sam	Ami Pro Document	 	No
//.scc	Scenarist Closed Caption File	 	No
//.scm	Schema File	 	No
//.sct	FoxPro Form Memo	 	No
//.scw	Movie Magic Screenwriter Document	 	No
//.sdm	StarOffice Mail Message	 	No
//.sdw	StarOffice Writer Text Document	 	No
//.sgm	SGML File	 	No
//.sig	Signature File	 	No
//.sls	Image Playlist	 	No
//.sms	Exported SMS Text Message	 	No
//.ssa	Sub Station Alpha Subtitle File	 	No
//.strings	Text Strings File	 	No
//.stw	StarOffice Text Document Template	 	No
//.sub	Subtitle File	 	No
//.sxw	StarOffice Writer Text Document	 	No
//.tab	Guitar Tablature File	 	No
//.tdf	Guide Text Definition File	 	No
//.tdf	Xserve Test Definition File	 	No
//.tex	LaTeX Source Document	 	No
//.text	Plain Text File	 	No
//.thp	TurboTax Text String	 	No
//.tlb	VAX Text Library	 	No
//.tmx	Translation Memory eXchange File	 	No
//.tpc	Topic Connection Placeholder	 	No

    /// <summary>
    /// Plain text file format.
    /// </summary>
    [XmlEnumAttribute("txt")]
    [DescriptionAttribute("Plain text file format")]
    [DescriptionAttribute("Αρχείο κειμένου", "el-GR")]
    Txt,

//.u3i	U3 Application Information File	 	No
//.unauth	SiteMinder Unauthorized Message File	 	No
//.unx	Unix Text File	 	No
//.upd	Program Update Information	 	No
//.utf8	Unicode UTF8-Encoded Text	 	No
//.utxt	Unicode Text File	 	No
//.vct	Visual Class Library Memo	 	No
//.vnt	Mobile Phone vNote File	 	No
//.wbk	Word Document Backup	 	No
//.wbk	WordPerfect Workbook	 	No
//.wcf	WebEx Saved Chat Session	 	No
//.wgz	S60 Web Runtime Widget Package	 	No
//.wn	WriteNow Text Document	 	No
//.wp	WordPerfect Document	 	No
//.wp4	WordPerfect 4 Document	 	No
//.wp5	WordPerfect 5 Document	 	No
//.wp6	WordPerfect 6 Document	 	No
//.wp7	WordPerfect 7 Document	 	No
//.wpa	ACT! Word Processing Document	 	No
//.wpd	WordPerfect Document	 	Yes
//.wpd	ACT! 2 Word Processing Document	 	No
//.wpl	DEC WPS Plus Text Document	 	No
//.wps	Microsoft Works Word Processor Document	 	Yes
//.wpt	WordPerfect Template	 	No
//.wri	Windows Write Document	 	No
//.wsc	Windows Script Component	 	No
//.wsh	Windows Script Host Settings	 	No

    /// <summary>
    /// Extensible file format.
    /// </summary>
    [XmlEnumAttribute("xml")]
    [DescriptionAttribute("Extensible file format")]
    [DescriptionAttribute("Αρχείο xml", "el-GR")]
    Xml,

//.xdl	XML Schema File	 	No
//.xdl	Oracle Expert Definition Language File	 	No
//.xlf	XLIFF Document	 	No
//.xps	XML Paper Specification File	 	No
//.xwp	XMLwriter Project	 	No
//.xwp	Xerox Writer Text Document	 	No
//.xwp	Crosstalk Session File	 	No
//.xy	XYWrite Document	 	No
//.xy3	XYWrite III Document	 	No
//.xyp	XYWrite Plus Document	 	No
//.xyw	XYWrite for Windows Document	 	No
//.ybk	YanCEyWare Reader eBook	 	No
//.yml	YAML Document	 	No

  }

}
