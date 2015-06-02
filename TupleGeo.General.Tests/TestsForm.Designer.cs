namespace TupleGeo.General.Tests {
  partial class TestsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label double1Label;
      System.Windows.Forms.Label int1Label;
      System.Windows.Forms.Label string1Label;
      this.TestsTabControl = new System.Windows.Forms.TabControl();
      this.ConnectionDetailsTabPage = new System.Windows.Forms.TabPage();
      this.ConnectionDetailsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.ConnectionDetailsInputTextBox = new System.Windows.Forms.TextBox();
      this.ConnectionDetailsOutputTextBox = new System.Windows.Forms.TextBox();
      this.ConnectionDetailsPanel = new System.Windows.Forms.Panel();
      this.TestConnectionDetailsDeserializeButton = new System.Windows.Forms.Button();
      this.TestConnectionDetailsSerializeButton = new System.Windows.Forms.Button();
      this.ObservableObjectTabPage = new System.Windows.Forms.TabPage();
      this.double1TextBox = new System.Windows.Forms.TextBox();
      this.obs1BindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.int1TextBox = new System.Windows.Forms.TextBox();
      this.string1TextBox = new System.Windows.Forms.TextBox();
      this.ObservableObjectTestButton = new System.Windows.Forms.Button();
      double1Label = new System.Windows.Forms.Label();
      int1Label = new System.Windows.Forms.Label();
      string1Label = new System.Windows.Forms.Label();
      this.TestsTabControl.SuspendLayout();
      this.ConnectionDetailsTabPage.SuspendLayout();
      this.ConnectionDetailsTableLayoutPanel.SuspendLayout();
      this.ConnectionDetailsPanel.SuspendLayout();
      this.ObservableObjectTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.obs1BindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // double1Label
      // 
      double1Label.AutoSize = true;
      double1Label.Location = new System.Drawing.Point(4, 11);
      double1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      double1Label.Name = "double1Label";
      double1Label.Size = new System.Drawing.Size(50, 13);
      double1Label.TabIndex = 1;
      double1Label.Text = "Double1:";
      // 
      // int1Label
      // 
      int1Label.AutoSize = true;
      int1Label.Location = new System.Drawing.Point(4, 34);
      int1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      int1Label.Name = "int1Label";
      int1Label.Size = new System.Drawing.Size(28, 13);
      int1Label.TabIndex = 3;
      int1Label.Text = "Int1:";
      // 
      // string1Label
      // 
      string1Label.AutoSize = true;
      string1Label.Location = new System.Drawing.Point(4, 57);
      string1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      string1Label.Name = "string1Label";
      string1Label.Size = new System.Drawing.Size(43, 13);
      string1Label.TabIndex = 5;
      string1Label.Text = "String1:";
      // 
      // TestsTabControl
      // 
      this.TestsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TestsTabControl.Controls.Add(this.ConnectionDetailsTabPage);
      this.TestsTabControl.Controls.Add(this.ObservableObjectTabPage);
      this.TestsTabControl.Location = new System.Drawing.Point(9, 10);
      this.TestsTabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.TestsTabControl.Name = "TestsTabControl";
      this.TestsTabControl.SelectedIndex = 0;
      this.TestsTabControl.Size = new System.Drawing.Size(855, 533);
      this.TestsTabControl.TabIndex = 0;
      // 
      // ConnectionDetailsTabPage
      // 
      this.ConnectionDetailsTabPage.Controls.Add(this.ConnectionDetailsTableLayoutPanel);
      this.ConnectionDetailsTabPage.Location = new System.Drawing.Point(4, 22);
      this.ConnectionDetailsTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsTabPage.Name = "ConnectionDetailsTabPage";
      this.ConnectionDetailsTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsTabPage.Size = new System.Drawing.Size(847, 507);
      this.ConnectionDetailsTabPage.TabIndex = 0;
      this.ConnectionDetailsTabPage.Text = "Connection Details Tests";
      this.ConnectionDetailsTabPage.UseVisualStyleBackColor = true;
      // 
      // ConnectionDetailsTableLayoutPanel
      // 
      this.ConnectionDetailsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ConnectionDetailsTableLayoutPanel.ColumnCount = 2;
      this.ConnectionDetailsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.ConnectionDetailsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
      this.ConnectionDetailsTableLayoutPanel.Controls.Add(this.ConnectionDetailsInputTextBox, 0, 0);
      this.ConnectionDetailsTableLayoutPanel.Controls.Add(this.ConnectionDetailsOutputTextBox, 0, 1);
      this.ConnectionDetailsTableLayoutPanel.Controls.Add(this.ConnectionDetailsPanel, 1, 0);
      this.ConnectionDetailsTableLayoutPanel.Location = new System.Drawing.Point(4, 5);
      this.ConnectionDetailsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsTableLayoutPanel.Name = "ConnectionDetailsTableLayoutPanel";
      this.ConnectionDetailsTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsTableLayoutPanel.RowCount = 2;
      this.ConnectionDetailsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ConnectionDetailsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.ConnectionDetailsTableLayoutPanel.Size = new System.Drawing.Size(840, 500);
      this.ConnectionDetailsTableLayoutPanel.TabIndex = 0;
      // 
      // ConnectionDetailsInputTextBox
      // 
      this.ConnectionDetailsInputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ConnectionDetailsInputTextBox.Location = new System.Drawing.Point(4, 4);
      this.ConnectionDetailsInputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsInputTextBox.Multiline = true;
      this.ConnectionDetailsInputTextBox.Name = "ConnectionDetailsInputTextBox";
      this.ConnectionDetailsInputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.ConnectionDetailsInputTextBox.Size = new System.Drawing.Size(682, 244);
      this.ConnectionDetailsInputTextBox.TabIndex = 0;
      // 
      // ConnectionDetailsOutputTextBox
      // 
      this.ConnectionDetailsOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ConnectionDetailsOutputTextBox.Location = new System.Drawing.Point(4, 252);
      this.ConnectionDetailsOutputTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ConnectionDetailsOutputTextBox.Multiline = true;
      this.ConnectionDetailsOutputTextBox.Name = "ConnectionDetailsOutputTextBox";
      this.ConnectionDetailsOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.ConnectionDetailsOutputTextBox.Size = new System.Drawing.Size(682, 244);
      this.ConnectionDetailsOutputTextBox.TabIndex = 1;
      // 
      // ConnectionDetailsPanel
      // 
      this.ConnectionDetailsPanel.Controls.Add(this.TestConnectionDetailsDeserializeButton);
      this.ConnectionDetailsPanel.Controls.Add(this.TestConnectionDetailsSerializeButton);
      this.ConnectionDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ConnectionDetailsPanel.Location = new System.Drawing.Point(688, 2);
      this.ConnectionDetailsPanel.Margin = new System.Windows.Forms.Padding(0);
      this.ConnectionDetailsPanel.Name = "ConnectionDetailsPanel";
      this.ConnectionDetailsPanel.Size = new System.Drawing.Size(150, 248);
      this.ConnectionDetailsPanel.TabIndex = 3;
      // 
      // TestConnectionDetailsDeserializeButton
      // 
      this.TestConnectionDetailsDeserializeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TestConnectionDetailsDeserializeButton.Location = new System.Drawing.Point(2, 33);
      this.TestConnectionDetailsDeserializeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.TestConnectionDetailsDeserializeButton.Name = "TestConnectionDetailsDeserializeButton";
      this.TestConnectionDetailsDeserializeButton.Size = new System.Drawing.Size(146, 26);
      this.TestConnectionDetailsDeserializeButton.TabIndex = 3;
      this.TestConnectionDetailsDeserializeButton.Text = "Deserialize";
      this.TestConnectionDetailsDeserializeButton.UseVisualStyleBackColor = true;
      this.TestConnectionDetailsDeserializeButton.Click += new System.EventHandler(this.TestConnectionDetailsDeserializeButton_Click);
      // 
      // TestConnectionDetailsSerializeButton
      // 
      this.TestConnectionDetailsSerializeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TestConnectionDetailsSerializeButton.Location = new System.Drawing.Point(2, 2);
      this.TestConnectionDetailsSerializeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.TestConnectionDetailsSerializeButton.Name = "TestConnectionDetailsSerializeButton";
      this.TestConnectionDetailsSerializeButton.Size = new System.Drawing.Size(146, 26);
      this.TestConnectionDetailsSerializeButton.TabIndex = 2;
      this.TestConnectionDetailsSerializeButton.Text = "Serialize";
      this.TestConnectionDetailsSerializeButton.UseVisualStyleBackColor = true;
      this.TestConnectionDetailsSerializeButton.Click += new System.EventHandler(this.TestConnectionDetailsSerializeButton_Click);
      // 
      // ObservableObjectTabPage
      // 
      this.ObservableObjectTabPage.AutoScroll = true;
      this.ObservableObjectTabPage.Controls.Add(double1Label);
      this.ObservableObjectTabPage.Controls.Add(this.double1TextBox);
      this.ObservableObjectTabPage.Controls.Add(int1Label);
      this.ObservableObjectTabPage.Controls.Add(this.int1TextBox);
      this.ObservableObjectTabPage.Controls.Add(string1Label);
      this.ObservableObjectTabPage.Controls.Add(this.string1TextBox);
      this.ObservableObjectTabPage.Controls.Add(this.ObservableObjectTestButton);
      this.ObservableObjectTabPage.Location = new System.Drawing.Point(4, 22);
      this.ObservableObjectTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ObservableObjectTabPage.Name = "ObservableObjectTabPage";
      this.ObservableObjectTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ObservableObjectTabPage.Size = new System.Drawing.Size(847, 507);
      this.ObservableObjectTabPage.TabIndex = 1;
      this.ObservableObjectTabPage.Text = "ObservableObject";
      this.ObservableObjectTabPage.UseVisualStyleBackColor = true;
      // 
      // double1TextBox
      // 
      this.double1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.obs1BindingSource, "Double1", true));
      this.double1TextBox.Location = new System.Drawing.Point(58, 9);
      this.double1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.double1TextBox.Name = "double1TextBox";
      this.double1TextBox.Size = new System.Drawing.Size(76, 20);
      this.double1TextBox.TabIndex = 2;
      // 
      // obs1BindingSource
      // 
      this.obs1BindingSource.DataSource = typeof(TupleGeo.General.Tests.ObservableObjectTest.Obs1);
      // 
      // int1TextBox
      // 
      this.int1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.obs1BindingSource, "Int1", true));
      this.int1TextBox.Location = new System.Drawing.Point(58, 32);
      this.int1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.int1TextBox.Name = "int1TextBox";
      this.int1TextBox.Size = new System.Drawing.Size(76, 20);
      this.int1TextBox.TabIndex = 4;
      // 
      // string1TextBox
      // 
      this.string1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.obs1BindingSource, "String1", true));
      this.string1TextBox.Location = new System.Drawing.Point(58, 54);
      this.string1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.string1TextBox.Name = "string1TextBox";
      this.string1TextBox.Size = new System.Drawing.Size(76, 20);
      this.string1TextBox.TabIndex = 6;
      // 
      // ObservableObjectTestButton
      // 
      this.ObservableObjectTestButton.Location = new System.Drawing.Point(688, 5);
      this.ObservableObjectTestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.ObservableObjectTestButton.Name = "ObservableObjectTestButton";
      this.ObservableObjectTestButton.Size = new System.Drawing.Size(156, 26);
      this.ObservableObjectTestButton.TabIndex = 0;
      this.ObservableObjectTestButton.Text = "Observable Object Test";
      this.ObservableObjectTestButton.UseVisualStyleBackColor = true;
      this.ObservableObjectTestButton.Click += new System.EventHandler(this.ObservableObjectTestButton_Click);
      // 
      // TestsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(873, 552);
      this.Controls.Add(this.TestsTabControl);
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.Name = "TestsForm";
      this.Text = "Form1";
      this.TestsTabControl.ResumeLayout(false);
      this.ConnectionDetailsTabPage.ResumeLayout(false);
      this.ConnectionDetailsTableLayoutPanel.ResumeLayout(false);
      this.ConnectionDetailsTableLayoutPanel.PerformLayout();
      this.ConnectionDetailsPanel.ResumeLayout(false);
      this.ObservableObjectTabPage.ResumeLayout(false);
      this.ObservableObjectTabPage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.obs1BindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl TestsTabControl;
    private System.Windows.Forms.TabPage ConnectionDetailsTabPage;
    private System.Windows.Forms.TabPage ObservableObjectTabPage;
    private System.Windows.Forms.TableLayoutPanel ConnectionDetailsTableLayoutPanel;
    private System.Windows.Forms.TextBox ConnectionDetailsInputTextBox;
    private System.Windows.Forms.TextBox ConnectionDetailsOutputTextBox;
    private System.Windows.Forms.Button TestConnectionDetailsSerializeButton;
    private System.Windows.Forms.Panel ConnectionDetailsPanel;
    private System.Windows.Forms.Button TestConnectionDetailsDeserializeButton;
    private System.Windows.Forms.Button ObservableObjectTestButton;
    private System.Windows.Forms.TextBox double1TextBox;
    private System.Windows.Forms.BindingSource obs1BindingSource;
    private System.Windows.Forms.TextBox int1TextBox;
    private System.Windows.Forms.TextBox string1TextBox;
  }
}

