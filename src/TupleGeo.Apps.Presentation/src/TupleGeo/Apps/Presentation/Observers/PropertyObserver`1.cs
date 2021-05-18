
#region Header
// Title Name       : PropertyObserver<T>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : An object that its property value changes can be observed by other objects.
// Created by       : 30/05/2012, 13:38
// Updated by       : 18/05/2021, 02:36 - 1.0.1 Minor changes.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2021.
// Comments         : Code originally developed by Josh Smith, found at:
//                    https://joshsmithonwpf.wordpress.com/2009/07/11/one-way-to-avoid-messy-propertychanged-event-handling/
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// Monitors the <see cref="INotifyPropertyChanged.PropertyChanged">PropertyChanged</see> event of an object that
  /// implements <see cref="INotifyPropertyChanged"/>, and executes callback methods (i.e. handlers) registered for
  /// properties of that object.
  /// </summary>
  /// <typeparam name="TPropertySource">The type of object to monitor for property changes.</typeparam>
  public sealed class PropertyObserver<TPropertySource> : IWeakEventListener where TPropertySource : INotifyPropertyChanged {

    #region Member Variables

    private readonly Dictionary<string, Action<TPropertySource>> _propertyNameToHandlerMap;
    //readonly Dictionary<string, Action> _propertyNameToHandlerMap2;
    private readonly WeakReference _propertySourceRef;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of <see cref="PropertyObserver{TPropertySource}"/>.
    /// </summary>
    /// <param name="propertySource">The object to monitor for property changes.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="propertySource"/> is <c>null</c>.</exception>
    public PropertyObserver(TPropertySource propertySource) {
      if (propertySource == null) {
        throw new ArgumentNullException("propertySource");
      }

      _propertySourceRef = new WeakReference(propertySource);
      _propertyNameToHandlerMap = new Dictionary<string, Action<TPropertySource>>();
      // _propertyNameToHandlerMap2 = new Dictionary<string, Action>();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Registers a callback to be invoked when the <see cref="INotifyPropertyChanged.PropertyChanged">PropertyChanged</see>
    /// event has been raised for the specified property.
    /// </summary>
    /// <param name="expression">A lambda expression like <code>n => n.PropertyName</code></param>
    /// <param name="handler">The callback to invoke when the property has changed.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="expression"/> or <paramref name="handler"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="expression"/> does not provide a property name.
    /// </exception>
    /// <returns>
    /// The object on which this method was invoked, to allow for multiple invocations chained together.
    /// </returns>
    public PropertyObserver<TPropertySource> RegisterHandler(Expression<Func<TPropertySource, object>> expression, Action<TPropertySource> handler) {
      if (expression == null) {
        throw new ArgumentNullException("expression");
      }

      string propertyName = Prop.GetPropertyName<TPropertySource>(expression);
      if (String.IsNullOrEmpty(propertyName)) {
        throw new ArgumentException("'expression' did not provide a property name.", "expression");
      }

      if (handler == null) {
        throw new ArgumentNullException("handler");
      }

      TPropertySource propertySource = this.GetPropertySource();
      if (propertySource != null) {
        Debug.Assert(!_propertyNameToHandlerMap.ContainsKey(propertyName), "Why is the '" + propertyName + "' property being registered again?");

        _propertyNameToHandlerMap[propertyName] = handler;
        PropertyChangedEventManager.AddListener(propertySource, this, propertyName);
      }

      return this;
    }

    /// <summary>
    /// Removes the callback associated with the specified property.
    /// </summary>
    /// <param name="expression">A lambda expression like <code>n => n.PropertyName</code></param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="expression"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="expression"/> does not provide a property name.
    /// </exception>
    /// <returns>
    /// The object on which this method was invoked, to allow for multiple invocations chained together.
    /// </returns>
    public PropertyObserver<TPropertySource> UnregisterHandler(Expression<Func<TPropertySource, object>> expression) {
      if (expression == null) {
        throw new ArgumentNullException("expression");
      }

      string propertyName = Prop.GetPropertyName<TPropertySource>(expression); // GetPropertyName(expression);
      if (String.IsNullOrEmpty(propertyName)) {
        throw new ArgumentException("'expression' did not provide a property name.");
      }

      TPropertySource propertySource = this.GetPropertySource();
      if (propertySource != null) {
        if (_propertyNameToHandlerMap.ContainsKey(propertyName)) {
          _propertyNameToHandlerMap.Remove(propertyName);
          PropertyChangedEventManager.RemoveListener(propertySource, this, propertyName);
        }
      }

      return this;
    }

    #endregion

    #region IWeakEventListener Members

    /// <summary>
    /// Receives a weak event.
    /// </summary>
    /// <param name="managerType">The Type of the manager.</param>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>
    /// A value determining whether the event was handled or not.
    /// </returns>
    bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e) {
      bool handled = false;

      if (managerType == typeof(PropertyChangedEventManager)) {
        PropertyChangedEventArgs args = e as PropertyChangedEventArgs;
        if (args != null && sender is TPropertySource) {
          string propertyName = args.PropertyName;
          TPropertySource propertySource = (TPropertySource)sender;

          if (String.IsNullOrEmpty(propertyName)) {
            // When the property name is empty, all properties are considered to be invalidated.
            // Iterate over a copy of the list of handlers, in case a handler is registered by a callback.
            foreach (Action<TPropertySource> handler in _propertyNameToHandlerMap.Values.ToArray()) {
              handler(propertySource);
            }
            
            handled = true;
          }
          else {
            if (_propertyNameToHandlerMap.TryGetValue(propertyName, out Action<TPropertySource> handler)) {
              handler(propertySource);
              handled = true;
            }
          }
        }
      }

      return handled;
    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Gets the target of the property source.
    /// </summary>
    /// <returns>
    /// A <typeparamref name="TPropertySource"/> object.
    /// </returns>
    private TPropertySource GetPropertySource() {
      try {
        return (TPropertySource)_propertySourceRef.Target;
      }
      catch {
        // Swallow the error.
        return default(TPropertySource);
      }
    }

    #endregion

  }

}
