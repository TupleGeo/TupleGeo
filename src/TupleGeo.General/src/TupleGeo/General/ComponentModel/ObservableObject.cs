
#region Header
// Title Name       : ObservableObject.
// Member of        : TupleGeo.General.dll
// Description      : An object that its property value changes can be observed by other objects.
// Created by       : 18/05/2021, 12:46, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2021.
// Comments         : 
#endregion

#region Imported Namespaces

using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace TupleGeo.General.ComponentModel {

  /// <summary>
  /// An object that is observed by other objects for value changes in its properties.
  /// </summary>
  public abstract class ObservableObject : INotifyPropertyChanged {

    #region Protected Methods

    /// <summary>
    /// Called when a property value changes.
    /// </summary>
    /// <param name="propertyName">The name of the property that has been changed.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    #region Public Events

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

  }

}
