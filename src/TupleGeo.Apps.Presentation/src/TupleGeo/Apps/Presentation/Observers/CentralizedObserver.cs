
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
      this._weakPropertyChangedEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(RequeryCanExecute);
      this._weakCollectionChangedEventListener = new WeakEventManagerBase<NotifyCollectionChangedEventArgs>(RequeryCanExecute);
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
      //OnCanExecuteChanged();
    }

    /// <summary>
    /// Re-queries whether the command can execute or not.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The PropertyChangedEventArgs.</param>
    private void RequeryCanExecute(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      //OnCanExecuteChanged();
    }

    /// <summary>
    /// Re-queries whether the command can execute or not.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="notifyCollectionChangedEventArgs">The NotifyCollectionChangedEventArgs.</param>
    private void RequeryCanExecute(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) {
      //OnCanExecuteChanged();
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
      throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="observableObject"></param>
    public void AddPropertyChangedListener<TModel>(ObservableObject<TModel> observableObject) where TModel : IModel {
      throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    public void AddCollectionChangedListener(INotifyCollectionChanged source) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="observableCollection"></param>
    public void AddCollectionChangedListener<TModel>(System.Collections.ObjectModel.ObservableCollection<TModel> observableCollection) where TModel : IModel {
      throw new NotImplementedException();
    }

    #endregion
  }

}
