
#region Header
// Title Name       : EnumToResourceDescriptionConverter
// Member of        : TupleGeo.General.Windows.Presentation.dll
// Description      : Converts an Enum Value to its Description and vice versa.
// Created by       : 23/05/2015, 02:51, Vasilis Vlastaras.
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
using System.Text;
using System.Windows.Data;

#endregion

namespace TupleGeo.General.Windows.Data {

  /// <summary>
  /// Converts the value of an enumeration to a descriptive <see cref="string"/> value.
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
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      
      //if (value != null) {
      //  FieldInfo fi = value.GetType().GetField(value.ToString());

      //  // To get around the stupid wpf designer bug
      //  if (fi != null) {
      //    var attributes =
      //        (LocalizableDescriptionAttribute[])fi.GetCustomAttributes(typeof(LocalizableDescriptionAttribute), false);

      //    return ((attributes.Length > 0) &&
      //            (!String.IsNullOrEmpty(attributes[0].Description)))
      //               ?
      //                   attributes[0].Description
      //               : value.ToString();
      //  }
      //}

      return string.Empty;

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

