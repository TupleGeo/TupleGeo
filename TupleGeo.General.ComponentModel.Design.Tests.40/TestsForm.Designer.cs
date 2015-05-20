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
      this.enumDescriptionEditorControlTest1Button = new System.Windows.Forms.Button();
      this.enumDescriptionEditorControl = new TupleGeo.General.ComponentModel.Design.EnumDescriptionEditorControl();
      this.enumDescriptionEditorTabPage = new System.Windows.Forms.TabPage();
      this.testsTabControl.SuspendLayout();
      this.enumDescriptionEditorControlTabPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // testsTabControl
      // 
      this.testsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.testsTabControl.Controls.Add(this.enumDescriptionEditorControlTabPage);
      this.testsTabControl.Controls.Add(this.enumDescriptionEditorTabPage);
      this.testsTabControl.Location = new System.Drawing.Point(12, 12);
      this.testsTabControl.Name = "testsTabControl";
      this.testsTabControl.SelectedIndex = 0;
      this.testsTabControl.Size = new System.Drawing.Size(800, 517);
      this.testsTabControl.TabIndex = 0;
      // 
      // enumDescriptionEditorControlTabPage
      // 
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.enumDescriptionEditorControlTest1Button);
      this.enumDescriptionEditorControlTabPage.Controls.Add(this.enumDescriptionEditorControl);
      this.enumDescriptionEditorControlTabPage.Location = new System.Drawing.Point(4, 25);
      this.enumDescriptionEditorControlTabPage.Name = "enumDescriptionEditorControlTabPage";
      this.enumDescriptionEditorControlTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.enumDescriptionEditorControlTabPage.Size = new System.Drawing.Size(792, 488);
      this.enumDescriptionEditorControlTabPage.TabIndex = 1;
      this.enumDescriptionEditorControlTabPage.Text = "EnumDescriptionEditorControl Tests";
      this.enumDescriptionEditorControlTabPage.UseVisualStyleBackColor = true;
      // 
      // enumDescriptionEditorControlTest1Button
      // 
      this.enumDescriptionEditorControlTest1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.enumDescriptionEditorControlTest1Button.Location = new System.Drawing.Point(711, 7);
      this.enumDescriptionEditorControlTest1Button.Name = "enumDescriptionEditorControlTest1Button";
      this.enumDescriptionEditorControlTest1Button.Size = new System.Drawing.Size(75, 23);
      this.enumDescriptionEditorControlTest1Button.TabIndex = 1;
      this.enumDescriptionEditorControlTest1Button.Text = "Test";
      this.enumDescriptionEditorControlTest1Button.UseVisualStyleBackColor = true;
      this.enumDescriptionEditorControlTest1Button.Click += new System.EventHandler(this.enumDescriptionEditorControlTest1Button_Click);
      // 
      // enumDescriptionEditorControl
      // 
      this.enumDescriptionEditorControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.enumDescriptionEditorControl.Location = new System.Drawing.Point(7, 7);
      this.enumDescriptionEditorControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.enumDescriptionEditorControl.Name = "enumDescriptionEditorControl";
      this.enumDescriptionEditorControl.Size = new System.Drawing.Size(380, 306);
      this.enumDescriptionEditorControl.TabIndex = 0;
      // 
      // enumDescriptionEditorTabPage
      // 
      this.enumDescriptionEditorTabPage.Location = new System.Drawing.Point(4, 25);
      this.enumDescriptionEditorTabPage.Name = "enumDescriptionEditorTabPage";
      this.enumDescriptionEditorTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.enumDescriptionEditorTabPage.Size = new System.Drawing.Size(792, 488);
      this.enumDescriptionEditorTabPage.TabIndex = 0;
      this.enumDescriptionEditorTabPage.Text = "EnumDescriptionEditor Tests";
      this.enumDescriptionEditorTabPage.UseVisualStyleBackColor = true;
      // 
      // TestsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(824, 541);
      this.Controls.Add(this.testsTabControl);
      this.Name = "TestsForm";
      this.Text = "Tests Form";
      this.testsTabControl.ResumeLayout(false);
      this.enumDescriptionEditorControlTabPage.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl testsTabControl;
    private System.Windows.Forms.TabPage enumDescriptionEditorTabPage;
    private System.Windows.Forms.TabPage enumDescriptionEditorControlTabPage;
    private EnumDescriptionEditorControl enumDescriptionEditorControl;
    private System.Windows.Forms.Button enumDescriptionEditorControlTest1Button;
  }
}

