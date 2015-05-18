
#region Header
// Title Name       : ObjectExtensions
// Member of        : TupleGeo.General.dll
// Description      : Contains a set of extension methods for the System.Object type.
// Created by       : 12/06/2009, 15:53, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using TupleGeo.General.Properties;

#endregion

namespace TupleGeo.General {

  /// <summary>
  /// Contains a set of extension methods for the <see cref="System.Object"/> type.
  /// </summary>
  public static class ObjectExtensions {

    #region Public Methods

    /// <summary>
    /// Gets a <see cref="string"/> representation of the value of a
    /// specified property of an object.
    /// </summary>
    /// <param name="object">The object whose property value will be got.</param>
    /// <param name="propertyName">The name pf the property of the object.</param>
    /// <returns>A <see cref="string"/> with the converted value.</returns>
    public static string GetPropertyValueString(this object @object, string propertyName) {
      PropertyInfo propertyInfo = @object.GetType().GetProperty(propertyName);

      if (propertyInfo.PropertyType == typeof(string)) {
        // String.
        return Convert.ToString(propertyInfo.GetValue(@object, null));
      }
      else if (propertyInfo.PropertyType.IsPrimitive) {
        // Primitive type.
        return Convert.ToString(propertyInfo.GetValue(@object, null));
      }
      else if (propertyInfo.PropertyType.IsGenericType) {
        // Generic type.
        Type[] genericArgs = propertyInfo.PropertyType.GetGenericArguments();
        if (genericArgs.Length == 1) {
          if (genericArgs[0].IsPrimitive) {
            return Convert.ToString(propertyInfo.GetValue(@object, null));
          }
          else {
            throw new Exception(Resources.General_PropertyNullableTypeIsNotOfAPrimitiveType);
          }
        }
        else {
          throw new Exception(Resources.General_PropertyHasMoreThanOneGenericArguments);
        }
      }
      else {
        throw new Exception(Resources.General_PropertyCouldNotConvertValueToString);
      }
    }

    #endregion

  }

}
