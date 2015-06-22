
#region Header
// Title Name       : IFiltering.
// Member of        : TupleGeo.General.Windows.Presentation.dll
// Description      : The contract for those objects need to provide CollectionViewSource filtering capabilities.
// Created by       : 05/06/2012, 19:24, Vasilis Vlastaras.
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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

#endregion

namespace TupleGeo.General.Windows.Data {

  /// <summary>
  /// The contract for those objects need to provide
  /// <see cref="System.Windows.Data.CollectionViewSource">CollectionViewSource</see> filtering capabilities.
  /// </summary>
  public interface IFiltering {

    #region Public Properties

    /// <summary>
    /// Gets the filters used for <see cref="System.Windows.Data.CollectionViewSource">CollectionViewSource</see> filtering.
    /// </summary>
    ObservableCollection<Filter> Filters {
      get;
    }

    /// <summary>
    /// Gets / Sets the currently selected filter.
    /// </summary>
    Filter CurrentFilter {
      get;
      set;
    }
    
    #endregion

  }

}
