namespace CheckPublicTransportRelations
{
    partial class ExtractRoutesForm
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
            this.archiveProgressBar = new System.Windows.Forms.ProgressBar();
            this.fileProgressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.extractRoutesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // archiveProgressBar
            // 
            this.archiveProgressBar.Location = new System.Drawing.Point(12, 41);
            this.archiveProgressBar.Name = "archiveProgressBar";
            this.archiveProgressBar.Size = new System.Drawing.Size(579, 23);
            this.archiveProgressBar.TabIndex = 11;
            // 
            // fileProgressBar
            // 
            this.fileProgressBar.Location = new System.Drawing.Point(12, 12);
            this.fileProgressBar.Name = "fileProgressBar";
            this.fileProgressBar.Size = new System.Drawing.Size(579, 23);
            this.fileProgressBar.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(516, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // extractRoutesBackgroundWorker
            // 
            this.extractRoutesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ExtractRoutesBackgroundWorker_DoWork);
            this.extractRoutesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ExtractRoutesBackgroundWorker_ProgressChanged);
            this.extractRoutesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ExtractRoutesBackgroundWorker_RunWorkerCompleted);
            // 
            // ExtractRoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 103);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.archiveProgressBar);
            this.Controls.Add(this.fileProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtractRoutesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extracting Routes";
            this.Load += new System.EventHandler(this.ExtractRoutesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar archiveProgressBar;
        private System.Windows.Forms.ProgressBar fileProgressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker extractRoutesBackgroundWorker;
    }
}