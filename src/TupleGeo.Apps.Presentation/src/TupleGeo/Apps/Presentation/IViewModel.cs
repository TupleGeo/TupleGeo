
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
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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

    /// <summary>
    /// Gets the title of the view model.
    /// </summary>
    string Title {
      get;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="property">The property of the <typeparamref name="TEntity"/>.</param>
    /// <remarks>The method can be used to chain together multiple listeners.</remarks>
    /// <returns>An ActionCommand.</returns>
    IViewModel AddPropertyChangedListener<TEntity>(INotifyPropertyChanged source, Expression<Func<TEntity, object>> property);

    /// <summary>
    /// Adds a listener to an ObservableObject of <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="observableObject">The observable object.</param>
    /// <returns>An ActionCommand.</returns>
    public ActionCommand AddListener<TEntity>(ObservableObject<TEntity> observableObject) {
      if (observableObject == null) {
        throw new ArgumentNullException("observableObject", "ObservableObject could not be null.");
      }

      observableObject.PropertyChanged += new PropertyChangedEventHandler(ObservableObject_PropertyChanged);

      return this;
    }

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the command.</param>
    /// <remarks>The method can be used to chain together multiple listeners.</remarks>
    /// <returns>An ActionCommand.</returns>
    public ActionCommand AddObservableCollectionListener(INotifyCollectionChanged source) {
      CollectionChangedEventManager.AddListener(source, _weakCollectionChangedEventListener);

      return this;
    }

    /// <summary>
    /// Adds a listener to an ObservableCollection of <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="observableCollection"/> is <c>null</c>.
    /// </exception>
    /// <remarks>The method can be used to chain together multiple listeners.</remarks>
    /// <returns>An ActionCommand.</returns>
    public ActionCommand AddObservableCollectionListener<TEntity>(ObservableCollection<TEntity> observableCollection) {
      if (observableCollection == null) {
        throw new ArgumentNullException("observableCollection", "ObservableCollection could not be NULL.");
      }

      observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollection_CollectionChanged);

      return this;
    }

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
