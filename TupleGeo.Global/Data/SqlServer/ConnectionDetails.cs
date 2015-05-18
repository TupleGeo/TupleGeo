
#region Header
// Title Name       : ConnectionDetails
// Member of        : ErNet.Global.dll
// Description      : The details used to define an SQL Server connection
//                    as they appear in a connection string.
// Created by       : 18/03/2009, 20:40, Vasilis Vlastaras.
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
using System.Xml.Serialization;
using TupleGeo.General.Properties;
using TupleGeo.General.Security;

#endregion

namespace TupleGeo.General.Data.SqlServer {

  /// <summary>
  /// The details used to define an SQL Server connection as they appear in a connection string.
  /// </summary>
  [SerializableAttribute()]
  [XmlTypeAttribute(AnonymousType = false)]
  [XmlRootAttribute(Namespace = "urn:TupleGeo:Global:Data:SqlServer", IsNullable = false)]
  public class ConnectionDetails {

    #region Constructors - Destructors

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ConnectionDetails() {
      this._dataSource = "";
      this._initialCatalogue = "";
      this._isPersistSecurityInfo = true;
      this._sqlServerUserList = new List<SqlServerUser>();
    }

    /// <summary>
    /// Updates the connection details using a connection string.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to updated the ConnectionDetails object.
    /// </param>
    /// <param name="encryptPassword">
    /// Specifies whether the password should be encrypted or not.
    /// </param>
    public ConnectionDetails(string connectionString, bool encryptPassword) {
      FromConnectionString(connectionString, encryptPassword);
    }

    #endregion
    
    #region Public Properties

    private string _dataSource;

    /// <summary>
    /// The name of the data source. It should be the name of the SQL Server hosting machine.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "datasource")]
    public string DataSource {
      get {
        return _dataSource;
      }
      set {
        _dataSource = value;
      }
    }

    private string _initialCatalogue;

    /// <summary>
    /// The name of the initial catalogue. It should be the name of the database.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "initialCatalogue")]
    public string InitialCatalogue {
      get {
        return _initialCatalogue;
      }
      set {
        _initialCatalogue = value;
      }
    }

    private bool _isPersistSecurityInfo;

    /// <summary>
    /// Indicates if the security info is persisted.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "isPersistSecurityInfo")]
    public bool IsPersistSecurityInfo {
      get {
        return _isPersistSecurityInfo;
      }
      set {
        _isPersistSecurityInfo = value;
      }
    }

    private List<SqlServerUser> _sqlServerUserList;

    /// <summary>
    /// Gets / Sets the <see cref="List{SqlServerUser}"/>.
    /// </summary>
    [XmlArrayAttribute(ElementName = "SqlServerUsers")]
    [XmlArrayItem(ElementName = "SqlServerUser", Type = typeof(SqlServerUser))]
    public List<SqlServerUser> SqlServerUserList {
      get {
        return _sqlServerUserList;
      }
      set {
        _sqlServerUserList = value;
      }
    }

    private string _base64Key;

    /// <summary>
    /// Sets the base64 key used to decrypt the password.
    /// </summary>
    /// <remarks>
    /// The key must be a base64 string used as a key feed for the
    /// <see cref="CryptographicString"/> object.
    /// </remarks>
    [XmlIgnoreAttribute()]
    public string Base64Key {
      set {
        _base64Key = value;
      }
    }

    private string _base64InitializationVector;

    /// <summary>
    /// Sets the base64 initialization vector used to decrypt the password.
    /// </summary>
    /// <remarks>
    /// The initialization vector must be a base64 string used as an initialization vector
    /// feed for the <see cref="CryptographicString"/> object.
    /// </remarks>
    [XmlIgnoreAttribute()]
    public string Base64InitializationVector {
      set {
        _base64InitializationVector = value;
      }
    }
    
    #endregion

    #region Public Methods

