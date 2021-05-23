
#region Header
// Title Name       : ActionCommand.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : ActionCommand is a custom ICommand used in Model - View - ViewModel.
// Created by       : 04/01/2012, 13:51, Vasilis Vlastaras.
// Updated by       : 08/03/2012, 21:36, Vasilis Vlastaras.
//                    1.0.1 - Added observed collection support.
// Updated by       : 24/06/2015, 18:15, Vasilis Vlastaras.
//                    1.0.2 - Changed AddListener<TEntity> and AddObservableCollectionListener<TEntity> methods.
//                    22/05/2021, 15:45, Vasilis Vlastaras.
//                    2.0.0 - Implemented the newly IObservationMethods<T> interface using as T the ActionCommand. 
// Version          : 2.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Commands {
  
  /// <summary>
  /// ActionCommand is a custom <see cref="ICommand"/> used in Model - View - ViewModel.
  /// </summary>
  public sealed class ActionCommand : ICommand, IChangesObserverMethods<ActionCommand> {

    #region Member Variables

    private readonly Func<object, bool> _canExecuteFunction;
    private readonly Action<object> _executeAction;

    private readonly WeakEventManager<PropertyChangedEventArgs> _weakPropertyChangedEventManager;
    private readonly WeakEventManager<NotifyCollectionChangedEventArgs> _weakCollectionChangedEventManager;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ActionCommand"/>.
    /// </summary>
    /// <param name="executeAction">The action to be executed.</param>
    /// <param name="canExecuteFunction">The function which determines if the action can be executed.</param>
    public ActionCommand(Action<object> executeAction, Func<object, bool> canExecuteFunction) {
      this._executeAction = executeAction;
      this._canExecuteFunction = canExecuteFunction;
      this._weakPropertyChangedEventManager = new WeakEventManager<PropertyChangedEventArgs>(RequeryCanExecute);
      this._weakCollectionChangedEventManager = new WeakEventManager<NotifyCollectionChangedEventArgs>(RequeryCanExecute);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Fires when <see cref="ActionCommand.CanExecute">CanExecute</see> has been changed.
    /// </summary>
    public void OnCanExecuteChanged() {
      CanExecuteChanged?.Invoke(this, EventArgs.Empty);
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

    #region ICommand Members

    /// <summary>
    /// Indicates whether the command can execute or not.
    /// </summary>
    /// <param name="parameter">The parameter of the command.</param>
    /// <returns>A value indicating whether the command can execute or not.</returns>
    public bool CanExecute(object parameter) {

      if (_canExecuteFunction == null) {
        return false;
      }

      return _canExecuteFunction(parameter);

    }

    /// <summary>
    /// Fires when the <see cref="ActionCommand.CanExecute">CanExecute</see> has been changed.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="parameter">The parameter of the command.</param>
    public void Execute(object parameter) {
      _executeAction?.Invoke(parameter);
    }

    #endregion

    #region IListeners<CentralizedChangesObserver> Members

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventManager, propertyName);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

      string propertyName = Prop.GetPropertyName<TModel>(property);
      PropertyChangedEventManager.RemoveListener(source, _weakPropertyChangedEventManager, propertyName);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventManager, propertyName);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventManager, propertyName);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.AddListener(source, _weakPropertyChangedEventManager, string.Empty);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.RemoveListener(source, _weakPropertyChangedEventManager, string.Empty);

      return this;

    }

    /// <summary>
    /// Adds an event handler to the property of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

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
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel {

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
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.AddHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Removes an event handler from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel {

      PropertyChangedEventManager.RemoveHandler(source, ObservableObject_PropertyChanged, propertyName);

      return this;

    }

    /// <summary>
    /// Adds an event handler to all the properties of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.AddHandler(source, ObservableObject_PropertyChanged, string.Empty);

      return this;

    }

    /// <summary>
    /// Removes an event handler from all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel {

      PropertyChangedEventManager.RemoveHandler(source, ObservableObject_PropertyChanged, string.Empty);

      return this;

    }

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddCollectionChangedListener(INotifyCollectionChanged source) {

      CollectionChangedEventManager.AddListener(source, _weakCollectionChangedEventManager);

      return this;

    }

    /// <summary>
    /// Removes a weak listener from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemoveCollectionChangedListener(INotifyCollectionChanged source) {

      CollectionChangedEventManager.RemoveListener(source, _weakCollectionChangedEventManager);

      return this;

    }

    /// <summary>
    /// Adds an event handler to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddCollectionChangedHandler(INotifyCollectionChanged source) {

      CollectionChangedEventManager.AddHandler(source, ObservableCollection_CollectionChanged);

      return this;

    }

    /// <summary>
    /// Removes an event handler from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemoveCollectionChangedHandler(INotifyCollectionChanged source) {

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
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand AddObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel {

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
    /// <remarks>The method can be used to chain together multiple calls of <see cref="ActionCommand"/> methods.</remarks>
    /// <returns>Itself (<see cref="ActionCommand"/>).</returns>
    public ActionCommand RemoveObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel {

      CollectionChangedEventManager.RemoveHandler(observableCollection, ObservableCollection_CollectionChanged);

      return this;

    }

    #endregion

  }

}
