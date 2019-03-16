namespace CheckPublicTransportRelations
{
    partial class NaptanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.addStopButton = new System.Windows.Forms.Button();
            this.findNaptanCodeInRefButton = new System.Windows.Forms.Button();
            this.findNaptanCodeButton = new System.Windows.Forms.Button();
            this.findAtcoCodeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.naptanGroupBox = new System.Windows.Forms.GroupBox();
            this.naptanDataGridView = new System.Windows.Forms.DataGridView();
            this.keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.naptanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naptanDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.addStopButton);
            this.buttonPanel.Controls.Add(this.findNaptanCodeInRefButton);
            this.buttonPanel.Controls.Add(this.findNaptanCodeButton);
            this.buttonPanel.Controls.Add(this.findAtcoCodeButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 401);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(800, 49);
            this.buttonPanel.TabIndex = 4;
            // 
            // addStopButton
            // 
            this.addStopButton.Location = new System.Drawing.Point(362, 14);
            this.addStopButton.Name = "addStopButton";
            this.addStopButton.Size = new System.Drawing.Size(85, 23);
            this.addStopButton.TabIndex = 5;
            this.addStopButton.Text = "Add &Stop";
            this.addStopButton.UseVisualStyleBackColor = true;
            this.addStopButton.Click += new System.EventHandler(this.AddStopButton_Click);
            // 
            // findNaptanCodeInRefButton
            // 
            this.findNaptanCodeInRefButton.Location = new System.Drawing.Point(208, 14);
            this.findNaptanCodeInRefButton.Name = "findNaptanCodeInRefButton";
            this.findNaptanCodeInRefButton.Size = new System.Drawing.Size(129, 23);
            this.findNaptanCodeInRefButton.TabIndex = 4;
            this.findNaptanCodeInRefButton.Text = "Find NaptanCode in &Ref";
            this.findNaptanCodeInRefButton.UseVisualStyleBackColor = true;
            this.findNaptanCodeInRefButton.Click += new System.EventHandler(this.FindNaptanCodeInRefButton_Click);
            // 
            // findNaptanCodeButton
            // 
            this.findNaptanCodeButton.Location = new System.Drawing.Point(103, 14);
            this.findNaptanCodeButton.Name = "findNaptanCodeButton";
            this.findNaptanCodeButton.Size = new System.Drawing.Size(99, 23);
            this.findNaptanCodeButton.TabIndex = 3;
            this.findNaptanCodeButton.Text = "Find &NaptanCode";
            this.findNaptanCodeButton.UseVisualStyleBackColor = true;
            this.findNaptanCodeButton.Click += new System.EventHandler(this.FindNaptanCodeButton_Click);
            // 
            // findAtcoCodeButton
            // 
            this.findAtcoCodeButton.Location = new System.Drawing.Point(12, 14);
            this.findAtcoCodeButton.Name = "findAtcoCodeButton";
            this.findAtcoCodeButton.Size = new System.Drawing.Size(85, 23);
            this.findAtcoCodeButton.TabIndex = 2;
            this.findAtcoCodeButton.Text = "Find &AtcoCode";
            this.findAtcoCodeButton.UseVisualStyleBackColor = true;
            this.findAtcoCodeButton.Click += new System.EventHandler(this.FindAtcoCodeButton_Click);
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
            this.naptanDataGridView.Size = new System.Drawing.Size(794, 382);
            this.naptanDataGridView.TabIndex = 0;
            // 
            // keyColumn
            // 
            this.keyColumn.DataPropertyName = "Key";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.keyColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.keyColumn.HeaderText = "Key";
            this.keyColumn.Name = "keyColumn";
            this.keyColumn.ReadOnly = true;
            this.keyColumn.Width = 150;
            // 
            // valueColumn
            // 
            this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueColumn.DataPropertyName = "Value";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan;
            this.valueColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            // 
            // NaptanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "NaptanForm";
            this.ShowIcon = false;
            this.Text = "NaPTAN Information";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NaptanForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.naptanGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naptanDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox naptanGroupBox;
        private System.Windows.Forms.DataGridView naptanDataGridView;
        private System.Windows.Forms.Button findNaptanCodeButton;
        private System.Windows.Forms.Button findAtcoCodeButton;
        private System.Windows.Forms.Button addStopButton;
        private System.Windows.Forms.Button findNaptanCodeInRefButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
    }
}