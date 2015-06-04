
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public ApplicationModel() {
      this.Caption = "TupleGeo.TemplateApplication";
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

    private string _logSubFolder;

    /// <summary>
    /// Gets / Sets the log folder.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "logSubFolder")]
    public string LogSubFolder {
      get {
        return _logSubFolder;
      }
      set {
        _logSubFolder = value;
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
