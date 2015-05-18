
#region Header
// Title Name       : ObservableObject<T>.
// Member of        : TupleGeo.General.dll
// Description      : An object that its property value changes can be observed by other objects.
// Created by       : 26/05/2011, 15:08, Vasilis Vlastaras.
// Updated by       : 09/06/2011, 14:43, Vasilis Vlastaras. - Added overloaded OnPropertyChanged event procedure.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2011 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

#endregion

namespace TupleGeo.General.ComponentModel {

  /// <summary>
  /// An object that its property value changes can be observed by other objects.
  /// </summary>
  /// <typeparam name="T">Any object need to be observed.</typeparam>
  public abstract class ObservableObject<T> : INotifyPropertyChanged {

    #region INotifyPropertyChanged Members

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Executed when a property changes.
    /// </summary>
    /// <param name="prop">The property.</param>
    protected virtual void OnPropertyChanged(Expression<Func<T, object>> prop) {
      if (prop == null || prop.Body == null) {
        return;
      }

      var lambda = prop as LambdaExpression;
      MemberExpression memberExpression;

      if (lambda.Body is UnaryExpression) {
        var unaryExpression = lambda.Body as UnaryExpression;
        memberExpression = unaryExpression.Operand as MemberExpression;
      }
      else {
        memberExpression = lambda.Body as MemberExpression;
      }

      var constantExpression = memberExpression.Expression as ConstantExpression;
      var propertyInfo = memberExpression.Member as PropertyInfo;

      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) {
        handler(this, new PropertyChangedEventArgs(propertyInfo.Name));
      }
    }

    /// <summary>
    /// Called when [property changed].
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    protected virtual void OnPropertyChanged(string propertyName) {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion

  }

}
