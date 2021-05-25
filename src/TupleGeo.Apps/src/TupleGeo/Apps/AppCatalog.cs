
#region Header
// Title Name       : AppCatalog
// Member of        : TupleGeo.Apps.dll
// Description      : The application catalog provides a registry of models, views and viewmodels.
// Created by       : 27/07/2015, 19:32, Vasilis Vlastaras.
// Updated by       : 19/05/2021, 17:26, Vasilis Vlastaras.
//                    1.1.0 - Moved the class from assembly TupleGeo.Apps.Presentation.dll
//                  : 25/05/2021, 02:08, Vasilis Vlastaras.
//                    2.0.0 - Extensive rewrite of the AppCatalog class.
//                            Only Singleton instances are supported in this version.
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
//using System.Linq;
using System.Reflection;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The application catalog provides a registry of models, views and viewmodels.
  /// </summary>
  public sealed class AppCatalog {

    #region Member Variables

    private readonly Dictionary<Type, ModelViewViewModelTypesRecord> _viewToTypesTripletDictionary = new Dictionary<Type, ModelViewViewModelTypesRecord>();
    private readonly Dictionary<Type, ModelViewViewModelTypesRecord> _viewModelToTypesTripletDictionary = new Dictionary<Type, ModelViewViewModelTypesRecord>();
    private readonly Dictionary<Type, ModelViewViewModelInstancesRecord> _viewToSingletonsTripletDictionary = new Dictionary<Type, ModelViewViewModelInstancesRecord>();
    private readonly Dictionary<Type, ModelViewViewModelInstancesRecord> _viewModelToSingletonsTripletDictionary = new Dictionary<Type, ModelViewViewModelInstancesRecord>();

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the singleton <see cref="IViewModel"/> associated with the specified view.
    /// </summary>
    /// <param name="viewType">The type of the view whose view model would be returned.</param>
    /// <returns>The <see cref="IViewModel"/> associated with the specified view.</returns>
    public IViewModel GetSingletonViewModel(Type viewType) {

      if (viewType == null) {
        throw new ArgumentNullException("viewType", "The argument 'viewType' could not be null.");
      }

      if (viewType.GetInterface("IView") != typeof(IView)) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface", viewType.Name)
        );
      }

      if (!_viewModelToSingletonsTripletDictionary.ContainsKey(viewType)) {
        throw new KeyNotFoundException("The view was not found");
      }

      return _viewModelToSingletonsTripletDictionary[viewType].ViewModel;

    }

    /// <summary>
    /// Gets the singleton <see cref="IViewModel"/> associated with the specified view.
    /// </summary>
    /// <typeparam name="TView">The view type.</typeparam>
    /// <param name="view">The view whose view model would be returned.</param>
    /// <remarks>
    /// The method either returns an <see cref="IViewModel"/> existing in a triplet of singletons,
    /// or it proceeds to create a new one and to populate the relevant type and singleton triplet dictionaries.
    /// </remarks>
    /// <returns>The <see cref="IViewModel"/> associated with the specified view.</returns>
    public IViewModel GetSingletonViewModel<TView>(TView view) where TView: IView {

      if (view == null) {
        throw new ArgumentNullException("view", "The argument 'view' could not be null.");
      }

      Type viewType = view.GetType();

      // Get the type of the view model associated with the view.

      AssociatedViewModelAttribute viewModelAttribute =
        (AssociatedViewModelAttribute)viewType.GetCustomAttribute(typeof(AssociatedViewModelAttribute));

      if (viewModelAttribute == null) {
        throw new NullReferenceException("No AssociatedViewModelAttribute was found in the specified view.");
      }

      Type viewModelType = viewModelAttribute.ViewModelType;

      //
      // Check if viewModelType is valid.
      //

      if (viewModelType == null) {
        throw new ArgumentNullException("viewModelType");
      }

      //if (viewModelType.GetInterface("IViewModel") == typeof(IViewModel)) {
      //  throw new ArgumentException(
      //    string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IViewModel interface", viewModelType.Name)
      //  );
      //}

      // Check if an instances triplet exists and return the view model instance.
      if (_viewToSingletonsTripletDictionary.ContainsKey(viewType)) {
        return _viewToSingletonsTripletDictionary[viewType].ViewModel;
      }

      //
      // No instances triplet has been found, so proceed to create one.
      // Get the type of the model associated with the view model.
      //

      if (viewModelType.BaseType == null) {
        throw new NullReferenceException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", viewModelType.Name)
        );
      }

      if (!(viewModelType.BaseType.Namespace == "TupleGeo.Apps" && viewModelType.BaseType.Name == "ViewModel`1")) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", viewModelType.Name)
        );
      }

      Type[] genericTypeArguments = viewModelType.BaseType.GenericTypeArguments;

      if (genericTypeArguments.Length != 1) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "The base type of {0} has an invalid number of generic arguments; must be only one.", viewModelType.Name)
        );
      }

      Type modelType = genericTypeArguments[0];

      if (modelType.BaseType == null) {
        throw new NullReferenceException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", modelType.Name)
        );
      }

      if (!(modelType.BaseType.Namespace == "TupleGeo.Apps" && modelType.BaseType.Name == "Model")) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", modelType.Name)
        );
      }

      if (modelType.BaseType.GetInterface("IModel") != typeof(IModel)) {
        throw new TypeLoadException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name)
        );
      }

      // Create the types triplet if one does not exist.
      if (!_viewToTypesTripletDictionary.ContainsKey(viewType)) {
        ModelViewViewModelTypesRecord mvvmTypesRecord = new ModelViewViewModelTypesRecord(modelType, viewType, viewModelType);
        _viewToTypesTripletDictionary.Add(viewType, mvvmTypesRecord);
        _viewModelToTypesTripletDictionary.Add(viewModelType, mvvmTypesRecord);
      }

      // Create the model instance.
      IModel model = (IModel)(Activator.CreateInstance(modelType));

      // Create the constructor parameters for the view model.
      object[] constructorParams = new object[1] { model };

      // Create the view model instance.
      IViewModel viewModel = (IViewModel)(Activator.CreateInstance(viewModelType, constructorParams));

      // Create the instances triplet.
      ModelViewViewModelInstancesRecord mvvmInstancesRecord = new ModelViewViewModelInstancesRecord(model, view, viewModel);
      _viewToSingletonsTripletDictionary.Add(viewType, mvvmInstancesRecord);
      _viewModelToSingletonsTripletDictionary.Add(viewModelType, mvvmInstancesRecord);

      return viewModel;

    }

    /// <summary>
    /// Gets 
    /// </summary>
    /// <param name="viewType"></param>
    /// <returns></returns>
    public IView GetSingletonView(Type viewType) {

      if (viewType == null) {
        throw new ArgumentNullException("viewType", "The argument 'viewType' could not be null.");
      }

      // Check if the specified viewType implements the IView interface
      if (viewType.GetInterface("IView") == typeof(IView)) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface", viewType.Name)
        );
      }

      // Check if an instance of a triplet of singletons is present.
      if (_viewToSingletonsTripletDictionary.ContainsKey(viewType)) {
        return _viewToSingletonsTripletDictionary[viewType].View;
      }

      // Create a view singleton instance.
      IView view = (IView)(Activator.CreateInstance(viewType));

      // Make sure a view model is created as well, to allow for the types and instances triplets
      // to be created and the relevant dictionaries to be populated.
      GetSingletonViewModel(view);

      return view;

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

    ///// <summary>
    ///// Creates an instance of <see cref="IViewModel"/>.
    ///// </summary>
    ///// <param name="viewType">The <see cref="Type"/> of the view.</param>
    ///// <returns>An <see cref="IViewModel"/> instance.</returns>
    //public IViewModel InstantiateViewModel(Type viewType) {

    //  // Check if a valid viewType has been passed.

    //  if (viewType == null) {
    //    throw new ArgumentNullException("viewType");
    //  }

    //  if (viewType.GetInterface("IView") == typeof(IView)) {
    //    throw new ArgumentException(
    //      string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface", viewType.Name)
    //    );
    //  }

    //  // Get the type of the view model associated with the view.

    //  AssociatedViewModelAttribute viewModelAttribute =
    //    (AssociatedViewModelAttribute)viewType.GetCustomAttribute(typeof(AssociatedViewModelAttribute));

    //  Type viewModelType = viewModelAttribute.ViewModelType;

    //}

    #endregion

    /// <summary>
    /// The class used to register all the type triplets of Model, View and ViewModel.
    /// </summary>
    private class ModelViewViewModelTypesRecord {

      #region Constructors - Destructors

      /// <summary>
      /// Creates a <see cref="ModelViewViewModelTypesRecord"/>.
      /// </summary>
      /// <param name="modelType">The type of the model.</param>
      /// <param name="viewType">The type of the view.</param>
      /// <param name="viewModelType">The type of the view model.</param>
      public ModelViewViewModelTypesRecord(Type modelType, Type viewType, Type viewModelType) {

        if (modelType == null) {
          throw new ArgumentNullException("modelType", "The 'modelType' argument could not be null.");
        }
        if (viewType == null) {
          throw new ArgumentNullException("viewType", "The 'viewType' argument could not be null.");
        }
        if (viewModelType == null) {
          throw new ArgumentNullException("viewModelType", "The 'viewModelType' argument could not be null.");
        }

        if (modelType.BaseType == null) {
          throw new NullReferenceException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", modelType.Name)
          );
        }

        if (!(modelType.BaseType.Namespace == "TupleGeo.Apps" && modelType.BaseType.Name == "Model")) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", modelType.Name)
          );
        }

        if (modelType.BaseType.GetInterface("IModel") != typeof(IModel)) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name)
          );
        }

        if (viewType.GetInterface("IView") != typeof(IView)) {
          throw new ArgumentException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IView interface.", viewType.Name)
          );
        }

        if (viewModelType.BaseType == null) {
          throw new NullReferenceException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", viewModelType.Name)
          );
        }

        if (!(viewModelType.BaseType.Namespace == "TupleGeo.Apps" && viewModelType.BaseType.Name == "ViewModel`1")) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", viewModelType.Name)
          );
        }

        Type[] genericTypeArguments = viewModelType.BaseType.GenericTypeArguments;

        if (genericTypeArguments.Length != 1) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "The base type of {0} has an invalid number of generic arguments; must be only one.", viewModelType.Name)
          );
        }

        Type modelType2 = genericTypeArguments[0];

        if (modelType2.BaseType == null) {
          throw new NullReferenceException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", modelType2.Name)
          );
        }

        if (!(modelType2.BaseType.Namespace == "TupleGeo.Apps" && modelType2.BaseType.Name == "Model")) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", modelType2.Name)
          );
        }

        if (modelType2.BaseType.GetInterface("IModel") != typeof(IModel)) {
          throw new TypeLoadException(
            string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType2.Name)
          );
        }

        this.ModelType = modelType;
        this.ViewType = viewType;
        this.ViewModelType = viewModelType;

      }

      #endregion

      #region Public Properties

      /// <summary>
      /// Gets/Sets the type of the model.
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
        get; set;
      }

      #endregion

    }

    /// <summary>
    /// The class used to register all the isntance triplets of Model, View and ViewModel.
    /// </summary>
    private class ModelViewViewModelInstancesRecord {

      #region Constructors - Destructors

      /// <summary>
      /// Creates a <see cref="ModelViewViewModelInstancesRecord"/>.
      /// </summary>
      /// <param name="model">The <see cref="IModel"/></param>
      /// <param name="view"></param>
      /// <param name="viewModel"></param>
      public ModelViewViewModelInstancesRecord(IModel model, IView view, IViewModel viewModel) {

        if (model == null) {
          throw new ArgumentNullException("modelType", "The 'model' argument could not be null.");
        }
        if (view == null) {
          throw new ArgumentNullException("viewType", "The 'view' argument could not be null.");
        }
        if (viewModel == null) {
          throw new ArgumentNullException("viewModelType", "The 'viewModel' argument could not be null.");
        }

        this.Model = model;
        this.View = view;
        this.ViewModel = viewModel;

      }

      #endregion

      #region Public Properties

      /// <summary>
      /// Gets/Sets the model.
      /// </summary>
      public IModel Model {
        get; private set;
      }

      /// <summary>
      /// Gets the view.
      /// </summary>
      public IView View {
        get; private set;
      }

      /// <summary>
      /// Gets the view model.
      /// </summary>
      public IViewModel ViewModel {
        get; private set;
      }

      #endregion

    }

  }

}
