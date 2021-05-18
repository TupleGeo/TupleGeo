
#region Header
// Title Name       : Model.
// Member of        : TupleGeo.Apps.dll
// Description      : The abstract Model class defines the default behaviour of the model.
// Created by       : 15/05/2021, 21:33, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2021.
// Comments         : 

#endregion

#region Imported Namespaces

using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The abstract Model class defines the default behaviour of the model.
  /// </summary>
  public abstract class Model : IModel {

    #region Public Properties

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public abstract string ModelName {
      get;
    }

    #endregion

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="Model.PropertyChanged" /> event.
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed.</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }

    #endregion

    #region Public Events

    /// <summary>
    /// The <see cref="PropertyChanged"/> event.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

  }

}
