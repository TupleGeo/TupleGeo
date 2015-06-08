
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TupleGeo.Apps;
using TupleGeo.Apps.Presentation;
using TupleGeo.TemplateApplication.Models;

#endregion

namespace TupleGeo.TemplateApplication.ViewModels {

  /// <summary>
  /// The shell view model.
  /// </summary>
  public sealed class ShellViewModel : BaseViewModel<ShellModel>, IViewModel {

    #region Member Variables

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="ShellViewModel"/>.
    /// </summary>
    /// <param name="shellModel">The <see cref="ShellModel"/> used against this view model.</param>
    public ShellViewModel(ShellModel shellModel)
      : base(shellModel) {
      
    }

    #endregion

    #region Public Properties

    #endregion

    #region Public Methods

    /// <summary>
    /// Sets the cursor of the shell.
    /// </summary>
    /// <param name="cursor">The <see cref="Cursor"/> that will be set.</param>
    public static void SetCursor(Cursor cursor) {
      Application.Current.MainWindow.Cursor = cursor;
    }

    #endregion

    #region Event Procedures

    #endregion

    #region Private Procedures

    #endregion

    #region Private Actions

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

    private const string _name = "ShellViewModel";

    /// <summary>
    /// Gets the name of the view model.
    /// </summary>
    public string Name {
      get {
        return _name;
      }
    }

    /// <summary>
    /// Binds this view model to events raised by its corresponding view.
    /// </summary>
    /// <param name="triggeringObjectsDictionary">The object whose events will be observed.</param>
    public void SubscribeToEvents(Dictionary<string, object> triggeringObjectsDictionary) {

    }

    /// <summary>
    /// Removes event subscriptions of this view model.
    /// </summary>
    /// <param name="triggeringObjectsDictionary">The objects whose events will be stopped being observed.</param>
    public void UnsubscribeFromEvents(Dictionary<string, object> triggeringObjectsDictionary) {
      
    }

    /// <summary>
    /// Sets the <see cref="CollectionViewSource">CollectionViewSources</see> for this model.
    /// </summary>
    /// <param name="collectionViewSourcesDictionary">
    /// The Dictionary of collection view sources that will be used to display data.
    /// </param>
    public void SetCollectionViewSources(Dictionary<string, CollectionViewSource> collectionViewSourcesDictionary) {

    }
    
    #endregion

  }

}
