using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TupleGeo.General.Attributes;

namespace TupleGeo.General.ComponentModel.Design.Tests.TestEnumDescription {
  
  /// <summary>
  /// 
  /// </summary>
  public enum TestEnum {

    [DescriptionAttribute("Normal car")]
    [DescriptionAttribute("Κανονικό αυτοκίνητο", "el-GR")]
    NormalCar = 0,

    [DescriptionAttribute("Big car")]
    [DescriptionAttribute("Μεγάλο αυτοκίνητο", "el-GR")]
    BigCar = 1,

    [DescriptionAttribute("Small car")]
    [DescriptionAttribute("Μικρό αυτοκίνητο", "el-GR")]
    SmallCar = 2,

    [DescriptionAttribute("TRACTOR")]
    [DescriptionAttribute("Νταλίκα", "el-GR")]
    Tractor = 3

  }

}
