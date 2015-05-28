using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TupleGeo.General.Windows.Presentation.Tests.ResourceDescription {

  /// <summary>
  /// 
  /// </summary>
  public class Test1ViewModel {

    private Test1Model _test1Model = new Test1Model {
      CoffeeType = ResourceDescription.CoffeeType.Greek
    };

    /// <summary>
    /// 
    /// </summary>
    public Test1Model Test1Model {
      get {
        return _test1Model;
      }
    }

  }

}
