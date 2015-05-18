
#region Header
// Title Name       : IQueyrableExtentions
// Member of        : TupleGeo.Global.dll
// Description      : Provides extension methods for IQueryable<T>.
// Created by       : 13/05/2009, 00:59, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Member Variables

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TupleGeo.Global.Data;

#endregion

namespace TupleGeo.Global.Linq {

  /// <summary>
  /// Provides extension methods for <see cref="IQueryable{TEntity}"/>.
  /// </summary>
  public static class IQueyrableExtentions {

    #region Public Methods

    /// <summary>
    /// Sorts the elements of a sequence in ascending order by using a specified property.
    /// </summary>
    /// <typeparam name="TEntity">A class object.</typeparam>
    /// <param name="source">The source that needs to be ordered.</param>
    /// <param name="orderByProperty">The property name used to order the entities.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> of <typeparamref name="TEntity"/>.</returns>
    public static IQueryable<TEntity> OrderBy<TEntity>(
      this IQueryable<TEntity> source,
      string orderByProperty
    ) where TEntity : class {

      var type = typeof(TEntity);

      var property = type.GetProperty(orderByProperty);

      var parameter = Expression.Parameter(type, "p");
      var propertyAccess = Expression.MakeMemberAccess(parameter, property);

      var orderByExp = Expression.Lambda(propertyAccess, parameter);

      var resultExp = Expression.Call(
        typeof(Queryable),
        "OrderBy",
        new Type[] { type, property.PropertyType },
        source.Expression,
        Expression.Quote(orderByExp)
      );

      return source.Provider.CreateQuery<TEntity>(resultExp);

    }

    /// <summary>
    /// Sorts the elements of a sequence in descending order by using a specified property.
    /// </summary>
    /// <typeparam name="TEntity">A class object.</typeparam>
    /// <param name="source">The source that needs to be ordered.</param>
    /// <param name="orderByProperty">The property name used to order the entities.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> of <typeparamref name="TEntity"/>.</returns>
    public static IQueryable<TEntity> OrderByDescending<TEntity>(
      this IQueryable<TEntity> source,
      string orderByProperty
    ) where TEntity : class {

      var type = typeof(TEntity);

      var property = type.GetProperty(orderByProperty);

      var parameter = Expression.Parameter(type, "p");
      var propertyAccess = Expression.MakeMemberAccess(parameter, property);

      var orderByExp = Expression.Lambda(propertyAccess, parameter);

      var resultExp = Expression.Call(
        typeof(Queryable),
        "OrderByDescending",
        new Type[] { type, property.PropertyType },
        source.Expression,
        Expression.Quote(orderByExp)
      );

      return source.Provider.CreateQuery<TEntity>(resultExp);

    }

    #endregion

  }

}
