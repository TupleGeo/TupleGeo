using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TupleGeo.Apps.Presentation.Tests.ObserverTests;

namespace TupleGeo.Apps.Presentation.Tests {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    #region Member Variables

    private Observer _observer = new Observer();
    private CarModel _carModel;
    private ObservableCollection<CarModel> _carModels = new ObservableCollection<CarModel>();

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
    private void SetupWeakPropertyObserver_Click(object sender, RoutedEventArgs e) {

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
    private void SetupHardPropertyObserver_Click(object sender, RoutedEventArgs e) {

      _carModel = new CarModel() {
        Id = 1,
        Brand = "Ford",
        Colour = "Red",
        Weight = 1200
      };

      _observer.AddPropertyChangedListener<CarModel>(_carModel);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SetupWeakCollectionObserver_Click(object sender, RoutedEventArgs e) {

      _carModels.Add(new CarModel() {
        Id = 1,
        Brand = "Ford",
        Colour = "Red",
        Weight = 1200
      });
      _carModels.Add(new CarModel() {
        Id = 2,
        Brand = "Mercedes",
        Colour = "Gray",
        Weight = 1800
      });
      _carModels.Add(new CarModel() {
        Id = 3,
        Brand = "Kia",
        Colour = "Yellow",
        Weight = 800
      });
      _carModels.Add(new CarModel() {
        Id = 4,
        Brand = "Peugeot",
        Colour = "Green",
        Weight = 1400
      });

      _observer.AddCollectionChangedListener(_carModels);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SetupHardCollectionObserver_Click(object sender, RoutedEventArgs e) {

      _carModels.Add(new CarModel() {
        Id = 1,
        Brand = "Ford",
        Colour = "Red",
        Weight = 1200
      });
      _carModels.Add(new CarModel() {
        Id = 2,
        Brand = "Mercedes",
        Colour = "Gray",
        Weight = 1800
      });
      _carModels.Add(new CarModel() {
        Id = 3,
        Brand = "Kia",
        Colour = "Yellow",
        Weight = 800
      });
      _carModels.Add(new CarModel() {
        Id = 4,
        Brand = "Peugeot",
        Colour = "Green",
        Weight = 1400
      });

      _observer.AddCollectionChangedListener(_carModels);
      
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TestPropertyObserver_Click(object sender, RoutedEventArgs e) {

      _carModel.Brand = "Mazda";
      _carModel.Colour = "Blue";
      _carModel.Weight = 1500;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TestCollectionObserver_Click(object sender, RoutedEventArgs e) {

      _carModels.RemoveAt(2);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TestGeneral_Click(object sender, RoutedEventArgs e) {

      Type viewType = typeof(TestView);
      
      Type viewInterface = viewType.GetInterface("IView2");

    }

    #endregion

  }

}
