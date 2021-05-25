
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.ComponentModel;
using TupleGeo.Apps;

#endregion

namespace TupleGeo.TemplateApplication.Models {

  /// <summary>
  /// The model that describes a user.
  /// </summary>
  public sealed class UserModel : Model {

    #region Member Variables

    private static int _autoIncrementId = 0;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UserModel"/>.
    /// </summary>
    public UserModel() {
      _id = ++_autoIncrementId;
    }

    #endregion

    #region Public Properties

    private readonly int _id;

    /// <summary>
    /// Gets / Sets the user id.
    /// </summary>
    public int Id {
      get {
        return _id;
      }
    }

    private string _name;

    /// <summary>
    /// Gets / Sets the name.
    /// </summary>
    public string Name {
      get {
        return _name;
      }
      set {
        if (_name != value) {
          _name = value;
          this.OnPropertyChanged();
        }
      }
    }

    private string _surname;

    /// <summary>
    /// Gets / Sets the surname.
    /// </summary>
    public string Surname {
      get {
        return _surname;
      }
      set {
        if (_surname != value) {
          _surname = value;
          this.OnPropertyChanged();
        }
      }
    }

    private int _age;

    /// <summary>
    /// Gets / Sets the age.
    /// </summary>
    public int Age {
      get {
        return _age;
      }
      set {
        if (_age != value) {
          _age = value;
          this.OnPropertyChanged();
        }
      }
    }

    private string _department;

    /// <summary>
    /// Gets / Sets the department.
    /// </summary>
    public string Department {
      get {
        return _department;
      }
      set {
        if (_department != value) {
          _department = value;
          this.OnPropertyChanged();
        }
      }
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region Model Members

    /// <summary>
    /// Gets the name of the model.
    /// </summary>
    public override string ModelName => "UserModel";

    #endregion

  }

}
