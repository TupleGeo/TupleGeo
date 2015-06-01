
#region Header
// Title Name       : GreekHelper
// Member of        : TupleGeo.General.Text.Greek.dll
// Description      : Provides helper methods for manipulating Greek strings.
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

namespace TupleGeo.General.Text.Greek {

  /// <summary>
  /// Provides helper methods for manipulating Greek strings.
  /// </summary>
  public static class GreekHelper {
    
    #region Member Variables

    private static Dictionary<char, char> greekPunctuatedDictionary;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="GreekHelper"/>.
    /// </summary>
    static GreekHelper() {
      greekPunctuatedDictionary = new Dictionary<char, char>();

      // Uppercase characters.
      greekPunctuatedDictionary.Add('Ά', 'Α');
      greekPunctuatedDictionary.Add('Έ', 'Ε');
      greekPunctuatedDictionary.Add('Ή', 'Η');
      greekPunctuatedDictionary.Add('Ί', 'Ι');
      greekPunctuatedDictionary.Add('Ό', 'Ο');
      greekPunctuatedDictionary.Add('Ύ', 'Υ');
      greekPunctuatedDictionary.Add('Ϊ', 'Ι');
      greekPunctuatedDictionary.Add('Ϋ', 'Υ');

      // Lowercase characters.
      greekPunctuatedDictionary.Add('ά', 'α');
      greekPunctuatedDictionary.Add('έ', 'ε');
      greekPunctuatedDictionary.Add('ή', 'η');
      greekPunctuatedDictionary.Add('ί', 'ι');
      greekPunctuatedDictionary.Add('ό', 'ο');
      greekPunctuatedDictionary.Add('ύ', 'υ');
      greekPunctuatedDictionary.Add('ώ', 'ω');
      greekPunctuatedDictionary.Add('ϊ', 'ι');
      greekPunctuatedDictionary.Add('ϋ', 'υ');

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
    /// Converts the punctuated Greek characters of a string to non punctuated Greek characters.
    /// </summary>
    /// <param name="greek">
    /// The string that its chars will be converted.
    /// </param>
    /// <returns>A <see cref="string"/> containing non punctuated Greek characters.</returns>
    public static string ToNonPunctuatedChars(string greek) {

      if (string.IsNullOrEmpty(greek)) {
        throw new ArgumentException("String could not be NULL or Empty.", "greek");
      }

      char[] chars = new char[greek.Length];

      for (int i = 0; i < greek.Length; i++) {
        try {
          chars[i] = greekPunctuatedDictionary[greek[i]];
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
