
#region Header
// Title Name       : IViewModelMethods.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : The methods that view models might need to implement.
// Created by       : 25/06/2015, 00:31, Vasilis Vlastaras.
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

#endregion

namespace TupleGeo.Apps.Presentation {

  /// <summary>
  /// The methods that view models might need to implement.
  /// </summary>
  public interface IViewModelMethods {

    #region Public Methods

    /// <summary>
    /// Binds this view model to events raised by its corresponding view.
    /// </summary>
    /// <param name="triggeringControlsDictionary">The controls whose events will be observed.</param>
    void SubscribeToEvents(Dictionary<string, object> triggeringControlsDictionary);

    /// <summary>
    /// Removes event subscriptions of this view model.
    /// </summary>
    /// <param name="triggeringControlsDictionary">The controls whose events will be stopped being observed.</param>
    void UnsubscribeFromEvents(Dictionary<string, object> triggeringControlsDictionary);

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
