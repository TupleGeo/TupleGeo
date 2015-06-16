
#region Header
// Title Name       : EnumDescriptionConverter
// Member of        : TupleGeo.General.dll
// Description      : A type converter used to convert values of an enumeration in to its corresponding descriptions.
// Created by       : 03/03/2010, 15:54, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 22:50, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
//                  : 20/05/2015, 07:39, Vasilis Vlastaras.
//                    1.0.2 - Changed Overloaded Methods GetEnumDescription, GetEnumDescriptions.
//                  : 23/05/2015, 06:50, Vasilis Vlastaras.
//                    1.0.3 - Changes in logic so as to make the converter behave better.
// Version          : 1.0.3
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2010 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

#endregion

namespace TupleGeo.General.ComponentModel {

  /// <summary>
  /// Converts an enumerated value to its
  /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">attribute description</see> and vice versa.
  /// </summary>
  public class EnumDescriptionConverter : EnumConverter {

    #region Member Declarations

    private Type _type;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="EnumDescriptionConverter"/>.
    /// </summary>
    /// <param name="type">The Type to be used.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is <c>null</c>.</exception>
    public EnumDescriptionConverter(Type type)
      : base(type) {

      if (type == null) {
        throw new ArgumentNullException("type", "An EnumDescriptionConverter could not be initialized for a NULL type.");
      }

      _type = type;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the neutral culture
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description value
    /// of an enum value.
    /// </summary>
    /// <param name="enumValue">An enumerated value.</param>
    /// <returns>
    /// A string containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated value, a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Enum enumValue) {
      return GetEnumDescription(enumValue, null);
    }

    /// <summary>
    /// Gets the 
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description value
    /// of an enum value in the specified culture.
    /// </summary>
    /// <param name="enumValue">An enumerated value.</param>
    /// <param name="culture">The culture of the description.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="enumValue"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="culture"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>
    /// A string containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated value, a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Enum enumValue, string culture) {
      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      if (string.IsNullOrEmpty(culture)) {
        throw new ArgumentException("Culture could not be NULL or Empty.", "culture");
      }

      string enumValueString = enumValue.ToString();

      FieldInfo fi = enumValue.GetType().GetField(enumValueString);

      TupleGeo.General.Attributes.DescriptionAttribute[] attributes =
        (TupleGeo.General.Attributes.DescriptionAttribute[])fi.GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);

      // Try to get the description for the specified culture.
      TupleGeo.General.Attributes.DescriptionAttribute attribute = attributes.FirstOrDefault(a => a.Culture == culture);

      // If the retrieved attribute is null try to get the neutral culture description.
      if (attribute == null) {
        attribute = attributes.FirstOrDefault(a => a.Culture == null);
      }

