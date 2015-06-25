
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
  public sealed class UserViewModel : BaseViewModel<UserModel> {

    #region Member Variables

    // TODO: Declare any view models needed here.
    //private Sample1ViewModel _sample1ViewModel;
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
    
    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UserViewModel"/>.
    /// </summary>
    /// <param name="userModel">The <see cref="UserModel"/> used against this view model.</param>
    public UserViewModel(UserModel userModel)
      : base(userModel) {

      // TODO: Get other necessary view models here.
      //_sample2ViewModel = (Sample2ViewModel)(Catalog.GetViewModel(typeof(Sample2View)));
      //_sample3ViewModel = (Sample3ViewModel)(Catalog.GetViewModel(typeof(Sample3View)));
      // ...
      //_sampleNViewModel = (SampleNViewModel)(Catalog.GetViewModel(typeof(SampleNView)));

      // TODO: 'Sample 2' of SubscribeToEvents method.
      // Force all property changes of SampleModel to be handled by only one event handler.
      //sampleModel.PropertyChanged += new PropertyChangedEventHandler(SampleModel_PropertyChanged);

    }

    #endregion

    #region Public Properties

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

    #endregion

    #region Private Procedures

    // TODO: 'Sample 2' of SubscribeToEvents method.

    ///// <summary>
    ///// Refreshes the specified element on the GUI.
    ///// </summary>
    ///// <param name="uiElement">The <see cref="UIElement"/> that will be refreshed.</param>
    //private static void RefreshElement(UIElement uiElement) {
    //  uiElement.Dispatcher.Invoke(DispatcherPriority.Render, RefreshDelegate);
    //}

    #endregion

    #region Private Actions

    // TODO: 'Sample 2' of SubscribeToEvents method.

    ///// <summary>
    ///// An action used to refresh the GUI.
    ///// </summary>
    //private static Action RefreshDelegate = delegate() {
    //};

    #endregion

    #region BaseViewModel Members

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

    #region IViewModel Members

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
