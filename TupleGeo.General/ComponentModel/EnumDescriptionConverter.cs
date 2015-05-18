
#region Header
// Title Name       : EnumDescriptionConverter
// Member of        : TupleGeo.General.dll
// Description      : A type converter used to convert values of an enumeration in to its corresponding descriptions.
// Created by       : 03/03/2010, 15:54, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 22:50, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.1
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
using System.Reflection;
using System.Text;

#endregion

namespace TupleGeo.General.ComponentModel {

  /// <summary>
  /// Converts an enumerated value to a string holding its description attribute and vice versa.
  /// </summary>
  public class EnumDescriptionConverter : EnumConverter {

    #region Member Declarations

    private Type _type;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the EnumDescriptionConverter.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> to be used.</param>
    public EnumDescriptionConverter(Type type)
      : base(type.GetType()) {
      _type = type;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the description attribute value of an enum value.
    /// </summary>
    /// <param name="enumValue">An enumerated value.</param>
    /// <returns>
    /// A <see cref="string"/> containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="DescriptionAttribute"/> has been set for the enumerated value,
    /// a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Enum enumValue) {
      FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
      TupleGeo.General.Attributes.DescriptionAttribute[] attributes = (TupleGeo.General.Attributes.DescriptionAttribute[])fi.GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : enumValue.ToString();
    }

    /// <summary>
    /// Gets the description attribute value of a specified enum value.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <param name="name">The name of an enumerated value.</param>
    /// <returns>
    /// A <see cref="string"/> containing the description (if any) of the enumerated value.
    /// </returns>
    /// <remarks>
    /// If no <see cref="DescriptionAttribute"/> has been set for the enumerated value,
    /// a string representation of the name of the enumerated value is returned instead.
    /// </remarks>
    public static string GetEnumDescription(Type type, string name) {
      FieldInfo fi = type.GetField(name);
      TupleGeo.General.Attributes.DescriptionAttribute[] attributes = (TupleGeo.General.Attributes.DescriptionAttribute[])fi.GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : name;
    }

    /// <summary>
    /// Gets the descriptions of all enumerated values found in an anumeration.
    /// </summary>
    /// <param name="enumValue">An enumerated value used to find out the enumeration it belongs.</param>
    /// <returns>
    /// An array of <see cref="string">strings</see> containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a null is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="DescriptionAttribute"/> has been set for the enumerated values,
    /// a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Enum enumValue) {
      Type type = enumValue.GetType();

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
    /// Gets the descriptions of all enumerated values found in an enumeration.
    /// </summary>
    /// <param name="type">The type of the enumeration.</param>
    /// <returns>
    /// An array of <see cref="string">strings</see> containing the descriptions of the enumerated values.
    /// </returns>
    /// <remarks>
    /// <para>
    /// If no enumerated values found in the enumeration a <c>null</c> is returned instead.
    /// </para>
    /// <para>
    /// If no <see cref="DescriptionAttribute"/> has been set for the enumerated values,
    /// a string representation of the name of the enumerated values is returned instead.
    /// </para>
    /// </remarks>
    public static string[] GetEnumDescriptions(Type type) {
      FieldInfo[] fis = type.GetFields();
      string[] descriptions = null;
      
      if (fis.Length > 0) {
        for (int i = 0; i < fis.Length; i++) {
          
          object[] atts = fis[i].GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), true);
          
          TupleGeo.General.Attributes.DescriptionAttribute[] attributes = (TupleGeo.General.Attributes.DescriptionAttribute[])fis[i].GetCustomAttributes(typeof(TupleGeo.General.Attributes.DescriptionAttribute), false);
          descriptions[i] = (attributes.Length > 0) ? attributes[0].Description : fis[i].Name;
        }
      }

      return descriptions;
    }
    
    /// <summary>
    /// Gets the value of an enumeration, based on it's description attribute or named value.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the enumeration.</param>
    /// <param name="description">The description or name of the element.</param>
    /// <returns>
    /// An <see cref="object"/> containing the value or the description if it was not found.
    /// </returns>
    public static object GetEnumValue(Type type, string description) {
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
    /// <param name="context">An <see cref="ITypeDescriptorContext"/>.</param>
    /// <param name="culture">A <see cref="CultureInfo"/>.</param>
    /// <param name="value">The description of an emumerated value. (should be a <see cref="string"/>).</param>
    /// <returns>
    /// An <see cref="object"/> containing the enumerated value.
    /// </returns>
    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value
    ) {
      if (value is string) {
        return GetEnumValue(_type, (string)value);
      }
      if (value is Enum) {
        return GetEnumDescription((Enum)value);
      }
      return base.ConvertFrom(context, culture, value);
    }
    
    /// <summary>
    /// Converts an enumerated value to a <see cref="string"/>.
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext"/>.</param>
    /// <param name="culture">A <see cref="CultureInfo"/>.</param>
    /// <param name="value">The enumerated value need to be converted.</param>
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
        return GetEnumDescription((Enum)value);
      }
      if (value is string && destinationType == typeof(string)) {
        return GetEnumDescription(_type, (string)value);
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }

    #endregion

  }

}
