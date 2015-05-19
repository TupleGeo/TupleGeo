namespace TupleGeo.General.ComponentModel.Design {
  partial class GeneralObjectEditorControl {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralObjectEditorControl));
      this.GeneralObjectEditorToolStrip = new System.Windows.Forms.ToolStrip();
      this.NewObjectToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.DeleteObjectToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.GeneralObjectEditorToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // GeneralObjectEditorToolStrip
      // 
      resources.ApplyResources(this.GeneralObjectEditorToolStrip, "GeneralObjectEditorToolStrip");
      this.GeneralObjectEditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.GeneralObjectEditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewObjectToolStripButton,
            this.DeleteObjectToolStripButton});
      this.GeneralObjectEditorToolStrip.Name = "GeneralObjectEditorToolStrip";
      // 
      // NewObjectToolStripButton
      // 
      resources.ApplyResources(this.NewObjectToolStripButton, "NewObjectToolStripButton");
      this.NewObjectToolStripButton.Name = "NewObjectToolStripButton";
      this.NewObjectToolStripButton.Click += new System.EventHandler(this.NewObjectToolStripButton_Click);
      // 
      // DeleteObjectToolStripButton
      // 
      resources.ApplyResources(this.DeleteObjectToolStripButton, "DeleteObjectToolStripButton");
      this.DeleteObjectToolStripButton.Name = "DeleteObjectToolStripButton";
      this.DeleteObjectToolStripButton.Click += new System.EventHandler(this.DeleteObjectToolStripButton_Click);
      // 
      // GeneralObjectEditorControl
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.GeneralObjectEditorToolStrip);
      this.Name = "GeneralObjectEditorControl";
      this.GeneralObjectEditorToolStrip.ResumeLayout(false);
      this.GeneralObjectEditorToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip GeneralObjectEditorToolStrip;
    private System.Windows.Forms.ToolStripButton NewObjectToolStripButton;
    private System.Windows.Forms.ToolStripButton DeleteObjectToolStripButton;
  }
}
