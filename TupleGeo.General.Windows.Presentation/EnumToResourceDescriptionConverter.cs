
#region Header
// Title Name       : EnumToResourceDescriptionConverter
// Member of        : TupleGeo.General.Windows.Presentation.dll
// Description      : Converts an Enum Value to its Description and vice versa.
// Created by       : 27/05/2015, 18:55, Vasilis Vlastaras.
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
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Data;
using TupleGeo.General.Attributes;

#endregion

namespace TupleGeo.General.Windows.Data {

  /// <summary>
  /// Converts the value of an enumeration to a <see cref="string"/> having the description of this value.
  /// </summary>
  /// <remarks>
  /// The description is retrieved by using the attached
  /// <see cref="ResourceDescriptionAttribute"/> for each enumerated value.
  /// The description then is used to retrieve a localized version of it from
  /// an associated localized resource.
  /// </remarks>
  [ValueConversion(typeof(object), typeof(string))]
  public class EnumToResourceDescriptionConverter : IValueConverter {

    #region IValueConverter Members

    /// <summary>
    /// Converts the enumeration value to a <see cref="string"/> having the description of this value.
    /// </summary>
    /// <param name="value">The enumeration value that needs to be converted.</param>
    /// <param name="targetType">The target <see cref="Type"/>.</param>
    /// <param name="parameter">
    /// A parameter used by the converter. Accepted values for this converter is either null or
    /// an instance of a Resource file.
    /// </param>
    /// <param name="culture">
    /// The <see cref="CultureInfo">culture</see> used by this converter during the conversion operation.
    /// </param>
    /// <remarks>
    /// <para>
    /// The Convert method can be used in two ways.
    /// </para>
    /// <para>
    /// If no parameter is supplied, then it is assumed that the Resource that will be used by the
    /// associated <see cref="ResourceDescriptionAttribute"/> has a <see cref="CultureInfo">Culture</see> set.
    /// If this is not set then the UI culture will be used instead.
    /// </para>
    /// <para>
    /// If a parameter is supplied, then it must be a Resource object and the culture must be set as well.
    /// In XAML this can be done by setting either the Language property of the element that will show
    /// the converted values, or by setting the ConverterCulture of the converter.
    /// </para>
    /// <para>
    /// If no resource description will be retrieved then the name of the enumerated value will be returned instead.
    /// </para>
    /// </remarks>
    /// <returns>A <see cref="string"/> containing the description.</returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

      if (value != null) {
        if (parameter != null) {
          // The parameter is not null. The converter expects a Resource file instance.
          // Try to get the 'Culture' static property of this Resource file object.
          PropertyInfo propertyInfo = parameter.GetType().GetProperty(
            "Culture",
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic
          );
          if (propertyInfo != null && propertyInfo.CanWrite) {
            // A property info has been retrieved and it is writable.
            // Use the culture argument to set the resource culture property.
            propertyInfo.SetValue(parameter, culture, null);
          }
        }

        FieldInfo fi = value.GetType().GetField(value.ToString());

        if (fi != null) {
          var attributes = (ResourceDescriptionAttribute[])fi.GetCustomAttributes(
            typeof(ResourceDescriptionAttribute), false
          );
          if (attributes != null) {
            return ((attributes.Length > 0) && (!string.IsNullOrEmpty(attributes[0].Description))) ?
              attributes[0].Description : Enum.GetName(value.GetType(), value);
          }
        }
      }

      return Enum.GetName(value.GetType(), value);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }

    #endregion

  }

}

