
#region Header
// Title Name       : IViewModel.
// Member of        : TupleGeo.Apps.dll
// Description      : The interface implemented by all view model classes.
// Created by       : 04/01/2012, 17:13, Vasilis Vlastaras.
// Updated by       : 20/04/2012, 15:46, Vasilis Vlastaras.
//                    1.0.1 - SetCollectionViewSource method replaced by SetCollectionViewSources method and
//                    changed arguments in SubscribeToEvents and UnsubscribeFromEvents methods.
//                    25/06/2015, 00:42, Vasilis Vlastaras.
//                    1.0.2 - Moved all methods to IViewModelMethods.
//                    19/05/2021, 16:57, Vasilis Vlastaras.
//                    1.1.0 - Moved the interface from assembly TupleGeo.Apps.Presentation.dll
// Version          : 1.1.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The interface implemented by all view model classes.
  /// </summary>
  public interface IViewModel {

    #region Public Properties

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    string Name {
      get;
    }

    /// <summary>
    /// Gets the title of the view model.
    /// </summary>
    string Title {
      get;
    }

    #endregion

  }

}
