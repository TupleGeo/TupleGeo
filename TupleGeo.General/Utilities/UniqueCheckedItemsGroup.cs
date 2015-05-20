
#region Header
// Title Name       : UniqueCheckedItemsGroup
// Member of        : TupleGeo.General.dll
// Description      : Groups a list of items having a Checked property together
//                  : so as to ensure that only one of these items will be checked at a time.
// Created by       : 27/04/2009, 06:00, Vasilis Vlastaras.
// Updated by       : 11/05/2009, 02:37, Vasilis Vlastaras.
//                    1.0.1 - Updated the logic of the UpdateCheck  method.
//                  : 23/02/2011, 17:49, Vasilis Vlastaras.
//                    1.0.2 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.2
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

#endregion

namespace TupleGeo.General.Utilities {

  /// <summary>
  /// Groups a list of items having a Checked property together
  /// so as to ensure that only one of these items will be checked at a time.
  /// </summary>
  public sealed class UniqueCheckedItemsGroup {

    #region Member Variables

    object _checkedItem;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UniqueCheckedItemsGroup"/>.
    /// </summary>
    public UniqueCheckedItemsGroup() {
      _checkedItem = null;
    }

    /// <summary>
    /// Initializes the <see cref="UniqueCheckedItemsGroup"/> with an item already checked.
    /// </summary>
    /// <param name="checkedItem">
    /// The item in the group being already checked.
    /// </param>
    public UniqueCheckedItemsGroup(object checkedItem) {
      _checkedItem = checkedItem;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the Checked property in the group of items.
    /// </summary>
    /// <param name="item">
    /// The item that its Checked property will be set to true.
    /// </param>
    /// <param name="denyUnCheck">
    /// Specifies whether the checked item can be unchecked.
    /// </param>
    public void UpdateCheck(object item, bool denyUnCheck) {
      if ((item == _checkedItem) && (denyUnCheck)) {
        return;
      }

      Type type = item.GetType();

      PropertyInfo property = type.GetProperty("Checked");

      if (property != null) {
        if (property.PropertyType == typeof(bool)) {
          property.SetValue(item, !((bool)(property.GetValue(item, null))), null);

          if (_checkedItem != null) {
            if (_checkedItem != item) {
              type = _checkedItem.GetType();
              property = type.GetProperty("Checked");

              if (property.PropertyType == typeof(bool)) {
                property.SetValue(_checkedItem, (object)false, null);
              }
            }
          }

          _checkedItem = item;

        }
      }
    }
    
    #endregion
        
  }

}
