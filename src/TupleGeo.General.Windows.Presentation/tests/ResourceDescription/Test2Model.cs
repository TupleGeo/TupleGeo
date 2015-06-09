using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TupleGeo.General.Windows.Presentation.Tests.ResourceDescription {
  
  /// <summary>
  /// 
  /// </summary>
  public class Test2Model {

    /// <summary>
    /// 
    /// </summary>
    public Test2Model() {
      Array values = Enum.GetValues(typeof(CoffeeType));
      _coffeeTypeList = new List<CoffeeType>(values.Length);

      for (int i = 0; i < values.Length; i++) {
        _coffeeTypeList.Add((CoffeeType)values.GetValue(i));
      }
    }

    private CoffeeType _currentCoffeeType;

    /// <summary>
    /// 
    /// </summary>
    public CoffeeType CurrentCoffeeType {
      get {
        return _currentCoffeeType;
      }
      set {
        _currentCoffeeType = value;
      }
    }

    private List<CoffeeType> _coffeeTypeList;

    /// <summary>
    /// 
    /// </summary>
    public List<CoffeeType> CoffeeTypeList {
      get {
        return _coffeeTypeList;
      }
      set {
        _coffeeTypeList = value;
      }
    }

  }

}
