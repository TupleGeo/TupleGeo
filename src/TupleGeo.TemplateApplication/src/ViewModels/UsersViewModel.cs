
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;
using TupleGeo.Apps.Presentation.Commands;
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General.Linq.Expressions;
using TupleGeo.TemplateApplication.Engine;
using TupleGeo.TemplateApplication.Models;
using TupleGeo.TemplateApplication.Views;

#endregion

namespace TupleGeo.TemplateApplication.ViewModels {

  /// <summary>
  /// The view model used by the <see cref="Views.UsersView">UsersView</see>.
  /// </summary>
  public sealed class UsersViewModel : BaseViewModel<UsersModel> {

    #region Member Variables

    private UserViewModel _userViewModel;
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UsersViewModel"/>.
    /// </summary>
    /// <param name="usersModel">The <see cref="UsersModel"/> used against this view model.</param>
    public UsersViewModel(UsersModel usersModel)
      : base(usersModel) {

      AddUsers();
      
      _userViewModel = (UserViewModel)(Catalog.GetViewModel(typeof(UserView)));
      
      this.Model.PropertyChanged += new PropertyChangedEventHandler(UsersModel_PropertyChanged);

      InitializeCommands();
      
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Adds a <see cref="UserModel"/>.
    /// </summary>
    public ICommand AddUserCommand {
      get;
      private set;
    }

    /// <summary>
    /// Deletes a <see cref="UserModel"/>.
    /// </summary>
    public ICommand DeleteUserCommand {
      get;
      private set;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Event Procedures
    
    /// <summary>
    /// Occurs when a model property changes.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The PropertyEventArgs.</param>
    private void UsersModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      if (e.PropertyName == "CurrentUser") {
        _userViewModel.Model = this.Model.CurrentUser;
      }
    }
    
    #endregion

    #region Private Procedures

    /// <summary>
    /// Initializes the commands.
    /// </summary>
    private void InitializeCommands() {

      // AddUserCommand.
      AddUserCommand = new ActionCommand(
        (parameter) => {
          AddUserCommandAction(parameter);
        },
        (parameter) => {
          return AddUserCommandCanExecute(parameter);
        }
      );
      
      // DeleteUserCommand.
      DeleteUserCommand = new ActionCommand(
        (parameter) => {
          DeleteUserCommandAction(parameter);
        },
        (parameter) => {
          return DeleteUserCommandCanExecute(parameter);
        }
      );
      // Add listeners here.
      ((ActionCommand)this.DeleteUserCommand).AddListener<UsersModel>(this.Model, m => m.CurrentUser)
                                             .AddListener<UsersModel>(this.Model, m => m.Users)
                                             .AddObservableCollectionListener(this.Model.Users);

    }

    /// <summary>
    /// Adds users in the user collection.
    /// </summary>
    private void AddUsers() {
      this.Model.Users.Add(new UserModel() {
        Age = 42,
        Department = "CUPS",
        Name = "Vasilis",
        Surname = "Vlastaras"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 39,
        Department = "Eratosthenes",
        Name = "Konstantinos",
        Surname = "Daras"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 30,
        Department = "Eratosthenes",
        Name = "Eleanna",
        Surname = "Kalantidi"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 44,
        Department = "Planning",
        Name = "Richard",
        Surname = "Kingston"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 35,
        Department = "Home",
        Name = "Alexandra",
        Surname = "Fomenko"
      });
    }

    #endregion

    #region Private Actions

    /// <summary>
    /// The command action associated with <see cref="AddUserCommand"/>.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    private void AddUserCommandAction(object parameter) {

      UserModel newUser = new UserModel();

      this.Model.Users.Add(newUser);
      this.Model.CurrentUser = newUser;

    }

    /// <summary>
    /// Determines whether the <see cref="AddUserCommand"/> can execute.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    /// <returns>A <see cref="bool"/> with the result of the evaluation.</returns>
    private bool AddUserCommandCanExecute(object parameter) {
      return (this.Model.Users != null);
    }

    /// <summary>
    /// The command action associated with <see cref="DeleteUserCommand"/>.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    private void DeleteUserCommandAction(object parameter) {
      
      MessageBoxResult result = MessageBox.Show(
        "Do you want to delete the user?",
        "Confirmation",
        MessageBoxButton.YesNo,
        MessageBoxImage.Question
      );

      if (result == MessageBoxResult.Yes) {
        this.Model.Users.Remove(this.Model.CurrentUser);
      }

    }

    /// <summary>
    /// Determines whether the <see cref="DeleteUserCommand"/> can execute.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    /// <returns>A <see cref="bool"/> with the result of the evaluation.</returns>
    private bool DeleteUserCommandCanExecute(object parameter) {
      return (this.Model.Users != null && this.Model.Users.Count > 0 && this.Model.CurrentUser != null);
    }

    #endregion

    #region BaseViewModel Members

    private const string _name = "UsersViewModel";

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
