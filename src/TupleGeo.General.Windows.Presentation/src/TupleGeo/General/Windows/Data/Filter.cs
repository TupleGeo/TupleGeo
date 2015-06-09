
#region Header
// Title Name       : Filter.
// Member of        : TupleGeo.General.Windows.Presentation.dll
// Description      : The object used to define a filter capable to be used in a CollectionViewsource for filtering rows.
// Created by       : 05/06/2012, 19:29, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2012.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.General.Windows.Data {

  /// <summary>
  /// The object used to define a filter capable to be used in a CollectionViewsource for filtering rows.
  /// </summary>
  public sealed class Filter : ObservableObject<Filter> {

    #region Public Properties

    private int _id;

    /// <summary>
    /// Gets / Sets the id of the filter.
    /// </summary>
    public int Id {
      get {
        return _id;
      }
      set {
        if (_id != value) {
          _id = value;
          this.OnPropertyChanged(m => m.Id);
        }
      }
    }

    private string _name;

    /// <summary>
    /// Gets / Sets the filter name.
    /// </summary>
    public string Name {
      get {
        return _name;
      }
      set {
        if (_name != value) {
          _name = value;
          this.OnPropertyChanged(m => m.Name);
        }
      }
    }

    private string _description;

    /// <summary>
    /// Gets / Sets the filter description.
    /// </summary>
    public string Description {
      get {
        return _description;
      }
      set {
        if (_description != value) {
          _description = value;
          this.OnPropertyChanged(m => m.Description);
        }
      }
    }

    private Predicate<object> _callback;

    /// <summary>
    /// Gets / Sets the callback function used to perform the filtering action.
    /// </summary>
    public Predicate<object> Callback {
      get {
        return _callback;
      }
      set {
        if (_callback != value) {
          _callback = value;
          this.OnPropertyChanged(m => m.Callback);
        }
      }
    }

    #endregion

  }

}
