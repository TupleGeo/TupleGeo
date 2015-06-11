
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TupleGeo.General.ComponentModel;
using TupleGeo.Apps;

#endregion

namespace TupleGeo.TemplateApplication.Models.Application {

  /// <summary>
  /// The model of the application.
  /// </summary>
  [SerializableAttribute()]
  [XmlRootAttribute(Namespace = "urn:TupleGeo.TemplateApplication.Models", ElementName = "applicationConfiguration")]
  public sealed class ApplicationModel : ObservableObject<ApplicationModel>, IModel {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ApplicationModel"/>.
    /// </summary>
    [
      System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "TupleGeo.TemplateApplication.Models.Application.ApplicationModel.set_Caption(System.String)"),
      System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "TemplateApplication"),
      System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "TupleGeo")
    ]
    public ApplicationModel() {
      this.Caption = "TupleGeo.TemplateApplication"; // TODO: Change the caption accordingly.
    }

    #endregion

    #region Public Properties

    private string _caption;

    /// <summary>
    /// Gets / Sets the caption text of the main application window.
    /// </summary>
    [XmlIgnoreAttribute()]
    public string Caption {
      get {
        return _caption;
      }
      set {
        if (_caption != value) {
          _caption = value;
          this.OnPropertyChanged(m => m.Caption);
        }
      }
    }

    private string _logSubfolder;

    /// <summary>
    /// Gets / Sets the log folder.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "logSubFolder")]
    public string LogSubfolder {
      get {
        return _logSubfolder;
      }
      set {
        _logSubfolder = value;
      }
    }

    #endregion

    #region IModel Members

    private const string _modelName = "ApplicationModel";
    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public string ModelName {
      get {
        return _modelName;
      }
    }

    #endregion
    
  }

}
