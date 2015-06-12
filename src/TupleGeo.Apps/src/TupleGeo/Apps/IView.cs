
#region Header
// Title Name       : IView.
// Member of        : TupleGeo.Apps.dll
// Description      : The interface implemented by all views classes.
// Created by       : 04/01/2012, 17:04, Vasilis Vlastaras.
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
  /// The interface implemented by all view classes.
  /// </summary>
  public interface IView {

    #region Public Properties

    /// <summary>
    /// Gets the name of the view.
    /// </summary>
    string ViewName {
      get;
    }

    #endregion

  }

}
