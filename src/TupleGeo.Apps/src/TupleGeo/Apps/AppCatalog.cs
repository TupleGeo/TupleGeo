
#region Header
// Title Name       : AppCatalog
// Member of        : TupleGeo.Apps.dll
// Description      : The application catalog provides a registry of models, views and viewmodels.
// Created by       : 27/07/2015, 19:32, Vasilis Vlastaras.
// Updated by       : 19/05/2021, 17:26, Vasilis Vlastaras.
//                    1.1.0 - Moved the class from assembly TupleGeo.Apps.Presentation.dll
//                  : 26/05/2021, 00:54, Vasilis Vlastaras.
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
using TupleGeo.General;

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

      // Check if a singletons triplet exist.
      if (_viewToSingletonsTripletDictionary.ContainsKey(viewType)) {
        
        // Check if the singletons triplet has an instance of view model.
        if (_viewToSingletonsTripletDictionary[viewType].ViewModel != null) {
          return _viewToSingletonsTripletDictionary[viewType].ViewModel;
        }

      }

      // No instances triplet has been found, so proceed to create one.
      return CreateSingletonViewModel(viewType);

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

      IViewModel viewModel = GetSingletonViewModel(viewType);

      // Update the View values in the instances triplet.
      if (_viewToSingletonsTripletDictionary[viewType].View == null) {
        _viewToSingletonsTripletDictionary[viewType].View = (IView)view;
      }
      if (_viewModelToSingletonsTripletDictionary[viewModel.GetType()].View == null) {
        _viewModelToSingletonsTripletDictionary[viewModel.GetType()].View = (IView)view;
      }

      return viewModel;

    }

    /// <summary>
    /// Gets the singleton <see cref="IView"/>.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>The <see cref="IView"/> singleton instance.</returns>
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

        // Check if an instance of a view exists in the triplet of singletons.
        if (_viewToSingletonsTripletDictionary[viewType].View != null) {
          return _viewToSingletonsTripletDictionary[viewType].View;
        }
        
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

    #region Private Methods

    /// <summary>
    /// Creates a view model that is used in a singleton model, view, view model triplet.
    /// </summary>
    /// <param name="viewType">The <see cref="Type"/> of the view.</param>
    /// <returns>The <see cref="IViewModel"/> associated with the view.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "AssociatedViewModelAttribute")]
    private IViewModel CreateSingletonViewModel(Type viewType) {

      // Get the type of the view model associated with the view.

      AssociatedViewModelAttribute viewModelAttribute =
        (AssociatedViewModelAttribute)viewType.GetCustomAttribute(typeof(AssociatedViewModelAttribute));

      if (viewModelAttribute == null) {
        throw new GeneralException("No AssociatedViewModelAttribute was found in the specified view.");
      }

      Type viewModelType = viewModelAttribute.ViewModelType;

      //
      // Check if viewModelType is valid.
      //

      if (viewModelType == null) {
        throw new ArgumentException("The type of the view Model associated with the view could not be null.", "viewType");
      }

      //
      // Get the type of the model associated with the view model.
      //

      if (viewModelType.BaseType == null) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", viewModelType.Name),
          "viewType"
        );
      }

      if (!(viewModelType.BaseType.Namespace == "TupleGeo.Apps" && viewModelType.BaseType.Name == "ViewModel`1")) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", viewModelType.Name),
          "viewType"
        );
      }

      Type[] genericTypeArguments = viewModelType.BaseType.GenericTypeArguments;

      if (genericTypeArguments.Length != 1) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "The base type of {0} has an invalid number of generic arguments; must be only one.", viewModelType.Name),
          "viewType"
        );
      }

      Type modelType = genericTypeArguments[0];

      if (modelType.BaseType == null) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", modelType.Name),
          "viewType"
        );
      }

      if (!(modelType.BaseType.Namespace == "TupleGeo.Apps" && modelType.BaseType.Name == "Model")) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", modelType.Name),
          "viewType"
        );
      }

      if (modelType.BaseType.GetInterface("IModel") != typeof(IModel)) {
        throw new ArgumentException(
          string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name),
          "viewType"
        );
      }

      // Create the types triplet if one does not exist.
      if (!_viewToTypesTripletDictionary.ContainsKey(viewType)) {
        ModelViewViewModelTypesRecord mvvmTypesRecord = new ModelViewViewModelTypesRecord(viewType, viewModelType);
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
      ModelViewViewModelInstancesRecord mvvmInstancesRecord = new ModelViewViewModelInstancesRecord(model, null, viewModel);
      _viewToSingletonsTripletDictionary.Add(viewType, mvvmInstancesRecord);
      _viewModelToSingletonsTripletDictionary.Add(viewModelType, mvvmInstancesRecord);

      return viewModel;

    }

    #endregion

    #region Private Classes

    /// <summary>
    /// The class used to register all the type triplets of Model, View and ViewModel.
    /// </summary>
    private class ModelViewViewModelTypesRecord {

      #region Constructors - Destructors

      /// <summary>
      /// Creates a <see cref="ModelViewViewModelTypesRecord"/>.
      /// </summary>
      /// <param name="viewType">The type of the view.</param>
      /// <param name="viewModelType">The type of the view model.</param>
      public ModelViewViewModelTypesRecord(Type viewType = null, Type viewModelType = null) {

        Type modelType = null;

        if (viewType != null) {
          if (viewType.GetInterface("IView") != typeof(IView)) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "Invalid type. The {0} must implement the TupleGeo.Apps.IView interface.", viewType.Name),
              "viewType"
            );
          }
        }

        if (viewModelType != null) {
          if (viewModelType.BaseType == null) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "Invalid type. The {0} has no base type.", viewModelType.Name),
              "viewModelType"
            );
          }

          if (!(viewModelType.BaseType.Namespace == "TupleGeo.Apps" && viewModelType.BaseType.Name == "ViewModel`1")) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", viewModelType.Name),
              "viewModelType"
            );
          }

          Type[] genericTypeArguments = viewModelType.BaseType.GenericTypeArguments;

          if (genericTypeArguments.Length != 1) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "The base type of {0} has an invalid number of generic arguments; must be only one.", viewModelType.Name),
              "viewModelType"
            );
          }

          modelType = genericTypeArguments[0];

          if (modelType.BaseType == null) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "The {0} has no base type.", modelType.Name),
              "viewModelType"
            );
          }

          if (!(modelType.BaseType.Namespace == "TupleGeo.Apps" && modelType.BaseType.Name == "Model")) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "The {0} has an invalid base type.", modelType.Name),
              "viewModelType"
            );
          }

          if (modelType.BaseType.GetInterface("IModel") != typeof(IModel)) {
            throw new ArgumentException(
              string.Format(CultureInfo.InvariantCulture, "Invalid type. {0} must implement the TupleGeo.Apps.IModel interface", modelType.Name),
              "viewModelType"
            );
          }
          
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
        get; set;
      }

      /// <summary>
      /// Gets the type of the view.
      /// </summary>
      public Type ViewType {
        get; set;
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
    /// The class used to register all the instance triplets of Model, View and ViewModel.
    /// </summary>
    private class ModelViewViewModelInstancesRecord {

      #region Constructors - Destructors

      /// <summary>
      /// Creates a <see cref="ModelViewViewModelInstancesRecord"/>.
      /// </summary>
      /// <param name="model">The <see cref="IModel"/>.</param>
      /// <param name="view">The <see cref="IView"/>.</param>
      /// <param name="viewModel">The <see cref="IViewModel"/>.</param>
      public ModelViewViewModelInstancesRecord(IModel model = null, IView view = null, IViewModel viewModel = null) {

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
        get; set;
      }

      /// <summary>
      /// Gets the view.
      /// </summary>
      public IView View {
        get; set;
      }

      /// <summary>
      /// Gets the view model.
      /// </summary>
      public IViewModel ViewModel {
        get; set;
      }

      #endregion

    }

    #endregion

  }

}
