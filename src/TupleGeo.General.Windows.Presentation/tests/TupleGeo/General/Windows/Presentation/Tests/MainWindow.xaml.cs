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
using TupleGeo.General.Windows.Presentation.Tests.ResourceDescription;

namespace TupleGeo.General.Windows.Presentation.Tests {

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    
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

  }

}
