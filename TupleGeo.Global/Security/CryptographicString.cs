
#region Header
// Title Name       : GryptographicString
// Member of        : TupleGeo.Global.dll
// Description      : Defines a cryptographic string object.
// Created by       : 18/03/2009, 18:34, Source code in public domain.
// Updated by       : 22/02/2011, 21:51, Source code in public domain.
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
using System.Security.Cryptography;
using System.Text;
using TupleGeo.Global.Properties;

#endregion

namespace TupleGeo.Global.Security {

  /// <summary>
  /// Defines a cryptographic string object.
  /// </summary>
  public sealed class CryptographicString {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CryptographicString"/>.
    /// </summary>
    private CryptographicString() {

    }
    
    #endregion

    #region Public Properties

    private static byte[] _key = null;

    /// <summary>
    /// Gets / Sets the key used for encrypting / decrypting the <see cref="System.String"/>.
    /// </summary>
    public static byte[] Key {
      get {
        return _key;
      }
      set {
        _key = value;
      }
    }

    private static byte[] _initializationVector = null;

    /// <summary>
    /// Gets / Sets the initialization vector.
    /// </summary>
    public static byte[] InitializationVector {
      get {
        return _initializationVector;
      }
      set {
        _initializationVector = value;
      }
    }
        
    #endregion

    #region Public Methods

    /// <summary>
    /// Encrypts a <see cref="System.String"/>.
    /// </summary>
    /// <param name="original">The <see cref="System.String"/> to be encrypted.</param>
    /// <returns>An encrypted <see cref="System.String"/>.</returns>
    public static string Encrypt(string original) {

      // Encode data string to be stored in memory.
      byte[] originalStringAsBytes = Encoding.ASCII.GetBytes(original);
      byte[] originalBytes = { };

      // Create a MemoryStream to contain output.
      using (MemoryStream memStream = new MemoryStream(originalStringAsBytes.Length)) {
        using (RijndaelManaged rijndael = new RijndaelManaged()) {

          // Generate and save secret key and initialization vector.
          GenerateRijndaelSecretKey(rijndael);
          GenerateRijndaelSecretInitilizationVector(rijndael);

          if (_key == null || _initializationVector == null) {
            throw new NullReferenceException(
              Resources.Security_CryptographicString_ExceptionNullKeyOrInitializationVector
            );
          }

          // Create encryptor and stream objects.
          using (
            ICryptoTransform rijndaelTransform = rijndael.CreateEncryptor(
              (byte[])_key.Clone(),
              (byte[])_initializationVector.Clone()
            )
          ) {
            using (
              CryptoStream cryptoStream = new CryptoStream(
                memStream,
                rijndaelTransform,
                CryptoStreamMode.Write
              )
            ) {
              // Write encrypted data to the MemoryStream.
              cryptoStream.Write(originalStringAsBytes, 0, originalStringAsBytes.Length);
              cryptoStream.FlushFinalBlock();
              originalBytes = memStream.ToArray();
            }
          }

        }
      }

      // Convert encrypted string.
      string encrypted = Convert.ToBase64String(originalBytes);

      return encrypted;

    }

    /// <summary>
    /// Decrypts a <see cref="System.String"/>.
    /// </summary>
    /// <param name="encrypted">The <see cref="System.String"/> to be decrypted.</param>
    /// <returns>A decrypted <see cref="System.String"/>.</returns>
    public static string Decrypt(string encrypted) {

      // Convert encrypted string.
      byte[] encryptedStringAsBytes = Convert.FromBase64String(encrypted);
      byte[] initialText = new byte[encryptedStringAsBytes.Length];

      using (RijndaelManaged rijndael = new RijndaelManaged()) {
        using (MemoryStream memStream = new MemoryStream(encryptedStringAsBytes)) {

          if (_key == null || _initializationVector == null) {
            throw new NullReferenceException(
              Resources.Security_CryptographicString_ExceptionNullKeyOrInitializationVector
            );
          }

          // Create decryptor and stream objects.
          using (ICryptoTransform rijndaelTransform = rijndael.CreateDecryptor((byte[])_key.Clone(), (byte[])_initializationVector.Clone())) {
            using (CryptoStream cryptoStream = new CryptoStream(memStream, rijndaelTransform, CryptoStreamMode.Read)) {

              // Read in decrypted string as byte[].
              cryptoStream.Read(initialText, 0, initialText.Length);

            }
          }

        }
      }

      // Convert byte[] to string.
      string decrypted = Encoding.ASCII.GetString(initialText).TrimEnd(new char[1] { '\0' });

      return decrypted;

    }
    
    #endregion
    
    #region Private Procedures

    /// <summary>
    /// Generates a Rijndael symmetric secret key.
    /// </summary>
    /// <param name="rijndaelProvider">The <see cref="RijndaelManaged"/> provider.</param>
    private static void GenerateRijndaelSecretKey(RijndaelManaged rijndaelProvider) {
      if (_key == null) {
        rijndaelProvider.KeySize = 256;
        rijndaelProvider.GenerateKey();
        _key = rijndaelProvider.Key;
      }
    }

    /// <summary>
    /// Generates a Rijndael initialization vector.
    /// </summary>
    /// <param name="rijndaelProvider">The <see cref="RijndaelManaged"/> provider.</param>
    private static void GenerateRijndaelSecretInitilizationVector(RijndaelManaged rijndaelProvider) {
      if (_initializationVector == null) {
        rijndaelProvider.GenerateIV();
        _initializationVector = rijndaelProvider.IV;
      }
    }

    #endregion
    
  }

}
