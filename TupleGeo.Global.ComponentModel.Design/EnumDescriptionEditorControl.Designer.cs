namespace TupleGeo.General.ComponentModel.Design {
  partial class EnumDescriptionEditorControl {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.EnumDescriptionsListBox = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // EnumDescriptionsListBox
      // 
      this.EnumDescriptionsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.EnumDescriptionsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.EnumDescriptionsListBox.FormattingEnabled = true;
      this.EnumDescriptionsListBox.Location = new System.Drawing.Point(0, 0);
      this.EnumDescriptionsListBox.Name = "EnumDescriptionsListBox";
      this.EnumDescriptionsListBox.Size = new System.Drawing.Size(150, 143);
      this.EnumDescriptionsListBox.TabIndex = 0;
      this.EnumDescriptionsListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnumDescriptionsListBox_MouseClick);
      this.EnumDescriptionsListBox.SelectedValueChanged += new System.EventHandler(this.EnumDescriptionsListBox_SelectedValueChanged);
      // 
      // EnumDescriptionControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.EnumDescriptionsListBox);
      this.Name = "EnumDescriptionControl";
      this.Load += new System.EventHandler(this.EnumDescriptionControl_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox EnumDescriptionsListBox;
  }
}
