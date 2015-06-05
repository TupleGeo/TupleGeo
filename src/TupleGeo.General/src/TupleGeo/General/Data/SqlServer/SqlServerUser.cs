
#region Header
// Title Name       : SqlServerUser
// Member of        : TupleGeo.General.dll
// Description      : Defines an SQL Server user as it appears in a connection string.
// Created by       : 12/03/2009, 22:50, Vasilis Vlastaras.
// Updated by       : 23/03/2009, 20:55, Vasilis Vlastaras.
//                    1.0.1 - Added IsPasswordPersisted property.
//                  : 22/02/2011, 23:03, Vasilis Vlastaras.
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
using System.Xml.Serialization;

#endregion

namespace TupleGeo.General.Data.SqlServer {

  /// <summary>
  /// Defines an SQL Server user as it appears in a connection string.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  [XmlRootAttribute(Namespace = "urn:TupleGeo:General:Data:SqlServer", IsNullable = false)]
  public sealed class SqlServerUser {

    #region Public Properties

    private string _userName;

    /// <summary>
    /// Gets / Sets the username.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "username")]
    public string UserName {
      get {
        return _userName;
      }
      set {
        _userName = value;
      }
    }

    private string _password;

    /// <summary>
    /// Gets / Sets the password.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "password")]
    public string Password {
      get {
        return _password;
      }
      set {
        _password = value;
      }
    }

    private bool _isPasswordPersisted = false;

    /// <summary>
    /// Gets / Sets whether the password of the user is persisted or not.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "isPasswordPersisted")]
    public bool IsPasswordPersisted {
      get {
        return _isPasswordPersisted;
      }
      set {
        _isPasswordPersisted = value;
      }
    }
    
    private bool _isPasswordEncrypted = false;

    /// <summary>
    /// Gets / Sets whether the password of the user is encrypted or not.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "isPasswordEncrypted")]
    public bool IsPasswordEncrypted {
      get {
        return _isPasswordEncrypted;
      }
      set {
        _isPasswordEncrypted = value;
      }
    }
    
    #endregion

  }

}
