
#region Header
// Title Name       : IListeners.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : Provides listeners for property and collection changes.
// Created by       : 25/06/2015, 00:31, Vasilis Vlastaras.
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
using System.Threading.Tasks;
using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// Provides listeners for property and collection changes..
  /// </summary>
  public interface IListeners<T> {

    #region Public Methods

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">A model implementing</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="modelProperty">The property of the <typeparamref name="TAnyModel"/>.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>A T object.</returns>
    T AddPropertyChangedListener<TEntity>(INotifyPropertyChanged source, Expression<Func<TEntity, object>> prop) where TEntity : IModel;

    /// <summary>
    /// Adds a listener to an <see cref="ObservableObject{TEntity}">ObservableObject</see> of <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TAnyModel">The entity used.</typeparam>
    /// <param name="observableObject">The observable object.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    T AddPropertyChangedListener<TEntity>(ObservableObject<TEntity> observableObject) where TAnyModel : IModel;

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the command.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    IViewModel AddCollectionChangedListener(INotifyCollectionChanged source);

    /// <summary>
    /// Adds a listener to an ObservableCollection of <typeparamref name="TAnyModel"/>.
    /// </summary>
    /// <typeparam name="TAnyModel">The model used.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>An IViewModel.</returns>
    IViewModel AddCollectionChangedListener<TAnyModel>(ObservableCollection<TAnyModel> observableCollection) where TAnyModel : IModel;

    #endregion

  }

}
