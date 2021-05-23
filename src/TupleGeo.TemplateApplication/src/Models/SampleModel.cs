
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;
using TupleGeo.Apps;

#endregion

namespace TupleGeo.TemplateApplication.Models {

  /// <summary>
  /// 
  /// </summary>
  public sealed class SampleModel : ObservableObject, IModel {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="SampleModel"/>.
    /// </summary>
    public SampleModel() {
      
    }

    #endregion

    #region Public Properties

    private int _property1;

    /// <summary>
    /// 
    /// </summary>
    public int Property1 {
      get {
        return _property1;
      }
      set {
        _property1 = value;
        this.OnPropertyChanged();
      }
    }

    private int _property2;

    /// <summary>
    /// 
    /// </summary>
    public int Property2 {
      get {
        return _property2;
      }
      set {
        _property2 = value;
        this.OnPropertyChanged();
      }
    }

    private string _property3;

    /// <summary>
    /// 
    /// </summary>
    public string Property3 {
      get {
        return _property3;
      }
      set {
        _property3 = value;
        this.OnPropertyChanged();
      }
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region IModel Members

    private const string _modelName = "SampleModel";

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
