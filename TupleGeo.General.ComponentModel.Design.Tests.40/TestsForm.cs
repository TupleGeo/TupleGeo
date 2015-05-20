using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TupleGeo.General.ComponentModel.Design.Tests.TestEnumDescription;

namespace TupleGeo.General.ComponentModel.Design.Tests {
  
  /// <summary>
  /// 
  /// </summary>
  public partial class TestsForm : Form {
    
    /// <summary>
    /// 
    /// </summary>
    public TestsForm() {
      InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void enumDescriptionEditorControlTest1Button_Click(object sender, EventArgs e) {
      string[] names = Enum.GetNames(typeof(TestEnum));
      string[] descriptions = EnumDescriptionConverter.GetEnumDescriptions(typeof(TestEnum), "el-GR");

      this.enumDescriptionEditorControl.EnumDescriptionsCollection.Clear();

      for (int i = 0; i < descriptions.Length; i++) {
        this.enumDescriptionEditorControl.EnumDescriptionsCollection.Add(
          new EnumNameDescriptionPair(names[i], descriptions[i])
        );
      }

      this.enumDescriptionEditorControl.DataBind();

      //string s;

      //Console.WriteLine("{0}: {1}", "el-GR", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar, "el-GR"));
      //Console.WriteLine("{0}: {1}", "fr", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar, "fr"));
      //Console.WriteLine("{0}: {1}", "Null", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar, null));
      //Console.WriteLine("{0}: {1}", "en-US", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar, "en-US"));
      //Console.WriteLine("{0}: {1}", "Empty", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar, ""));
      //Console.WriteLine("{0}: {1}", "Default", TupleGeo.General.Attributes.DescriptionAttribute.GetEnumeratedValueDescriptionAttribute(TestEnum.NormalCar));

      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.NormalCar));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.BigCar));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.SmallCar));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.Tractor));
      //Console.WriteLine();

      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "NormalCar"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "BigCar"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "SmallCar"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "Tractor"));
      //Console.WriteLine();

      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.NormalCar, "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.BigCar, "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.SmallCar, "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(TestEnum.Tractor, "el-GR"));
      //Console.WriteLine();

      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "NormalCar", "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "BigCar", "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "SmallCar", "el-GR"));
      //Console.WriteLine("{0}", EnumDescriptionConverter.GetEnumDescription(typeof(TestEnum), "Tractor", "el-GR"));
      //Console.WriteLine();

    }

  }

}
