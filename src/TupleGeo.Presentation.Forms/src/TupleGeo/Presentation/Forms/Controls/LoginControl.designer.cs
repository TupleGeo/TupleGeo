namespace TupleGeo.Presentation.Forms.Controls {
  partial class LoginControl {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginControl));
      this.lblInfo = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.cboUsername = new System.Windows.Forms.ComboBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.chkRememberPassword = new System.Windows.Forms.CheckBox();
      this.lblWarning = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.picLogin = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picLogin)).BeginInit();
      this.SuspendLayout();
      // 
      // lblInfo
      // 
      resources.ApplyResources(this.lblInfo, "lblInfo");
      this.lblInfo.Name = "lblInfo";
      // 
      // lblUsername
      // 
      resources.ApplyResources(this.lblUsername, "lblUsername");
      this.lblUsername.Name = "lblUsername";
      // 
      // lblPassword
      // 
      resources.ApplyResources(this.lblPassword, "lblPassword");
      this.lblPassword.Name = "lblPassword";
      // 
      // cboUsername
      // 
      resources.ApplyResources(this.cboUsername, "cboUsername");
      this.cboUsername.FormattingEnabled = true;
      this.cboUsername.Name = "cboUsername";
      // 
      // txtPassword
      // 
      resources.ApplyResources(this.txtPassword, "txtPassword");
      this.txtPassword.Name = "txtPassword";
      // 
      // chkRememberPassword
      // 
      resources.ApplyResources(this.chkRememberPassword, "chkRememberPassword");
      this.chkRememberPassword.Name = "chkRememberPassword";
      this.chkRememberPassword.UseVisualStyleBackColor = true;
      // 
      // lblWarning
      // 
      resources.ApplyResources(this.lblWarning, "lblWarning");
      this.lblWarning.ForeColor = System.Drawing.Color.Firebrick;
      this.lblWarning.Name = "lblWarning";
      // 
      // btnOK
      // 
      resources.ApplyResources(this.btnOK, "btnOK");
      this.btnOK.Name = "btnOK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      resources.ApplyResources(this.btnCancel, "btnCancel");
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // picLogin
      // 
      resources.ApplyResources(this.picLogin, "picLogin");
      this.picLogin.Name = "picLogin";
      this.picLogin.TabStop = false;
      // 
      // LoginControl
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lblWarning);
      this.Controls.Add(this.chkRememberPassword);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.cboUsername);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.lblUsername);
      this.Controls.Add(this.lblInfo);
      this.Controls.Add(this.picLogin);
      this.Name = "LoginControl";
      ((System.ComponentModel.ISupportInitialize)(this.picLogin)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picLogin;
    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.ComboBox cboUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.CheckBox chkRememberPassword;
    private System.Windows.Forms.Label lblWarning;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;

  }

}
