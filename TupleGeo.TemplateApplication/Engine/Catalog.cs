
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;
using TupleGeo.TemplateApplication.Models;
using TupleGeo.TemplateApplication.ViewModels;
using TupleGeo.TemplateApplication.Views;

#endregion

namespace TupleGeo.TemplateApplication.Engine {

  /// <summary>
  /// The Catalog of the application. It stores models, views and viewmodels.
  /// </summary>
  public static class Catalog {

    #region Member Variables

    private static Dictionary<Type, Type> _mappedViewModels; // view type, view model type.
    private static Dictionary<Type, IViewModel> _viewModelInstances; // view type, IViewModel instance.
    private static Dictionary<Type, Type> _mappedModels; // view model type, model type.
    private static Dictionary<Type, IView> _singletonViewInstances; // view type, IView instance.

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the Catalog.
    /// </summary>
    static Catalog() {
      RegisterViewModels();
      RegisterModels();

      _singletonViewInstances = new Dictionary<Type, IView>();
      _viewModelInstances = new Dictionary<Type, IViewModel>();
    }

    #endregion

    #region Public Methods

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

    #region Private Procedures

    /// <summary>
    /// Registers the view models.
    /// </summary>
    /// <remarks>
    /// ViewModels are registered using a dictionary having the types of views as keys.
    /// </remarks>
    private static void RegisterViewModels() {
      _mappedViewModels = new Dictionary<Type, Type>();

      // Key: Views                                          Value: ViewModels
      // ----------------------------------------------------------------------------------------------------
      // SampleView                                          SampleViewModel.
      _mappedViewModels.Add(typeof(SampleView),              typeof(SampleViewModel));
      // Sample1View                                         Sample1ViewModel.
      //_mappedViewModels.Add(typeof(Sample1View),           typeof(Sample1ViewModel));
      // Sample2View                                         Sample2ViewModel.
      //_mappedViewModels.Add(typeof(Sample2View),           typeof(Sample2ViewModel));
      // etc ...

      // ShellView                                           ShellViewModel.
      _mappedViewModels.Add(typeof(ShellView),               typeof(ShellViewModel));
    }

    /// <summary>
    /// Registers the models.
    /// </summary>
    /// <remarks>
    /// Models are registered using a dictionary having the types of view models as keys.
    /// </remarks>
    private static void RegisterModels() {
      _mappedModels = new Dictionary<Type, Type>();

      // Key: ViewModels                                             Value: Models
      // ----------------------------------------------------------------------------------------------------
      // SampleViewModel                                             SampleModel.
      _mappedModels.Add(typeof(SampleViewModel),                     typeof(SampleModel));
      // Sample1ViewModel                                            Sample1Model.
      //_mappedModels.Add(typeof(Sample1ViewModel),                  typeof(Sample1Model));
      // Sample2ViewModel                                            Sample2Model.
      //_mappedModels.Add(typeof(Sample2ViewModel),                  typeof(Sample2Model));
      // etc ...

      // ShellViewModel                                              ShellModel.
      _mappedModels.Add(typeof(ShellViewModel),                      typeof(ShellModel));
    }

    #endregion

  }

}
