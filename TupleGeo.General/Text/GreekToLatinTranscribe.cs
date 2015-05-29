
#region Header
// Title Name       : GreekToLatinTranscribe
// Member of        : TupleGeo.General.dll
// Description      : Transcribes from Greek to Latin according to ELOT specification.
// Created by       : 06/04/2010, 14:12, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 22:08, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2010 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#endregion

namespace TupleGeo.General.Text {

  /// <summary>
  /// Transcribes from Greek to Latin according to ELOT specification.
  /// </summary>
  public static class GreekToLatinTranscribe {

    #region Member Variables
    
    private static string CharReadAhead = "αάγεέημνόο";

    private static string CharVoiced = "αάβγδεέζηήιίϊΐλμνοόρυύϋΰωώ";
    //private static string CharVoiceless = "θκξπσςτφχψ";

    private static Dictionary<char, string> MapSingleDictionary = MapSingle();
    private static Dictionary<string, string> MapDoubleDictionary = MapDouble();

    private static Dictionary<string, string> MapWordStartDictionary = MapWordStart();
    private static Dictionary<string, string> MapWordMiddleDictionary = MapWordMiddle();

    private static Dictionary<string, string> MapNextVoicedDictionary = ΜapNextVoiced();
    private static Dictionary<string, string> MapNextVoicelessDictionary = ΜapNextVoiceless();

    private static CultureInfo _locale = new CultureInfo("el-GR");

    #endregion

    #region Public Methods
    
    /// <summary>
    /// Converts a string in Greek to a Latin one using upper case characters.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>A <see cref="string"/> with the Latin interpretation of the string in Greek.</returns>
    public static string Convert(string input) {
      return Convert(input, GreekToLatinConversionMode.Uppercase);
    }
    
    /// <summary>
    /// Converts a string in Greek to a Latin one according to the specified conversion mode.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="mode">The <see cref="GreekToLatinConversionMode">mode</see> used to convert the string.</param>
    /// <returns>A <see cref="string"/> with the Latin interpretation of the string in Greek.</returns>
    public static string Convert(string input, GreekToLatinConversionMode mode) {
      if (input == null) {
        return null;
      }

      if (mode != GreekToLatinConversionMode.Mixedcase) {
        input = input.ToLower(_locale);
      }

      StringBuilder result = new StringBuilder();
      bool wordStart = true;
      for (int i = 0; i < input.Length; i++) {
        char current = input[i];

        string replacement = null;
        if (ReadAhead(current) && i + 1 < input.Length) {
          string str = "" + current + input[i + 1];
          replacement = Replace(str, wordStart, mode);
          if (replacement == null) {
            // Check if next incoming is voiced.
            bool voiced = false;
            if (i + 2 < input.Length) {
              voiced = CharVoiced.IndexOf(input[i + 2]) >= 0;
            }

            if (voiced) {
              MapNextVoicedDictionary.TryGetValue(str, out replacement);
            }
            else {
              MapNextVoicelessDictionary.TryGetValue(str, out replacement);
            }
          }
        }

        if (replacement == null) {
          result.Append(Replace(current, mode));
          wordStart = !char.IsLetter(current);
        }
        else {
          result.Append(replacement);
          wordStart = !char.IsLetter(input[++i]);
        }

      }

      if (mode == GreekToLatinConversionMode.Uppercase) {
        return result.ToString().ToUpper(_locale);
      }
      else if (mode == GreekToLatinConversionMode.Lowercase) {
        return result.ToString().ToLower(_locale);
      }

      return result.ToString();
    }
    
    #endregion

    #region Private Procedures
    
    /// <summary>
    /// Reads ahead.
    /// </summary>
    /// <param name="current">The current <see cref="char"/>.</param>
    /// <returns>Returns a <see cref="bool"/>.</returns>
    private static bool ReadAhead(char current) {
      return CharReadAhead.IndexOf(char.ToLower(current, CultureInfo.InvariantCulture)) >= 0;
    }

    /// <summary>
    /// Replaces a Greek <see cref="char"/> with a Latin one.
    /// </summary>
    /// <param name="current">The <see cref="char"/> to replace.</param>
    /// <param name="mode">
    /// The <see cref="GreekToLatinConversionMode">mode</see> used for the replacement.
    /// </param>
    /// <returns>A <see cref="string"/> containing the replaced <see cref="char"/>.</returns>
    private static string Replace(char current, GreekToLatinConversionMode mode) {
      string result = null;
      if (mode == GreekToLatinConversionMode.Mixedcase) {
        bool upperCase = char.IsUpper(current);
        MapSingleDictionary.TryGetValue(char.ToLower(current, CultureInfo.InvariantCulture), out result);
        if (result != null && upperCase) {
          result = char.ToUpper(result[0], CultureInfo.InvariantCulture) + result.Substring(1);
        }
      }
      else {
        MapSingleDictionary.TryGetValue(current, out result);
      }

      if (result == null) {
        return current.ToString();
      }

      return result;
    }

