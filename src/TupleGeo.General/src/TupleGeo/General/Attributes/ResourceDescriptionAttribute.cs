
#region Header
// Title Name       : ResourceDescriptionAttribute
// Member of        : TupleGeo.General.dll
// Description      : Defines a custom attribute used to add a localizable description loaded from a Resource file.
// Created by       : 27/05/2015, 18:02, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Comments         : Code adapted from: http://www.codeproject.com/Articles/29495/Binding-and-Using-Friendly-Enums-in-WPF
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
  /// A custom attribute used to add a localizable description.
  /// </summary>
  [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
  public sealed class ResourceDescriptionAttribute : System.ComponentModel.DescriptionAttribute {

    #region Member Variables

    private bool _isLocalized;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes a <see cref="ResourceDescriptionAttribute"/>.
    /// </summary>
    /// <param name="description">The description that the attribute sets.</param>
    /// <param name="resourcesType">The Type of the resources.</param>
    public ResourceDescriptionAttribute(string description, Type resourcesType)
      : base(description) {
      _resourcesType = resourcesType;
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Gets the string value from the resources.
    /// </summary>
    /// <returns>A string containing the description stored in this attribute.</returns>
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

    private readonly Type _resourcesType;
    
    /// <summary>
    /// Gets the Resources Type.
    /// </summary>
    public Type ResourcesType {
      get {
        return _resourcesType;
      }
    }

    #endregion

  }

}
