
#region Header
// Title Name       : AttributeHelper
// Member of        : TupleGeo.General.dll
// Description      : A Helper object to deal with attributes.
// Created by       : 18/02/2009, 22:50, Vasilis Vlastaras.
// Updated by       : 27/03/2009. 01:38, Vasilis Vlastaras.
//                    1.0.1 - Added methods GetMatchingAttributes, GetFirstMatchingAttribute
//                    GetMatchingEnumeratedValueAttributes, GetFirstMatchingEnumeratedValueAttribute.
//                  : 25/06/2009. 21:56, Vasilis Vlastaras.
//                    1.0.2 - Added methods using type argument.
//                  : 22/02/2011, 22:18, Vasilis Vlastaras.
//                    1.0.3 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.3
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

#endregion

namespace TupleGeo.General.Attributes {

  /// <summary>
  /// A Helper object to deal with <see cref="Attribute">attributes</see>.
  /// </summary>
  public static class AttributeHelper {

    #region Public Methods

    /// <summary>
    /// Gets all matching custom attributes for a specified object based on specified attribute type.
    /// </summary>
    /// <param name="value">The object that is used to find attached attributes.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>
    /// An object array containing the <see cref="Attribute">attributes</see> found.
    /// </returns>
    public static object[] GetMatchingCustomAttributes(object value, Type attributeType) {
      return TypeDescriptor.GetReflectionType(value).GetCustomAttributes(attributeType, false);
    }

    /// <summary>
    /// Gets all matching attributes for a specified object based on specified attribute type.
    /// </summary>
    /// <param name="value">The object that is used to find attached attributes.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>
    /// An object array containing the <see cref="Attribute">attributes</see> found.
    /// </returns>
    public static object[] GetMatchingAttributes(object value, Type attributeType) {
      AttributeCollection attributeCollection = TypeDescriptor.GetAttributes(value);
      List<object> attributesList = new List<object>();
      for (int i = 0; i < attributeCollection.Count; i++) {
        if (attributeCollection[i].GetType() == attributeType) {
          attributesList.Add((object)attributeCollection[i]);
        }
      }
      return attributesList.ToArray();
    }

    /// <summary>
    /// Gets all matching attributes for a specified type based on specified attribute type.
    /// </summary>
    /// <param name="type">The Type that is used to find attached attributes.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>
    /// An object array containing the <see cref="Attribute">attributes</see> found.
    /// </returns>
    public static object[] GetMatchingAttributes(Type type, Type attributeType) {
      AttributeCollection attributeCollection = TypeDescriptor.GetAttributes(type);
      List<object> attributesList = new List<object>();
      for (int i = 0; i < attributeCollection.Count; i++) {
        if (attributeCollection[i].GetType() == attributeType) {
          attributesList.Add((object)attributeCollection[i]);
        }
      }
      return attributesList.ToArray();
    }

    /// <summary>
    /// Gets the matching attributes for a specified enumerated field based on a specified attribute type.
    /// </summary>
    /// <param name="enumValue">
    /// The Enumerated value used to retrieve its attributes.
    /// </param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="enumValue"/> or <paramref name="attributeType"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// An object array containing the matching <see cref="Attribute">attributes</see>.
    /// </returns>
    public static object[] GetMatchingEnumeratedValueAttributes(object enumValue, Type attributeType) {
      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      if (attributeType == null) {
        throw new ArgumentNullException("attributeType");
      }

      Type type = enumValue.GetType();

      object[] enumeratedFieldAttributes = TypeDescriptor.GetReflectionType(type).GetField(
        Enum.GetName(type, enumValue)).GetCustomAttributes(attributeType, false
      );

      return enumeratedFieldAttributes;
    }
        
    /// <summary>
    /// Gets the first matching custom attribute for a specified object based on a specified attribute type.
    /// </summary>
    /// <param name="value">The object that is used to find the attached attribute.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>
    /// An object containing the <see cref="Attribute">attribute</see>.
    /// </returns>
    public static object GetFirstMatchingCustomAttribute(object value, Type attributeType) {
      object attribute = null;
      object[] attributes = TypeDescriptor.GetReflectionType(value).GetCustomAttributes(attributeType, false);
      if (attributes != null) {
        if (attributes.Length > 0) {
          attribute = attributes[0];
        }
      }
      return attribute;
    }

    /// <summary>
    /// Gets the first matching custom attribute for a specified object based on a specified attribute type.
    /// </summary>
    /// <param name="type">The Type that is used to find the attached attribute.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>An object containing the <see cref="Attribute">attribute</see>.</returns>
    public static object GetFirstMatchingCustomAttribute(Type type, Type attributeType) {
      object attribute = null;
      object[] attributes = TypeDescriptor.GetReflectionType(type).GetCustomAttributes(attributeType, false);
      if (attributes != null) {
        if (attributes.Length > 0) {
          attribute = attributes[0];
        }
      }
      return attribute;
    }

    /// <summary>
    /// Gets the first matching attribute for a specified object based on a specified attribute type.
    /// </summary>
    /// <param name="value">The object that is used to find the attached attribute.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>An object containing the <see cref="Attribute">attribute</see>.</returns>
    public static object GetFirstMatchingAttribute(object value, Type attributeType) {
      object attribute = null;
      AttributeCollection attributes = TypeDescriptor.GetAttributes(value);
      for (int i = 0; i < attributes.Count; i++) {
        if (attributes[i].GetType() == attributeType) {
          attribute = attributes[i];
          break;
        }
      }
      return attribute;
    }

    /// <summary>
    /// Gets the first matching attribute for a specified type based on a specified attribute type.
    /// </summary>
    /// <param name="type">The Type that is used to find the attached attribute.</param>
    /// <param name="attributeType">The Type of the attribute to seek for.</param>
    /// <returns>An object containing the <see cref="Attribute">attribute</see>.</returns>
    public static object GetFirstMatchingAttribute(Type type, Type attributeType) {
      object attribute = null;
      AttributeCollection attributes = TypeDescriptor.GetAttributes(type);
      for (int i = 0; i < attributes.Count; i++) {
        if (attributes[i].GetType() == attributeType) {
          attribute = attributes[i];
          break;
        }
      }
      return attribute;
    }
        
    /// <summary>
    /// Gets the first matching attribute for a specified enumerated field based on a specified attribute type.
    /// </summary>
    /// <param name="enumValue">
    /// The Enumerated value used to retrieve its attribute.
    /// </param>
    /// <param name="attributeType">The Type of the attribute.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="enumValue"/> or <paramref name="attributeType"/> is <c>null</c>.
    /// </exception>
    /// <returns>An object containing the matching attribute.</returns>
    public static object GetFirstMatchingEnumeratedValueAttribute(object enumValue, Type attributeType) {
      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      if (attributeType == null) {
        throw new ArgumentNullException("attributeType");
      }

      Type type = enumValue.GetType();

      object[] enumeratedFieldAttributes = TypeDescriptor.GetReflectionType(type).GetField(
        Enum.GetName(type, enumValue)).GetCustomAttributes(attributeType, false
      );

      object attribute = null;

      if (enumeratedFieldAttributes != null) {
        if (enumeratedFieldAttributes.Length > 0) {
          attribute = enumeratedFieldAttributes[0];
        }
      }

      return attribute;
    }
    
    #endregion

  }

}
