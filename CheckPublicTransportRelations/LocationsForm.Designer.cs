namespace CheckPublicTransportRelations
{
    partial class LocationsForm
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.locationsDataGridView = new System.Windows.Forms.DataGridView();
            this.editLocationButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.locationDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationBoundingBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationBusStopsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Controls.Add(this.addButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 412);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(834, 49);
            this.buttonPanel.TabIndex = 1;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(174, 14);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(93, 14);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(747, 14);
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
            this.mainPanel.Controls.Add(this.locationsDataGridView);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(834, 412);
            this.mainPanel.TabIndex = 2;
            // 
            // locationsDataGridView
            // 
            this.locationsDataGridView.AllowUserToAddRows = false;
            this.locationsDataGridView.AllowUserToDeleteRows = false;
            this.locationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.locationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editLocationButtonColumn,
            this.locationDescriptionColumn,
            this.locationBoundingBoxColumn,
            this.locationBusStopsColumn,
            this.locationDataColumn});
            this.locationsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.locationsDataGridView.MultiSelect = false;
            this.locationsDataGridView.Name = "locationsDataGridView";
            this.locationsDataGridView.RowHeadersVisible = false;
            this.locationsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.locationsDataGridView.Size = new System.Drawing.Size(834, 412);
            this.locationsDataGridView.TabIndex = 1;
            this.locationsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocationsDataGridView_CellContentClick);
            this.locationsDataGridView.SelectionChanged += new System.EventHandler(this.LocationsDataGridView_SelectionChanged);
            // 
            // editLocationButtonColumn
            // 
            this.editLocationButtonColumn.HeaderText = "Edit";
            this.editLocationButtonColumn.Name = "editLocationButtonColumn";
            this.editLocationButtonColumn.Text = "...";
            this.editLocationButtonColumn.UseColumnTextForButtonValue = true;
            this.editLocationButtonColumn.Width = 40;
            // 
            // locationDescriptionColumn
            // 
            this.locationDescriptionColumn.DataPropertyName = "Description";
            this.locationDescriptionColumn.HeaderText = "Description";
            this.locationDescriptionColumn.Name = "locationDescriptionColumn";
            this.locationDescriptionColumn.ReadOnly = true;
            this.locationDescriptionColumn.Width = 150;
            // 
            // locationBoundingBoxColumn
            // 
            this.locationBoundingBoxColumn.DataPropertyName = "BoundingBox";
            this.locationBoundingBoxColumn.HeaderText = "BBox";
            this.locationBoundingBoxColumn.Name = "locationBoundingBoxColumn";
            this.locationBoundingBoxColumn.ReadOnly = true;
            this.locationBoundingBoxColumn.Width = 200;
            // 
            // locationBusStopsColumn
            // 
            this.locationBusStopsColumn.DataPropertyName = "BusStopQuery";
            this.locationBusStopsColumn.HeaderText = "Stops";
            this.locationBusStopsColumn.Name = "locationBusStopsColumn";
            this.locationBusStopsColumn.ReadOnly = true;
            this.locationBusStopsColumn.Width = 200;
            // 
            // locationDataColumn
            // 
            this.locationDataColumn.DataPropertyName = "TransportQuery";
            this.locationDataColumn.HeaderText = "Data";
            this.locationDataColumn.Name = "locationDataColumn";
            this.locationDataColumn.ReadOnly = true;
            this.locationDataColumn.Width = 200;
            // 
            // LocationsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "LocationsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Locations";
            this.Load += new System.EventHandler(this.LocationsForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.locationsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView locationsDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewButtonColumn editLocationButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationBoundingBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationBusStopsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataColumn;
    }
}