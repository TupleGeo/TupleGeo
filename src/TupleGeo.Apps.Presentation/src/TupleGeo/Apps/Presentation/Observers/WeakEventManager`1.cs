
#region Header
// Title Name       : WeakEventManager<TEventArgs>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : The WeakEventManager provides a way to take advantage of the weak event patttern.
// Created by       : 31/05/2012, 12:58, Vasilis Vlastaras.
// Updated by       : 18/05/2021, 20:18, Vasilis Vlastaras.
//                    2.0.0 - Changed the name of the class and polished it a bit.
// Version          : 2.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// The WeakEventManager provides a way to take advantage of the weak event pattern.
  /// </summary>
  /// <typeparam name="TEventArgs">The event arguments.</typeparam>
  public sealed class WeakEventManager<TEventArgs> : IWeakEventListener where TEventArgs : EventArgs {

    #region Member Variables

    private readonly EventHandler<TEventArgs> _handler;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="WeakEventManager{TEventArgs}"/> of <typeparamref name="TEventArgs"/>.
    /// </summary>
    /// <param name="handler">The handler for the event.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="handler"/> is <c>null</c>.</exception>
    public WeakEventManager(EventHandler<TEventArgs> handler) {
      _handler = handler ?? throw new ArgumentNullException("handler");
    }

    #endregion

    #region IWeakEventListener Members

    /// <summary>
    /// Receives events from the centralized event manager.
    /// </summary>
    /// <param name="managerType">The type of the WeakEventManager calling this method.</param>
    /// <param name="sender">Object that originated the event.</param>
    /// <param name="e">The event data.</param>
    /// <returns>
    /// A <c>true</c> value if the listener handled the event.
    /// </returns>
    /// <remarks>
    /// It is considered an error by the WeakEventManager handling in WPF to register a listener for an event that
    /// the listener does not handle. Regardless, the method should return a <c>false</c> value
    /// if it receives an event that it does not recognize or handle.
    /// </remarks>
    bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e) {
      
      TEventArgs args = (TEventArgs)e;
      
      _handler(sender, args);

      return true;

    }

    #endregion

  }

}
