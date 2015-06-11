
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
  public sealed class SampleModel : ObservableObject<SampleModel>, IModel {

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
