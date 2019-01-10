namespace CheckPublicTransportRelations
{
    partial class SettingsForm
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.travelineDataGroupBox = new System.Windows.Forms.GroupBox();
            this.localPathBrowseButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.ftpSiteTextBox = new System.Windows.Forms.TextBox();
            this.ftpSiteLabel = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.overpassGroupBox = new System.Windows.Forms.GroupBox();
            this.overpassQueryPrefixTextBox = new System.Windows.Forms.TextBox();
            this.overpassServerTextBox = new System.Windows.Forms.TextBox();
            this.overpassQueryPrefixLabel = new System.Windows.Forms.Label();
            this.overpassServerLabel = new System.Windows.Forms.Label();
            this.boundingBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.locationsButton = new System.Windows.Forms.Button();
            this.locationsComboBox = new System.Windows.Forms.ComboBox();
            this.boundingBoxLabel = new System.Windows.Forms.Label();
            this.localFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.travelineDataGroupBox.SuspendLayout();
            this.overpassGroupBox.SuspendLayout();
            this.boundingBoxGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 512);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(784, 49);
            this.buttonPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(697, 14);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 14);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.travelineDataGroupBox);
            this.mainPanel.Controls.Add(this.overpassGroupBox);
            this.mainPanel.Controls.Add(this.boundingBoxGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.mainPanel.Size = new System.Drawing.Size(784, 512);
            this.mainPanel.TabIndex = 1;
            // 
            // travelineDataGroupBox
            // 
            this.travelineDataGroupBox.Controls.Add(this.localPathBrowseButton);
            this.travelineDataGroupBox.Controls.Add(this.passwordTextBox);
            this.travelineDataGroupBox.Controls.Add(this.usernameTextBox);
            this.travelineDataGroupBox.Controls.Add(this.passwordLabel);
            this.travelineDataGroupBox.Controls.Add(this.pathLabel);
            this.travelineDataGroupBox.Controls.Add(this.usernameLabel);
            this.travelineDataGroupBox.Controls.Add(this.ftpSiteTextBox);
            this.travelineDataGroupBox.Controls.Add(this.ftpSiteLabel);
            this.travelineDataGroupBox.Controls.Add(this.pathTextBox);
            this.travelineDataGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.travelineDataGroupBox.Location = new System.Drawing.Point(5, 130);
            this.travelineDataGroupBox.Name = "travelineDataGroupBox";
            this.travelineDataGroupBox.Size = new System.Drawing.Size(774, 128);
            this.travelineDataGroupBox.TabIndex = 2;
            this.travelineDataGroupBox.TabStop = false;
            this.travelineDataGroupBox.Text = "TNDS";
            // 
            // localPathBrowseButton
            // 
            this.localPathBrowseButton.Location = new System.Drawing.Point(734, 92);
            this.localPathBrowseButton.Name = "localPathBrowseButton";
            this.localPathBrowseButton.Size = new System.Drawing.Size(33, 23);
            this.localPathBrowseButton.TabIndex = 24;
            this.localPathBrowseButton.Text = "...";
            this.localPathBrowseButton.UseVisualStyleBackColor = true;
            this.localPathBrowseButton.Click += new System.EventHandler(this.LocalPathBrowseButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(125, 69);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(642, 20);
            this.passwordTextBox.TabIndex = 23;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(125, 43);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(642, 20);
            this.usernameTextBox.TabIndex = 22;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(10, 72);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Password";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(10, 98);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(96, 13);
            this.pathLabel.TabIndex = 17;
            this.pathLabel.Text = "Local path for files:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(8, 46);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Username";
            // 
            // ftpSiteTextBox
            // 
            this.ftpSiteTextBox.Location = new System.Drawing.Point(125, 17);
            this.ftpSiteTextBox.Name = "ftpSiteTextBox";
            this.ftpSiteTextBox.Size = new System.Drawing.Size(642, 20);
            this.ftpSiteTextBox.TabIndex = 19;
            // 
            // ftpSiteLabel
            // 
            this.ftpSiteLabel.AutoSize = true;
            this.ftpSiteLabel.Location = new System.Drawing.Point(8, 20);
            this.ftpSiteLabel.Name = "ftpSiteLabel";
            this.ftpSiteLabel.Size = new System.Drawing.Size(84, 13);
            this.ftpSiteLabel.TabIndex = 18;
            this.ftpSiteLabel.Text = "TNDS FTP Site:";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(125, 95);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(603, 20);
            this.pathTextBox.TabIndex = 16;
            // 
            // overpassGroupBox
            // 
            this.overpassGroupBox.Controls.Add(this.overpassQueryPrefixTextBox);
            this.overpassGroupBox.Controls.Add(this.overpassServerTextBox);
            this.overpassGroupBox.Controls.Add(this.overpassQueryPrefixLabel);
            this.overpassGroupBox.Controls.Add(this.overpassServerLabel);
            this.overpassGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.overpassGroupBox.Location = new System.Drawing.Point(5, 52);
            this.overpassGroupBox.Name = "overpassGroupBox";
            this.overpassGroupBox.Size = new System.Drawing.Size(774, 78);
            this.overpassGroupBox.TabIndex = 0;
            this.overpassGroupBox.TabStop = false;
            this.overpassGroupBox.Text = "Overpass";
            // 
            // overpassQueryPrefixTextBox
            // 
            this.overpassQueryPrefixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overpassQueryPrefixTextBox.Location = new System.Drawing.Point(125, 45);
            this.overpassQueryPrefixTextBox.Name = "overpassQueryPrefixTextBox";
            this.overpassQueryPrefixTextBox.Size = new System.Drawing.Size(642, 20);
            this.overpassQueryPrefixTextBox.TabIndex = 5;
            // 
            // overpassServerTextBox
            // 
            this.overpassServerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.overpassServerTextBox.Location = new System.Drawing.Point(125, 19);
            this.overpassServerTextBox.Name = "overpassServerTextBox";
            this.overpassServerTextBox.Size = new System.Drawing.Size(642, 20);
            this.overpassServerTextBox.TabIndex = 4;
            // 
            // overpassQueryPrefixLabel
            // 
            this.overpassQueryPrefixLabel.AutoSize = true;
            this.overpassQueryPrefixLabel.Location = new System.Drawing.Point(8, 48);
            this.overpassQueryPrefixLabel.Name = "overpassQueryPrefixLabel";
            this.overpassQueryPrefixLabel.Size = new System.Drawing.Size(64, 13);
            this.overpassQueryPrefixLabel.TabIndex = 1;
            this.overpassQueryPrefixLabel.Text = "Query Prefix";
            // 
            // overpassServerLabel
            // 
            this.overpassServerLabel.AutoSize = true;
            this.overpassServerLabel.Location = new System.Drawing.Point(8, 22);
            this.overpassServerLabel.Name = "overpassServerLabel";
            this.overpassServerLabel.Size = new System.Drawing.Size(63, 13);
            this.overpassServerLabel.TabIndex = 0;
            this.overpassServerLabel.Text = "Server URL";
            // 
            // boundingBoxGroupBox
            // 
            this.boundingBoxGroupBox.Controls.Add(this.locationsButton);
            this.boundingBoxGroupBox.Controls.Add(this.locationsComboBox);
            this.boundingBoxGroupBox.Controls.Add(this.boundingBoxLabel);
            this.boundingBoxGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.boundingBoxGroupBox.Location = new System.Drawing.Point(5, 5);
            this.boundingBoxGroupBox.Name = "boundingBoxGroupBox";
            this.boundingBoxGroupBox.Size = new System.Drawing.Size(774, 47);
            this.boundingBoxGroupBox.TabIndex = 1;
            this.boundingBoxGroupBox.TabStop = false;
            this.boundingBoxGroupBox.Text = "Location";
            // 
            // locationsButton
            // 
            this.locationsButton.Location = new System.Drawing.Point(734, 17);
            this.locationsButton.Name = "locationsButton";
            this.locationsButton.Size = new System.Drawing.Size(33, 23);
            this.locationsButton.TabIndex = 25;
            this.locationsButton.Text = "...";
            this.locationsButton.UseVisualStyleBackColor = true;
            this.locationsButton.Click += new System.EventHandler(this.LocationsButton_Click);
            // 
            // locationsComboBox
            // 
            this.locationsComboBox.DisplayMember = "Description";
            this.locationsComboBox.FormattingEnabled = true;
            this.locationsComboBox.Location = new System.Drawing.Point(125, 19);
            this.locationsComboBox.Name = "locationsComboBox";
            this.locationsComboBox.Size = new System.Drawing.Size(603, 21);
            this.locationsComboBox.TabIndex = 1;
            // 
            // boundingBoxLabel
            // 
            this.boundingBoxLabel.AutoSize = true;
            this.boundingBoxLabel.Location = new System.Drawing.Point(8, 22);
            this.boundingBoxLabel.Name = "boundingBoxLabel";
            this.boundingBoxLabel.Size = new System.Drawing.Size(89, 13);
            this.boundingBoxLabel.TabIndex = 0;
            this.boundingBoxLabel.Text = "Selected location";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.travelineDataGroupBox.ResumeLayout(false);
            this.travelineDataGroupBox.PerformLayout();
            this.overpassGroupBox.ResumeLayout(false);
            this.overpassGroupBox.PerformLayout();
            this.boundingBoxGroupBox.ResumeLayout(false);
            this.boundingBoxGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox overpassGroupBox;
        private System.Windows.Forms.Label overpassQueryPrefixLabel;
        private System.Windows.Forms.Label overpassServerLabel;
        private System.Windows.Forms.TextBox overpassQueryPrefixTextBox;
        private System.Windows.Forms.TextBox overpassServerTextBox;
        private System.Windows.Forms.GroupBox boundingBoxGroupBox;
        private System.Windows.Forms.Label boundingBoxLabel;
        private System.Windows.Forms.GroupBox travelineDataGroupBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox ftpSiteTextBox;
        private System.Windows.Forms.Label ftpSiteLabel;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button localPathBrowseButton;
        private System.Windows.Forms.FolderBrowserDialog localFolderBrowserDialog;
        private System.Windows.Forms.Button locationsButton;
        private System.Windows.Forms.ComboBox locationsComboBox;
    }
}