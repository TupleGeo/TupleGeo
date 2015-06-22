
#region Header

#endregion

#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TupleGeo.Apps;

#endregion

namespace TupleGeo.TemplateApplication.Views {

  /// <summary>
  /// The User View.
  /// </summary>
  public partial class UserView : UserControl, IView {

    #region Constructors - Destructors

    /// <summary>
    /// Initializes the <see cref="UserView"/>.
    /// </summary>
    public UserView() {
      InitializeComponent();
      InitializeView();
    }

    #endregion

    #region Private Procedures

    /// <summary>
    /// Initializes the view.
    /// </summary>
    private void InitializeView() {

      try {
        // Make sure this executes in runtime.
        if (!DesignerProperties.GetIsInDesignMode(this)) {
          // The viewmodel of this view acts as a datacontext. Bind the viewmodel here.
          //ShellViewModel shellViewModel = (ShellViewModel)((IViewModel)(Catalog.GetViewModel(this.GetType())));
          //this.DataContext = shellViewModel;

          // The event procedures reside in to the viewmodel. Bind the view model event procedures here.

          // The dictionary of the controls needed to be observed by the viewmodel.
          //Dictionary<string, object> observedControlsDictionary = new Dictionary<string, object>();
          // Add the controls.
          //observedControlsDictionary.Add(this.layoutGrid.Name, this.layoutGrid);

          // Call the SubscribeToEvents method of the viewmodel.
          //shellViewModel.SubscribeToEvents(observedControlsDictionary);

          // Get any CollectionViewSources defined in the view as resources.
          //Dictionary<string, CollectionViewSource> collectionViewSourcesDictionary = new Dictionary<string, CollectionViewSource>();
          //CollectionViewSource collection1ViewSource = (CollectionViewSource)(this.Resources["collection1ViewSourceName"]); // TODO: Change key and value here.
          //collectionViewSourcesDictionary.Add("collection1ViewSourceName", collection1ViewSource); // TODO: Change key and value here.
          //CollectionViewSource collection2ViewSource = (CollectionViewSource)(this.Resources["collection2ViewSourceName"]); // TODO: Change key and value here.
          //collectionViewSourcesDictionary.Add("collection2ViewSourceName", collection2ViewSource); // TODO: Change key and value here.
          // ...
          //CollectionViewSource collectionNViewSource = (CollectionViewSource)(this.Resources["collectionNViewSourceName"]); // TODO: Change key and value here.
          //collectionViewSourcesDictionary.Add("collectionNViewSourceName", collectionNViewSource); // TODO: Change key and value here.

          // Set the collection view sources in the viewmodel.
          //sampleViewModel.SetCollectionViewSources(collectionViewSourcesDictionary);
        }
      }
      catch (Exception ex) {
        //AppEngine.Instance.LogError(ex, "ShellView - InitializeView()");
        string error = "An Error has occurred during data binding in 'UserView'\r\n\r\n" +
                       "Error Message: " + ex.Message + "\r\n\r\n";
        if (ex.InnerException != null) {
          error += string.Format(CultureInfo.InvariantCulture, "Inner Exception: {0}", ex.InnerException.Message);
        }
        MessageBox.Show(error, TupleGeo.TemplateApplication.Properties.Resources.Application_ViewDataBindingError, MessageBoxButton.OK, MessageBoxImage.Error);
      }

    }

    #endregion

    #region IView Members

    /// <summary>
    /// Gets the view name.
    /// </summary>
    public string ViewName {
      get {
        return "UserView";
      }
    }

    #endregion

  }

}
