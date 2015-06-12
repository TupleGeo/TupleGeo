
#region Header
// Title Name       : IModel.
// Member of        : TupleGeo.Apps.dll
// Description      : Defines the protocol for a model.
// Created by       : 04/01/2012, 14:51, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// Defines the protocol for a model.
  /// </summary>
  public interface IModel {

    #region Public Properties

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    string ModelName {
      get;
    }

    #endregion

  }

}
