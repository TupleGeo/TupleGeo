
#region Header
// Title Name       : LocalizableDescriptionAttribute
// Member of        : TupleGeo.General.dll
// Description      : Defines a custom attribute used to add a localizable descriptive information.
// Created by       : 22/05/2015, 21:48, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

#endregion

namespace TupleGeo.General.Attributes {

  /// <summary>
  /// A custom attribute used to add a localizable descriptive information.
  /// </summary>
  [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
  public sealed class LocalizableDescriptionAttribute : System.ComponentModel.DescriptionAttribute {

    #region Member Variables

    private readonly Type _resourcesType;
    private bool _isLocalized;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a <see cref="LocalizableDescriptionAttribute"/>.
    /// </summary>
    /// <param name="description">The description that the <see cref="LocalizableDescriptionAttribute"/> sets.</param>
    /// <param name="resourcesType">Type of the resources.</param>
    public LocalizableDescriptionAttribute(string description, Type resourcesType)
      : base(description) {
      _resourcesType = resourcesType;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the string value from the resources.
    /// </summary>
    /// <returns>The description stored in this attribute.</returns>
    public override string Description {
      get {
        if (!_isLocalized) {
          ResourceManager resourceManager = _resourcesType.InvokeMember(
            "ResourceManager",
            BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            null,
            new object[] { }
          ) as ResourceManager;

          CultureInfo culture = _resourcesType.InvokeMember(
            "Culture",
            BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic,
            null,
            null,
            new object[] {}
          ) as CultureInfo;

          _isLocalized = true;

          if (resourceManager != null) {
            DescriptionValue = resourceManager.GetString(DescriptionValue, culture);
          }
        }

        return DescriptionValue;
      }
    }
    
    #endregion

  }

}
