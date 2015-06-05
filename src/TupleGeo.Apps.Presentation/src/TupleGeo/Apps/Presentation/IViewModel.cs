
#region Header
// Title Name       : IViewModel.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : The interface implemented by all view model classes.
// Created by       : 04/01/2012, 17:13, Vasilis Vlastaras.
// Updated by       : 20/04/2012, 15:46, Vasilis Vlastaras. - SetCollectionViewSource method replaced by
//                    SetCollectionViewSources method and changed arguments in SubscribeToEvents and UnsubscribeFromEvents methods.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

#endregion

namespace TupleGeo.Apps.Presentation {

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

    #endregion

    #region Public Methods

    /// <summary>
    /// Binds this view model to events raised by its corresponding view.
    /// </summary>
    /// <param name="triggeringObjectsDictionary">The object whose events will be observed.</param>
    void SubscribeToEvents(Dictionary<string, object> triggeringObjectsDictionary);
    
    /// <summary>
    /// Removes event subscriptions of this view model.
    /// </summary>
    /// <param name="triggeringObjectsDictionary">The objects whose events will be stopped being observed.</param>
    void UnsubscribeFromEvents(Dictionary<string, object> triggeringObjectsDictionary);
    
    /// <summary>
    /// Sets the <see cref="CollectionViewSource">CollectionViewSources</see> for this model.
    /// </summary>
    /// <param name="collectionViewSourcesDictionary">
    /// The dictionary of <see cref="CollectionViewSource">CollectionViewSources</see>
    /// that will be used to display data.
    /// </param>
    void SetCollectionViewSources(Dictionary<string, CollectionViewSource> collectionViewSourcesDictionary);

    #endregion

  }

}
