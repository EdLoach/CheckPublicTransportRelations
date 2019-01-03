namespace CheckPublicTransportRelations
{
    partial class MainForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.travelineTabPage = new System.Windows.Forms.TabPage();
            this.travelineDataGridView = new System.Windows.Forms.DataGridView();
            this.openStreetMapTabPage = new System.Windows.Forms.TabPage();
            this.openStreetMapDataGridView = new System.Windows.Forms.DataGridView();
            this.compareRouteMastersTabPage = new System.Windows.Forms.TabPage();
            this.compareRouteMasterDataGridView = new System.Windows.Forms.DataGridView();
            this.servicesTabControlsPanel = new System.Windows.Forms.Panel();
            this.showMatchedServicesCheckBox = new System.Windows.Forms.CheckBox();
            this.compareRouteVariantsTabPage = new System.Windows.Forms.TabPage();
            this.routesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.comparedRoutesDataGridView = new System.Windows.Forms.DataGridView();
            this.routesTabControlsPanel = new System.Windows.Forms.Panel();
            this.showMatchedRoutesCheckBox = new System.Windows.Forms.CheckBox();
            this.stopsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.openStreetMapStopsGroupBox = new System.Windows.Forms.GroupBox();
            this.openStreetMapStopsListBox = new System.Windows.Forms.DataGridView();
            this.travelineStopsGroupBox = new System.Windows.Forms.GroupBox();
            this.travelineStopsListBox = new System.Windows.Forms.DataGridView();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.openstreetMapLastDownloadedLabel = new System.Windows.Forms.Label();
            this.openstreetmapDataDownloadedLabel = new System.Windows.Forms.Label();
            this.localRoutesLastExtractedLabel = new System.Windows.Forms.Label();
            this.localRoutesLabel = new System.Windows.Forms.Label();
            this.travelineLastDownloadedLabel = new System.Windows.Forms.Label();
            this.travelineZipsLabel = new System.Windows.Forms.Label();
            this.busStopsLastDownloadedLabel = new System.Windows.Forms.Label();
            this.busStopsLabel = new System.Windows.Forms.Label();
            this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshBusStopsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTravelineNationalDataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractLocalRoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getOpenstreetmapDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.travelineTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travelineDataGridView)).BeginInit();
            this.openStreetMapTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openStreetMapDataGridView)).BeginInit();
            this.compareRouteMastersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareRouteMasterDataGridView)).BeginInit();
            this.servicesTabControlsPanel.SuspendLayout();
            this.compareRouteVariantsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesSplitContainer)).BeginInit();
            this.routesSplitContainer.Panel1.SuspendLayout();
            this.routesSplitContainer.Panel2.SuspendLayout();
            this.routesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparedRoutesDataGridView)).BeginInit();
            this.routesTabControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stopsSplitContainer)).BeginInit();
            this.stopsSplitContainer.Panel1.SuspendLayout();
            this.stopsSplitContainer.Panel2.SuspendLayout();
            this.stopsSplitContainer.SuspendLayout();
            this.openStreetMapStopsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openStreetMapStopsListBox)).BeginInit();
            this.travelineStopsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travelineStopsListBox)).BeginInit();
            this.statusGroupBox.SuspendLayout();
            this.mainFormMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 526);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(800, 35);
            this.buttonPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(713, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "C&lose";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mainTabControl);
            this.mainPanel.Controls.Add(this.statusGroupBox);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.mainPanel.Size = new System.Drawing.Size(800, 502);
            this.mainPanel.TabIndex = 1;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.travelineTabPage);
            this.mainTabControl.Controls.Add(this.openStreetMapTabPage);
            this.mainTabControl.Controls.Add(this.compareRouteMastersTabPage);
            this.mainTabControl.Controls.Add(this.compareRouteVariantsTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(5, 74);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(790, 423);
            this.mainTabControl.TabIndex = 19;
            // 
            // travelineTabPage
            // 
            this.travelineTabPage.Controls.Add(this.travelineDataGridView);
            this.travelineTabPage.Location = new System.Drawing.Point(4, 22);
            this.travelineTabPage.Name = "travelineTabPage";
            this.travelineTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.travelineTabPage.Size = new System.Drawing.Size(782, 397);
            this.travelineTabPage.TabIndex = 0;
            this.travelineTabPage.Text = "TNDS";
            this.travelineTabPage.UseVisualStyleBackColor = true;
            // 
            // travelineDataGridView
            // 
            this.travelineDataGridView.AllowUserToAddRows = false;
            this.travelineDataGridView.AllowUserToDeleteRows = false;
            this.travelineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travelineDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelineDataGridView.Location = new System.Drawing.Point(3, 3);
            this.travelineDataGridView.Name = "travelineDataGridView";
            this.travelineDataGridView.ReadOnly = true;
            this.travelineDataGridView.Size = new System.Drawing.Size(776, 391);
            this.travelineDataGridView.TabIndex = 0;
            // 
            // openStreetMapTabPage
            // 
            this.openStreetMapTabPage.Controls.Add(this.openStreetMapDataGridView);
            this.openStreetMapTabPage.Location = new System.Drawing.Point(4, 22);
            this.openStreetMapTabPage.Name = "openStreetMapTabPage";
            this.openStreetMapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.openStreetMapTabPage.Size = new System.Drawing.Size(782, 397);
            this.openStreetMapTabPage.TabIndex = 1;
            this.openStreetMapTabPage.Text = "OSM";
            this.openStreetMapTabPage.UseVisualStyleBackColor = true;
            // 
            // openStreetMapDataGridView
            // 
            this.openStreetMapDataGridView.AllowUserToAddRows = false;
            this.openStreetMapDataGridView.AllowUserToDeleteRows = false;
            this.openStreetMapDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.openStreetMapDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openStreetMapDataGridView.Location = new System.Drawing.Point(3, 3);
            this.openStreetMapDataGridView.Name = "openStreetMapDataGridView";
            this.openStreetMapDataGridView.ReadOnly = true;
            this.openStreetMapDataGridView.Size = new System.Drawing.Size(776, 391);
            this.openStreetMapDataGridView.TabIndex = 0;
            // 
            // compareRouteMastersTabPage
            // 
            this.compareRouteMastersTabPage.Controls.Add(this.compareRouteMasterDataGridView);
            this.compareRouteMastersTabPage.Controls.Add(this.servicesTabControlsPanel);
            this.compareRouteMastersTabPage.Location = new System.Drawing.Point(4, 22);
            this.compareRouteMastersTabPage.Name = "compareRouteMastersTabPage";
            this.compareRouteMastersTabPage.Size = new System.Drawing.Size(782, 397);
            this.compareRouteMastersTabPage.TabIndex = 2;
            this.compareRouteMastersTabPage.Text = "Services";
            this.compareRouteMastersTabPage.UseVisualStyleBackColor = true;
            // 
            // compareRouteMasterDataGridView
            // 
            this.compareRouteMasterDataGridView.AllowUserToAddRows = false;
            this.compareRouteMasterDataGridView.AllowUserToDeleteRows = false;
            this.compareRouteMasterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compareRouteMasterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compareRouteMasterDataGridView.Location = new System.Drawing.Point(0, 0);
            this.compareRouteMasterDataGridView.Name = "compareRouteMasterDataGridView";
            this.compareRouteMasterDataGridView.ReadOnly = true;
            this.compareRouteMasterDataGridView.Size = new System.Drawing.Size(782, 364);
            this.compareRouteMasterDataGridView.TabIndex = 0;
            // 
            // servicesTabControlsPanel
            // 
            this.servicesTabControlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.servicesTabControlsPanel.Controls.Add(this.showMatchedServicesCheckBox);
            this.servicesTabControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.servicesTabControlsPanel.Location = new System.Drawing.Point(0, 364);
            this.servicesTabControlsPanel.Name = "servicesTabControlsPanel";
            this.servicesTabControlsPanel.Size = new System.Drawing.Size(782, 33);
            this.servicesTabControlsPanel.TabIndex = 1;
            // 
            // showMatchedServicesCheckBox
            // 
            this.showMatchedServicesCheckBox.AutoSize = true;
            this.showMatchedServicesCheckBox.Checked = true;
            this.showMatchedServicesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMatchedServicesCheckBox.Location = new System.Drawing.Point(8, 6);
            this.showMatchedServicesCheckBox.Name = "showMatchedServicesCheckBox";
            this.showMatchedServicesCheckBox.Size = new System.Drawing.Size(142, 17);
            this.showMatchedServicesCheckBox.TabIndex = 0;
            this.showMatchedServicesCheckBox.Text = "Show Matched Services";
            this.showMatchedServicesCheckBox.UseVisualStyleBackColor = true;
            this.showMatchedServicesCheckBox.CheckedChanged += new System.EventHandler(this.ShowMatchedServicesCheckBox_CheckedChanged);
            // 
            // compareRouteVariantsTabPage
            // 
            this.compareRouteVariantsTabPage.Controls.Add(this.routesSplitContainer);
            this.compareRouteVariantsTabPage.Location = new System.Drawing.Point(4, 22);
            this.compareRouteVariantsTabPage.Name = "compareRouteVariantsTabPage";
            this.compareRouteVariantsTabPage.Size = new System.Drawing.Size(782, 397);
            this.compareRouteVariantsTabPage.TabIndex = 3;
            this.compareRouteVariantsTabPage.Text = "Routes";
            this.compareRouteVariantsTabPage.UseVisualStyleBackColor = true;
            // 
            // routesSplitContainer
            // 
            this.routesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routesSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.routesSplitContainer.Name = "routesSplitContainer";
            // 
            // routesSplitContainer.Panel1
            // 
            this.routesSplitContainer.Panel1.Controls.Add(this.comparedRoutesDataGridView);
            this.routesSplitContainer.Panel1.Controls.Add(this.routesTabControlsPanel);
            this.routesSplitContainer.Panel1MinSize = 600;
            // 
            // routesSplitContainer.Panel2
            // 
            this.routesSplitContainer.Panel2.Controls.Add(this.stopsSplitContainer);
            this.routesSplitContainer.Size = new System.Drawing.Size(782, 397);
            this.routesSplitContainer.SplitterDistance = 600;
            this.routesSplitContainer.TabIndex = 0;
            // 
            // comparedRoutesDataGridView
            // 
            this.comparedRoutesDataGridView.AllowUserToAddRows = false;
            this.comparedRoutesDataGridView.AllowUserToDeleteRows = false;
            this.comparedRoutesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.comparedRoutesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comparedRoutesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.comparedRoutesDataGridView.Name = "comparedRoutesDataGridView";
            this.comparedRoutesDataGridView.ReadOnly = true;
            this.comparedRoutesDataGridView.RowHeadersVisible = false;
            this.comparedRoutesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.comparedRoutesDataGridView.Size = new System.Drawing.Size(600, 364);
            this.comparedRoutesDataGridView.TabIndex = 2;
            this.comparedRoutesDataGridView.SelectionChanged += new System.EventHandler(this.ComparedRoutesDataGridView_SelectionChanged);
            // 
            // routesTabControlsPanel
            // 
            this.routesTabControlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.routesTabControlsPanel.Controls.Add(this.showMatchedRoutesCheckBox);
            this.routesTabControlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.routesTabControlsPanel.Location = new System.Drawing.Point(0, 364);
            this.routesTabControlsPanel.Name = "routesTabControlsPanel";
            this.routesTabControlsPanel.Size = new System.Drawing.Size(600, 33);
            this.routesTabControlsPanel.TabIndex = 3;
            // 
            // showMatchedRoutesCheckBox
            // 
            this.showMatchedRoutesCheckBox.AutoSize = true;
            this.showMatchedRoutesCheckBox.Checked = true;
            this.showMatchedRoutesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMatchedRoutesCheckBox.Location = new System.Drawing.Point(8, 6);
            this.showMatchedRoutesCheckBox.Name = "showMatchedRoutesCheckBox";
            this.showMatchedRoutesCheckBox.Size = new System.Drawing.Size(135, 17);
            this.showMatchedRoutesCheckBox.TabIndex = 0;
            this.showMatchedRoutesCheckBox.Text = "Show Matched Routes";
            this.showMatchedRoutesCheckBox.UseVisualStyleBackColor = true;
            this.showMatchedRoutesCheckBox.CheckedChanged += new System.EventHandler(this.ShowMatchedRoutesCheckBox_CheckedChanged);
            // 
            // stopsSplitContainer
            // 
            this.stopsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.stopsSplitContainer.Name = "stopsSplitContainer";
            // 
            // stopsSplitContainer.Panel1
            // 
            this.stopsSplitContainer.Panel1.Controls.Add(this.openStreetMapStopsGroupBox);
            this.stopsSplitContainer.Panel1MinSize = 85;
            // 
            // stopsSplitContainer.Panel2
            // 
            this.stopsSplitContainer.Panel2.Controls.Add(this.travelineStopsGroupBox);
            this.stopsSplitContainer.Panel2MinSize = 85;
            this.stopsSplitContainer.Size = new System.Drawing.Size(178, 397);
            this.stopsSplitContainer.SplitterDistance = 85;
            this.stopsSplitContainer.TabIndex = 0;
            // 
            // openStreetMapStopsGroupBox
            // 
            this.openStreetMapStopsGroupBox.Controls.Add(this.openStreetMapStopsListBox);
            this.openStreetMapStopsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openStreetMapStopsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.openStreetMapStopsGroupBox.Name = "openStreetMapStopsGroupBox";
            this.openStreetMapStopsGroupBox.Size = new System.Drawing.Size(85, 397);
            this.openStreetMapStopsGroupBox.TabIndex = 0;
            this.openStreetMapStopsGroupBox.TabStop = false;
            this.openStreetMapStopsGroupBox.Text = "OSM";
            // 
            // openStreetMapStopsListBox
            // 
            this.openStreetMapStopsListBox.AllowUserToAddRows = false;
            this.openStreetMapStopsListBox.AllowUserToDeleteRows = false;
            this.openStreetMapStopsListBox.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.openStreetMapStopsListBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.openStreetMapStopsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openStreetMapStopsListBox.Location = new System.Drawing.Point(3, 16);
            this.openStreetMapStopsListBox.Name = "openStreetMapStopsListBox";
            this.openStreetMapStopsListBox.ReadOnly = true;
            this.openStreetMapStopsListBox.RowHeadersVisible = false;
            this.openStreetMapStopsListBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.openStreetMapStopsListBox.Size = new System.Drawing.Size(79, 378);
            this.openStreetMapStopsListBox.TabIndex = 0;
            // 
            // travelineStopsGroupBox
            // 
            this.travelineStopsGroupBox.Controls.Add(this.travelineStopsListBox);
            this.travelineStopsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelineStopsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.travelineStopsGroupBox.Name = "travelineStopsGroupBox";
            this.travelineStopsGroupBox.Size = new System.Drawing.Size(89, 397);
            this.travelineStopsGroupBox.TabIndex = 0;
            this.travelineStopsGroupBox.TabStop = false;
            this.travelineStopsGroupBox.Text = "TNDS";
            // 
            // travelineStopsListBox
            // 
            this.travelineStopsListBox.AllowUserToAddRows = false;
            this.travelineStopsListBox.AllowUserToDeleteRows = false;
            this.travelineStopsListBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.travelineStopsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travelineStopsListBox.Location = new System.Drawing.Point(3, 16);
            this.travelineStopsListBox.Name = "travelineStopsListBox";
            this.travelineStopsListBox.ReadOnly = true;
            this.travelineStopsListBox.RowHeadersVisible = false;
            this.travelineStopsListBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.travelineStopsListBox.Size = new System.Drawing.Size(83, 378);
            this.travelineStopsListBox.TabIndex = 1;
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.openstreetMapLastDownloadedLabel);
            this.statusGroupBox.Controls.Add(this.openstreetmapDataDownloadedLabel);
            this.statusGroupBox.Controls.Add(this.localRoutesLastExtractedLabel);
            this.statusGroupBox.Controls.Add(this.localRoutesLabel);
            this.statusGroupBox.Controls.Add(this.travelineLastDownloadedLabel);
            this.statusGroupBox.Controls.Add(this.travelineZipsLabel);
            this.statusGroupBox.Controls.Add(this.busStopsLastDownloadedLabel);
            this.statusGroupBox.Controls.Add(this.busStopsLabel);
            this.statusGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusGroupBox.Location = new System.Drawing.Point(5, 5);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(790, 69);
            this.statusGroupBox.TabIndex = 18;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Status";
            // 
            // openstreetMapLastDownloadedLabel
            // 
            this.openstreetMapLastDownloadedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openstreetMapLastDownloadedLabel.AutoSize = true;
            this.openstreetMapLastDownloadedLabel.Location = new System.Drawing.Point(575, 40);
            this.openstreetMapLastDownloadedLabel.Name = "openstreetMapLastDownloadedLabel";
            this.openstreetMapLastDownloadedLabel.Size = new System.Drawing.Size(91, 13);
            this.openstreetMapLastDownloadedLabel.TabIndex = 12;
            this.openstreetMapLastDownloadedLabel.Text = "Last downloaded:";
            // 
            // openstreetmapDataDownloadedLabel
            // 
            this.openstreetmapDataDownloadedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openstreetmapDataDownloadedLabel.AutoSize = true;
            this.openstreetmapDataDownloadedLabel.Location = new System.Drawing.Point(404, 40);
            this.openstreetmapDataDownloadedLabel.Name = "openstreetmapDataDownloadedLabel";
            this.openstreetmapDataDownloadedLabel.Size = new System.Drawing.Size(72, 13);
            this.openstreetmapDataDownloadedLabel.TabIndex = 11;
            this.openstreetmapDataDownloadedLabel.Text = "OSM PT data";
            // 
            // localRoutesLastExtractedLabel
            // 
            this.localRoutesLastExtractedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localRoutesLastExtractedLabel.AutoSize = true;
            this.localRoutesLastExtractedLabel.Location = new System.Drawing.Point(575, 16);
            this.localRoutesLastExtractedLabel.Name = "localRoutesLastExtractedLabel";
            this.localRoutesLastExtractedLabel.Size = new System.Drawing.Size(77, 13);
            this.localRoutesLastExtractedLabel.TabIndex = 10;
            this.localRoutesLastExtractedLabel.Text = "Last extracted:";
            // 
            // localRoutesLabel
            // 
            this.localRoutesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localRoutesLabel.AutoSize = true;
            this.localRoutesLabel.Location = new System.Drawing.Point(404, 16);
            this.localRoutesLabel.Name = "localRoutesLabel";
            this.localRoutesLabel.Size = new System.Drawing.Size(115, 13);
            this.localRoutesLabel.TabIndex = 9;
            this.localRoutesLabel.Text = "Local routes extracted:";
            // 
            // travelineLastDownloadedLabel
            // 
            this.travelineLastDownloadedLabel.AutoSize = true;
            this.travelineLastDownloadedLabel.Location = new System.Drawing.Point(180, 39);
            this.travelineLastDownloadedLabel.Name = "travelineLastDownloadedLabel";
            this.travelineLastDownloadedLabel.Size = new System.Drawing.Size(91, 13);
            this.travelineLastDownloadedLabel.TabIndex = 8;
            this.travelineLastDownloadedLabel.Text = "Last downloaded:";
            // 
            // travelineZipsLabel
            // 
            this.travelineZipsLabel.AutoSize = true;
            this.travelineZipsLabel.Location = new System.Drawing.Point(9, 39);
            this.travelineZipsLabel.Name = "travelineZipsLabel";
            this.travelineZipsLabel.Size = new System.Drawing.Size(61, 13);
            this.travelineZipsLabel.TabIndex = 7;
            this.travelineZipsLabel.Text = "TNDS zips:";
            // 
            // busStopsLastDownloadedLabel
            // 
            this.busStopsLastDownloadedLabel.AutoSize = true;
            this.busStopsLastDownloadedLabel.Location = new System.Drawing.Point(180, 16);
            this.busStopsLastDownloadedLabel.Name = "busStopsLastDownloadedLabel";
            this.busStopsLastDownloadedLabel.Size = new System.Drawing.Size(91, 13);
            this.busStopsLastDownloadedLabel.TabIndex = 6;
            this.busStopsLastDownloadedLabel.Text = "Last downloaded:";
            // 
            // busStopsLabel
            // 
            this.busStopsLabel.AutoSize = true;
            this.busStopsLabel.Location = new System.Drawing.Point(9, 16);
            this.busStopsLabel.Name = "busStopsLabel";
            this.busStopsLabel.Size = new System.Drawing.Size(80, 13);
            this.busStopsLabel.TabIndex = 5;
            this.busStopsLabel.Text = "Bus stops read:";
            // 
            // mainFormMenuStrip
            // 
            this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFormMenuStrip.Name = "mainFormMenuStrip";
            this.mainFormMenuStrip.Size = new System.Drawing.Size(800, 24);
            this.mainFormMenuStrip.TabIndex = 2;
            this.mainFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshBusStopsToolStripMenuItem,
            this.downloadTravelineNationalDataSetToolStripMenuItem,
            this.extractLocalRoutesToolStripMenuItem,
            this.getOpenstreetmapDataToolStripMenuItem,
            this.compareDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // refreshBusStopsToolStripMenuItem
            // 
            this.refreshBusStopsToolStripMenuItem.Name = "refreshBusStopsToolStripMenuItem";
            this.refreshBusStopsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.refreshBusStopsToolStripMenuItem.Text = "Refresh Bus Stops";
            this.refreshBusStopsToolStripMenuItem.Click += new System.EventHandler(this.RefreshBusStopsToolStripMenuItem_Click);
            // 
            // downloadTravelineNationalDataSetToolStripMenuItem
            // 
            this.downloadTravelineNationalDataSetToolStripMenuItem.Name = "downloadTravelineNationalDataSetToolStripMenuItem";
            this.downloadTravelineNationalDataSetToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.downloadTravelineNationalDataSetToolStripMenuItem.Text = "Download TNDS...";
            this.downloadTravelineNationalDataSetToolStripMenuItem.Click += new System.EventHandler(this.DownloadTravelineNationalDataSetToolStripMenuItem_Click);
            // 
            // extractLocalRoutesToolStripMenuItem
            // 
            this.extractLocalRoutesToolStripMenuItem.Name = "extractLocalRoutesToolStripMenuItem";
            this.extractLocalRoutesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.extractLocalRoutesToolStripMenuItem.Text = "Extract Local Routes...";
            this.extractLocalRoutesToolStripMenuItem.Click += new System.EventHandler(this.ExtractLocalRoutesToolStripMenuItem_Click);
            // 
            // getOpenstreetmapDataToolStripMenuItem
            // 
            this.getOpenstreetmapDataToolStripMenuItem.Name = "getOpenstreetmapDataToolStripMenuItem";
            this.getOpenstreetmapDataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.getOpenstreetmapDataToolStripMenuItem.Text = "Get OSM Data...";
            this.getOpenstreetmapDataToolStripMenuItem.Click += new System.EventHandler(this.GetOpenStreetMapDataToolStripMenuItem_Click);
            // 
            // compareDataToolStripMenuItem
            // 
            this.compareDataToolStripMenuItem.Name = "compareDataToolStripMenuItem";
            this.compareDataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.compareDataToolStripMenuItem.Text = "&Compare data";
            this.compareDataToolStripMenuItem.Click += new System.EventHandler(this.CompareDataToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.mainFormMenuStrip);
            this.MainMenuStrip = this.mainFormMenuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Check Public Transport v2 Bus Relations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.travelineTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travelineDataGridView)).EndInit();
            this.openStreetMapTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openStreetMapDataGridView)).EndInit();
            this.compareRouteMastersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compareRouteMasterDataGridView)).EndInit();
            this.servicesTabControlsPanel.ResumeLayout(false);
            this.servicesTabControlsPanel.PerformLayout();
            this.compareRouteVariantsTabPage.ResumeLayout(false);
            this.routesSplitContainer.Panel1.ResumeLayout(false);
            this.routesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.routesSplitContainer)).EndInit();
            this.routesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comparedRoutesDataGridView)).EndInit();
            this.routesTabControlsPanel.ResumeLayout(false);
            this.routesTabControlsPanel.PerformLayout();
            this.stopsSplitContainer.Panel1.ResumeLayout(false);
            this.stopsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stopsSplitContainer)).EndInit();
            this.stopsSplitContainer.ResumeLayout(false);
            this.openStreetMapStopsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openStreetMapStopsListBox)).EndInit();
            this.travelineStopsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travelineStopsListBox)).EndInit();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.mainFormMenuStrip.ResumeLayout(false);
            this.mainFormMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip mainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshBusStopsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadTravelineNationalDataSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractLocalRoutesToolStripMenuItem;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label busStopsLabel;
        private System.Windows.Forms.Label busStopsLastDownloadedLabel;
        private System.Windows.Forms.Label travelineZipsLabel;
        private System.Windows.Forms.Label travelineLastDownloadedLabel;
        private System.Windows.Forms.Label localRoutesLastExtractedLabel;
        private System.Windows.Forms.Label localRoutesLabel;
        private System.Windows.Forms.Label openstreetMapLastDownloadedLabel;
        private System.Windows.Forms.Label openstreetmapDataDownloadedLabel;
        private System.Windows.Forms.ToolStripMenuItem getOpenstreetmapDataToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage travelineTabPage;
        private System.Windows.Forms.DataGridView travelineDataGridView;
        private System.Windows.Forms.TabPage openStreetMapTabPage;
        private System.Windows.Forms.DataGridView openStreetMapDataGridView;
        private System.Windows.Forms.ToolStripMenuItem compareDataToolStripMenuItem;
        private System.Windows.Forms.TabPage compareRouteMastersTabPage;
        private System.Windows.Forms.DataGridView compareRouteMasterDataGridView;
        private System.Windows.Forms.TabPage compareRouteVariantsTabPage;
        private System.Windows.Forms.SplitContainer routesSplitContainer;
        private System.Windows.Forms.DataGridView comparedRoutesDataGridView;
        private System.Windows.Forms.SplitContainer stopsSplitContainer;
        private System.Windows.Forms.GroupBox openStreetMapStopsGroupBox;
        private System.Windows.Forms.GroupBox travelineStopsGroupBox;
        private System.Windows.Forms.DataGridView openStreetMapStopsListBox;
        private System.Windows.Forms.DataGridView travelineStopsListBox;
        private System.Windows.Forms.Panel servicesTabControlsPanel;
        private System.Windows.Forms.CheckBox showMatchedServicesCheckBox;
        private System.Windows.Forms.Panel routesTabControlsPanel;
        private System.Windows.Forms.CheckBox showMatchedRoutesCheckBox;
    }
}

