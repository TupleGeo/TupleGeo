using System;
using System.Collections.Generic;
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
using TupleGeo.Apps.Presentation.Tests.ObserverTests;

namespace TupleGeo.Apps.Presentation.Tests {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    #region Member Variables

    private Observer _observer = new Observer();
    private CarModel _carModel;

    #endregion

    #region Constructors - Destructors

    /// <summary>
    /// 
    /// </summary>
    public MainWindow() {
      InitializeComponent();
    }

    #endregion

    #region Event Procedures

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SetupObserver_Click(object sender, RoutedEventArgs e) {

      _carModel = new CarModel() {
        Id = 1,
        Brand = "Ford",
        Colour = "Red",
        Weight = 1200
      };

      _observer.AddPropertyChangedListener<CarModel>(_carModel, m => m.Brand);
      _observer.AddPropertyChangedListener<CarModel>(_carModel, m => m.Colour);
      _observer.AddPropertyChangedListener<CarModel>(_carModel, m => m.Weight);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TestObserver_Click(object sender, RoutedEventArgs e) {

      _carModel.Brand = "Mazda";
      _carModel.Colour = "Blue";
      _carModel.Weight = 1500;

    }

    #endregion

  }

}
