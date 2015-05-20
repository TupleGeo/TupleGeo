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
      this.enumDescriptionEditorControl = new TupleGeo.General.ComponentModel.Design.EnumDescriptionEditorControl();
      this.enumDescriptionEditorTabPage = new System.Windows.Forms.TabPage();
      this.greekToLatinTabPage = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.testTranscribeButton = new System.Windows.Forms.Button();
      this.fromGreekTextBox = new System.Windows.Forms.TextBox();
      this.toLatinTextBox = new System.Windows.Forms.TextBox();
      this.testsTabControl.SuspendLayout();
      this.enumDescriptionEditorControlTabPage.SuspendLayout();
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
      this.testsTabControl.Location = new System.Drawing.Point(9, 10);
      this.testsTabControl.Margin = new System.Windows.Forms.Padding(2);
      this.testsTabControl.Name = "testsTabControl";
      this.testsTabControl.SelectedIndex = 0;
      this.testsTabControl.Size = new System.Drawing.Size(936, 615);
      this.testsTabControl.TabIndex = 0;
      // 
      // enumDescriptionEditorControlTabPage
      // 
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.testEnumDescriptionsButton);
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.testEnumDescriptionEditorControlButton);
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.enumDescriptionEditorControl);
      this.enumDescriptionEditorControlTabPage.Location = new System.Drawing.Point(4, 22);
      this.enumDescriptionEditorControlTabPage.Margin = new System.Windows.Forms.Padding(2);
      this.enumDescriptionEditorControlTabPage.Name = "enumDescriptionEditorControlTabPage";
      this.enumDescriptionEditorControlTabPage.Padding = new System.Windows.Forms.Padding(2);
      this.enumDescriptionEditorControlTabPage.Size = new System.Drawing.Size(928, 589);
      this.enumDescriptionEditorControlTabPage.TabIndex = 1;
      this.enumDescriptionEditorControlTabPage.Text = "EnumDescriptionEditorControl Tests";
      this.enumDescriptionEditorControlTabPage.UseVisualStyleBackColor = true;
      // 
      // testEnumDescriptionsButton
      // 
      this.testEnumDescriptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.testEnumDescriptionsButton.Location = new System.Drawing.Point(633, 6);
      this.testEnumDescriptionsButton.Name = "testEnumDescriptionsButton";
      this.testEnumDescriptionsButton.Size = new System.Drawing.Size(290, 23);
      this.testEnumDescriptionsButton.TabIndex = 2;
      this.testEnumDescriptionsButton.Text = "Test Enum Descriptions";
      this.testEnumDescriptionsButton.UseVisualStyleBackColor = true;
      this.testEnumDescriptionsButton.Click += new System.EventHandler(this.testEnumDescriptionsbutton_Click);
      // 
      // testEnumDescriptionEditorControlButton
      // 
      this.testEnumDescriptionEditorControlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.testEnumDescriptionEditorControlButton.Location = new System.Drawing.Point(633, 34);
      this.testEnumDescriptionEditorControlButton.Margin = new System.Windows.Forms.Padding(2);
      this.testEnumDescriptionEditorControlButton.Name = "testEnumDescriptionEditorControlButton";
      this.testEnumDescriptionEditorControlButton.Size = new System.Drawing.Size(290, 23);
      this.testEnumDescriptionEditorControlButton.TabIndex = 1;
      this.testEnumDescriptionEditorControlButton.Text = "Test Enum Description Editor Control";
      this.testEnumDescriptionEditorControlButton.UseVisualStyleBackColor = true;
      this.testEnumDescriptionEditorControlButton.Click += new System.EventHandler(this.testEnumDescriptionEditorControlButton_Click);
      // 
      // enumDescriptionEditorControl
      // 
      this.enumDescriptionEditorControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.enumDescriptionEditorControl.Location = new System.Drawing.Point(5, 6);
      this.enumDescriptionEditorControl.Name = "enumDescriptionEditorControl";
      this.enumDescriptionEditorControl.Size = new System.Drawing.Size(286, 249);
      this.enumDescriptionEditorControl.TabIndex = 0;
      // 
      // enumDescriptionEditorTabPage
      // 
      this.enumDescriptionEditorTabPage.Location = new System.Drawing.Point(4, 22);
      this.enumDescriptionEditorTabPage.Margin = new System.Windows.Forms.Padding(2);
      this.enumDescriptionEditorTabPage.Name = "enumDescriptionEditorTabPage";
      this.enumDescriptionEditorTabPage.Padding = new System.Windows.Forms.Padding(2);
      this.enumDescriptionEditorTabPage.Size = new System.Drawing.Size(928, 589);
      this.enumDescriptionEditorTabPage.TabIndex = 0;
      this.enumDescriptionEditorTabPage.Text = "EnumDescriptionEditor Tests";
      this.enumDescriptionEditorTabPage.UseVisualStyleBackColor = true;
      // 
      // greekToLatinTabPage
      // 
      this.greekToLatinTabPage.Controls.Add(this.tableLayoutPanel);
      this.greekToLatinTabPage.Location = new System.Drawing.Point(4, 22);
      this.greekToLatinTabPage.Margin = new System.Windows.Forms.Padding(8);
      this.greekToLatinTabPage.Name = "greekToLatinTabPage";
      this.greekToLatinTabPage.Padding = new System.Windows.Forms.Padding(8);
      this.greekToLatinTabPage.Size = new System.Drawing.Size(928, 589);
      this.greekToLatinTabPage.TabIndex = 2;
      this.greekToLatinTabPage.Text = "Greek to Latin Tests";
      this.greekToLatinTabPage.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tableLayoutPanel.Controls.Add(this.testTranscribeButton, 1, 0);
      this.tableLayoutPanel.Controls.Add(this.fromGreekTextBox, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.toLatinTextBox, 0, 1);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(8, 8);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 2;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(912, 573);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // testTranscribeButton
      // 
      this.testTranscribeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.testTranscribeButton.Location = new System.Drawing.Point(712, 8);
      this.testTranscribeButton.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
      this.testTranscribeButton.Name = "testTranscribeButton";
      this.testTranscribeButton.Size = new System.Drawing.Size(200, 23);
      this.testTranscribeButton.TabIndex = 0;
      this.testTranscribeButton.Text = "Test Transcribe";
      this.testTranscribeButton.UseVisualStyleBackColor = true;
      this.testTranscribeButton.Click += new System.EventHandler(this.testTranscribeButton_Click);
      // 
      // fromGreekTextBox
      // 
      this.fromGreekTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.fromGreekTextBox.Location = new System.Drawing.Point(8, 8);
      this.fromGreekTextBox.Margin = new System.Windows.Forms.Padding(8);
      this.fromGreekTextBox.Multiline = true;
      this.fromGreekTextBox.Name = "fromGreekTextBox";
      this.fromGreekTextBox.Size = new System.Drawing.Size(696, 270);
      this.fromGreekTextBox.TabIndex = 1;
      // 
      // toLatinTextBox
      // 
      this.toLatinTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toLatinTextBox.Location = new System.Drawing.Point(8, 294);
      this.toLatinTextBox.Margin = new System.Windows.Forms.Padding(8);
      this.toLatinTextBox.Multiline = true;
      this.toLatinTextBox.Name = "toLatinTextBox";
      this.toLatinTextBox.Size = new System.Drawing.Size(696, 271);
      this.toLatinTextBox.TabIndex = 2;
      // 
      // TestsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(954, 635);
      this.Controls.Add(this.testsTabControl);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "TestsForm";
      this.Text = "Tests Form";
      this.testsTabControl.ResumeLayout(false);
      this.enumDescriptionEditorControlTabPage.ResumeLayout(false);
      this.greekToLatinTabPage.ResumeLayout(false);
      this.tableLayoutPanel.ResumeLayout(false);
      this.tableLayoutPanel.PerformLayout();
      this.ResumeLayout(false);

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
  }
}

