
#region Header
// Title Name       : IEnumerableExtentions
// Member of        : TupleGeo.General.dll
// Description      : Provides extension methods for IEnumerable<T>.
// Created by       : 13/05/2009, 20:39, Vasilis Vlastaras.
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
using System.Text;
using TupleGeo.General.Data;
using System.Linq.Expressions;

#endregion

namespace TupleGeo.General.Linq {

  /// <summary>
  /// Provides extension methods for <see cref="IEnumerable{T}"/>.
  /// </summary>
  public static class IEnumerableExtentions {

    /// <summary>
    /// Filters a sequence of values based on ......
    /// </summary>
    /// <typeparam name="TEntity">A class object.</typeparam>
    /// <param name="source">The source that needs to be filtered.</param>
    /// <param name="sFilterProperty">The name of the filter property.</param>
    /// <param name="sFilterValue">The filter value.</param>
    /// <param name="filterType">The <see cref="FilterType"/>.</param>
    /// <returns>An <see cref="IQueyable{TEntity}"/>.</returns>
    public static IEnumerable<TEntity> Where<TEntity>(
      this IEnumerable<TEntity> source,
      string sFilterProperty,
      string sFilterValue,
      FilterType filterType
    ) where TEntity : class {

      //return source.Where(MakeFilter<TEntity>(sFilterProperty, sFilterValue));

      var type = typeof(TEntity);

      var property = type.GetProperty(sFilterProperty);

      var parameter = Expression.Parameter(type, "p");
      var propertyAccess = Expression.MakeMemberAccess(parameter, property);
      var constantValue = Expression.Constant(sFilterValue);

      var equality = Expression.Equal(propertyAccess, constantValue);

      var whereExp = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);

      var resultExp = Expression.Call(typeof(Enumerable), "Where", new Type[] { type, whereExp.Body.Type }, source.AsQueryable<TEntity>().Expression, Expression.Quote(whereExp));
      //var resultExp = Expression.Call(typeof(Enumerable),"Where",new Type[] { type, property.PropertyType },source.AsQueryable<TEntity>().Expression,Expression.Quote(whereExp));

      //return source.AsQueryable<TEntity>().Provider.CreateQuery<TEntity>(resultExp);

      //var type = typeof(TEntity);

      //var property = type.GetProperty(sFilterProperty);


      //var parameter = System.Linq.Expressions.Expression.Parameter(type, "p");
      //var propertyAccess = System.Linq.Expressions.Expression.MakeMemberAccess(parameter, property);

      //var orderByExp = System.Linq.Expressions.Expression.Lambda(propertyAccess, parameter);

      //var resultExp = System.Linq.Expressions.Expression.Call(
      //  typeof(Queryable),
      //  "Where",
      //  new Type[] { type, property.PropertyType },
      //  source.Expression,
      //  System.Linq.Expressions.Expression.Quote(orderByExp)
      //);
      ////System.Linq.Expressions.Expression.Quote(orderByExp)
      //return source.Provider.CreateQuery<TEntity>(resultExp);

      return null;

    }


    private static Expression<Func<object, bool>> MakeFilter<TEntity>(string propertyName, string value) where TEntity : class {
      var type = typeof(TEntity);

      var property = type.GetProperty(propertyName);

      var parameter = Expression.Parameter(type, "p");
      var propertyAccess = Expression.MakeMemberAccess(parameter, property);
      var constantValue = Expression.Constant((object)value);

      var equality = Expression.Equal(propertyAccess, constantValue);

      return Expression.Lambda<Func<object, bool>>(equality, parameter);
    }



  }

}


//static Expression<Func<Order, bool>> MakeFilter(string propertyName, object value)
//        {
//            var type = typeof(Order);

//            var property = type.GetProperty(propertyName);

//            var parameter = Expression.Parameter(type, "p");
//            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
//            var constantValue = Expression.Constant(value);

//            var equality = Expression.Equal(propertyAccess, constantValue);

//            return Expression.Lambda<Func<Order, bool>>(equality, parameter);
//        }
