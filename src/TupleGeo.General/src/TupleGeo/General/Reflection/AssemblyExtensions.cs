
#region Header
// Title Name       : AssemblyExtensions
// Member of        : TupleGeo.General.dll
// Description      : Provides methods for manipulating the Assembly object more efficiently.
// Created by       : 17/05/2009, 19:49, Vasilis Vlastaras.
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
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using TupleGeo.General.Properties;

#endregion

namespace TupleGeo.General.Reflection {

  /// <summary>
  /// Provides extension methods for the Assembly object.
  /// </summary>
  public static class AssemblyExtensions {

    #region Public Methods

    /// <summary>
    /// Gets all exported types of the assembly implementing the specified interface.
    /// </summary>
    /// <param name="assembly">The Assembly.</param>
    /// <param name="interfaceType">
    /// The Type of interface whose implementors will be returned.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="interfaceType"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// The types implementing the specified interface.
    /// </returns>
    public static IEnumerable<Type> GetExportedTypes(this Assembly assembly, Type interfaceType) {
      if (interfaceType == null) {
        throw new ArgumentNullException("interfaceType");
      }

      // Get the public types of the assembly implementing the interfaceType.
      IEnumerable<Type> types =
        from exportedT in assembly.GetExportedTypes()
        from interfaceT in exportedT.GetInterfaces()
        where interfaceT == interfaceType
        select exportedT;

      return types;
    }
    
    /// <summary>
    /// Creates an instance of an object implementing the specified interface type.
    /// </summary>
    /// <param name="assembly">The Assembly.</param>
    /// <param name="interfaceType">
    /// The Type of interface implemented by the object to be instantiated.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="interfaceType"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <para>
    /// Thrown when no type will be found implementing the specified <paramref name="interfaceType"/>.
    /// </para>
    /// <para>
    /// Thrown when more than one types found implementing the specified <paramref name="interfaceType"/>.
    /// </para>
    /// </exception>
    /// <returns>An object instance implementing the specified interface.</returns>
    /// <remarks>
    /// The method expects only one of the exported types to implement this interface.
    /// In case there are more exported types implementing this interface the method
    /// will raise an <see cref="ArgumentException"/> as described in exceptions section.
    /// </remarks>
    public static object CreateInstance(this Assembly assembly, Type interfaceType) {
      if (interfaceType == null) {
        throw new ArgumentNullException("interfaceType");
      }

      object instance = null;

      // Get the public types of the assembly implementing the interfaceType.
      IEnumerable<Type> types =
        from exportedT in assembly.GetExportedTypes()
        from interfaceT in exportedT.GetInterfaces()
        where interfaceT == interfaceType
        select exportedT;

      if (types != null) {
        if (types.Count() == 1) {
          foreach (Type type in types) {
            instance = assembly.CreateInstance(type.ToString());
          }
        }
        else {
          throw new ArgumentException(
            string.Format(
              CultureInfo.InvariantCulture,
              Resources.Reflection_AssemblyExtensions_ExceptionTypeNotFoundOrMoreThanOneTypesFoundInAssembly,
              interfaceType.Name
            ),
            "interfaceType"
          );
        }
      }
      else {
        throw new ArgumentException(
          string.Format(
            CultureInfo.InvariantCulture,
            Resources.Reflection_AssemblyExtensions_ExceptionTypeNotFoundInAssembly,
            interfaceType.Name
          ),
          "interfaceType"
        );
      }

      return instance;
    }
    
    #endregion
    
  }

}
