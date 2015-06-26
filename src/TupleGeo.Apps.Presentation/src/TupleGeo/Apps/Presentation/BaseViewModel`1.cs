
#region Header
// Title Name       : BaseViewModel<TModel>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : All Views inherit from this class.
// Created by       : 17/01/2012, 18:17, Vasilis Vlastaras.
// Updated by       : 26/06/2015, 17:16, Vasilis Vlastaras.
//                    1.1.0 - BaseViewModel inherits from IViewModel.
// Version          : 1.1.0
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
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General.ComponentModel;
using TupleGeo.General.Linq.Expressions;

#endregion

namespace TupleGeo.Apps.Presentation {

  /// <summary>
  /// All Views inherit from this class.
  /// </summary>
  /// <typeparam name="TModel">The model which is associated with this view.</typeparam>
  public abstract class BaseViewModel<TModel> : ObservableObject<BaseViewModel<TModel>>, IViewModel where TModel : IModel {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseViewModel{TModel}"/> class.
    /// </summary>
    /// <param name="model">The model.</param>
    protected BaseViewModel(TModel model) {
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
          OnPropertyChanged(vm => vm.Model);
        }
      }
    }

    #endregion

    #region IViewModel Members

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    public virtual string Name {
      get {
        return string.Empty;
      }
    }

    /// <summary>
    /// Gets the title of the view model.
    /// </summary>
    public virtual string Title {
      get {
        return string.Empty;
      }
    }

    #endregion

  }

}
