
#region Header
// Title Name       : StringExtensions
// Member of        : TupleGeo.General.dll
// Description      : Contains a set of extension methods for the System.String type.
// Created by       : 15/05/2009, 02:39, Vasilis Vlastaras.
// Updated by       : 
// Version          : 1.0.0
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace TupleGeo.General {

  /// <summary>
  /// Contains a set of extension methods for the <see cref="System.String"/> type.
  /// </summary>
  public static class StringExtensions {

    #region Member Variables

    private static Dictionary<char, char> greekNormalizedChars;
    //private static int iCounter = 0;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="StringExtensions"/>.
    /// </summary>
    static StringExtensions() {
      greekNormalizedChars = new Dictionary<char, char>();

      greekNormalizedChars.Add('Ά', 'Α');
      greekNormalizedChars.Add('Έ', 'Ε');
      greekNormalizedChars.Add('Ή', 'Η');
      greekNormalizedChars.Add('Ί', 'Ι');
      greekNormalizedChars.Add('Ό', 'Ο');
      greekNormalizedChars.Add('Ύ', 'Υ');
      greekNormalizedChars.Add('Ϊ', 'Ι');
      greekNormalizedChars.Add('Ϋ', 'Υ');

      greekNormalizedChars.Add('ά', 'α');
      greekNormalizedChars.Add('έ', 'ε');
      greekNormalizedChars.Add('ή', 'η');
      greekNormalizedChars.Add('ί', 'ι');
      greekNormalizedChars.Add('ό', 'ο');
      greekNormalizedChars.Add('ύ', 'υ');
      greekNormalizedChars.Add('ώ', 'ω');
      greekNormalizedChars.Add('ϊ', 'ι');
      greekNormalizedChars.Add('ϋ', 'υ');

      //greekNormalizedChars.Add('Α', 'Α');
      //greekNormalizedChars.Add('Β', 'Β');
      //greekNormalizedChars.Add('Γ', 'Γ');
      //greekNormalizedChars.Add('Δ', 'Δ');
      //greekNormalizedChars.Add('Ε', 'Ε');
      //greekNormalizedChars.Add('Ζ', 'Ζ');
      //greekNormalizedChars.Add('Η', 'Η');
      //greekNormalizedChars.Add('Θ', 'Θ');
      //greekNormalizedChars.Add('Ι', 'Ι');
      //greekNormalizedChars.Add('Κ', 'Κ');
      //greekNormalizedChars.Add('Λ', 'Λ');
      //greekNormalizedChars.Add('Μ', 'Μ');
      //greekNormalizedChars.Add('Ν', 'Ν');
      //greekNormalizedChars.Add('Ξ', 'Ξ');
      //greekNormalizedChars.Add('Ο', 'Ο');
      //greekNormalizedChars.Add('Π', 'Π');
      //greekNormalizedChars.Add('Ρ', 'Ρ');
      //greekNormalizedChars.Add('Σ', 'Σ');
      //greekNormalizedChars.Add('Τ', 'Τ');
      //greekNormalizedChars.Add('Υ', 'Υ');
      //greekNormalizedChars.Add('Φ', 'Φ');
      //greekNormalizedChars.Add('Χ', 'Χ');
      //greekNormalizedChars.Add('Ψ', 'Ψ');
      //greekNormalizedChars.Add('Ω', 'Ω');

      //greekNormalizedChars.Add('α', 'α');
      //greekNormalizedChars.Add('β', 'β');
      //greekNormalizedChars.Add('γ', 'γ');
      //greekNormalizedChars.Add('δ', 'δ');
      //greekNormalizedChars.Add('ε', 'ε');
      //greekNormalizedChars.Add('ζ', 'ζ');
      //greekNormalizedChars.Add('η', 'η');
      //greekNormalizedChars.Add('θ', 'θ');
      //greekNormalizedChars.Add('ι', 'ι');
      //greekNormalizedChars.Add('κ', 'κ');
      //greekNormalizedChars.Add('λ', 'λ');
      //greekNormalizedChars.Add('μ', 'μ');
      //greekNormalizedChars.Add('ν', 'ν');
      //greekNormalizedChars.Add('ξ', 'ξ');
      //greekNormalizedChars.Add('ο', 'ο');
      //greekNormalizedChars.Add('π', 'π');
      //greekNormalizedChars.Add('ρ', 'ρ');
      //greekNormalizedChars.Add('σ', 'σ');
      //greekNormalizedChars.Add('τ', 'τ');
      //greekNormalizedChars.Add('υ', 'υ');
      //greekNormalizedChars.Add('φ', 'φ');
      //greekNormalizedChars.Add('χ', 'χ');
      //greekNormalizedChars.Add('ψ', 'ψ');
      //greekNormalizedChars.Add('ω', 'ω');
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Normalizes the punctuated Greek characters of a string to non punctuated Greek characters.
    /// </summary>
    /// <param name="greek">
    /// The string which chars will be normalized.
    /// </param>
    /// <returns>A string containing non punctuated Greek characters.</returns>
    public static string NormalizeGreekChars(this string greek) {
      char[] chars = new char[greek.Length];

      for (int i = 0; i < greek.Length; i++) {
        try {
          chars[i] = greekNormalizedChars[greek[i]];
        }
        catch (KeyNotFoundException) {
          chars[i] = greek[i];
        }
      }

      return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(chars));
    }

    #endregion

  }

}
