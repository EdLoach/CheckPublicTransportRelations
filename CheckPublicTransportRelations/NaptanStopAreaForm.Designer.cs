namespace CheckPublicTransportRelations
{
    partial class NaptanStopAreaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.addStopAreaButton = new System.Windows.Forms.Button();
            this.findCodeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.naptanGroupBox = new System.Windows.Forms.GroupBox();
            this.naptanDataGridView = new System.Windows.Forms.DataGridView();
            this.keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaStopsPanel = new System.Windows.Forms.Panel();
            this.areaStopsDataGridView = new System.Windows.Forms.DataGridView();
            this.atcoCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.atcoLookupButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.naptanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naptanDataGridView)).BeginInit();
            this.areaStopsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaStopsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.addStopAreaButton);
            this.buttonPanel.Controls.Add(this.findCodeButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 401);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(800, 49);
            this.buttonPanel.TabIndex = 4;
            // 
            // addStopAreaButton
            // 
            this.addStopAreaButton.Location = new System.Drawing.Point(323, 14);
            this.addStopAreaButton.Name = "addStopAreaButton";
            this.addStopAreaButton.Size = new System.Drawing.Size(152, 23);
            this.addStopAreaButton.TabIndex = 5;
            this.addStopAreaButton.Text = "Stop &Area Tags to clipboard";
            this.addStopAreaButton.UseVisualStyleBackColor = true;
            this.addStopAreaButton.Click += new System.EventHandler(this.AddStopButton_Click);
            // 
            // findCodeButton
            // 
            this.findCodeButton.Location = new System.Drawing.Point(12, 14);
            this.findCodeButton.Name = "findCodeButton";
            this.findCodeButton.Size = new System.Drawing.Size(113, 23);
            this.findCodeButton.TabIndex = 2;
            this.findCodeButton.Text = "Find &StopAreaCode";
            this.findCodeButton.UseVisualStyleBackColor = true;
            this.findCodeButton.Click += new System.EventHandler(this.FindCodeButton_Click);
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
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.naptanGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 401);
            this.mainPanel.TabIndex = 5;
            // 
            // naptanGroupBox
            // 
            this.naptanGroupBox.Controls.Add(this.naptanDataGridView);
            this.naptanGroupBox.Controls.Add(this.areaStopsPanel);
            this.naptanGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naptanGroupBox.Location = new System.Drawing.Point(0, 0);
            this.naptanGroupBox.Name = "naptanGroupBox";
            this.naptanGroupBox.Size = new System.Drawing.Size(800, 401);
            this.naptanGroupBox.TabIndex = 0;
            this.naptanGroupBox.TabStop = false;
            // 
            // naptanDataGridView
            // 
            this.naptanDataGridView.AllowUserToAddRows = false;
            this.naptanDataGridView.AllowUserToDeleteRows = false;
            this.naptanDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.naptanDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyColumn,
            this.valueColumn});
            this.naptanDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naptanDataGridView.Location = new System.Drawing.Point(3, 16);
            this.naptanDataGridView.Name = "naptanDataGridView";
            this.naptanDataGridView.ReadOnly = true;
            this.naptanDataGridView.RowHeadersVisible = false;
            this.naptanDataGridView.Size = new System.Drawing.Size(615, 382);
            this.naptanDataGridView.TabIndex = 0;
            // 
            // keyColumn
            // 
            this.keyColumn.DataPropertyName = "Key";
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.keyColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.keyColumn.HeaderText = "Key";
            this.keyColumn.Name = "keyColumn";
            this.keyColumn.ReadOnly = true;
            this.keyColumn.Width = 150;
            // 
            // valueColumn
            // 
            this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueColumn.DataPropertyName = "Value";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightCyan;
            this.valueColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            // 
            // areaStopsPanel
            // 
            this.areaStopsPanel.Controls.Add(this.areaStopsDataGridView);
            this.areaStopsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.areaStopsPanel.Location = new System.Drawing.Point(618, 16);
            this.areaStopsPanel.Name = "areaStopsPanel";
            this.areaStopsPanel.Size = new System.Drawing.Size(179, 382);
            this.areaStopsPanel.TabIndex = 1;
            // 
            // areaStopsDataGridView
            // 
            this.areaStopsDataGridView.AllowUserToAddRows = false;
            this.areaStopsDataGridView.AllowUserToDeleteRows = false;
            this.areaStopsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.areaStopsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.atcoCodeColumn,
            this.atcoLookupButtonColumn});
            this.areaStopsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areaStopsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.areaStopsDataGridView.Name = "areaStopsDataGridView";
            this.areaStopsDataGridView.ReadOnly = true;
            this.areaStopsDataGridView.RowHeadersVisible = false;
            this.areaStopsDataGridView.Size = new System.Drawing.Size(179, 382);
            this.areaStopsDataGridView.TabIndex = 1;
            this.areaStopsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AreaStopsDataGridView_CellContentClick);
            // 
            // atcoCodeColumn
            // 
            this.atcoCodeColumn.DataPropertyName = "Key";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.atcoCodeColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.atcoCodeColumn.HeaderText = "AtcoCode";
            this.atcoCodeColumn.Name = "atcoCodeColumn";
            this.atcoCodeColumn.ReadOnly = true;
            this.atcoCodeColumn.Width = 150;
            // 
            // atcoLookupButtonColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCyan;
            this.atcoLookupButtonColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.atcoLookupButtonColumn.HeaderText = "N";
            this.atcoLookupButtonColumn.Name = "atcoLookupButtonColumn";
            this.atcoLookupButtonColumn.ReadOnly = true;
            this.atcoLookupButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.atcoLookupButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.atcoLookupButtonColumn.Text = "?";
            this.atcoLookupButtonColumn.UseColumnTextForButtonValue = true;
            this.atcoLookupButtonColumn.Width = 25;
            // 
            // NaptanStopAreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "NaptanStopAreaForm";
            this.ShowIcon = false;
            this.Text = "NaPTAN Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NaptanForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.naptanGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naptanDataGridView)).EndInit();
            this.areaStopsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.areaStopsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox naptanGroupBox;
        private System.Windows.Forms.DataGridView naptanDataGridView;
        private System.Windows.Forms.Button findCodeButton;
        private System.Windows.Forms.Button addStopAreaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.Panel areaStopsPanel;
        private System.Windows.Forms.DataGridView areaStopsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn atcoCodeColumn;
        private System.Windows.Forms.DataGridViewButtonColumn atcoLookupButtonColumn;
    }
}