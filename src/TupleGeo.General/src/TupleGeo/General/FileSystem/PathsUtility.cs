
#region Header
// Title Name       : PathsUtility
// Member of        : TupleGeo.General.dll
// Description      : The PathsUtility is a static class providing common
//                    utilities for managing paths.
// Created by       : 17/02/2009, 20:19, Vasilis Vlastaras.
// Updated by       : 02/06/2009, 13:02, Vasilis Vlastaras.
//                    1.0.1 - Added method GetParentPath.
//                  : 22/02/2011, 22:35, Vasilis Vlastaras.
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
using System.Text;

#endregion

namespace TupleGeo.General.FileSystem {

  /// <summary>
  /// The PathsUtility is a static class providing common utilities for managing paths.
  /// </summary>
  public static class PathsUtility {

    #region Public Methods

    /// <summary>
    /// Adds a backslash to the specified path.
    /// </summary>
    /// <param name="path">The string representing the path.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="path"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>A string representing the path with the added backslash.</returns>
    /// <remarks>If the path ends with a backslash the method returns the path as it is.</remarks>
    public static string AddBackslashToPath(string path) {
      if (string.IsNullOrEmpty(path)) {
        throw new ArgumentException("string could not be NULL or Empty.", "path");
      }
      
      if (path.LastIndexOf("\\", StringComparison.OrdinalIgnoreCase) == path.Length - 1) {
        return path;
      }
      else {
        return path + "\\";
      }
    }

    /// <summary>
    /// Adds a slash to the specified path.
    /// </summary>
    /// <param name="path">The string representing the path.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="path"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>A string representing the path with the added slash.</returns>
    /// <remarks>If the path ends with a slash the method returns the path as it is.</remarks>
    public static string AddSlashToPath(string path) {
      if (string.IsNullOrEmpty(path)) {
        throw new ArgumentException("string could not be NULL or Empty.", "path");
      }

      if (path.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) == path.Length - 1) {
        return path;
      }
      else {
        return path + "/";
      }
    }

    /// <summary>
    /// Gets the parent path from a given path.
    /// </summary>
    /// <param name="path">The path to get its parent.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="path"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>A <see cref="string"/> storing the parent path.</returns>
    /// <remarks>
    /// In case the path is the full path to a file, the path returned is that storing the file.
    /// </remarks>
    public static string GetParentPath(string path) {
      if (string.IsNullOrEmpty(path)) {
        throw new ArgumentException("string could not be NULL or Empty.", "path");
      }

      char[] pathDelimiters = new char[2] { '\\', '/' };
      string parentPath = "";

      // Check if last character is slash or backslash.
      if (path.EndsWith("\\", StringComparison.OrdinalIgnoreCase) || path.EndsWith("//", StringComparison.OrdinalIgnoreCase)) {
        int index = path.Substring(0, path.Length - 2).LastIndexOfAny(pathDelimiters);
        if (index > -1) {
          parentPath = path.Substring(0, index);
        }
      }
      else {
        int index = path.LastIndexOfAny(pathDelimiters);
        if (index > -1) {
          parentPath = path.Substring(0, index);
        }
      }

      return parentPath;
    }

    /// <summary>
    /// Gets the file extension from a given path.
    /// </summary>
    /// <param name="path">The path from which to extract the file extension.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="path"/> is <c>null</c> or <see cref="string.Empty"/>.
    /// </exception>
    /// <returns>A <see cref="string"/> storing the file extension.</returns>
    /// <remarks>
    /// In case file extension can not be retrieved, a <see cref="string.Empty"/> is returned instead.
    /// </remarks>
    public static string GetFileExtension(string path) {
      if (string.IsNullOrEmpty(path)) {
        throw new ArgumentException("string could not be NULL or Empty.", "path");
      }

      string extension = string.Empty;

      if (!string.IsNullOrEmpty(path)) {
        string parentPath = PathsUtility.GetParentPath(path);

        if (!string.IsNullOrEmpty(parentPath)) {
          string fileName = path.Replace(parentPath, "");

          if (!string.IsNullOrEmpty(fileName)) {
            int iIndex = fileName.LastIndexOf('.');

            if (iIndex > -1) {
              extension = fileName.Substring(iIndex);
            }
          }
        }
      }

      return extension;
    }

    #endregion

  }

}
