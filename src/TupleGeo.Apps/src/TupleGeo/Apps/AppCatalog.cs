
#region Header
// Title Name       : AppCatalog
// Member of        : TupleGeo.Apps.dll
// Description      : The application catalog provides a registry of models, views and viewmodels.
// Created by       : 27/07/2015, 19:32, Vasilis Vlastaras.
// Updated by       : 19/05/2021, 17:26, Vasilis Vlastaras.
//                    1.1.0 - Moved the class from assembly TupleGeo.Apps.Presentation.dll
//                  : 22/05/2021, 02:44, Vasilis Vlastaras.
//                    2.0.0 - Extensive rewrite of the AppCatalog class.
// Version          : 2.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2015 - 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The application catalog provides a registry of models, views and viewmodels.
  /// </summary>
  public sealed class AppCatalog {

    #region Member Variables

    private List<MovelViewBinderTypesRecord> _modelViewBinderDictionary = new List<MovelViewBinderTypesRecord>();

    private readonly Dictionary<Type, IView> _singletonViewInstances = new Dictionary<Type, IView>();
    private readonly Dictionary<Type, IViewModel> _singletonViewModelInstances = new Dictionary<Type, IViewModel>();


    //private readonly Dictionary<Type, MovelViewBinderTypesRecord> _modelViewBinderDictionary =
    //  new Dictionary<Type, MovelViewBinderTypesRecord>();

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the singleton view instance associated with the specified IView type.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>An <see cref="IView"/> instance.</returns>
    public object GetSingletonView(Type viewType) {

      if (viewType == null) {
        throw new ArgumentNullException("viewType");
      }

      if (viewType.GetInterface("IView") == null) {
        throw new ArgumentException("viewType must implement interface IView.", "viewType");
      }

      // Check if a view instance already exists.
      if (!_singletonViewInstances.ContainsKey(viewType)) {
        // Create the view instance and add it in to the relevant dictionary.
        _singletonViewInstances.Add(viewType, (IView)(Activator.CreateInstance(viewType)));
      }

      // Return the view instance.
      return _singletonViewInstances[viewType];

    }

    ///// <summary>
    ///// Gets a new view instance associated with the specified type.
    ///// </summary>
    ///// <param name="viewType">The <see cref="Type"/> of the view.</param>
    ///// <returns>An <see cref="IView"/> instance.</returns>
    ///// <remarks>This instance is not registered in the relevant dictionary.</remarks>
    //public static IView GetNewView(Type viewType) {

    //  if (viewType == null) {
    //    throw new ArgumentNullException("viewType");
    //  }

    //  if (viewType.GetInterface("IView") == null) {
    //    throw new ArgumentException("viewType must implement interface IView.", "viewType");
    //  }

    //  return (IView)(Activator.CreateInstance(viewType));

    //}

    /// <summary>
    /// Gets the singleton view model instance associated with the specified view model type.
    /// </summary>
    /// <param name="viewModelType">The <see cref="Type"/> of the view model.</param>
    /// <returns>An IViewModel instance.</returns>
    public IViewModel GetViewModel(Type viewModelType) {

      // Check if a valid viewModelType has been passed.

      if (viewModelType == null) {
        throw new ArgumentNullException("viewModelType");
      }

      if (viewModelType.GetInterface("IViewModel") == typeof(IViewModel)) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IViewModel interface", viewModelType.Name)
        );
      }

      // Get the type of the model associated with the view model.

      Type[] genericTypeArguments = viewModelType.GenericTypeArguments;

      if (genericTypeArguments.Length != 1) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid number of arguments; must be only one", viewModelType.Name)
        );
      }

      Type modelType = genericTypeArguments[0];

      if (modelType.GetInterface("IModel") == typeof(IModel)) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name)
        );
      }

      // Register the model, view, and view model.
      if (!_modelViewBinderDictionary.ContainsKey(viewType)) {
        _modelViewBinderDictionary.Add(viewType, new MovelViewBinderTypesRecord(modelType, viewType, viewModelType));
      }

      // Create the constructor parameters for the view model.
      object[] constructorParams = new object[1] { Activator.CreateInstance(modelType) };

      // Create the view model instance and return it to the caller.
      return (IViewModel)(Activator.CreateInstance(viewModelType, constructorParams));


    }




    /// <summary>
    /// Creates an instance of <see cref="IViewModel"/>.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>An <see cref="IViewModel"/> instance.</returns>
    public IViewModel InstantiateViewModel(Type viewType) {

      // Check if a valid viewType has been passed.

      if (viewType == null) {
        throw new ArgumentNullException("viewType");
      }

      if (viewType.GetInterface("IView") == typeof(IView)) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface", viewType.Name)
        );
      }

      // Get the type of the view model associated with the view.

      AssociatedViewModelAttribute viewModelAttribute =
        (AssociatedViewModelAttribute)viewType.GetCustomAttribute(typeof(AssociatedViewModelAttribute));

      Type viewModelType = viewModelAttribute.ViewModelType;

      
    }

    
    #endregion

    /// <summary>
    /// The class used to register all the type triplets of Model, View and Binder (ViewModel).
    /// </summary>
    private class MovelViewBinderTypesRecord {

      #region Constructors - Destructors

      /// <summary>
      /// Initializes the <see cref="MovelViewBinderTypesRecord"/>.
      /// </summary>
      public MovelViewBinderTypesRecord(Type modelType, Type viewType, Type viewModelType) {

        if (modelType.GetInterface("IModel") == typeof(IModel)) {
          throw new ArgumentException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name)
          );
        }
        this.ModelType = modelType;

        if (viewType.GetInterface("IView") == typeof(IView)) {
          throw new ArgumentException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface", viewType.Name)
          );
        }
        this.ViewType = viewType;

        if (viewModelType.GetInterface("IViewModel") == typeof(IView)) {
          throw new ArgumentException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IViewModel interface", viewModelType.Name)
          );
        }
        this.ViewModelType = viewModelType;

      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the type of the model.
      /// </summary>
      public Type ModelType {
        get; private set;
      }

      /// <summary>
      /// Gets the type of the view.
      /// </summary>
      public Type ViewType {
        get; private set;
      }

      /// <summary>
      /// Gets the type of the view model.
      /// </summary>
      public Type ViewModelType {
        get; private set;
      }

      #endregion

    }

  }

}
