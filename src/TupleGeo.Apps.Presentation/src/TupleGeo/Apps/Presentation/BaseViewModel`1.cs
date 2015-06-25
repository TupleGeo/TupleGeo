
#region Header
// Title Name       : BaseViewModel<TModel>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : All Views inherit from this class.
// Created by       : 17/01/2012, 18:17, Vasilis Vlastaras.
// Updated by       : 25/06/2015, 00:26, Vasilis Vlastaras.
//                    1.1.0 - BaseViewModel inherits from IViewModel.
// Version          : 1.1.0
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
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General.ComponentModel;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation {

  /// <summary>
  /// All Views inherit from this class.
  /// </summary>
  /// <typeparam name="TModel">The model which is associated with this view.</typeparam>
  public abstract class BaseViewModel<TModel> : ObservableObject<BaseViewModel<TModel>>, IViewModel, IViewModelListeners where TModel : class {

    #region Member Variables

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakPropertyChangedEventListener;
    private readonly WeakEventManagerBase<NotifyCollectionChangedEventArgs> _weakCollectionChangedEventListener;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseViewModel{TModel}"/> class.
    /// </summary>
    /// <param name="model">The model.</param>
    protected BaseViewModel(TModel model) {
      this._model = model;
      this._weakPropertyChangedEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(ModelPropertyChanged);
      this._weakCollectionChangedEventListener = new WeakEventManagerBase<NotifyCollectionChangedEventArgs>(CollectionChanged);
    }

    #endregion
    
    #region Public Properties

    private TModel _model;

    /// <summary>
    /// Gets / Sets the associated model.
    /// </summary>
    public TModel Model {
      get {
        return _model;
      }
      set {
        if (_model != value) {
          _model = value;
          OnPropertyChanged(vm => vm.Model);
        }
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Occurs when a property of a model has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The PropertyChangedEventArgs.</param>
    public virtual void ModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
      //Console.WriteLine("BaseViewModel: OnModelPropertyChanged()");
    }

    /// <summary>
    /// Occurs when the observable collection storing a model has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The NotifyCollectionChangedEventArgs.</param>
    public virtual void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      //Console.WriteLine("BaseViewModel: OnCollectionChanged()");
    }
    
    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when a property of a model has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The PropertyChangedEventArgs.</param>
    private void ObservableObject_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      ModelPropertyChanged(sender, e);
    }

    /// <summary>
    /// Occurs when the observable collection storing a model has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The NotifyCollectionChangedEventArgs.</param>
    private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      CollectionChanged(sender, e);
    }

    #endregion

    #region IViewModel Members

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    public virtual string Name {
      get {
        return string.Empty;
      }
    }

    /// <summary>
    /// Gets the title of the view model.
    /// </summary>
    public virtual string Title {
      get {
        return string.Empty;
      }
    }

    #endregion

    #region IViewModelListeners Members

    /// <summary>
    /// Adds a weak listener to the property of a model implementing <see cref="IModel"/>.
    /// </summary>
    /// <typeparam name="TAnyModel">A model whose property needs to be observed.</typeparam>
    /// <param name="source">The source model.</param>
    /// <param name="modelProperty">
    /// The property of the <typeparamref name="TModel"/> that needs to be observed for changes.
    /// </param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel</returns>
    public IViewModel AddPropertyChangedListener<TAnyModel>(INotifyPropertyChanged source, Expression<Func<TAnyModel, object>> modelProperty) where TAnyModel : IModel {

      string propertyName = Prop.GetPropertyName<TAnyModel>(modelProperty);
      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventListener, propertyName);

      return this;

    }

    /// <summary>
    /// Adds a listener to an <see cref="ObservableObject{TAnyModel}">ObservableObject</see> of <typeparamref name="TAnyModel"/>.
    /// </summary>
    /// <typeparam name="TAnyModel">A model whose property needs to be observed.</typeparam>
    /// <param name="observableObject">The observable object which implements <see cref="IModel"/>.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    public IViewModel AddPropertyChangedListener<TAnyModel>(ObservableObject<TAnyModel> observableObject) where TAnyModel : IModel {

      if (observableObject == null) {
        throw new ArgumentNullException("observableObject", "ObservableObject could not be null.");
      }

      observableObject.PropertyChanged += new PropertyChangedEventHandler(ObservableObject_PropertyChanged);
      
      return this;

    }

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source collection.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    public IViewModel AddCollectionChangedListener(INotifyCollectionChanged source) {

      CollectionChangedEventManager.AddListener(source, _weakCollectionChangedEventListener);

      return this;

    }

    /// <summary>
    /// Adds a listener to an <see cref="ObservableCollection{TAnyModel}">ObservableCollection</see> of <typeparamref name="TAnyModel"/>.
    /// </summary>
    /// <typeparam name="TAnyModel">The model that is stored in the observable collection.</typeparam>
    /// <param name="observableCollection">The observable collection.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    public IViewModel AddCollectionChangedListener<TAnyModel>(ObservableCollection<TAnyModel> observableCollection) where TAnyModel : IModel {

      if (observableCollection == null) {
        throw new ArgumentNullException("observableCollection", "ObservableCollection could not be NULL.");
      }

      observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollection_CollectionChanged);

      return this;

    }

    #endregion
    
  }

}
