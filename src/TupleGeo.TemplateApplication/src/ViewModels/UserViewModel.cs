
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;
using TupleGeo.Apps.Presentation.Commands;
using TupleGeo.TemplateApplication.Models;

#endregion

namespace TupleGeo.TemplateApplication.ViewModels {

  /// <summary>
  /// The view model used by the <see cref="Views.UserView">UserView</see>.
  /// </summary>
  public sealed class UserViewModel : ViewModel<UserModel> {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UserViewModel"/>.
    /// </summary>
    /// <param name="userModel">The <see cref="UserModel"/> used against this view model.</param>
    public UserViewModel(UserModel userModel)
      : base(userModel) {

    }

    #endregion

    #region Public Properties

    #endregion

    #region Public Methods

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region Private Actions

    #endregion

    #region ViewModel Members

    private const string _name = "UserViewModel";

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    public override string Name {
      get {
        return _name;
      }
    }

    /// <summary>
    /// Gets the title for this view model.
    /// </summary>
    public override string Title {
      get {
        return this.Model.ModelName;
      }
    }

    #endregion

  }

}