    /// <summary>
    /// Converts the connection Details in to an SQL Server connection string.
    /// </summary>
    /// <param name="user">
    /// The username that will be used to form the connection string.
    /// </param>
    /// <remarks>
    /// In case the <see cref="SqlServerUserList"/> property is populated with users having
    /// encrypted passwords the <see cref="Base64Key"/> and the
    /// <see cref="Base64InitializationVector"/> properties must be set first in order
    /// for this method to succeed returning a connection string.
    /// </remarks>
    /// <returns>A <see cref="string"/>containing the SQL Server connection string.</returns>
    public string ToConnectionString(string user) {

      StringBuilder sb = new StringBuilder();

      // Append Data Source.
      if (this._dataSource != "") {
        sb.Append(Resources.Data_SqlServer_ConnectionDetails_DataSource);
        sb.Append(this._dataSource);
        sb.Append(";");

        // Append Initial Catalogue.
        if (this._initialCatalogue != "") {
          sb.Append(Resources.Data_SqlServer_ConnectionDetails_InitialCatalogue);
          sb.Append(this._initialCatalogue);
          sb.Append(";");

          // Append Persist Security Info.
          sb.Append(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo);
          sb.Append(this._isPersistSecurityInfo.ToString());
          sb.Append(";");

          // Append User ID.
          if (user != "") {
            var users =
            from usr in this._sqlServerUserList
            where usr.Username == user
            select usr;

            if (users != null) {
              if (users.Count() == 1) {
                // Only one user must be present in the returned list !!!
                foreach (var u in users) {
                  sb.Append(Resources.Data_SqlServer_ConnectionDetials_UserID);
                  sb.Append(u.Username);
                  sb.Append(";");

                  // Append Password.
                  sb.Append(Resources.Data_SqlServer_ConnectionDetails_Password);
                  if (!u.IsPasswordEncrypted) {
                    sb.Append(u.Password);
                  }
                  else {
                    // Use the base64 key to decrypt the password.
                    if (_base64Key != null || _base64Key != "") {
                      CryptographicString.Key = Convert.FromBase64String(_base64Key);
                      // Use the base64 initialization vector to decrypt the password.
                      if (_base64InitializationVector != null || _base64InitializationVector != "") {
                        CryptographicString.InitializationVector = Convert.FromBase64String(_base64InitializationVector);
                        // Decrypt the password.
                        sb.Append(CryptographicString.Decrypt(u.Password));
                      }
                      else {
                        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitializationVectorNotSpecified);
                      }
                    }
                    else {
                      throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionSecurityKeyNotSpecified);
                    }
                  }
                }
              }
              else {
                throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionUniqueUserIDNotFound);
              }
            }
            else {
              throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionUserIDNotFound);
            }
          }
          else {
            throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionUserIDNotSpecified);
          }

        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitialCalogueNotSpecified);
        }

      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionDataSourceNotSpecified);
      }
      
      return sb.ToString();

    }
    
    /// <summary>
    /// Updates the connection details using a connection string.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to updated the ConnectionDetails object.
    /// </param>
    /// <param name="encryptPassword">
    /// Specifies whether the password should be encrypted or not.
    /// </param>
    /// <remarks>
    /// In case the bEncryptPassword argument is set to true the
    /// <see cref="Base64Key"/> and the <see cref="Base64InitializationVector"/>
    /// properties must be set first in order for this method to succeed seting the
    /// ConnectionDetails object using a connection string.
    /// </remarks>
    public void FromConnectionString(string connectionString, bool encryptPassword) {

      string dataSource = "";
      string initialCatalogue = "";
      bool persistSecurityInfo = true;
      string userID = "";
      string password = "";
      SqlServerUser sqlServerUser = null;

      // Split the connection string to its tokens.
      char[] sep = new char[1] { ';' };
      string[] tokens = connectionString.Split(sep);

      // Get the Data Source.
      #region Data Source

      var selectedTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_DataSource)
        select token;

      if (selectedTokens != null) {
        if (selectedTokens.Count() == 1) {
          foreach (var token in selectedTokens) {
            dataSource = token.Replace(Resources.Data_SqlServer_ConnectionDetails_DataSource, "");
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingDataSource);
        }
      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingDataSource);
      }

      #endregion

      // Get the Initial Catalogue.
      #region Initial Catalogue

      selectedTokens = null;
      selectedTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_InitialCatalogue)
        select token;

      if (selectedTokens != null) {
        if (selectedTokens.Count() == 1) {
          foreach (var token in selectedTokens) {
            initialCatalogue = token.Replace(Resources.Data_SqlServer_ConnectionDetails_InitialCatalogue, "");
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingInitialCatalogue);
        }
      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingInitialCatalogue);
      }

      #endregion

      // Get the Persist Security Info.
      #region Persist Security Info

      selectedTokens = null;
      selectedTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo)
        select token;

      if (selectedTokens != null) {
        if (selectedTokens.Count() == 1) {
          foreach (var token in selectedTokens) {
            persistSecurityInfo = bool.Parse(
              token.Replace(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo, "").ToLower()
            );
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPersistSecurityInfo);
        }
      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPersistSecurityInfo);
      }

      #endregion

      // Get the User ID.
      #region User ID

      selectedTokens = null;
      selectedTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetials_UserID)
        select token;

      if (selectedTokens != null) {
        if (selectedTokens.Count() == 1) {
          foreach (var token in selectedTokens) {
            userID = token.Replace(Resources.Data_SqlServer_ConnectionDetials_UserID, "");
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingUserID);
        }
      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingUserID);
      }

      #endregion

      // Get the Password.
      #region Password

      selectedTokens = null;
      selectedTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_Password)
        select token;

      if (selectedTokens != null) {
        if (selectedTokens.Count() == 1) {
          foreach (var token in selectedTokens) {
            if (!encryptPassword) {
              password = token.Replace(Resources.Data_SqlServer_ConnectionDetails_Password, "");
            }
            else {
              // Use the base64 key to encrypt the password.
              if (_base64Key == null || _base64Key == "") {
                throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionSecurityKeyNotSpecified);
              }
              else {
                CryptographicString.Key = Convert.FromBase64String(_base64Key);
                // Use the base64 initialization vector to encrypt the password.
                if (_base64InitializationVector == null || _base64InitializationVector == "") {
                  throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitializationVectorNotSpecified);
                }
                else {
                  CryptographicString.InitializationVector = Convert.FromBase64String(_base64InitializationVector);
                  // Encrypt the password.
                  password = CryptographicString.Encrypt(token.Replace(Resources.Data_SqlServer_ConnectionDetails_Password, ""));
                }
              }
            }
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPassword);
        }
      }
      else {
        throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPassword);
      }

      #endregion

      // Set the user list.
      #region User list

      this._dataSource = dataSource;
      this._initialCatalogue = initialCatalogue;
      this._isPersistSecurityInfo = persistSecurityInfo;

      // Check if the user already exists in the users list.

      var users =
        from user in this._sqlServerUserList
        where user.Username == userID
        select user;

      if (users != null) {
        if (users.Count() == 0) {
          // No user with this id found in the list. Add the user in to the list.
          sqlServerUser = new SqlServerUser();
          sqlServerUser.Username = userID;
          sqlServerUser.IsPasswordEncrypted = encryptPassword;

          sqlServerUser.Password = password;
          this._sqlServerUserList.Add(sqlServerUser);
        }
        else if (users.Count() == 1) {
          // A user has been found with this name in the list. Update the user.
          foreach (var user in users) {
            user.IsPasswordEncrypted = encryptPassword;
            user.Password = password;
          }
        }
        else {
          throw new Exception(Resources.Data_SqlServer_ConnectionDetails_ExceptionUniqueUserIDNotFound);
        }
      }
      else {
        // No user with this id found in the list. Add the user in to the list.
        sqlServerUser = new SqlServerUser();
        sqlServerUser.Username = userID;
        sqlServerUser.IsPasswordEncrypted = encryptPassword;

        sqlServerUser.Password = password;
        this._sqlServerUserList.Add(sqlServerUser);
      }

      #endregion
      
    }

    #endregion
    
  }

}
