
#region Header
// Title Name       : ConnectionDetails
// Member of        : TupleGeo.General.dll
// Description      : The details used to define an SQL Server connection
//                    as they appear in a connection string.
// Created by       : 18/03/2009, 20:40, Vasilis Vlastaras.
// Updated by       : 02/06/2015, 16:03, Vasilis Vlastaras.
//                    1.0.1 - Re-engineered ConnectionDetails to meet Microsoft All Rules code analysis standards.
// Version          : 1.0.1
// Contact Details  : TupleGeo.
// License          : Apache License.
// Copyright        : TupleGeo, 2009 - 2015.
// Comments         : 
#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
  [XmlRootAttribute(Namespace = "urn:TupleGeo:General:Data:SqlServer", IsNullable = false)]
  public sealed class ConnectionDetails {

    #region Member Variables

    private string _base64Key;
    private string _base64InitializationVector;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ConnectionDetails"/>.
    /// </summary>
    public ConnectionDetails() {
      this._dataSource = "";
      this._initialCatalogue = "";
      this._isPersistSecurityInfo = true;
      this._sqlServerUserCollection = new Collection<SqlServerUser>();
    }

    /// <summary>
    /// Initializes the <see cref="ConnectionDetails"/>.
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
    /// The name of the initial catalog. It should be the name of the database.
    /// </summary>
    [XmlAttributeAttribute(AttributeName = "initialCatalogue")]
    public string InitialCatalog {
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

    private System.Collections.ObjectModel.Collection<SqlServerUser> _sqlServerUserCollection;

    /// <summary>
    /// Gets / Sets the <see cref="List{SqlServerUser}"/>.
    /// </summary>
    [XmlArrayAttribute(ElementName = "SqlServerUsers")]
    [XmlArrayItem(ElementName = "SqlServerUser", Type = typeof(SqlServerUser))]
    public System.Collections.ObjectModel.Collection<SqlServerUser> SqlServerUserCollection {
      get {
        return _sqlServerUserCollection;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Sets the base64 key used to decrypt the password.
    /// </summary>
    /// <param name="base64Key">The base64 key string.</param>
    /// <remarks>
    /// The key must be a base64 string used as a key feed for the <see cref="CryptographicString"/> object.
    /// </remarks>
    public void SetBase64Key(string base64Key) {
      _base64Key = base64Key;
    }

    /// <summary>
    /// Sets the base64 initialization vector used to decrypt the password.
    /// </summary>
    /// <param name="base64InitializationVector">The base64 initialization vector.</param>
    /// <remarks>
    /// The initialization vector must be a base64 string used as an initialization vector
    /// feed for the <see cref="CryptographicString"/> object.
    /// </remarks>
    public void SetBase64InitializationVector(string base64InitializationVector) {
      _base64InitializationVector = base64InitializationVector;
    }

    /// <summary>
    /// Converts the connection Details in to an SQL Server connection string.
    /// </summary>
    /// <param name="user">
    /// The username that will be used to form the connection string.
    /// </param>
    /// <remarks>
    /// In case the <see cref="SqlServerUserCollection"/> property is populated with users having
    /// encrypted passwords a call to methods <see cref="SetBase64Key"/> and 
    /// <see cref="SetBase64InitializationVector"/> must be made first in order
    /// for this method to succeed returning a connection string.
    /// </remarks>
    /// <returns>A <see cref="string"/>containing the SQL Server connection string.</returns>
    public string ToConnectionString(string user) {

      StringBuilder sb = new StringBuilder();

      // Append Data Source.
      if (!string.IsNullOrEmpty(this._dataSource)) {
        sb.Append(Resources.Data_SqlServer_ConnectionDetails_DataSource);
        sb.Append(this._dataSource);
        sb.Append(";");

        // Append Initial Catalog.
        if (!string.IsNullOrEmpty(this._initialCatalogue)) {
          sb.Append(Resources.Data_SqlServer_ConnectionDetails_InitialCatalog);
          sb.Append(this._initialCatalogue);
          sb.Append(";");

          // Append Persist Security Info.
          sb.Append(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo);
          sb.Append(this._isPersistSecurityInfo.ToString());
          sb.Append(";");

          // Append User ID.
          if (!string.IsNullOrEmpty(user)) {
            var users =
              from usr in this._sqlServerUserCollection
              where usr.UserName == user
              select usr;

            if (users != null) {
              if (users.Count() == 1) {
                // Only one user must be present in the returned list !!!
                foreach (var u in users) {
                  sb.Append(Resources.Data_SqlServer_ConnectionDetials_UserID);
                  sb.Append(u.UserName);
                  sb.Append(";");

                  // Append Password.
                  sb.Append(Resources.Data_SqlServer_ConnectionDetails_Password);
                  if (!u.IsPasswordEncrypted) {
                    sb.Append(u.Password);
                  }
                  else {
                    // Use the base64 key to decrypt the password.
                    if (!string.IsNullOrEmpty(_base64Key)) {
                      CryptographicString.SetKey(Convert.FromBase64String(_base64Key));
                      // Use the base64 initialization vector to decrypt the password.
                      if (!string.IsNullOrEmpty(_base64InitializationVector)) {
                        CryptographicString.SetInitializationVector(Convert.FromBase64String(_base64InitializationVector));
                        // Decrypt the password.
                        sb.Append(CryptographicString.Decrypt(u.Password));
                      }
                      else {
                        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitializationVectorNotSpecified);
                      }
                    }
                    else {
                      throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionSecurityKeyNotSpecified);
                    }
                  }
                }
              }
              else {
                throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionUniqueUserIDNotFound);
              }
            }
            else {
              throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionUserIDNotFound);
            }
          }
          else {
            throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionUserIDNotSpecified);
          }

        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitialCatalogNotSpecified);
        }

      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionDataSourceNotSpecified);
      }
      
      return sb.ToString();

    }

    /// <summary>
    /// Converts the connection Details in to an SQL Server connection string.
    /// </summary>
    /// <param name="user">
    /// The username that will be used to form the connection string.
    /// </param>
    /// <param name="base64Key">
    /// The base64 key used for encrypting passwords.
    /// </param>
    /// <param name="base64InitializationVector">
    /// The base64 initialization vector used for encrypting passwords.
    /// </param>
    /// <remarks>
    /// In case the <see cref="SqlServerUserCollection"/> property is populated with users having
    /// encrypted passwords a call to methods <see cref="SetBase64Key"/> and 
    /// <see cref="SetBase64InitializationVector"/> must be made first in order
    /// for this method to succeed returning a connection string.
    /// </remarks>
    /// <returns>A <see cref="string"/>containing the SQL Server connection string.</returns>
    public string ToConnectionString(string user, string base64Key, string base64InitializationVector) {

      if (string.IsNullOrEmpty(base64Key)) {
        throw new ArgumentNullException("base64Key", "Base64 Key could not be NULL or Empty.");
      }

      if (string.IsNullOrEmpty(base64InitializationVector)) {
        throw new ArgumentNullException("base64InitializationVector", "Base64 Initialization Vector could not be NULL or Empty");
      }

      SetBase64Key(base64Key);
      SetBase64InitializationVector(base64InitializationVector);

      return ToConnectionString(user);

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
    /// In case the bEncryptPassword argument is set to true a call to methods
    /// <see cref="SetBase64Key"/> and <see cref="SetBase64InitializationVector"/>
    /// must be made first in order for this method to succeed setting the
    /// ConnectionDetails object using a connection string.
    /// </remarks>
    public void FromConnectionString(string connectionString, bool encryptPassword) {

      if (string.IsNullOrEmpty(connectionString)) {
        throw new ArgumentNullException("connectionString");
      }

      // Split the connection string to its tokens.
      char[] sep = new char[1] { ';' };
      string[] tokens = connectionString.Split(sep);

      // Get the tokens for the data source part of the connection string.
      var dataSourceTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_DataSource, StringComparison.Ordinal)
        select token;

      // Get the Data Source.
      string dataSource = "";
      SetDataSource(ref dataSource, ref dataSourceTokens);

      // Get the Initial Catalog.
      string initialCatalog = "";
      SetInitialCatalog(ref initialCatalog, tokens, ref dataSourceTokens);

      // Get the Persist Security Info.
      bool persistSecurityInfo = true;
      SetPersistSecurityInfo(ref persistSecurityInfo, tokens, ref dataSourceTokens);

      // Get the User ID.
      string userID = "";
      SetUserID(ref userID, tokens, ref dataSourceTokens);

      // Get the Password.
      string password = "";
      SetPassword(encryptPassword, ref password, tokens, ref dataSourceTokens);

      // Set the user list.
      this._dataSource = dataSource;
      this._initialCatalogue = initialCatalog;
      this._isPersistSecurityInfo = persistSecurityInfo;

      // Update the user list.
      UpdateUserList(encryptPassword, userID, password);

    }

    /// <summary>
    /// Updates the connection details using a connection string.
    /// </summary>
    /// <param name="connectionString">
    /// The connection string used to updated the ConnectionDetails object.
    /// </param>
    /// <param name="base64Key">
    /// The base64 key used for encrypting passwords.
    /// </param>
    /// <param name="base64InitializationVector">
    /// The base64 initialization vector used for encrypting passwords.
    /// </param>
    /// <remarks>
    /// The method assumes that the password will be encrypted.
    /// </remarks>
    public void FromConnectionString(string connectionString, string base64Key, string base64InitializationVector) {

      if (string.IsNullOrEmpty(base64Key)) {
        throw new ArgumentNullException("base64Key", "Base64 Key could not be NULL or Empty.");
      }

      if (string.IsNullOrEmpty(base64InitializationVector)) {
        throw new ArgumentNullException("base64InitializationVector", "Base64 Initialization Vector could not be NULL or Empty");
      }

      SetBase64Key(base64Key);
      SetBase64InitializationVector(base64InitializationVector);

      FromConnectionString(connectionString, true);

    }

    #endregion

    #region Private properties

    /// <summary>
    /// Sets the data source.
    /// </summary>
    /// <param name="dataSource">The data source.</param>
    /// <param name="dataSourceTokens">The data source tokens.</param>
    private static void SetDataSource(ref string dataSource, ref IEnumerable<string> dataSourceTokens) {

      if (dataSourceTokens != null) {
        if (dataSourceTokens.Count() == 1) {
          foreach (var token in dataSourceTokens) {
            dataSource = token.Replace(Resources.Data_SqlServer_ConnectionDetails_DataSource, "");
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingDataSource);
        }
      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingDataSource);
      }

    }

    /// <summary>
    /// Sets the initial catalog.
    /// </summary>
    /// <param name="initialCatalog">The initial catalog.</param>
    /// <param name="tokens">The connection string tokens.</param>
    /// <param name="dataSourceTokens">The data source tokens.</param>
    private static void SetInitialCatalog(ref string initialCatalog, string[] tokens, ref IEnumerable<string> dataSourceTokens) {

      dataSourceTokens = null;
      dataSourceTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_InitialCatalog, StringComparison.Ordinal)
        select token;

      if (dataSourceTokens != null) {
        if (dataSourceTokens.Count() == 1) {
          foreach (var token in dataSourceTokens) {
            initialCatalog = token.Replace(Resources.Data_SqlServer_ConnectionDetails_InitialCatalog, "");
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingInitialCatalog);
        }
      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingInitialCatalog);
      }

    }

    /// <summary>
    /// Sets the PersistSecurityInfo.
    /// </summary>
    /// <param name="persistSecurityInfo">The PersistSecurityInfo.</param>
    /// <param name="tokens">The connection string tokens.</param>
    /// <param name="dataSourceTokens">The data source tokens.</param>
    private static void SetPersistSecurityInfo(ref bool persistSecurityInfo, string[] tokens, ref IEnumerable<string> dataSourceTokens) {

      dataSourceTokens = null;
      dataSourceTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo, StringComparison.Ordinal)
        select token;

      if (dataSourceTokens != null) {
        if (dataSourceTokens.Count() == 1) {
          foreach (var token in dataSourceTokens) {
            persistSecurityInfo = bool.Parse(
              token.Replace(Resources.Data_SqlServer_ConnectionDetails_PersistSecurityInfo, "").ToLowerInvariant()
            );
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPersistSecurityInfo);
        }
      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPersistSecurityInfo);
      }

    }

    /// <summary>
    /// Sets the userID.
    /// </summary>
    /// <param name="userID">The UserID.</param>
    /// <param name="tokens">The connection string tokens.</param>
    /// <param name="dataSourceTokens">The data source tokens.</param>
    private static void SetUserID(ref string userID, string[] tokens, ref IEnumerable<string> dataSourceTokens) {

      dataSourceTokens = null;
      dataSourceTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetials_UserID, StringComparison.Ordinal)
        select token;

      if (dataSourceTokens != null) {
        if (dataSourceTokens.Count() == 1) {
          foreach (var token in dataSourceTokens) {
            userID = token.Replace(Resources.Data_SqlServer_ConnectionDetials_UserID, "");
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingUserID);
        }
      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingUserID);
      }

    }

    /// <summary>
    /// Sets the password.
    /// </summary>
    /// <param name="encryptPassword">Indicates whether to encrypt the password or not.</param>
    /// <param name="password">The password.</param>
    /// <param name="tokens">The connection string tokens.</param>
    /// <param name="dataSourceTokens">The data source tokens.</param>
    private void SetPassword(bool encryptPassword, ref string password, string[] tokens, ref IEnumerable<string> dataSourceTokens) {

      dataSourceTokens = null;
      dataSourceTokens =
        from token in tokens
        where token.StartsWith(Resources.Data_SqlServer_ConnectionDetails_Password, StringComparison.Ordinal)
        select token;

      if (dataSourceTokens != null) {
        if (dataSourceTokens.Count() == 1) {
          foreach (var token in dataSourceTokens) {
            if (!encryptPassword) {
              password = token.Replace(Resources.Data_SqlServer_ConnectionDetails_Password, "");
            }
            else {
              // Use the base64 key to encrypt the password.
              if (string.IsNullOrEmpty(_base64Key)) {
                throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionSecurityKeyNotSpecified);
              }
              else {
                CryptographicString.SetKey(Convert.FromBase64String(_base64Key));
                // Use the base64 initialization vector to encrypt the password.
                if (string.IsNullOrEmpty(_base64InitializationVector)) {
                  throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionInitializationVectorNotSpecified);
                }
                else {
                  CryptographicString.SetInitializationVector(Convert.FromBase64String(_base64InitializationVector));
                  // Encrypt the password.
                  password = CryptographicString.Encrypt(token.Replace(Resources.Data_SqlServer_ConnectionDetails_Password, ""));
                }
              }
            }
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPassword);
        }
      }
      else {
        throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionGettingPassword);
      }

    }

    /// <summary>
    /// Get the <see cref="SqlServerUser"/>.
    /// </summary>
    /// <param name="encryptPassword">Indicates whether to encrypt the password or not.</param>
    /// <param name="userID">The UserID.</param>
    /// <param name="password">The password.</param>
    private void UpdateUserList(bool encryptPassword, string userID, string password) {

      // Check if the user already exists in the users list.
      var users =
        //from user in this._sqlServerUserList
        from user in this._sqlServerUserCollection
        where user.UserName == userID
        select user;

      SqlServerUser sqlServerUser;

      if (users != null) {
        if (users.Count() == 0) {
          // No user with this id found in the list. Add the user in to the list.
          sqlServerUser = new SqlServerUser();
          sqlServerUser.UserName = userID;
          sqlServerUser.IsPasswordEncrypted = encryptPassword;

          sqlServerUser.Password = password;
          //this._sqlServerUserList.Add(sqlServerUser);
          this._sqlServerUserCollection.Add(sqlServerUser);
        }
        else if (users.Count() == 1) {
          // A user has been found with this name in the list. Update the user.
          foreach (var user in users) {
            user.IsPasswordEncrypted = encryptPassword;
            user.Password = password;
          }
        }
        else {
          throw new ConnectionDetailsException(Resources.Data_SqlServer_ConnectionDetails_ExceptionUniqueUserIDNotFound);
        }
      }
      else {
        // No user with this id found in the list. Add the user in to the list.
        sqlServerUser = new SqlServerUser();
        sqlServerUser.UserName = userID;
        sqlServerUser.IsPasswordEncrypted = encryptPassword;

        sqlServerUser.Password = password;
        //this._sqlServerUserList.Add(sqlServerUser);
        this._sqlServerUserCollection.Add(sqlServerUser);
      }

    }

    #endregion

  }

}
