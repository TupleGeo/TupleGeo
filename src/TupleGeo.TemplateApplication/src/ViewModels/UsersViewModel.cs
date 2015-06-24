
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

    // TODO: Declare any view models needed here.
    private UserViewModel _userViewModel;
    //private Sample2ViewModel _sample2ViewModel;
    // ...
    //private SampleNViewModel _sampleNViewModel;

    // TODO: Declare any collection view sources here.
    //private CollectionViewSource _collection1ViewSource;
    //private CollectionViewSource _collection2ViewSource;
    // ...
    //private CollectionViewSource _collectionNViewSource;

    // TODO: Or use a potentially useful dictionary of collection view sources.
    //private Dictionary<string, CollectionViewSource> _collectionViewSourcesDictionary;

    // TODO: 'Sample 2' of SubscribeToEvents method.
    //private Dictionary<string, UIElement> _uiElementsDicionary;

    private readonly WeakEventManagerBase<PropertyChangedEventArgs> _weakEventListener;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UsersViewModel"/>.
    /// </summary>
    /// <param name="usersModel">The <see cref="UsersModel"/> used against this view model.</param>
    public UsersViewModel(UsersModel usersModel)
      : base(usersModel) {

      AddUsers();
      
      // TODO: Get other necessary view models here.
      _userViewModel = (UserViewModel)(Catalog.GetViewModel(typeof(UserView)));
      //_sample3ViewModel = (Sample3ViewModel)(Catalog.GetViewModel(typeof(Sample3View)));
      // ...
      //_sampleNViewModel = (SampleNViewModel)(Catalog.GetViewModel(typeof(SampleNView)));

      // TODO: 'Sample 2' of SubscribeToEvents method.
      // Force all property changes of SampleModel to be handled by only one event handler.
      //sampleModel.PropertyChanged += new PropertyChangedEventHandler(SampleModel_PropertyChanged);

      this._weakEventListener = new WeakEventManagerBase<PropertyChangedEventArgs>(PropChanged);
      
      this.AddListener<UsersModel>(this.Model, m => m.CurrentUser);

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

    // TODO: 'Sample 2' of SubscribeToEvents method.
    // In this sample all observed labels in the UI need to be refreshed while the model properties
    // are being constantly updated during bulk operations. This can be achieved by forcing the
    // UI dispatcher to update the labels.

    ///// <summary>
    ///// Occurs when a property of the associated model has been changed.
    ///// </summary>
    ///// <param name="sender">The sender of the event.</param>
    ///// <param name="e">The <see cref="PropertyChangedEventArgs"/>.</param>
    //private void SampleModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
    //  string key = e.PropertyName[0].ToString().ToLower() + e.PropertyName.Substring(1) + "Label";
    //  RefreshElement(_uiElementsDicionary[key]);
    //}

    /// <summary>
    /// Fires when a property changes.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="propertyChangedEventArgs">The PropertyChangedEventArgs.</param>
    private void PropChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs) {
      if (propertyChangedEventArgs.PropertyName == "CurrentUser") {
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
    /// Adds a listener.
    /// </summary>
    /// <typeparam name="TEntity">The entity used.</typeparam>
    /// <param name="source">The source of the command.</param>
    /// <param name="property">The property of the <typeparamref name="TEntity"/>.</param>
    /// <returns>A UsersViewModel.</returns>
    private UsersViewModel AddListener<TEntity>(INotifyPropertyChanged source, Expression<Func<TEntity, object>> property) {
      string propertyName = Prop.GetPropertyName<TEntity>(property);
      PropertyChangedEventManager.AddListener(source, _weakEventListener, propertyName);

      return this;
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

    /// <summary>
    /// Gets the title for this view model.
    /// </summary>
    public override string Title {
      get {
        return this.Model.ModelName;
      }
    }

    #endregion

    #region IViewModel Members

    //private const string _name = "UsersViewModel";

    ///// <summary>
    ///// Gets the name of the view model.
    ///// </summary>
    //public string Name {
    //  get {
    //    return _name;
    //  }
    //}

    ///// <summary>
    ///// Binds this view model to events raised by its corresponding view.
    ///// </summary>
    ///// <param name="triggeringControlsDictionary">The controls whose events will be observed.</param>
    //public void SubscribeToEvents(Dictionary<string, object> triggeringControlsDictionary) {
      
    //}

    ///// <summary>
    ///// Removes event subscriptions of this view model.
    ///// </summary>
    ///// <param name="triggeringControlsDictionary">The controls whose events will be stopped being observed.</param>
    //public void UnsubscribeFromEvents(Dictionary<string, object> triggeringControlsDictionary) {
      
    //}

    ///// <summary>
    ///// Sets the <see cref="CollectionViewSource">CollectionViewSources</see> for this model.
    ///// </summary>
    ///// <param name="collectionViewSourcesDictionary">
    ///// The dictionary of <see cref="CollectionViewSource">CollectionViewSources</see>
    ///// that will be used to display data.
    ///// </param>
    //public void SetCollectionViewSources(Dictionary<string, CollectionViewSource> collectionViewSourcesDictionary) {
      
    //}

    #endregion

  }

}
