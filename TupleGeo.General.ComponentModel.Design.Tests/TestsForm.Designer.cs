namespace TupleGeo.General.ComponentModel.Design.Tests {
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
      this.testsTabControl = new System.Windows.Forms.TabControl();
      this.enumDescriptionEditorControlTabPage = new System.Windows.Forms.TabPage();
      this.testEnumDescriptionsButton = new System.Windows.Forms.Button();
      this.testEnumDescriptionEditorControlButton = new System.Windows.Forms.Button();
      this.enumDescriptionEditorTabPage = new System.Windows.Forms.TabPage();
      this.testEnumDescriptionEditorButton = new System.Windows.Forms.Button();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.greekToLatinTabPage = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.testTranscribeButton = new System.Windows.Forms.Button();
      this.fromGreekTextBox = new System.Windows.Forms.TextBox();
      this.toLatinTextBox = new System.Windows.Forms.TextBox();
      this.appCultureComboBox = new System.Windows.Forms.ComboBox();
      this.enumDescriptionEditorControl = new TupleGeo.General.ComponentModel.Design.EnumDescriptionEditorControl();
      this.applicationCultureLabel = new System.Windows.Forms.Label();
      this.testsTabControl.SuspendLayout();
      this.enumDescriptionEditorControlTabPage.SuspendLayout();
      this.enumDescriptionEditorTabPage.SuspendLayout();
      this.greekToLatinTabPage.SuspendLayout();
      this.tableLayoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // testsTabControl
      // 
      this.testsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.testsTabControl.Controls.Add(this.enumDescriptionEditorControlTabPage);
      this.testsTabControl.Controls.Add(this.enumDescriptionEditorTabPage);
      this.testsTabControl.Controls.Add(this.greekToLatinTabPage);
      this.testsTabControl.Location = new System.Drawing.Point(12, 41);
      this.testsTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.testsTabControl.Name = "testsTabControl";
      this.testsTabControl.SelectedIndex = 0;
      this.testsTabControl.Size = new System.Drawing.Size(1156, 634);
      this.testsTabControl.TabIndex = 0;
      // 
      // enumDescriptionEditorControlTabPage
      // 
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.testEnumDescriptionsButton);
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.testEnumDescriptionEditorControlButton);
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.enumDescriptionEditorControl);
      this.enumDescriptionEditorControlTabPage.Location = new System.Drawing.Point(4, 25);
      this.enumDescriptionEditorControlTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.enumDescriptionEditorControlTabPage.Name = "enumDescriptionEditorControlTabPage";
      this.enumDescriptionEditorControlTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.enumDescriptionEditorControlTabPage.Size = new System.Drawing.Size(1148, 605);
      this.enumDescriptionEditorControlTabPage.TabIndex = 1;
      this.enumDescriptionEditorControlTabPage.Text = "EnumDescriptionEditorControl Tests";
      this.enumDescriptionEditorControlTabPage.UseVisualStyleBackColor = true;
      // 
      // testEnumDescriptionsButton
      // 
      this.testEnumDescriptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.testEnumDescriptionsButton.Location = new System.Drawing.Point(752, 7);
      this.testEnumDescriptionsButton.Margin = new System.Windows.Forms.Padding(4);
      this.testEnumDescriptionsButton.Name = "testEnumDescriptionsButton";
      this.testEnumDescriptionsButton.Size = new System.Drawing.Size(387, 28);
      this.testEnumDescriptionsButton.TabIndex = 2;
      this.testEnumDescriptionsButton.Text = "Test Enum Descriptions";
      this.testEnumDescriptionsButton.UseVisualStyleBackColor = true;
      this.testEnumDescriptionsButton.Click += new System.EventHandler(this.testEnumDescriptionsbutton_Click);
      // 
      // testEnumDescriptionEditorControlButton
      // 
      this.testEnumDescriptionEditorControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.testEnumDescriptionEditorControlButton.Location = new System.Drawing.Point(752, 42);
      this.testEnumDescriptionEditorControlButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.testEnumDescriptionEditorControlButton.Name = "testEnumDescriptionEditorControlButton";
      this.testEnumDescriptionEditorControlButton.Size = new System.Drawing.Size(387, 28);
      this.testEnumDescriptionEditorControlButton.TabIndex = 1;
      this.testEnumDescriptionEditorControlButton.Text = "Test Enum Description Editor Control";
      this.testEnumDescriptionEditorControlButton.UseVisualStyleBackColor = true;
      this.testEnumDescriptionEditorControlButton.Click += new System.EventHandler(this.testEnumDescriptionEditorControlButton_Click);
      // 
      // enumDescriptionEditorTabPage
      // 
      this.enumDescriptionEditorTabPage.Controls.Add(this.testEnumDescriptionEditorButton);
      this.enumDescriptionEditorTabPage.Controls.Add(this.propertyGrid);
      this.enumDescriptionEditorTabPage.Location = new System.Drawing.Point(4, 25);
      this.enumDescriptionEditorTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.enumDescriptionEditorTabPage.Name = "enumDescriptionEditorTabPage";
      this.enumDescriptionEditorTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.enumDescriptionEditorTabPage.Size = new System.Drawing.Size(1148, 605);
      this.enumDescriptionEditorTabPage.TabIndex = 0;
      this.enumDescriptionEditorTabPage.Text = "EnumDescriptionEditor Tests";
      this.enumDescriptionEditorTabPage.UseVisualStyleBackColor = true;
      // 
      // testEnumDescriptionEditorButton
      // 
      this.testEnumDescriptionEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.testEnumDescriptionEditorButton.Location = new System.Drawing.Point(802, 6);
      this.testEnumDescriptionEditorButton.Margin = new System.Windows.Forms.Padding(4);
      this.testEnumDescriptionEditorButton.Name = "testEnumDescriptionEditorButton";
      this.testEnumDescriptionEditorButton.Size = new System.Drawing.Size(339, 28);
      this.testEnumDescriptionEditorButton.TabIndex = 1;
      this.testEnumDescriptionEditorButton.Text = "Test EnumDescriptionEditor";
      this.testEnumDescriptionEditorButton.UseVisualStyleBackColor = true;
      this.testEnumDescriptionEditorButton.Click += new System.EventHandler(this.testEnumDescriptionEditorButton_Click);
      // 
      // propertyGrid
      // 
      this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.propertyGrid.Location = new System.Drawing.Point(7, 6);
      this.propertyGrid.Margin = new System.Windows.Forms.Padding(4);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(472, 590);
      this.propertyGrid.TabIndex = 0;
      // 
      // greekToLatinTabPage
      // 
      this.greekToLatinTabPage.Controls.Add(this.tableLayoutPanel);
      this.greekToLatinTabPage.Location = new System.Drawing.Point(4, 25);
      this.greekToLatinTabPage.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.greekToLatinTabPage.Name = "greekToLatinTabPage";
      this.greekToLatinTabPage.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.greekToLatinTabPage.Size = new System.Drawing.Size(1148, 634);
      this.greekToLatinTabPage.TabIndex = 2;
      this.greekToLatinTabPage.Text = "Greek to Latin Tests";
      this.greekToLatinTabPage.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
      this.tableLayoutPanel.Controls.Add(this.testTranscribeButton, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.fromGreekTextBox, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.toLatinTextBox, 0, 1);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(11, 10);
      this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 2;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(1126, 614);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // testTranscribeButton
      // 
      this.testTranscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.testTranscribeButton.Location = new System.Drawing.Point(859, 10);
      this.testTranscribeButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
      this.testTranscribeButton.Name = "testTranscribeButton";
      this.testTranscribeButton.Size = new System.Drawing.Size(267, 28);
      this.testTranscribeButton.TabIndex = 0;
      this.testTranscribeButton.Text = "Test Transcribe";
      this.testTranscribeButton.UseVisualStyleBackColor = true;
      this.testTranscribeButton.Click += new System.EventHandler(this.testTranscribeButton_Click);
      // 
      // fromGreekTextBox
      // 
      this.fromGreekTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fromGreekTextBox.Location = new System.Drawing.Point(11, 10);
      this.fromGreekTextBox.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.fromGreekTextBox.Multiline = true;
      this.fromGreekTextBox.Name = "fromGreekTextBox";
      this.fromGreekTextBox.Size = new System.Drawing.Size(837, 287);
      this.fromGreekTextBox.TabIndex = 1;
      // 
      // toLatinTextBox
      // 
      this.toLatinTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toLatinTextBox.Location = new System.Drawing.Point(11, 317);
      this.toLatinTextBox.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
      this.toLatinTextBox.Multiline = true;
      this.toLatinTextBox.Name = "toLatinTextBox";
      this.toLatinTextBox.Size = new System.Drawing.Size(837, 287);
      this.toLatinTextBox.TabIndex = 2;
      // 
      // appCultureComboBox
      // 
      this.appCultureComboBox.FormattingEnabled = true;
      this.appCultureComboBox.Items.AddRange(new object[] {
            "",
            "el-GR",
            "en-US"});
      this.appCultureComboBox.Location = new System.Drawing.Point(149, 12);
      this.appCultureComboBox.Name = "appCultureComboBox";
      this.appCultureComboBox.Size = new System.Drawing.Size(280, 24);
      this.appCultureComboBox.TabIndex = 2;
      this.appCultureComboBox.SelectedValueChanged += new System.EventHandler(this.appCultureComboBox_SelectedValueChanged);
      // 
      // enumDescriptionEditorControl
      // 
      this.enumDescriptionEditorControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.enumDescriptionEditorControl.Location = new System.Drawing.Point(7, 7);
      this.enumDescriptionEditorControl.Margin = new System.Windows.Forms.Padding(5);
      this.enumDescriptionEditorControl.Name = "enumDescriptionEditorControl";
      this.enumDescriptionEditorControl.Size = new System.Drawing.Size(381, 306);
      this.enumDescriptionEditorControl.TabIndex = 0;
      // 
      // applicationCultureLabel
      // 
      this.applicationCultureLabel.AutoSize = true;
      this.applicationCultureLabel.Location = new System.Drawing.Point(13, 15);
      this.applicationCultureLabel.Name = "applicationCultureLabel";
      this.applicationCultureLabel.Size = new System.Drawing.Size(130, 17);
      this.applicationCultureLabel.TabIndex = 3;
      this.applicationCultureLabel.Text = "Application Culture:";
      // 
      // TestsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1180, 688);
      this.Controls.Add(this.applicationCultureLabel);
      this.Controls.Add(this.appCultureComboBox);
      this.Controls.Add(this.testsTabControl);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.Name = "TestsForm";
      this.Text = "Tests Form";
      this.testsTabControl.ResumeLayout(false);
      this.enumDescriptionEditorControlTabPage.ResumeLayout(false);
      this.enumDescriptionEditorTabPage.ResumeLayout(false);
      this.greekToLatinTabPage.ResumeLayout(false);
      this.tableLayoutPanel.ResumeLayout(false);
      this.tableLayoutPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl testsTabControl;
    private System.Windows.Forms.TabPage enumDescriptionEditorTabPage;
    private System.Windows.Forms.TabPage enumDescriptionEditorControlTabPage;
    private EnumDescriptionEditorControl enumDescriptionEditorControl;
    private System.Windows.Forms.Button testEnumDescriptionEditorControlButton;
    private System.Windows.Forms.Button testEnumDescriptionsButton;
    private System.Windows.Forms.TabPage greekToLatinTabPage;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.Button testTranscribeButton;
    private System.Windows.Forms.TextBox fromGreekTextBox;
    private System.Windows.Forms.TextBox toLatinTextBox;
    private System.Windows.Forms.Button testEnumDescriptionEditorButton;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.ComboBox appCultureComboBox;
    private System.Windows.Forms.Label applicationCultureLabel;
  }
}

