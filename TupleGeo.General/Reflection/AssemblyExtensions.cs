
#region Header
// Title Name       : AssemblyHelper
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
using System.Linq;
using System.Reflection;
using System.Text;
using TupleGeo.General.Properties;

#endregion

namespace TupleGeo.General.Reflection {

  /// <summary>
  /// Provides methods for manipulating the Assembly object more efficiently.
  /// </summary>
  public static class AssemblyExtensions {

    #region Public Methods

    /// <summary>
    /// Gets all exported types of the assembly implementing the specified interface.
    /// </summary>
    /// <param name="assembly">The <see cref="Assembly"/>.</param>
    /// <param name="interfaceType">
    /// The <see cref="Type"/> of interface whose implementors will be returned.
    /// </param>
    /// <returns>
    /// An IEmumerable of <see cref="Type"/> with <see cref="Type">types</see> implementing the specified interface.
    /// </returns>
    public static IEnumerable<Type> GetExportedTypes(this Assembly assembly, Type interfaceType) {
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
    /// <param name="assembly">The <see cref="Assembly"/>.</param>
    /// <param name="interfaceType">
    /// The <see cref="Type"/> of interface implemented by the object to be instantiated.
    /// </param>
    /// <returns>An <see cref="object"/> instance implementing the specified interface.</returns>
    /// <remarks>
    /// The method expects only one of the exported types to implement this interface.
    /// In case there are more exported types implementing this interface the method
    /// will return null and raise an error.
    /// </remarks>
    public static object CreateInstance(this Assembly assembly, Type interfaceType) {
      object instance = null;

      if (interfaceType == null) {
        throw new ArgumentNullException("interfaceType");
      }

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
