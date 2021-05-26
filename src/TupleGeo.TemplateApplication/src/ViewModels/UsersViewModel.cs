
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
  public sealed class UsersViewModel : ViewModel<UsersModel> {

    #region Member Variables

    private UserViewModel _userViewModel;
    private ViewModelChangesObserver _currentUserChangesObserver;
    //protected Action<object, PropertyChangedEventArgs> _updateCurrentUserAction;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UsersViewModel"/>.
    /// </summary>
    /// <param name="usersModel">The <see cref="UsersModel"/> used against this view model.</param>
    public UsersViewModel(UsersModel usersModel)
      : base(usersModel) {

      AddUsers();
      
      _userViewModel = (UserViewModel)(AppEngine.Instance.Catalog.GetSingletonViewModel(typeof(UserView)));

      _currentUserChangesObserver = new ViewModelChangesObserver {
        UserViewModel = _userViewModel
      };

      //Action<object, PropertyChangedEventArgs> showCurrentUserAction = new Action<object, PropertyChangedEventArgs>(_currentUserChangesObserver.OnPropertyChanged);
      //_updateCurrentUserAction = (sender, pcea) => {
      //  _userViewModel.Model = ((UsersModel)sender).CurrentUser;
      //};

      //Action<object, PropertyChangedEventArgs> showCurrentUserAction = (s, e) => {
      //  _currentUserChangesObserver.OnPropertyChanged(s, e);
      //};



      _currentUserChangesObserver.AddPropertyChangedListener<UsersModel>(this.Model, "CurrentUser");
      
      //this.Model.PropertyChanged += new PropertyChangedEventHandler(UsersModel_PropertyChanged);

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
    
    ///// <summary>
    ///// Occurs when a model property changes.
    ///// </summary>
    ///// <param name="sender">The sender of the event.</param>
    ///// <param name="e">The PropertyEventArgs.</param>
    //private void UsersModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
    //  if (e.PropertyName == "CurrentUser") {
    //    _userViewModel.Model = this.Model.CurrentUser;
    //  }
    //}

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
      ((ActionCommand)this.DeleteUserCommand).AddPropertyChangedListener<UsersModel>(this.Model, m => m.CurrentUser)
                                             .AddPropertyChangedListener<UsersModel>(this.Model, m => m.Users)
                                             .AddCollectionChangedListener(this.Model.Users);
    }

    /// <summary>
    /// Adds users in the user collection.
    /// </summary>
    private void AddUsers() {
      this.Model.Users.Add(new UserModel() {
        Age = 42,
        Department = "Dept1",
        Name = "John",
        Surname = "Doe"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 39,
        Department = "Dept2",
        Name = "George",
        Surname = "Foe"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 30,
        Department = "Dept1",
        Name = "Elena",
        Surname = "Kala"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 44,
        Department = "Dept1",
        Name = "Richard",
        Surname = "None"
      });
      this.Model.Users.Add(new UserModel() {
        Age = 35,
        Department = "Dept2",
        Name = "Alexandra",
        Surname = "Fun"
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

    #region ViewModel Members

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

    private class ViewModelChangesObserver : ChangesObserver {

      private UserViewModel _userViewModel;

      public UserViewModel UserViewModel {
        get {
          return _userViewModel;
        }
        set {
          _userViewModel = value;
        }
      }

      public override void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
        //base.OnPropertyChanged(sender, propertyChangedEventArgs);

        //_updateCurrentUserAction(sender, propertyChangedEventArgs);
        this.UserViewModel.Model = ((UsersModel)sender).CurrentUser;

      }

    }

  }

}
