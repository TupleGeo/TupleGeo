
#region Imported Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TupleGeo.General.Attributes;

#endregion

namespace TupleGeo.General.Windows.Presentation.Tests.ResourceDescription {
  
  /// <summary>
  /// 
  /// </summary>
  public enum CoffeeType : int {

    [ResourceDescriptionAttribute("Americano", typeof(CoffeeResources))]
    Americano = 0,

    [ResourceDescriptionAttribute("Mocha", typeof(CoffeeResources))]
    Mocha = 1,
    
    [ResourceDescriptionAttribute("Cappuccino", typeof(CoffeeResources))]
    Cappuccino = 2,
    
    [ResourceDescriptionAttribute("Greek", typeof(CoffeeResources))]
    Greek = 3,
    
    [ResourceDescriptionAttribute("Latte", typeof(CoffeeResources))]
    Latte = 4,

    [ResourceDescriptionAttribute("Espresso", typeof(CoffeeResources))]
    Espresso = 5,
    
  }

}
