
#region Header
// Title Name       : Prop.
// Member of        : TupleGeo.General.dll
// Description      : Prop object provides utility functions related to object properties.
// Created by       : 04/06/2015, 02:05, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

#endregion

namespace TupleGeo.General.Linq.Expressions {

  /// <summary>
  /// Prop object provides utility functions related to object properties.
  /// </summary>
  public static class Prop {

    #region Public Methods

    /// <summary>
    /// Gets a property name.
    /// </summary>
    /// <typeparam name="T">The object whose property name will be retrieved.</typeparam>
    /// <param name="expression">
    /// The expression used to retrieve the property. Should be like: <code>p => p.PropertyName</code>
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="expression"/> is <c>null</c>.
    /// </exception>
    /// <returns>A string holding the property name.</returns>
    public static string GetPropertyName<T>(Expression<Func<T, object>> expression) {
      
      if (expression == null) {
        throw new ArgumentNullException("expression", "Expression could not be NULL.");
      }

      var lambda = expression as LambdaExpression;
      MemberExpression memberExpression;

      if (lambda.Body is UnaryExpression) {
        var unaryExpression = lambda.Body as UnaryExpression;
        memberExpression = unaryExpression.Operand as MemberExpression;
      }
      else {
        memberExpression = lambda.Body as MemberExpression;
      }

      //var constantExpression = memberExpression.Expression as ConstantExpression;

      if (memberExpression != null) {
        var propertyInfo = memberExpression.Member as PropertyInfo;

        return propertyInfo.Name;
      }

      return null;

    }

    #endregion

  }

}
