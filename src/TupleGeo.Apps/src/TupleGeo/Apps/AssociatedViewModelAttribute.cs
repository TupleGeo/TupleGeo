
#region Header
// Title Name       : AssociatedViewModelAttribute.
// Member of        : TupleGeo.General.dll
// Description      : The AssociatedViewModel Attribute is applied on a
//                    View class to mark the ViewModel controling the View.
// Created by       : 24/05/2021, 18:47, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The AssociatedViewModel Attribute is applied on a View class to mark the ViewModel controling the View.
  /// </summary>
  /// <exception cref="ArgumentNullException">
  /// The exception is thrown if the attribute is not used on a View implementing the <see cref="IView"/> interface.
  /// </exception>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public sealed class AssociatedViewModelAttribute : Attribute {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="AssociatedViewModelAttribute"/>.
    /// </summary>
    public AssociatedViewModelAttribute(Type viewModelType, Type viewType) {

      if (viewModelType == null) {
        throw new ArgumentNullException("viewModelType", "viewModelType could not be null.");
      }

      if (viewType == null) {
        throw new ArgumentNullException("viewType", "viewType could not be null.");
      }

      if (viewType.GetInterface("IView") == null) {
        throw new ArgumentException("The attribute has not been used on a view class", "viewType");
      }

      _viewModelType = viewModelType;
      _viewType = viewType;

    }

    #endregion

    #region Public Properties

    private readonly Type _viewModelType;

    /// <summary>
    /// Gets the <see cref="Type"/> of the ViewModel.
    /// </summary>
    public Type ViewModelType {
      get {
        return _viewModelType;
      }
    }

    private readonly Type _viewType;

    /// <summary>
    /// Gets the <see cref="Type"/> of the View.
    /// </summary>
    public Type ViewType {
      get {
        return _viewType;
      }
    }

    private string _name;

    /// <summary>
    /// Gets / Sets the name of the ViewModel.
    /// </summary>
    public string Name {
      get {
        return _name;
      }
      set {
        _name = value;
      }
    }

    private string _title;

    /// <summary>
    /// Gets / Sets the title of the ViewModel.
    /// </summary>
    public string Title {
      get {
        return _title;
      }
      set {
        _title = value;
      }
    }

    #endregion

  }

}
