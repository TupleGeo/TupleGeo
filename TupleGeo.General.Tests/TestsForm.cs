using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TupleGeo.General.Data.SqlServer;
using TupleGeo.General.Serialization;
using TupleGeo.General.Tests.ObservableObjectTest;

namespace TupleGeo.General.Tests {

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
    private void TestConnectionDetailsSerializeButton_Click(object sender, EventArgs e) {

      ConnectionDetails connectionDetails = new ConnectionDetails();

      connectionDetails.DataSource = "DataSource1";
      connectionDetails.InitialCatalog = "InitialCatalog1";
      connectionDetails.IsPersistSecurityInfo = true;
      connectionDetails.SqlServerUserCollection.Add(new SqlServerUser() {
        IsPasswordEncrypted = false,
        IsPasswordPersisted = false,
        Password = "password1",
        UserName = "username1"
      });
      connectionDetails.SqlServerUserCollection.Add(new SqlServerUser() {
        IsPasswordEncrypted = false,
        IsPasswordPersisted = true,
        Password = "password2",
        UserName = "username2"
      });

      string serialized = XmlSerializer.SerializeToString(connectionDetails);

      this.ConnectionDetailsOutputTextBox.Text = serialized;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TestConnectionDetailsDeserializeButton_Click(object sender, EventArgs e) {

      ConnectionDetails connectionDetails = (ConnectionDetails)XmlSerializer.Deserialize(
        typeof(ConnectionDetails),
        this.ConnectionDetailsInputTextBox.Text,
        Encoding.UTF8
      );

    }

    private Obs1 _obs1 = new Obs1();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ObservableObjectTestButton_Click(object sender, EventArgs e) {

      _obs1.Double1 = 4.8;
      _obs1.Int1 = 2;
      _obs1.String1 = "lala";

      _obs1.PropertyChanged += obs1_PropertyChanged;

      this.obs1BindingSource.DataSource = _obs1;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void obs1_PropertyChanged(object sender, PropertyChangedEventArgs e) {
      MessageBox.Show(string.Format("Name: {0}, Value: {1}", e.PropertyName, sender.GetPropertyValueString(e.PropertyName)), "Property Changed");
      //MessageBox.Show(string.Format("Name: {0}", e.PropertyName), "Property Changed");
    }

  }

}
