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
      this.GeneralObjectEditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.GeneralObjectEditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewObjectToolStripButton,
            this.DeleteObjectToolStripButton});
      this.GeneralObjectEditorToolStrip.Location = new System.Drawing.Point(0, 0);
      this.GeneralObjectEditorToolStrip.Margin = new System.Windows.Forms.Padding(2);
      this.GeneralObjectEditorToolStrip.Name = "GeneralObjectEditorToolStrip";
      this.GeneralObjectEditorToolStrip.Size = new System.Drawing.Size(132, 25);
      this.GeneralObjectEditorToolStrip.TabIndex = 0;
      this.GeneralObjectEditorToolStrip.Text = "GeneralObjectEditorToolStrip";
      // 
      // NewObjectToolStripButton
      // 
      this.NewObjectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewObjectToolStripButton.Image")));
      this.NewObjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.NewObjectToolStripButton.Name = "NewObjectToolStripButton";
      this.NewObjectToolStripButton.Size = new System.Drawing.Size(48, 22);
      this.NewObjectToolStripButton.Text = "New";
      this.NewObjectToolStripButton.Click += new System.EventHandler(this.NewObjectToolStripButton_Click);
      // 
      // DeleteObjectToolStripButton
      // 
      this.DeleteObjectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteObjectToolStripButton.Image")));
      this.DeleteObjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.DeleteObjectToolStripButton.Name = "DeleteObjectToolStripButton";
      this.DeleteObjectToolStripButton.Size = new System.Drawing.Size(58, 22);
      this.DeleteObjectToolStripButton.Text = "Delete";
      this.DeleteObjectToolStripButton.Click += new System.EventHandler(this.DeleteObjectToolStripButton_Click);
      // 
      // GeneralObjectEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.GeneralObjectEditorToolStrip);
      this.Name = "GeneralObjectEditorControl";
      this.Size = new System.Drawing.Size(132, 29);
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
