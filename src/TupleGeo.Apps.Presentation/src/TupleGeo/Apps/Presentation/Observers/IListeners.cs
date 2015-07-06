
#region Header
// Title Name       : IListeners.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : Provides listeners for property and collection changes.
// Created by       : 02/07/2015, 18:19, Vasilis Vlastaras.
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
  /// Provides listeners for property and collection changes.
  /// </summary>
  public interface IListeners<T> where T : IListeners<T> {

    #region Public Methods

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">A model entity whose properties will be observed.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="prop">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>Returns itself so as to allow chaining multiple listeners.</returns>
    T AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> prop) where TModel : IModel;

    /// <summary>
    /// Adds a listener to an <see cref="ObservableObject{TModel}">ObservableObject</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">A model entity whose properties will be observed.</typeparam>
    /// <param name="observableObject">The observable object.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>Returns itself so as to allow chaining multiple listeners.</returns>
    T AddPropertyChangedListener<TModel>(ObservableObject<TModel> observableObject) where TModel : IModel;

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source of the command.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>Returns itself so as to allow chaining multiple listeners.</returns>
    T AddCollectionChangedListener(INotifyCollectionChanged source);

    /// <summary>
    /// Adds a listener to an <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">A model entity whose properties will be observed.</typeparam>
    /// <param name="observableCollection">The observable collection used.</param>
    /// <remarks>The method can be used to chain multiple listeners.</remarks>
    /// <returns>Returns itself so as to allow chaining multiple listeners.</returns>
    T AddCollectionChangedListener<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel;

    #endregion

  }

}
