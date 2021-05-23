
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TupleGeo.Apps;
using TupleGeo.General.ComponentModel;

#endregion

namespace TupleGeo.TemplateApplication.Models {

  /// <summary>
  /// The model that describes a user.
  /// </summary>
  public sealed class UsersModel : ObservableObject, IModel {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UsersModel"/>.
    /// </summary>
    public UsersModel() {
      _users = new ObservableCollection<UserModel>();
    }

    #endregion

    #region Public Properties

    private readonly ObservableCollection<UserModel> _users;

    /// <summary>
    /// The users collection.
    /// </summary>
    public ObservableCollection<UserModel> Users {
      get {
        return _users;
      }
    }

    private UserModel _currentUser;

    /// <summary>
    /// Gets / Sets the current user.
    /// </summary>
    public UserModel CurrentUser {
      get {
        return _currentUser;
      }
      set {
        if (_currentUser != value) {
          _currentUser = value;
          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region IModel Members

    private const string _modelName = "UsersModel";

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public string ModelName {
      get {
        return _modelName;
      }
    }

    #endregion

  }

}