    /// <summary>
    /// Replaces a Greek <see cref="char"/> with a Latin one.
    /// </summary>
    /// <param name="current">The <see cref="string"/> to replace.</param>
    /// <param name="wordStart">
    /// Indicates whether this <see cref="string"/> is the beginning of the word to be converted or not.
    /// </param>
    /// <param name="mode">
    /// The <see cref="GreekToLatinConversionMode">mode</see> used for the replacement.
    /// </param>
    /// <returns>A <see cref="string"/> containing the replaced <see cref="string"/>.</returns>
    private static string Replace(string current, bool wordStart, GreekToLatinConversionMode mode) {
      string result = null;
      if (mode == GreekToLatinConversionMode.Mixedcase) {
        bool upperCase = char.IsUpper(current[0]);
        string currentLow = current.ToLower(_locale);
        MapDoubleDictionary.TryGetValue(currentLow, out result);

        if (result == null) {
          if (wordStart) {
            MapWordStartDictionary.TryGetValue(currentLow, out result);
          }
          else {
            MapWordMiddleDictionary.TryGetValue(currentLow, out result);
          }
        }

        if (result != null && upperCase) {
          result = char.ToUpper(result[0], CultureInfo.InvariantCulture) + result.Substring(1);
        }
      }
      else {
        MapDoubleDictionary.TryGetValue(current, out result);
      }

      if (result == null) {
        if (wordStart) {
          MapWordStartDictionary.TryGetValue(current, out result);
        }
        else {
          MapWordMiddleDictionary.TryGetValue(current, out result);
        }
      }

      return result;
    }

    /// <summary>
    /// Creates a <see cref="Dictionary{Char, String}"/> storing the mapping of Greek characters to Latin strings.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{Char, String}"/> storing the specified mapping.
    /// </returns>
    private static Dictionary<char, string> MapSingle() {
      Dictionary<char, string> result = new Dictionary<char, string>();
      
      result.Add('α', "a");
      result.Add('ά', "a");
      result.Add('β', "v");
      result.Add('γ', "g");
      result.Add('δ', "d");
      result.Add('ε', "e");
      result.Add('έ', "e");
      result.Add('ζ', "z");
      result.Add('η', "i");
      result.Add('ή', "i");
      result.Add('θ', "th");
      result.Add('ι', "i");
      result.Add('ί', "i");
      result.Add('ϊ', "i");
      result.Add('ΐ', "i");
      result.Add('κ', "k");
      result.Add('λ', "l");
      result.Add('μ', "m");
      result.Add('ν', "n");
      result.Add('ξ', "x");
      result.Add('ο', "o");
      result.Add('ό', "o");
      result.Add('π', "p");
      result.Add('ρ', "r");
      result.Add('σ', "s");
      result.Add('ς', "s");
      result.Add('τ', "t");
      result.Add('υ', "y");
      result.Add('ύ', "y");
      result.Add('ϋ', "y");
      result.Add('ΰ', "y");
      result.Add('φ', "f");
      result.Add('χ', "ch");
      result.Add('ψ', "ps");
      result.Add('ω', "o");
      result.Add('ώ', "o");
      
      return result;
    }

    /// <summary>
    /// Creates a <see cref="Dictionary{String, String}"/> storing the
    /// mapping of Greek double character strings to Latin strings.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{String, String}"/> storing the specified mapping.
    /// </returns>
    private static Dictionary<string, string> MapDouble() {
      Dictionary<string, string> result = new Dictionary<string, string>();

      result.Add("αϊ", "ai");
      result.Add("άι", "ai");
      result.Add("αι", "ai");

      result.Add("γγ", "ng");
      result.Add("γκ", "gk");
      result.Add("γξ", "nx");
      result.Add("γχ", "nch");

      result.Add("εϊ", "ei");
      result.Add("έι", "ei");
      result.Add("ει", "ei");

      result.Add("οϊ", "oi");
      result.Add("όι", "oi");
      result.Add("οι", "oi");
      result.Add("ου", "ou");
      result.Add("ού", "ou");

      return result;
    }

    /// <summary>
    /// Creates a <see cref="Dictionary{String, String}"/> storing the mapping of Greek
    /// double character strings to Latin strings for those cases that a word starts
    /// with the specified double characters.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{String, String}"/> storing the specified mapping.
    /// </returns>
    private static Dictionary<string, string> MapWordStart() {
      Dictionary<string, string> result = new Dictionary<string, string>();

      result.Add("μπ", "b");
      result.Add("ντ", "d");

      return result;
    }

    /// <summary>
    /// Creates a <see cref="Dictionary{String, String}"/> storing the mapping of Greek
    /// double character strings to Latin strings for those cases that a word has these
    /// double characters somewhere in the middle of its body.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{String, String}"/> storing the specified mapping.
    /// </returns>
    private static Dictionary<string, string> MapWordMiddle() {
      Dictionary<string, string> result = new Dictionary<string, string>();

      result.Add("μπ", "mp");
      result.Add("ντ", "nt");

      return result;
    }

    /// <summary>
    /// Creates a <see cref="Dictionary{String, String}"/> storing the mapping of Greek
    /// double character strings to Latin strings for those cases that are voiced.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{String, String}"/> storing the specified mapping.
    /// </returns>
    private static Dictionary<string, string> ΜapNextVoiced() {
      Dictionary<string, string> result = new Dictionary<string, string>();

      result.Add("αυ", "av");
      result.Add("αύ", "av");
      result.Add("ευ", "ev");
      result.Add("εύ", "ev");
      result.Add("ηυ", "iv");
      result.Add("ηύ", "iv");

      return result;
    }

    
    /// <summary>
    /// Creates a <see cref="Dictionary{String, String}"/> storing the mapping of Greek
    /// double character strings to Latin strings for those cases that are voiceless.
    /// </summary>
    /// <returns>
    /// The <see cref="Dictionary{String, String}"/>
    /// storing the specified mapping.
    /// </returns>
    private static Dictionary<string, string> ΜapNextVoiceless() {
      Dictionary<string, string> result = new Dictionary<string, string>();

      result.Add("αυ", "af");
      result.Add("αύ", "af");
      result.Add("ευ", "ef");
      result.Add("εύ", "ef");
      result.Add("ηυ", "if");
      result.Add("ηύ", "if");

      return result;
    }

    #endregion
    
  }

}
