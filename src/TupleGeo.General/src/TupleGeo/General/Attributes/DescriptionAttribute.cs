
#region Header
// Title Name       : DescriptionAttribute
// Member of        : TupleGeo.General.dll
// Description      : Defines a custom attribute used for adding descriptive information in code Metadata.
// Created by       : 10/02/2009, 17:10, Vasilis Vlastaras.
// Updated by       : 16/02/2009, 20:10, Vasilis Vlastaras.
//                    1.0.1 - Added sealed keyword in class accessors.
//                  : 22/02/2011, 22:20, Vasilis Vlastaras.
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
using System.ComponentModel;
using System.Globalization;
using System.Text;

#endregion

namespace TupleGeo.General.Attributes {

  /// <summary>
  /// A custom attribute used to add descriptive information.
  /// </summary>
  [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
  public sealed class DescriptionAttribute : Attribute {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a <see cref="DescriptionAttribute"/> by setting its description
    /// irrelevant to a culture.
    /// </summary>
    /// <param name="description">The description that the <see cref="DescriptionAttribute"/> sets.</param>
    public DescriptionAttribute(string description) {
      _description = description;
    }

    /// <summary>
    /// Initializes a <see cref="DescriptionAttribute"/> by setting its description
    /// for a specified culture.
    /// </summary>
    /// <param name="description">The description that this attribute sets.</param>
    /// <param name="culture">The culture string representation associated with this description.</param>
    public DescriptionAttribute(string description, string culture) {
      _description = description;
      _culture = culture;
    }

    #endregion

    #region Public Properties

    private string _description;

    /// <summary>
    /// Gets the Description.
    /// </summary>
    public string Description {
      get {
        return _description;
      }
    }

    private string _culture;

    /// <summary>
    /// Gets the Culture.
    /// </summary>
    public string Culture {
      get {
        return _culture;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the neutral culture
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description.
    /// </summary>
    /// <param name="enumValue">
    /// The Enumerated value used to retrieve its
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumValue"/> is <c>null</c>.</exception>
    /// <returns>A string with the neutral culture description.</returns>
    /// <remarks>
    /// The neutral culture description is not associated with a specific culture.
    /// Thus the <see cref="TupleGeo.General.Attributes.DescriptionAttribute.Culture">DescriptionAttribute.Culture</see>
    /// property must be null. In such a case a neutral culture description is specified. If no neutral culture
    /// description has been found, a zero length string will be returned instead.
    /// </remarks>
    public static string GetEnumeratedValueDescriptionAttribute(object enumValue) {

      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      string description = "";

      Type type = enumValue.GetType();

      object[] descriptionAttributes = TypeDescriptor.GetReflectionType(type).GetField(
        Enum.GetName(type, enumValue)).GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false
      );

      if (descriptionAttributes != null) {
        for (int i = 0; i < descriptionAttributes.Length; i++) {
          TupleGeo.General.Attributes.DescriptionAttribute descAttr = (TupleGeo.General.Attributes.DescriptionAttribute)descriptionAttributes[i];
          if (descAttr != null) {
            if (descAttr.Culture == null) {
              description = descAttr.Description;
              break;
            }
          }
        }
      }

      return description;

    }

    /// <summary>
    /// Gets the
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description.
    /// associated with the specified culture.
    /// </summary>
    /// <param name="enumValue">
    /// The Enumerated value used to retrieve its
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description.
    /// </param>
    /// <param name="culture">
    /// The culture of the description.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumValue"/> is <c>null</c>.</exception>
    /// <returns>A string with the description.</returns>
    /// <remarks>
    /// If no description will be found for the specified culture, the neutral culture description will be returned. 
    /// If no neutral culture description has been found, a zero length string will be returned instead.
    /// </remarks>
    public static string GetEnumeratedValueDescriptionAttribute(object enumValue, string culture) {

      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      string description = "";

      Type type = enumValue.GetType();

      object[] descriptionAttributes = TypeDescriptor.GetReflectionType(type).GetField(
        Enum.GetName(type, enumValue)).GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false
      );

      if (descriptionAttributes != null) {
        for (int i = 0; i < descriptionAttributes.Length; i++) {
          TupleGeo.General.Attributes.DescriptionAttribute descAttr = (TupleGeo.General.Attributes.DescriptionAttribute)descriptionAttributes[i];
          if (descAttr != null) {
            if (descAttr.Culture == null) {
              description = descAttr.Description;
            }
            else {
              if (!string.IsNullOrEmpty(culture)) {
                if (descAttr.Culture == culture) {
                  description = descAttr.Description;
                  break;
                }
              }
            }
          }
        }
      }

      return description;

    }

    #endregion

  }

}
