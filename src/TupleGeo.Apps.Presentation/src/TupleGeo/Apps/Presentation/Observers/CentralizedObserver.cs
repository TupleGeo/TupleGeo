
#region Header
// Title Name       : CentralizedObserver.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : The CentralizedObserver provides the abstract implementation of an observer that can be used
//                    to attach listeners for property and collection changes when there is a need for these changes
//                    to be managed centrally.
// Created by       : 24/07/2015, 11:08, Vasilis Vlastaras.
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TupleGeo.General.ComponentModel;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// The CentralizedObserver provides the abstract implementation of an observer that can be used to attach listeners
  /// for property and collection changes when there is a need for these changes to be managed centrally.
  /// </summary>
  public abstract class CentralizedObserver : IListeners<CentralizedObserver> {

    #region Imported Namespaces

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakPropertyChangedEventListener;
    private readonly WeakEventManagerBase<NotifyCollectionChangedEventArgs> _weakCollectionChangedEventListener;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CentralizedObserver"/>.
    /// </summary>
    protected CentralizedObserver() {
      this._weakPropertyChangedEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(OnPropertyChanged);
      this._weakCollectionChangedEventListener = new WeakEventManagerBase<NotifyCollectionChangedEventArgs>(OnCollectionChanged);

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// <para>Fires when a property has been changed.</para>
    /// <para>Override this to listen to property changes and to provide custom reaction logic to these changes.</para>
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The PropertyChangedEventArgs.</param>
    public virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      
    }

    /// <summary>
    /// <para>Fires when a collection has been changed.</para>
    /// <para>Override this to listen to property changes and to provide custom reaction logic to these changes.</para>
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="notifyCollectionChangedEventArgs">The NotifyCollectionChangedEventArgs.</param>
    public virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) {
      
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when the ObservableObject has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The PropertyChangedEventArgs.</param>
    private void ObservableObject_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      OnPropertyChanged(sender, e);
    }

    /// <summary>
    /// Occurs when the ObservableCollection has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The NotifyCollectionChangedEventArgs.</param>
    private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      OnCollectionChanged(sender, e);
    }

    #endregion

    #region IListeners<CentralizedObserver> Members

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.RemoveListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel {
      
      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, string.Empty);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.RemoveListener(source, _weakPropertyChangedEventListener, string.Empty);

      return this;

    }

    /// <summary>
    /// Adds an event handler to the property of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.AddHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Removes an event handler from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.RemoveHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Adds an event handler to the property of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Removes an event handler from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.RemoveHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Adds an event handler to all the properties of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.AddHandler(source, ObservableObject_PropertyChanged, string.Empty);

      return this;

    }

    /// <summary>
    /// Removes an event handler from all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.RemoveHandler(source, ObservableObject_PropertyChanged, string.Empty);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddCollectionChangedListener(INotifyCollectionChanged source) {

      CollectionChangedEventManager.AddListener(source, _weakCollectionChangedEventListener);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemoveCollectionChangedListener(INotifyCollectionChanged source) {

      CollectionChangedEventManager.RemoveListener(source, _weakCollectionChangedEventListener);

      return this;

    }

    /// <summary>
    /// Adds an event handler to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddCollectionChangedHandler(INotifyCollectionChanged source) {

      CollectionChangedEventManager.AddHandler(source, ObservableCollection_CollectionChanged);

      return this;

    }

    /// <summary>
    /// Removes an event handler from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemoveCollectionChangedHandler(INotifyCollectionChanged source) {

      CollectionChangedEventManager.RemoveHandler(source, ObservableCollection_CollectionChanged);

      return this;

    }

    /// <summary>
    /// Adds a listener to an <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="observableCollection"/> is <c>null</c>.
    /// </exception>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver AddObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel {

      CollectionChangedEventManager.AddHandler(observableCollection, ObservableCollection_CollectionChanged);

      return this;

    }

    /// <summary>
    /// Removes a listener to an <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="observableCollection"/> is <c>null</c>.
    /// </exception>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="CentralizedObserver"/> methods.</remarks>
    /// <returns>Itself (<see cref="CentralizedObserver"/>).</returns>
    public CentralizedObserver RemoveObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel {

      CollectionChangedEventManager.RemoveHandler(observableCollection, ObservableCollection_CollectionChanged);

      return this;

    }

    #endregion

  }

}
