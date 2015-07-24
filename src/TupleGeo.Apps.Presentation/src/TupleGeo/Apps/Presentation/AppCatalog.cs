
#region Header
// Title Name       : AppCatalog
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : The application catalog provides a registry of models, views and viewmodels.
// Created by       : 24/07/2015, 17:00, 
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;

#endregion

namespace TupleGeo.Apps.Presentation {

  /// <summary>
  /// The application catalog provides a registry of models, views and viewmodels.
  /// </summary>
  public sealed class AppCatalog {

    #region Member Variables

    private static Dictionary<Type, Type> _mappedViewModels = new Dictionary<Type,Type>(); // view type, view model type.
    private static Dictionary<Type, IViewModel> _viewModelInstances = new Dictionary<Type,IViewModel>(); // view type, IViewModel instance.
    private static Dictionary<Type, Type> _mappedModels = new Dictionary<Type,Type>(); // view model type, model type.
    private static Dictionary<Type, IView> _singletonViewInstances = new Dictionary<Type,IView>(); // view type, IView instance.

    #endregion

    #region Constructors - Destructors

    ///// <summary>
    ///// Initializes the <see cref="AppCatalog"/>.
    ///// </summary>
    //public AppCatalog() {

    //}

    #endregion

    #region Public Methods

    /// <summary>
    /// Registers the view models.
    /// </summary>
    /// <param name="viewType">The type of the view which is used as the key in the registry.</param>
    /// <param name="viewModelType">The type of the viewmodel which is used as the value in the registry.</param>
    /// <remarks>
    /// <para>Types of view models are registered using a dictionary having the types of views as keys.</para>
    /// <para>
    /// The view must implement the <see cref="IView"/> interface and the view model
    /// must implement the <see cref="IViewModel"/> interface.
    /// </para>
    /// </remarks>
    public static void RegisterViewModels(Type viewType, Type viewModelType) {

      if (viewType == null) {
        throw new ArgumentNullException("viewType");
      }

      if (viewModelType == null) {
        throw new ArgumentNullException("viewModelType");
      }

      if (viewType.GetInterface("IView") == null) {
        throw new ArgumentException("viewType must implement interface IView.", "viewType");
      }

      if (viewModelType.GetInterface("IViewModel") == null) {
        throw new ArgumentException("viewModelType must implement interface IViewModel.", "viewType");
      }
      
      _mappedViewModels.Add(viewType, viewModelType);

    }

    /// <summary>
    /// Registers the models.
    /// </summary>
    /// <param name="viewModelType">The type of view model which is used as the key in the registry.</param>
    /// <param name="modelType">The type of the model which is used as the value in the registry.</param>
    /// <remarks>
    /// <para>Types of models are registered using a dictionary having the types of view models as keys.</para>
    /// <para>
    /// The view model must implement the <see cref="IViewModel"/> interface and the model
    /// must implement the <see cref="IModel"/> interface.
    /// </para>
    /// </remarks>
    public static void RegisterModels(Type viewModelType, Type modelType) {

      if (viewModelType == null) {
        throw new ArgumentNullException("viewModelType");
      }

      if (modelType == null) {
        throw new ArgumentNullException("modelType");
      }

      if (viewModelType.GetInterface("IViewModel") == null) {
        throw new ArgumentException("viewModelType must implement interface IViewModel.", "viewModelType");
      }

      if (modelType.GetInterface("IModel") == null) {
        throw new ArgumentException("modelType must implement interface IModel.", "modelType");
      }
      
      _mappedModels.Add(viewModelType, modelType);

    }

    /// <summary>
    /// Gets the view singleton instance associated with the specified type.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>An <see cref="IView"/> instance.</returns>
    public static object GetSingletonView(Type viewType) {
      // Check if a view instance already exists.
      if (!_singletonViewInstances.ContainsKey(viewType)) {
        // Create the view instance and add it in to the relevant dictionary.
        _singletonViewInstances.Add(viewType, (IView)(Activator.CreateInstance(viewType)));
      }

      // Return the view instance.
      return _singletonViewInstances[viewType];
    }

    /// <summary>
    /// Gets a new view instance associated with the specified type.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>An <see cref="IView"/> instance.</returns>
    /// <remarks>This instance is not registered in the relevant dictionary.</remarks>
    public static IView GetNewView(Type viewType) {
      return (IView)(Activator.CreateInstance(viewType));
    }

    /// <summary>
    /// Gets the view model associated with the specified view type;
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>An <see cref="IViewModel"/> instance.</returns>
    public static IViewModel GetViewModel(Type viewType) {
      // Check if a view model instance already exists.
      if (!_viewModelInstances.ContainsKey(viewType)) {
        // Get the view model type from the relevant dictionary.
        Type viewModelType = _mappedViewModels[viewType];
        // Get the model type from the relevant dictionary.
        Type modelType = _mappedModels[viewModelType];

        // Create the constructor parameters for the view model.
        object[] constructorParams = new object[1] { Activator.CreateInstance(modelType) };

        // Create the view model instance and add it in to the relevant dictionary.
        _viewModelInstances.Add(viewType, (IViewModel)(Activator.CreateInstance(viewModelType, constructorParams)));
      }

      // Return the view model instance.
      return _viewModelInstances[viewType];
    }

    #endregion

  }

}
