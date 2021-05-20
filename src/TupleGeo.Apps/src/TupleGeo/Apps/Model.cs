
#region Header
// Title Name       : Model.
// Member of        : TupleGeo.Apps.dll
// Description      : The abstract Model class defines the default behaviour of the model.
// Created by       : 18/05/2021, 12:57, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2021.
// Comments         : 

#endregion

#region Imported Namespaces

using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The abstract Model class defines the default behaviour of the model.
  /// </summary>
  public abstract class Model : ObservableObject, IModel {

    #region Public Properties

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public abstract string ModelName {
      get;
    }

    #endregion

  }

}
