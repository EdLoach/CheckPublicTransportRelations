namespace CheckPublicTransportRelations
{
    partial class BusStopNameMappingsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusStopNameMappingsForm));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mappingDataGridView = new System.Windows.Forms.DataGridView();
            this.fromColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintainButtonPanel = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).BeginInit();
            this.maintainButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Controls.Add(this.saveButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 401);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(800, 49);
            this.buttonPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(711, 14);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 14);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mappingDataGridView);
            this.mainPanel.Controls.Add(this.maintainButtonPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 401);
            this.mainPanel.TabIndex = 1;
            // 
            // mappingDataGridView
            // 
            this.mappingDataGridView.AllowUserToAddRows = false;
            this.mappingDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mappingDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mappingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromColumn,
            this.toColumn});
            this.mappingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappingDataGridView.Location = new System.Drawing.Point(0, 0);
            this.mappingDataGridView.MultiSelect = false;
            this.mappingDataGridView.Name = "mappingDataGridView";
            this.mappingDataGridView.RowHeadersVisible = false;
            this.mappingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mappingDataGridView.Size = new System.Drawing.Size(694, 401);
            this.mappingDataGridView.TabIndex = 1;
            // 
            // fromColumn
            // 
            this.fromColumn.HeaderText = "From (Naptan)";
            this.fromColumn.Name = "fromColumn";
            this.fromColumn.Width = 250;
            // 
            // toColumn
            // 
            this.toColumn.HeaderText = "To (OSM expanded)";
            this.toColumn.Name = "toColumn";
            this.toColumn.Width = 250;
            // 
            // maintainButtonPanel
            // 
            this.maintainButtonPanel.Controls.Add(this.removeButton);
            this.maintainButtonPanel.Controls.Add(this.addButton);
            this.maintainButtonPanel.Controls.Add(this.moveDownButton);
            this.maintainButtonPanel.Controls.Add(this.moveUpButton);
            this.maintainButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.maintainButtonPanel.Location = new System.Drawing.Point(694, 0);
            this.maintainButtonPanel.Name = "maintainButtonPanel";
            this.maintainButtonPanel.Size = new System.Drawing.Size(106, 401);
            this.maintainButtonPanel.TabIndex = 0;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(17, 166);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(17, 137);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(17, 56);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 1;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(17, 27);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 0;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // BusStopNameMappingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BusStopNameMappingsForm";
            this.Text = "Bus Stop Name Mappings Form";
            this.Load += new System.EventHandler(this.BusStopNameMappingsForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mappingDataGridView)).EndInit();
            this.maintainButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView mappingDataGridView;
        private System.Windows.Forms.Panel maintainButtonPanel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toColumn;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
    }
}