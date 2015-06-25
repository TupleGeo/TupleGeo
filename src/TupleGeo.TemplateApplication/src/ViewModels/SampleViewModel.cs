
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
  /// The view model used by the <see cref="Views.SampleView">SampleView</see>.
  /// </summary>
  public sealed class SampleViewModel : BaseViewModel<SampleModel> {

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
    /// Initializes the <see cref="SampleViewModel"/>.
    /// </summary>
    /// <param name="sampleModel">The <see cref="SampleModel"/> used against this view model.</param>
    public SampleViewModel(SampleModel sampleModel)
      : base(sampleModel) {

      // TODO: Get other necessary view models here.
      //_sample2ViewModel = (Sample2ViewModel)(Catalog.GetViewModel(typeof(Sample2View)));
      //_sample3ViewModel = (Sample3ViewModel)(Catalog.GetViewModel(typeof(Sample3View)));
      // ...
      //_sampleNViewModel = (SampleNViewModel)(Catalog.GetViewModel(typeof(SampleNView)));

      // TODO: 'Sample 2' of SubscribeToEvents method.
      // Force all property changes of SampleModel to be handled by only one event handler.
      //sampleModel.PropertyChanged += new PropertyChangedEventHandler(SampleModel_PropertyChanged);

      InitializeCommands();

    }

    #endregion

    #region Public Properties

    /// <summary>
    /// 
    /// </summary>
    public ICommand Command1Command {
      get;
      private set;
    }

    /// <summary>
    /// 
    /// </summary>
    public ICommand Command2Command {
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

    #endregion

    #region Private Procedures

    /// <summary>
    /// Initializes the commands.
    /// </summary>
    private void InitializeCommands() {

      // Command1Command.
      Command1Command = new ActionCommand(
        (parameter) => {
          Command1CommandAction(parameter);
        },
        (parameter) => {
          return Command1CommandCanExecute(parameter);
        }
      );
      // Add listeners here.
      //((SampleCommand)this.Command1Command).AddListener<SampleModel>(this.Model, m => m.Property1);
      //((SampleCommand)this.Command1Command).AddListener<SampleModel>(this.Model, m => m.Property2);
      //((SampleCommand)this.Command1Command).AddObservableCollectionListener<SampleModel>(this.Model.ObservableCollection1);

      // Command2Command.
      Command2Command = new ActionCommand(
        (parameter) => {
          Command2CommandAction(parameter);
        },
        (parameter) => {
          return Command2CommandCanExecute(parameter);
        }
      );
      // Add listeners here.
      //((SampleCommand)this.Command2Command).AddListener<SampleModel>(this.Model, m => m.Property1);
      //((SampleCommand)this.Command2Command).AddListener<SampleModel>(this.Model, m => m.Property2);
      //((SampleCommand)this.Command2Command).AddObservableCollectionListener<SampleModel>(this.Model.ObservableCollection1);
      
    }

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

    /// <summary>
    /// The command action associated with <see cref="Command1Command"/>.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    private void Command1CommandAction(object parameter) {

    }

    /// <summary>
    /// Determines whether the <see cref="Command1Command"/> can execute.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    /// <returns>A <see cref="bool"/> with the result of the evaluation.</returns>
    private bool Command1CommandCanExecute(object parameter) {
      return false; // Replace with a boolean expression here.
    }

    /// <summary>
    /// The command action associated with <see cref="Command2Command"/>.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    private void Command2CommandAction(object parameter) {

    }

    /// <summary>
    /// Determines whether the <see cref="Command2Command"/> can execute.
    /// </summary>
    /// <param name="parameter">The parameter associated with the command.</param>
    /// <returns>A <see cref="bool"/> with the result of the evaluation.</returns>
    private bool Command2CommandCanExecute(object parameter) {
      return false; // Replace with a boolean expression here.
    }

    // TODO: 'Sample 2' of SubscribeToEvents method.

    ///// <summary>
    ///// An action used to refresh the GUI.
    ///// </summary>
    //private static Action RefreshDelegate = delegate() {
    //};

    #endregion

    #region BaseViewModel Members

    private const string _name = "SampleViewModel";

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
    //  // TODO: Subscribe to events here.
      
    //  // Sample 1
    //  //Control control1 = (Control)(triggeringObjectsDictionary["control1Name"]);
    //  //control1.Event1 += new Event1EventHandler(control1_Event1);
    //  // etc ...

    //  // Sample 2
    //  // In this sample the triggeringObjectsDictionary holds only labels.
    //  // During bulk operations the labels need to be refreshed every time the associated model changes
    //  // and not only once the bulk operation finishes and the wpf binding mechanism refreshes the labels.
    //  // To do so the UI dispatcher needs to explicitly refresh each label once a model property change is triggered.
    //  // 
    //  //_uiElementsDicionary = new Dictionary<string, UIElement>(triggeringObjectsDictionary.Count);
      
    //  //foreach (string key in triggeringObjectsDictionary.Keys) {
    //  //  _uiElementsDicionary.Add(key, (UIElement)triggeringObjectsDictionary[key]);
    //  //}
    //}

    ///// <summary>
    ///// Removes event subscriptions of this view model.
    ///// </summary>
    ///// <param name="triggeringControlsDictionary">The controls whose events will be stopped being observed.</param>
    //public void UnsubscribeFromEvents(Dictionary<string, object> triggeringControlsDictionary) {
    //  // TODO: Unsubscribe from events here.

    //  // Samples:
    //  //Control control1 = (Control)(triggeringObjectsDictionary["controlName"]);
    //  //control.Event1 -= new Event1EventHandler(control1_Event1);
    //}

    ///// <summary>
    ///// Sets the <see cref="CollectionViewSource">CollectionViewSources</see> for this model.
    ///// </summary>
    ///// <param name="collectionViewSourcesDictionary">
    ///// The dictionary of <see cref="CollectionViewSource">CollectionViewSources</see>
    ///// that will be used to display data.
    ///// </param>
    //public void SetCollectionViewSources(Dictionary<string, CollectionViewSource> collectionViewSourcesDictionary) {
    //  // TODO: Add any collection view sources here.

    //  // Samples:
    //  //_collection1ViewSource = collectionViewSourcesDictionary["collection1Name"];
    //  //_collection2ViewSource = collectionViewSourcesDictionary["collection2Name"];
    //  // ...
    //  //_collectionNViewSource = collectionViewSourcesDictionary["collectionNName"];

    //  // Or use the _collectionViewSourcesDictionary here to do something more systematic.
    //}

    #endregion

  }

}
