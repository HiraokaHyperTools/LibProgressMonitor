namespace kenjiuno.LibProgressMonitor
{
    partial class WaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSubHint;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxBar;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxBar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.labelSubHint = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBar
            // 
            this.pictureBoxBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBar.Location = new System.Drawing.Point(88, 88);
            this.pictureBoxBar.Name = "pictureBoxBar";
            this.pictureBoxBar.Size = new System.Drawing.Size(392, 32);
            this.pictureBoxBar.TabIndex = 2;
            this.pictureBoxBar.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = LibProgressMonitor.Properties.Resources.BLUE_i;
            this.pictureBox1.Location = new System.Drawing.Point(24, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelHint
            // 
            this.labelHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHint.Location = new System.Drawing.Point(96, 40);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(384, 40);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "お待ちください...";
            // 
            // labelSubHint
            // 
            this.labelSubHint.Location = new System.Drawing.Point(24, 152);
            this.labelSubHint.Name = "labelSubHint";
            this.labelSubHint.Size = new System.Drawing.Size(360, 32);
            this.labelSubHint.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(392, 144);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 40);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // WaitForm2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(502, 198);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelSubHint);
            this.Controls.Add(this.pictureBoxBar);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WaitForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closed += new System.EventHandler(this.WaitFormClosed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.WaitFormClosing);
            this.Load += new System.EventHandler(this.WaitForm2Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}