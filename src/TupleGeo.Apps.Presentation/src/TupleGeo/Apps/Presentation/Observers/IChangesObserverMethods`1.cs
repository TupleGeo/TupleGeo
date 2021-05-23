
#region Header
// Title Name       : IChangesObserverMethods<T>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : Provides the contract to observe object properties and collections for changes.
// Created by       : 22/05/2021, 13:37, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation.Observers {

  /// <summary>
  /// Provides the contract to observe object properties and collections for changes.
  /// </summary>
  public interface IChangesObserverMethods<T> {

    #region Public Methods

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    T AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel;

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    T RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel;

    /// <summary>
    /// Adds a weak listener to the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddPropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel;

    /// <summary>
    /// Removes a weak listener from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel;

    /// <summary>
    /// Adds a weak listener to all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddPropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel;

    /// <summary>
    /// Removes a weak listener from the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemovePropertyChangedListener<TModel>(INotifyPropertyChanged source) where TModel : IModel;

    /// <summary>
    /// Adds an event handler to the property of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    T AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel;

    /// <summary>
    /// Removes an event handler from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="property">The property of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    T RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, Expression<Func<TModel, object>> property) where TModel : IModel;

    /// <summary>
    /// Adds an event handler to the property of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel;

    /// <summary>
    /// Removes an event handler from the property of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The entity used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <param name="propertyName">The property name of the <typeparamref name="TModel"/>.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source, string propertyName) where TModel : IModel;

    /// <summary>
    /// Adds an event handler to all the properties of an object that implement the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddPropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel;

    /// <summary>
    /// Removes an event handler from all the properties of an object that implements the <see cref="INotifyPropertyChanged"/> interface.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="source">The source of the property that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemovePropertyChangedHandler<TModel>(INotifyPropertyChanged source) where TModel : IModel;

    /// <summary>
    /// Adds a weak listener to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source collection that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddCollectionChangedListener(INotifyCollectionChanged source);

    /// <summary>
    /// Removes a weak listener from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source collection that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/></returns>
    T RemoveCollectionChangedListener(INotifyCollectionChanged source);

    /// <summary>
    /// Adds an event handler to a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source collection that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddCollectionChangedHandler(INotifyCollectionChanged source);

    /// <summary>
    /// Removes an event handler from a collection implementing the <see cref="INotifyCollectionChanged"/>.
    /// </summary>
    /// <param name="source">The source collection that has been changed.</param>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemoveCollectionChangedHandler(INotifyCollectionChanged source);

    /// <summary>
    /// Adds a listener to an <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="observableCollection">
    /// The <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/> used.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="observableCollection"/> is <c>null</c>.
    /// </exception>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T AddObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel;

    /// <summary>
    /// Removes a listener from an <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="IModel"/> used.</typeparam>
    /// <param name="observableCollection">
    /// The <see cref="ObservableCollection{TModel}">ObservableCollection</see> of <typeparamref name="TModel"/> used.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="observableCollection"/> is <c>null</c>.
    /// </exception>
    /// <remarks>The method can be used to chain together multiple calls of <typeparamref name="T"/> methods.</remarks>
    /// <returns>A <typeparamref name="T"/>.</returns>
    T RemoveObservableCollectionChangedHandler<TModel>(ObservableCollection<TModel> observableCollection) where TModel : IModel;

    #endregion

  }

}
