
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
  public abstract class CentralizedObserver<T> {

    #region Imported Namespaces

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakPropertyChangedEventListener;
    private readonly WeakEventManagerBase<NotifyCollectionChangedEventArgs> _weakCollectionChangedEventListener;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CentralizedObserver"/>.
    /// </summary>
    protected CentralizedObserver() {
      this._weakPropertyChangedEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(RequeryCanExecute);
      this._weakCollectionChangedEventListener = new WeakEventManagerBase<NotifyCollectionChangedEventArgs>(RequeryCanExecute);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="T">The object that implements the <see cref="INotifyPropertyChanged"/> interface.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="property">The property of the <typeparamref name="TEntity"/>.</param>
    /// <remarks>The method can be used to chain together multiple listeners.</remarks>
    /// <returns>A CentralizedObserver.</returns>
    public CentralizedObserver AddPropertyChangedListener<T>(INotifyPropertyChanged source, Expression<Func<T, object>> prop) {
      string propertyName = Prop.GetPropertyName<T>(prop);

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;
    }

    /// <summary>
    /// Adds a listener to an <see cref="ObservableObject{T}">ObservableObject</see> of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The entity used.</typeparam>
    /// <param name="observableObject">The observable object.</param>
    /// <returns>A CentralizedObserver.</returns>
    public CentralizedObserver AddPropertyChangedListener<T>(ObservableObject<T> observableObject) {
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
    /// <returns>A CentralizedObserver.</returns>
    public CentralizedObserver AddObservableCollectionListener(INotifyCollectionChanged source) {
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
    /// Fires when <see cref="ActionCommand.CanExecute">CanExecute</see> has been changed.
    /// </summary>
    public void OnCanExecuteChanged() {
      if (CanExecuteChanged != null) {
        CanExecuteChanged(this, EventArgs.Empty);
      }
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when the ObservableObject has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The PropertyChangedEventArgs.</param>
    private void ObservableObject_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      RequeryCanExecute(sender);
    }

    /// <summary>
    /// Occurs when the ObservableCollection has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The NotifyCollectionChangedEventArgs.</param>
    private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      RequeryCanExecute(sender);
    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Re-queries whether the command can execute or not.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "sender")]
    private void RequeryCanExecute(object sender) {
      OnCanExecuteChanged();
    }

    /// <summary>
    /// Re-queries whether the command can execute or not.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The PropertyChangedEventArgs.</param>
    private void RequeryCanExecute(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      OnCanExecuteChanged();
    }

    /// <summary>
    /// Re-queries whether the command can execute or not.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="notifyCollectionChangedEventArgs">The NotifyCollectionChangedEventArgs.</param>
    private void RequeryCanExecute(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) {
      OnCanExecuteChanged();
    }

    #endregion




  }

}
