
#region Header
// Title Name       : BaseViewModel<T>.
// Member of        : TupleGeo.Apps.Presentation.dll
// Description      : All Views inherit from this class..
// Created by       : 17/01/2012, 18:17, Vasilis Vlastaras.
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
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.Apps.Presentation {

  /// <summary>
  /// All Views inherit from this class.
  /// </summary>
  /// <typeparam name="T">The model which is associated with this view.</typeparam>
  public abstract class BaseViewModel<T> : ObservableObject<BaseViewModel<T>>, IViewModel where T : class {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseViewModel{T}"/> class.
    /// </summary>
    /// <param name="model">The model.</param>
    protected BaseViewModel(T model) {
      this._model = model;
    }

    #endregion

    #region Public Properties

    
    private T _model;

    /// <summary>
    /// Gets / Sets the associated model.
    /// </summary>
    public T Model {
      get {
        return _model;
      }
      set {
        if (_model == value) {
          return;
        }
        _model = value;
        OnPropertyChanged(vm => vm.Model);
      }
    }

    #endregion

    #region IViewModel Members

    public virtual string Name {
      get {
        throw new NotImplementedException();
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
    
    public virtual void SubscribeToEvents(Dictionary<string, object> triggeringControlsDictionary) {
      throw new NotImplementedException();
    }

    public virtual void UnsubscribeFromEvents(Dictionary<string, object> triggeringControlsDictionary) {
      throw new NotImplementedException();
    }

    public virtual void SetCollectionViewSources(Dictionary<string, System.Windows.Data.CollectionViewSource> collectionViewSourcesDictionary) {
      throw new NotImplementedException();
    }

    #endregion
  }

}
