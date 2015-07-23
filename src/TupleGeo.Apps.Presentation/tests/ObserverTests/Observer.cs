
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TupleGeo.Apps.Presentation.Observers;
using TupleGeo.General;

#endregion

namespace TupleGeo.Apps.Presentation.Tests.ObserverTests {

  /// <summary>
  /// 
  /// </summary>
  public class Observer : CentralizedObserver {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="notifyCollectionChangedEventArgs"></param>
    public override void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) {
      base.OnCollectionChanged(sender, notifyCollectionChangedEventArgs);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="propertyChangedEventArgs"></param>
    public override void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs propertyChangedEventArgs) {
      base.OnPropertyChanged(sender, propertyChangedEventArgs);


      if (sender.GetType() == typeof(CarModel)) {
        CarModel carModel = (CarModel)sender;
        
        MessageBox.Show(
          string.Format("New Value: {0}", carModel.GetPropertyValueString(propertyChangedEventArgs.PropertyName)),
          string.Format("Property: {0}", propertyChangedEventArgs.PropertyName)
        );
      }


      

    }
        
  }

}
