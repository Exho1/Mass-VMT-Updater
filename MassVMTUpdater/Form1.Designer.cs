namespace MassVMTUpdater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrWaitForDirectory = new System.Windows.Forms.Timer(this.components);
            this.txtPathDivider = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Location = new System.Drawing.Point(12, 12);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(101, 28);
            this.btnOpenDialog.TabIndex = 0;
            this.btnOpenDialog.Text = "Select Directory";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // tmrWaitForDirectory
            // 
            this.tmrWaitForDirectory.Enabled = true;
            this.tmrWaitForDirectory.Interval = 10;
            this.tmrWaitForDirectory.Tick += new System.EventHandler(this.tmrWaitForDirectory_Tick);
            // 
            // txtPathDivider
            // 
            this.txtPathDivider.Location = new System.Drawing.Point(232, 28);
            this.txtPathDivider.Name = "txtPathDivider";
            this.txtPathDivider.Size = new System.Drawing.Size(120, 20);
            this.txtPathDivider.TabIndex = 3;
            this.txtPathDivider.Text = "/materials/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top level folder:";
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(12, 123);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(419, 167);
            this.txtDebug.TabIndex = 5;
            this.txtDebug.Text = "Debug";
            this.txtDebug.WordWrap = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(12, 67);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(101, 28);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(232, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(101, 28);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 302);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathDivider);
            this.Controls.Add(this.btnOpenDialog);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mass VMT Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.Timer tmrWaitForDirectory;
        private System.Windows.Forms.TextBox txtPathDivider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnReset;
    }
}

