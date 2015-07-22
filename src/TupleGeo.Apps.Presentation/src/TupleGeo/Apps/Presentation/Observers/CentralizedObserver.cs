
#region Header
// Title Name       : CentralizedObserver.
// Member of        : TupleGeo.Apps.Presentation.Observers.dll
// Description      : 
// Created by       : 26/06/2015, 17:50, 
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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TupleGeo.General.ComponentModel;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// The CentralizedObserver provides the abstract implementation of an observer that can be used to attach listeners
  /// for property and collection changes when there is a need for these changes to be managed centrally.
  /// </summary>
  public abstract class CentralizedObserver : IListeners {

    #region Imported Namespaces

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakPropertyChangedEventListener;
    private readonly WeakEventManagerBase<NotifyCollectionChangedEventArgs> _weakCollectionChangedEventListener;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CentralizedObserver{T}">CentralizedObserver</see> of <typeparamref name="T"/>
    /// </summary>
    protected CentralizedObserver() {
      this._weakPropertyChangedEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(OnPropertyChanged);
      this._weakCollectionChangedEventListener = new WeakEventManagerBase<NotifyCollectionChangedEventArgs>(OnCollectionChanged);
    }

    #endregion

    #region Public Methods

    ///// <summary>
    ///// Fires when a property has been changed.
    ///// </summary>
    ///// <param name="sender">The sender of the event.</param>
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "sender")]
    //public virtual void OnPropertyChanged(object sender) {
      
    //}

    /// <summary>
    /// Fires when a property has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The PropertyChangedEventArgs.</param>
    public virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      
    }

    /// <summary>
    /// Fires when a collection has been changed.
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

    #region IListeners Members

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">A model entity whose properties will be observed.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="prop">The property of the <typeparamref name="TModel"/>.</param>
    public void AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> prop) where TModel : IModel {
      string propertyName = Prop.GetPropertyName<TModel>(prop);
      PropertyChangedEventManager.AddListener(source, _weakCollectionChangedEventListener, propertyName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="observableObject"></param>
    public void AddPropertyChangedListener<TModel>(ObservableObject<TModel> observableObject) where TModel : IModel {
      if (observableObject == null) {
        throw new ArgumentNullException("observableObject", "ObservableObject could not be null.");
      }
      observableObject.PropertyChanged += new PropertyChangedEventHandler(ObservableObject_PropertyChanged);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    public void AddCollectionChangedListener(INotifyCollectionChanged source) {
      CollectionChangedEventManager.AddListener(source, _weakCollectionChangedEventListener);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="observableCollection"></param>
    public void AddCollectionChangedListener<TModel>(System.Collections.ObjectModel.ObservableCollection<TModel> observableCollection) where TModel : IModel {
      if (observableCollection == null) {
        throw new ArgumentNullException("observableCollection", "ObservableCollection could not be NULL.");
      }
      observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollection_CollectionChanged);
    }

    #endregion

  }

}
