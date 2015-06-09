
#region Header
// Title Name       : ActionCommand.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : ActionCommand is a custom ICommand used in Model - View - ViewModel.
// Created by       : 04/01/2012, 13:51, Vasilis Vlastaras.
// Updated by       : 08/03/2012, 21:36, Vasilis Vlastaras. - Added observed collection support.
// Version          : 1.0.1
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
using System.Reflection;
using System.Text;
using System.Windows.Input;
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Commands {
  
  /// <summary>
  /// ActionCommand is a custom <see cref="ICommand"/> used in Model - View - ViewModel.
  /// </summary>
  public sealed class ActionCommand : ICommand {

    #region Member Variables

    private readonly Func<object, bool> _canExecuteFunction;
    private readonly Action<object> _executeAction;

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakEventListener;

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
      this._weakEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(RequeryCanExecute);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a command listener.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="property">The property of the TEntity.</param>
    /// <returns>An <see cref="ActionCommand"/>.</returns>
    public ActionCommand AddListener<TEntity>(INotifyPropertyChanged source, Expression<Func<TEntity, object>> property) {
      string propertyName = Prop.GetPropertyName<TEntity>(property); // GetPropertyName<TEntity>(property);
      PropertyChangedEventManager.AddListener(source, _weakEventListener, propertyName);
      
      return this;
    }

    /// <summary>
    /// Adds an observable collection listener.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    public void AddObservableCollectionListener<TEntity>(ObservableCollection<TEntity> observableCollection) {
      if (observableCollection == null) {
        throw new ArgumentNullException("observableCollection", "ObservableCollection could not be NULL.");
      }
      observableCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(ObservableCollection_CollectionChanged);
    }

    /// <summary>
    /// Fires when can execute has been changed.
    /// </summary>
    public void OnCanExecuteChanged() {
      if (CanExecuteChanged != null) {
        CanExecuteChanged(this, EventArgs.Empty);
      }
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// Occurs when the observable collection has been changed.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/>.</param>
    private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      RequeryCanExecute(sender);
    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Re-queries the can execute.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The <see cref="PropertyChangedEventArgs"/>.</param>
    private void RequeryCanExecute(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      OnCanExecuteChanged();
    }

    /// <summary>
    /// Re-queries the can execute.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "sender")]
    private void RequeryCanExecute(object sender) {
      OnCanExecuteChanged();
    }

    #endregion

    #region ICommand Members

    /// <summary>
    /// Indicates whether the command can execute or not.
    /// </summary>
    /// <param name="parameter">The parameter of the command.</param>
    /// <returns>A <see cref="bool"/> indicating whether the command can execute or not.</returns>
    public bool CanExecute(object parameter) {
      if (_canExecuteFunction == null) {
        return false;
      }
      return _canExecuteFunction(parameter);
    }

    /// <summary>
    /// Fires when the can execute has been changed.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <param name="parameter">The parameter of the command.</param>
    public void Execute(object parameter) {
      if (_executeAction != null) {
        _executeAction(parameter);
      }
    }

    #endregion

  }

}
