using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TupleGeo.Apps.Presentation.Tests.ObserverTests {
  /// <summary>
  /// Interaction logic for TestView.xaml
  /// </summary>
  public partial class TestView : UserControl, IView {
    public TestView() {
      InitializeComponent();
    }

    #region IView Members

    /// <summary>
    /// 
    /// </summary>
    public string ViewName {
      get {
        return "TestView";
      }
    }

    #endregion

  }

}
