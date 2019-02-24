namespace CheckPublicTransportRelations
{
    partial class LocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.orphanRoutesTextBox = new System.Windows.Forms.TextBox();
            this.orphanRoutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.orphanRouteVariantsQuery = new System.Windows.Forms.Label();
            this.dataQueryTextBox = new System.Windows.Forms.TextBox();
            this.dataQueryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dataQueryLabel = new System.Windows.Forms.Label();
            this.stopsQueryTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stopsTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.stopsQueryLabel = new System.Windows.Forms.Label();
            this.areaQueryTextBox = new System.Windows.Forms.TextBox();
            this.boundingBoxTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.locationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orphanRoutesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataQueryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopsTimeoutNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 401);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(800, 49);
            this.buttonPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(713, 14);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Close";
            this.cancelButton.UseVisualStyleBackColor = true;
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
            this.mainPanel.Controls.Add(this.locationGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 401);
            this.mainPanel.TabIndex = 3;
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.Controls.Add(this.orphanRoutesTextBox);
            this.locationGroupBox.Controls.Add(this.orphanRoutesNumericUpDown);
            this.locationGroupBox.Controls.Add(this.orphanRouteVariantsQuery);
            this.locationGroupBox.Controls.Add(this.dataQueryTextBox);
            this.locationGroupBox.Controls.Add(this.dataQueryNumericUpDown);
            this.locationGroupBox.Controls.Add(this.dataQueryLabel);
            this.locationGroupBox.Controls.Add(this.stopsQueryTextBox);
            this.locationGroupBox.Controls.Add(this.label5);
            this.locationGroupBox.Controls.Add(this.stopsTimeoutNumericUpDown);
            this.locationGroupBox.Controls.Add(this.label4);
            this.locationGroupBox.Controls.Add(this.stopsQueryLabel);
            this.locationGroupBox.Controls.Add(this.areaQueryTextBox);
            this.locationGroupBox.Controls.Add(this.boundingBoxTextBox);
            this.locationGroupBox.Controls.Add(this.label3);
            this.locationGroupBox.Controls.Add(this.label2);
            this.locationGroupBox.Controls.Add(this.typeComboBox);
            this.locationGroupBox.Controls.Add(this.label1);
            this.locationGroupBox.Controls.Add(this.descriptionTextBox);
            this.locationGroupBox.Controls.Add(this.descriptionLabel);
            this.locationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationGroupBox.Location = new System.Drawing.Point(0, 0);
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.Size = new System.Drawing.Size(800, 401);
            this.locationGroupBox.TabIndex = 0;
            this.locationGroupBox.TabStop = false;
            this.locationGroupBox.Text = "Location Details";
            // 
            // orphanRoutesTextBox
            // 
            this.orphanRoutesTextBox.Location = new System.Drawing.Point(215, 272);
            this.orphanRoutesTextBox.Name = "orphanRoutesTextBox";
            this.orphanRoutesTextBox.Size = new System.Drawing.Size(537, 20);
            this.orphanRoutesTextBox.TabIndex = 18;
            // 
            // orphanRoutesNumericUpDown
            // 
            this.orphanRoutesNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.orphanRoutesNumericUpDown.Location = new System.Drawing.Point(138, 272);
            this.orphanRoutesNumericUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.orphanRoutesNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.orphanRoutesNumericUpDown.Name = "orphanRoutesNumericUpDown";
            this.orphanRoutesNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.orphanRoutesNumericUpDown.TabIndex = 17;
            this.orphanRoutesNumericUpDown.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // orphanRouteVariantsQuery
            // 
            this.orphanRouteVariantsQuery.AutoSize = true;
            this.orphanRouteVariantsQuery.Location = new System.Drawing.Point(12, 274);
            this.orphanRouteVariantsQuery.Name = "orphanRouteVariantsQuery";
            this.orphanRouteVariantsQuery.Size = new System.Drawing.Size(79, 13);
            this.orphanRouteVariantsQuery.TabIndex = 16;
            this.orphanRouteVariantsQuery.Text = "Orphan Routes";
            // 
            // dataQueryTextBox
            // 
            this.dataQueryTextBox.Location = new System.Drawing.Point(215, 246);
            this.dataQueryTextBox.Name = "dataQueryTextBox";
            this.dataQueryTextBox.Size = new System.Drawing.Size(537, 20);
            this.dataQueryTextBox.TabIndex = 15;
            // 
            // dataQueryNumericUpDown
            // 
            this.dataQueryNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.dataQueryNumericUpDown.Location = new System.Drawing.Point(138, 246);
            this.dataQueryNumericUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.dataQueryNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.dataQueryNumericUpDown.Name = "dataQueryNumericUpDown";
            this.dataQueryNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.dataQueryNumericUpDown.TabIndex = 14;
            this.dataQueryNumericUpDown.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // dataQueryLabel
            // 
            this.dataQueryLabel.AutoSize = true;
            this.dataQueryLabel.Location = new System.Drawing.Point(12, 248);
            this.dataQueryLabel.Name = "dataQueryLabel";
            this.dataQueryLabel.Size = new System.Drawing.Size(61, 13);
            this.dataQueryLabel.TabIndex = 13;
            this.dataQueryLabel.Text = "Data Query";
            // 
            // stopsQueryTextBox
            // 
            this.stopsQueryTextBox.Location = new System.Drawing.Point(215, 220);
            this.stopsQueryTextBox.Name = "stopsQueryTextBox";
            this.stopsQueryTextBox.Size = new System.Drawing.Size(537, 20);
            this.stopsQueryTextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Overpass Query";
            // 
            // stopsTimeoutNumericUpDown
            // 
            this.stopsTimeoutNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.stopsTimeoutNumericUpDown.Location = new System.Drawing.Point(138, 220);
            this.stopsTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.stopsTimeoutNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.stopsTimeoutNumericUpDown.Name = "stopsTimeoutNumericUpDown";
            this.stopsTimeoutNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.stopsTimeoutNumericUpDown.TabIndex = 10;
            this.stopsTimeoutNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "{{timeout}}";
            // 
            // stopsQueryLabel
            // 
            this.stopsQueryLabel.AutoSize = true;
            this.stopsQueryLabel.Location = new System.Drawing.Point(12, 222);
            this.stopsQueryLabel.Name = "stopsQueryLabel";
            this.stopsQueryLabel.Size = new System.Drawing.Size(65, 13);
            this.stopsQueryLabel.TabIndex = 8;
            this.stopsQueryLabel.Text = "Stops Query";
            // 
            // areaQueryTextBox
            // 
            this.areaQueryTextBox.Location = new System.Drawing.Point(138, 121);
            this.areaQueryTextBox.Name = "areaQueryTextBox";
            this.areaQueryTextBox.Size = new System.Drawing.Size(349, 20);
            this.areaQueryTextBox.TabIndex = 7;
            // 
            // boundingBoxTextBox
            // 
            this.boundingBoxTextBox.Location = new System.Drawing.Point(138, 89);
            this.boundingBoxTextBox.Name = "boundingBoxTextBox";
            this.boundingBoxTextBox.Size = new System.Drawing.Size(349, 20);
            this.boundingBoxTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Area Query {{area}}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bounding Box {{bbox}}";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(138, 56);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(349, 21);
            this.typeComboBox.TabIndex = 3;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(138, 24);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(349, 20);
            this.descriptionTextBox.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(12, 27);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description";
            // 
            // LocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocationForm";
            this.ShowIcon = false;
            this.Text = "LocationForm";
            this.Load += new System.EventHandler(this.LocationForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.locationGroupBox.ResumeLayout(false);
            this.locationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orphanRoutesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataQueryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopsTimeoutNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox locationGroupBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox areaQueryTextBox;
        private System.Windows.Forms.TextBox boundingBoxTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orphanRoutesTextBox;
        private System.Windows.Forms.NumericUpDown orphanRoutesNumericUpDown;
        private System.Windows.Forms.Label orphanRouteVariantsQuery;
        private System.Windows.Forms.TextBox dataQueryTextBox;
        private System.Windows.Forms.NumericUpDown dataQueryNumericUpDown;
        private System.Windows.Forms.Label dataQueryLabel;
        private System.Windows.Forms.TextBox stopsQueryTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown stopsTimeoutNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label stopsQueryLabel;
    }
}