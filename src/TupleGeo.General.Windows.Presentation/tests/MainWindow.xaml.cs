using System;
using System.Collections;
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
using TupleGeo.General.Windows.Data;
using TupleGeo.General.Windows.Presentation.Tests.Filtering;
using TupleGeo.General.Windows.Presentation.Tests.ResourceDescription;

namespace TupleGeo.General.Windows.Presentation.Tests {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    //private CollectionViewSource _collectionViewSource;
    private CollectionViewSource _personViewSource;
    
    /// <summary>
    /// 
    /// </summary>
    public MainWindow() {
      InitializeComponent();
      this.Test1Grid.DataContext = new Test1ViewModel();
      this.Test2Grid.DataContext = new Test2ViewModel();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Test1GetCurrentValueButton_Click(object sender, RoutedEventArgs e) {
      Test1ViewModel viewModel = (Test1ViewModel)this.Test1Grid.DataContext;
      MessageBox.Show(viewModel.Test1Model.CoffeeType.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Test2GetCurrentValueButton_Click(object sender, RoutedEventArgs e) {
      Test2ViewModel viewModel = (Test2ViewModel)this.Test2Grid.DataContext;
      MessageBox.Show(viewModel.Test2Model.CurrentCoffeeType.ToString());
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ShowListButton_Click(object sender, RoutedEventArgs e) {

      //List<int> testList = new List<int>();

      //testList.Add(40);
      //testList.Add(21);
      //testList.Add(35);
      //testList.Add(67);
      //testList.Add(88);
      //testList.Add(76);
      //testList.Add(32);
      //testList.Add(45);

      List<Person> testList = new List<Person>();

      testList.Add(new Person() {
        Age = 23,
        Id = 1,
        Name = "Koula"
      });
      testList.Add(new Person() {
        Age = 45,
        Id = 2,
        Name = "Roula"
      });
      testList.Add(new Person() {
        Age = 18,
        Id = 3,
        Name = "Soula"
      });
      testList.Add(new Person() {
        Age = 62,
        Id = 4,
        Name = "Loula"
      });

      //_collectionViewSource = new CollectionViewSource();
      //_collectionViewSource.Source = testList;

      //Binding binding = new Binding();
      //binding.Source = _collectionViewSource;

      //BindingOperations.SetBinding(this.DataListView, ListView.ItemsSourceProperty, binding);

      _personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
      // Load data by setting the CollectionViewSource.Source property:
      // personViewSource.Source = [generic data source]
      _personViewSource.Source = testList;
      
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FilterListButton_Click(object sender, RoutedEventArgs e) {

      //Filter filter = new Filter();

      //filter.Id = 1;
      //filter.Name = "Test";
      //filter.Description = "Find those greater than 50";
      //filter.Callback = item => {
      //  int i = int.Parse(item.ToString());
      //  return i > 50;
      //};

      //_collectionViewSource.View.Filter = filter.Callback;

      Filter filter = new Filter();

      filter.Id = 1;
      filter.Name = "Test";
      filter.Description = "Find those older than 40";
      filter.Callback = item => {
        Person p = (Person)item;
        return p.Age > 40;
      };

      //_collectionViewSource.View.Filter = filter.Callback;
      _personViewSource.View.Filter = filter.Callback;

    }

  }

}
