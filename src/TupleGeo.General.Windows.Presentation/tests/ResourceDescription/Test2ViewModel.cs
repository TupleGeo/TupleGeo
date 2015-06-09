using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TupleGeo.General.Windows.Presentation.Tests.ResourceDescription {
  
  /// <summary>
  /// 
  /// </summary>
  public class Test2ViewModel {

    private Test2Model _test2Model = new Test2Model {
      CurrentCoffeeType = ResourceDescription.CoffeeType.Cappuccino
    };

    /// <summary>
    /// 
    /// </summary>
    public Test2Model Test2Model {
      get {
        return _test2Model;
      }
    }

  }

}
