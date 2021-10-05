
#region Header
// Title Name       : MimeTypesHelper
// Member of        : TupleGeo.General.dll
// Description      : A helper class for mime types.
// Created by       : 16/03/2010, 18:35, Vasilis Vlastaras.
// Updated by       : 23/02/2011, 17:54, Vasilis Vlastaras.
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
using System.IO;
using System.Text;
using Microsoft.Win32;

#endregion

namespace TupleGeo.General.Utilities {

  /// <summary>
  /// A helper class for mime types.
  /// </summary>
  public static class MimeTypesHelper {

    #region Public Methods

    /// <summary>
    /// Gets the mime type using a file extension.
    /// </summary>
    /// <param name="fileExtension">The extension of a file.</param>
    /// <returns>A string indicating the mime type.</returns>
    /// <remarks>
    /// The method uses the windows registry to match file extensions to known mime types.
    /// </remarks>
    public static string GetMimeType(string fileExtension) {
      string mimeType = "application/unknown";
      // TODO: This needs to be moved to another assembly (Windows only) with a reference to 'Microsoft.Win32' DLL to allow for the method to work in .NET5
      if (!string.IsNullOrEmpty(fileExtension)) {
        RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(fileExtension);

        if (regKey != null && regKey.GetValue("Content Type") != null) {
          mimeType = regKey.GetValue("Content Type").ToString();
        }
      }
      
      return mimeType;
    }

    #endregion

  }

}