      // Return description or the enum named value if no description was found.
      return (attribute != null) ? attribute.Description : enumValue.ToString();
    }

    /// <summary>
    /// Gets the neutral culture 
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description value
    /// of a specified enum value.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <param name="name">The name of an enumerated value.</param>
    /// <returns>
    /// A string containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated value, a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Type type, string name) {
      return GetEnumDescription(type, name, null);
    }

    /// <summary>
    /// Gets the 
    /// <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see> description value
    /// of a specified enum value in the specified culture.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <param name="name">The name of an enumerated value.</param>
    /// <param name="culture">The culture of the description.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="type"/> is <c>null</c>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="name"/> or <paramref name="culture"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>
    /// A string containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute"/> has been set for the enumerated value,
    /// a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Type type, string name, string culture) {
      if (type == null) {
        throw new ArgumentNullException("type");
      }

      if (string.IsNullOrEmpty(name)) {
        throw new ArgumentException("Name could not be NULL or Empty", "name");
      }

      if (string.IsNullOrEmpty(culture)) {
        throw new ArgumentException("Culture could not be NULL or Empty", "culture");
      }

      FieldInfo fi = type.GetField(name);

      TupleGeo.General.Attributes.DescriptionAttribute[] attributes =
        (TupleGeo.General.Attributes.DescriptionAttribute[])fi.GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);

      // Try to get the description for the specified culture.
      TupleGeo.General.Attributes.DescriptionAttribute attribute = attributes.FirstOrDefault(a => a.Culture == culture);

      // If the retrieved attribute is null try to get the neutral culture description.
      if (attribute == null) {
        attribute = attributes.FirstOrDefault(a => a.Culture == null);
      }

      // Return description or the enum named value if no description was found.
      return (attribute != null) ? attribute.Description : name;
    }

    /// <summary>
    /// Gets the neutral culture descriptions of all enumerated values found in an enumeration.
    /// </summary>
    /// <param name="enumValue">An enumerated value used to find out the enumeration it belongs.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumValue"/> is <c>null</c>.</exception>
    /// <returns>
    /// An array of strings containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a <c>null</c> is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute"/> has been set for the enumerated values,
    /// a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Enum enumValue) {
      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }
      return GetEnumDescriptions(enumValue.GetType());
    }

    /// <summary>
    /// Gets the descriptions in a specified culture of all enumerated values found in an enumeration.
    /// </summary>
    /// <param name="enumValue">An enumerated value used to find out the enumeration it belongs.</param>
    /// <param name="culture">The culture of the descriptions.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumValue"/> is <c>null</c>.</exception>
    /// <returns>
    /// An array of strings containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a null is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated values, a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Enum enumValue, string culture) {
      if (enumValue == null) {
        throw new ArgumentNullException("enumValue");
      }

      return GetEnumDescriptions(enumValue.GetType(), culture);
    }

    /// <summary>
    /// Gets the neutral culture descriptions of all enumerated values found in an enumeration.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <returns>
    /// An array of strings containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a <c>null</c> is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated values, a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Type type) {
      string[] enumNames = Enum.GetNames(type);
      string[] descriptions = null;

      if (enumNames.Length > 0) {
        descriptions = new string[enumNames.Length];

        for (int i = 0; i < enumNames.Length; i++) {
          descriptions[i] = GetEnumDescription(type, enumNames[i]);
        }
      }

      return descriptions;
    }

    /// <summary>
    /// Gets the descriptions of all enumerated values found in an enumeration for a specified culture.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <param name="culture">The culture of the descriptions.</param>
    /// <returns>
    /// An array of strings containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a <c>null</c> is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="TupleGeo.General.Attributes.DescriptionAttribute">DescriptionAttribute</see>
    /// has been set for the enumerated values, a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Type type, string culture) {
      string[] enumNames = Enum.GetNames(type);
      string[] descriptions = null;

      if (enumNames.Length > 0) {
        descriptions = new string[enumNames.Length];

        for (int i = 0; i < enumNames.Length; i++) {
          descriptions[i] = GetEnumDescription(type, enumNames[i], culture);
        }
      }

      return descriptions;
    }
    
    /// <summary>
    /// Gets the value of an enumeration, based on it's description attribute or named value.
    /// </summary>
    /// <param name="type">The Type of the enumeration.</param>
    /// <param name="description">The description or name of the element.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="description"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>
    /// An object containing the value or the description if it was not found.
    /// </returns>
    public static object GetEnumValue(Type type, string description) {
      if (type == null) {
        throw new ArgumentNullException("type");
      }

      if (string.IsNullOrEmpty(description)) {
        throw new ArgumentException("Description could not be NULL or Empty.", "description");
      }

      FieldInfo[] fis = type.GetFields();
      foreach (FieldInfo fi in fis) {
        TupleGeo.General.Attributes.DescriptionAttribute[] attributes = (TupleGeo.General.Attributes.DescriptionAttribute[])fi.GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);
        if (attributes.Length > 0) {
          if (attributes[0].Description == description) {
            return fi.GetValue(fi.Name);
          }
        }
        if (fi.Name == description) {
          return fi.GetValue(fi.Name);
        }
      }
      return description;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Converts a string containing the description of an enumerated value in to the enumerated value.
    /// </summary>
    /// <param name="context">The context used in the conversion.</param>
    /// <param name="culture">the culture used in the conversion.</param>
    /// <param name="value">The description of an enumerated value. (should be a <see cref="string"/>).</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is <c>null</c>.</exception>
    /// <returns>
    /// An object containing the enumerated value.
    /// </returns>
    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value
    ) {
      if (value == null) {
        throw new ArgumentNullException("value");
      }
      if (value is string) {
        return GetEnumValue(_type, (string)value);
      }
      return base.ConvertFrom(context, culture, value);
    }
    
    /// <summary>
    /// Converts an enumerated value to a <see cref="string"/>.
    /// </summary>
    /// <param name="context">The context used in the conversion.</param>
    /// <param name="culture">The culture used in the conversion.</param>
    /// <param name="value">The enumerated value which is converted.</param>
    /// <param name="destinationType">The destination type. (Should be <see cref="string"/>).</param>
    /// <returns>
    /// An object containing a <see cref="string"/> with the converted enumerated value.
    /// </returns>
    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType
    ) {
      
      if (value is Enum && destinationType == typeof(string)) {
        Enum enumValue = (Enum)value;
        if (culture != null) {
          return GetEnumDescription(enumValue, culture.ToString());
        }
        return GetEnumDescription(enumValue);
      }
      
      if (value is string && destinationType == typeof(string)) {
        if (culture != null) {
          return GetEnumDescription(_type, culture.ToString());
        }
        return GetEnumDescription(_type, (string)value);
      }
      
      return base.ConvertTo(context, culture, value, destinationType);

    }

    #endregion

  }

}
