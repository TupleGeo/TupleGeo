using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TupleGeo.General.Windows.Presentation.Tests.ResourceDescription;

namespace TupleGeo.General.Windows.Presentation.Tests {

  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {
      base.OnStartup(e);

      Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("el-GR");
      Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("el-GR");

      CoffeeResources.Culture = Thread.CurrentThread.CurrentUICulture;
    }
  
  }

}
