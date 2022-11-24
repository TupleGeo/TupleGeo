
#region Header
// Title Name       : ViewModel<TModel>.
// Member of        : TupleGeo.Apps.dll
// Description      : The abstract ViewModel class defines the default behaviour of the view model.
// Created by       : 17/01/2012, 18:17, Vasilis Vlastaras.
// Updated by       : 26/06/2015, 17:16, Vasilis Vlastaras.
//                    1.1.0 - ViewModel inherits from IViewModel.
//                    19/05/2021, 17:28, Vasilis Vlastaras.
//                    2.0.0 - Changed the name of the class from BaseViewModel<TModel> to ViewModel<TModel>.
//                            Its inheritance was assigned to the newly created ObservableObject.
//                            Changed the way that the event PropertyChanged is raised.
//                            Moved the class from assembly TupleGeo.Apps.Presentation.dll
// Version          : 2.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012 - 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.Apps {

  /// <summary>
  /// The abstract ViewModel class defines the default behaviour of the view model.
  /// </summary>
  /// <typeparam name="TModel">The model which is associated with this view.</typeparam>
  public abstract class ViewModel<TModel> : ObservableObject, IViewModel where TModel : IModel {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewModel{TModel}"/> of <typeparamref name="TModel"/>.
    /// </summary>
    /// <param name="model">The model.</param>
    protected ViewModel(TModel model) {
      this._model = model;
    }

    #endregion
    
    #region Public Properties

    private TModel _model;

    /// <summary>
    /// Gets / Sets the associated model.
    /// </summary>
    public TModel Model {
      get {
        return _model;
      }
      set {
        if ((IModel)_model != (IModel)value) {
          _model = value;
          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region IViewModel Members

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    public abstract string Name {
      get;
    }

    /// <summary>
    /// Gets the title of the view model.
    /// </summary>
    public abstract string Title {
      get;
    }

    #endregion

  }

}
