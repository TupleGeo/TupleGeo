
#region Header
// Title Name       : GryptographicString
// Member of        : TupleGeo.General.dll
// Description      : Defines a cryptographic string object.
// Created by       : 18/03/2009, 18:34, Source code in public domain.
// Updated by       : 22/02/2011, 21:51, Source code in public domain.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
//                  : 01/06/2015, 21:43, Changed class to adhere to Microsoft All Rules code analysis standards.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0.
// Version          : 1.0.2
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
using TupleGeo.General.Properties;

#endregion

namespace TupleGeo.General.Security {

  /// <summary>
  /// Defines a cryptographic string object.
  /// </summary>
  public sealed class CryptographicString {

    #region Member Variables

    private static byte[] _key = null;
    private static byte[] _initializationVector = null;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="CryptographicString"/>.
    /// </summary>
    private CryptographicString() {

    }
    
    #endregion

    #region Public Methods

    /// <summary>
    /// Gets the key used for encrypting / decrypting the <see cref="System.String"/>.
    /// </summary>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static byte[] GetKey() {
      return _key;
    }

    /// <summary>
    /// Sets the key used for encrypting / decrypting the <see cref="System.String"/>.
    /// </summary>
    /// <param name="key">The <see cref="byte"/> array holding the key.</param>
    public static void SetKey(byte[] key) {
      if (key == null) {
        throw new ArgumentNullException("key", "Key could not be NULL.");
      }
      if (key.Length == 0) {
        throw new ArgumentException("Invalid key size.");
      }
      _key = key;
    }

    /// <summary>
    /// Gets the initialization vector.
    /// </summary>
    /// <returns>A <see cref="byte"/> array.</returns>
    public static byte[] GetInitializationVector() {
      return _initializationVector;
    }

    /// <summary>
    /// Sets the initialization vector.
    /// </summary>
    /// <param name="initializationVector">The <see cref="byte"/> array holding the initialization vector.</param>
    public static void SetInitializationVector(byte[] initializationVector) {
      if (initializationVector == null) {
        throw new ArgumentNullException("initializationVector", "Initialization vector could not be NULL.");
      }
      if (initializationVector.Length == 0) {
        throw new ArgumentException("Invalid initialization vector size.");
      }
      _initializationVector = initializationVector;
    }
    
    /// <summary>
    /// Encrypts a <see cref="System.String"/>.
    /// </summary>
    /// <param name="original">The <see cref="System.String"/> to be encrypted.</param>
    /// <returns>An encrypted <see cref="System.String"/>.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
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
            throw new CryptographicStringException(
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    public static string Decrypt(string encrypted) {

      // Convert encrypted string.
      byte[] encryptedStringAsBytes = Convert.FromBase64String(encrypted);
      byte[] initialText = new byte[encryptedStringAsBytes.Length];

      using (RijndaelManaged rijndael = new RijndaelManaged()) {
        using (MemoryStream memStream = new MemoryStream(encryptedStringAsBytes)) {

          if (_key == null || _initializationVector == null) {
            throw new CryptographicStringException(
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
