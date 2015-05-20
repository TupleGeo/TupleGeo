
#region Header
// Title Name       : XmlSerializer
// Member of        : TupleGeo.General.dll
// Description      : Provides methods to serialize and deserialize objects to or from xml.
// Created by       : 16/02/2009, 20:08, Vasilis Vlastaras.
// Updated by       : 22/02/2011, 21:45, Vasilis Vlastaras.
//                    1.0.1 - Removed System.Linq to make the source file compatible with .NET Framework 2.0
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
using System.Xml.Serialization;

#endregion

namespace TupleGeo.General.Serialization {

  /// <summary>
  /// Provides methods to serialize and deserialize objects to or from xml.
  /// </summary>
  public static class XmlSerializer {

    #region Public Methods

    /// <summary>
    /// Serializes the specified object in to the specified file.
    /// </summary>
    /// <param name="object">The object to serialize in the file.</param>
    /// <param name="filepath">The path and file used to serialize the object.</param>
    public static void Serialize(object @object, string filepath) {
      
      StreamWriter writer = null;
      
      try {
        writer = new StreamWriter(filepath);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(writer, @object);
        writer.Close();
      }
      catch (Exception) {
        if (writer != null) {
          writer.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to the specified file.
    /// </summary>
    /// <param name="object">The object to serialize in the file.</param>
    /// <param name="filepath">The path and file used to serialize the object.</param>
    /// <param name="encoding">The <see cref="Encoding"/> used to write in to the file.</param>
    public static void Serialize(object @object, string filepath, Encoding encoding) {

      StreamWriter writer = null;
      
      try {
        writer = new StreamWriter(filepath, false, encoding);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(writer, @object);
        writer.Close();
      }
      catch (Exception) {
        if (writer != null) {
          writer.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="object">The object to serialize in the <see cref="Stream"/>.</param>
    /// <param name="stream">The <see cref="Stream"/> used to write the serialized object.</param>
    public static void Serialize(object @object, Stream stream) {
      
      StreamWriter writer = null;
      
      try {
        writer = new StreamWriter(stream);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(writer, @object);
        writer.Close();
      }
      catch (Exception) {
        if (writer != null) {
          writer.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="object">The object to serialize in the <see cref="Stream"/>.</param>
    /// <param name="stream">The <see cref="Stream"/> used to write the serialized object.</param>
    /// <param name="encoding">The <see cref="Encoding"/> used to write the serialized object.</param>
    public static void Serialize(object @object, Stream stream, Encoding encoding) {
      
      StreamWriter writer = null;
      
      try {
        writer = new StreamWriter(stream, encoding);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(writer, @object);
        writer.Close();
      }
      catch (Exception) {
        if (writer != null) {
          writer.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to a <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="object">The object to serialize in to the <see cref="MemoryStream"/>.</param>
    /// <returns>A <see cref="MemoryStream"/> containing the serialized object.</returns>
    public static MemoryStream Serialize(object @object) {

      MemoryStream memStream = null;
      
      try {
        memStream = new MemoryStream();
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(memStream, @object);
      }
      catch (Exception) {
        memStream.Dispose();
        throw;
      }

      return memStream;

    }

    /// <summary>
    /// Serializes the specified object in to a <see cref="string"/>.
    /// </summary>
    /// <param name="object">The object to serialize.</param>
    /// <param name="serialized">The string that will contain the serialized object.</param>
    /// <returns>A <see cref="string"/> containing the serialized object.</returns>
    /// <remarks>
    /// <para>
    /// The method uses <see cref="UTF8Encoding"/> to serialize the object.
    /// </para>
    /// <para>
    /// The method might not return the entire object graph in to a serialized string.
    /// This is caused by the internal <see cref="MemoryStream"/> byte buffer length used
    /// in the serialization process of this method.
    /// </para>
    /// </remarks>
    public static void Serialize(object @object, out string serialized) {
      
      MemoryStream memStream = null;

      try {
        memStream = new MemoryStream();
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(memStream, @object);
        byte[] bytes = memStream.GetBuffer();
        UTF8Encoding encoding = new UTF8Encoding();
        serialized = encoding.GetString(bytes);
      }
      catch (Exception) {
        memStream.Dispose();
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to a <see cref="string"/>.
    /// </summary>
    /// <param name="object">The object to serialize.</param>
    /// <param name="serialized">The string that will contain the serialized object.</param>
    /// <param name="encoding">The <see cref="Encoding"/> used to serialize the object.</param>
    /// <returns>A <see cref="string"/> containing the serialized object.</returns>
    /// <remarks>
    /// <para>
    /// The method might not return the entire object graph in to a serialized string.
    /// This is caused by the internal <see cref="MemoryStream"/> byte buffer length used
    /// in the serialization process of this method.
    /// </para>
    /// </remarks>
    public static void Serialize(object @object, out string serialized, Encoding encoding) {
      
      MemoryStream memStream = null;

      try {
        memStream = new MemoryStream();
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(memStream, @object);
        byte[] bytes = memStream.GetBuffer();
        serialized = encoding.GetString(bytes);
      }
      catch (Exception) {
        if (memStream != null) {
          memStream.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Serializes the specified object in to a <see cref="string"/>.
    /// </summary>
    /// <param name="object">The object to serialize.</param>
    /// <param name="buffer">The buffer in to which the object will be serialized.</param>
    public static void Serialize(object @object, ref byte[] buffer) {
      
      MemoryStream memStream = null;

      try {
        memStream = new MemoryStream(buffer, true);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(@object.GetType());
        serializer.Serialize(memStream, @object);
        memStream.Close();
      }
      catch (Exception) {
        if (memStream != null) {
          memStream.Close();
        }
        throw;
      }

    }

    /// <summary>
    /// Deserializes an object with the specified <see cref="Type"/> from the specified file.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the object to be deserialized.</param>
    /// <param name="filepath">The path and file used to deserialize the object.</param>
    /// <returns>The deserialized object.</returns>
    public static object Deserialize(Type type, string filepath) {
      
      FileStream fileStream = null;
      object o = null;

      try {
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
        fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
        o = serializer.Deserialize(fileStream);
        fileStream.Close();
      }
      catch (Exception) {
        if (fileStream != null) {
          fileStream.Close();
        }
        throw;
      }

      return o;

    }

    /// <summary>
    /// Deserializes an object of the specified <see cref="Type"/>
    /// from the specified <see cref="Stream"/>.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the object to be deserialized.</param>
    /// <param name="object">
    /// The <see cref="Stream"/> containing the object to be deserialized.
    /// </param>
    /// <returns>The deserialized object.</returns>
    public static object Deserialize(Type type, Stream @object) {
      System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
      return serializer.Deserialize(@object);
    }
        
    /// <summary>
    /// Deserializes an object of the specified <see cref="Type"/>
    /// from the specified <see cref="string"/>.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the object to deserialize.</param>
    /// <param name="object">
    /// The <see cref="string"/> containing the object to be deserialized.
    /// </param>
    /// <param name="encoding">
    /// The <see cref="Encoding"/> that will be used during the deserialization process.
    /// </param>
    /// <returns>The deserialized object.</returns>
    public static object Deserialize(Type type, string @object, Encoding encoding) {
      
      object o = null;
      MemoryStream memStream = null;

      try {
        byte[] bytes = encoding.GetBytes(@object);
        memStream = new MemoryStream(bytes);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
        o = serializer.Deserialize(memStream);
        memStream.Close();
      }
      catch (Exception) {
        if (memStream != null) {
          memStream.Close();
        }
        throw;
      }

      return o;

    }

    /// <summary>
    /// Deserializes an object of the specified <see cref="Type"/>
    /// from the specified <see cref="byte"/> array.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> of the object to deserialize.</param>
    /// <param name="object">
    /// The <see cref="byte"/> array containing the object to be deserialized.
    /// </param>
    /// <param name="encoding">
    /// The <see cref="Encoding"/> that will be used during the deserialization process.
    /// </param>
    /// <returns>The deserialized object.</returns>
    public static object Deserialize(Type type, byte[] @object, Encoding encoding) {
      
      object o = null;
      MemoryStream memStream = null;
      
      try {
        memStream = new MemoryStream(@object);
        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
        o = serializer.Deserialize(memStream);
        memStream.Close();
      }
      catch (Exception) {
        if (memStream != null) {
          memStream.Close();
        }
        throw;
      }

      return o;

    }

    #endregion

  }

}
