namespace PortMan2014
{
    partial class FrmPageHuawei
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
            this.TabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageReserv = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.grdReserv = new DevExpress.XtraGrid.GridControl();
            this.grdReservView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtReservLog = new DevExpress.XtraEditors.MemoEdit();
            this.grpReservation = new DevExpress.XtraEditors.GroupControl();
            this.picAVEA = new DevExpress.XtraEditors.PictureEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.menu1SelectALL = new DevExpress.XtraBars.BarButtonItem();
            this.menu2UnSelectALL = new DevExpress.XtraBars.BarButtonItem();
            this.menuLine = new DevExpress.XtraBars.BarButtonItem();
            this.menu3Comment = new DevExpress.XtraBars.BarButtonItem();
            this.btnReservList = new DevExpress.XtraEditors.SimpleButton();
            this.btnReservCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReserv = new DevExpress.XtraEditors.SimpleButton();
            this.btnRequestCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRequest = new DevExpress.XtraEditors.SimpleButton();
            this.lbStatus = new DevExpress.XtraEditors.LabelControl();
            this.txtPortStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbSiteName = new DevExpress.XtraEditors.LabelControl();
            this.txtSiteNameV1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRefreshPorts = new DevExpress.XtraEditors.SimpleButton();
            this.btnReservClear = new DevExpress.XtraEditors.SimpleButton();
            this.pagePort = new DevExpress.XtraTab.XtraTabPage();
            this.btnUpdateConnection = new DevExpress.XtraEditors.SimpleButton();
            this.txtConnection = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPortsClear = new DevExpress.XtraEditors.SimpleButton();
            this.txtSiteNameV2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnPorts = new DevExpress.XtraEditors.SimpleButton();
            this.grdPort = new DevExpress.XtraGrid.GridControl();
            this.grdPortView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pageLog = new DevExpress.XtraTab.XtraTabPage();
            this.txtTerminal = new DevExpress.XtraEditors.MemoEdit();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).BeginInit();
            this.TabMain.SuspendLayout();
            this.pageReserv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReserv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReservView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReservLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReservation)).BeginInit();
            this.grpReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAVEA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNameV1.Properties)).BeginInit();
            this.pagePort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNameV2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPortView)).BeginInit();
            this.pageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // TabMain
            // 
            this.TabMain.Appearance.Options.UseTextOptions = true;
            this.TabMain.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TabMain.AppearancePage.Header.Options.UseFont = true;
            this.TabMain.AppearancePage.Header.Options.UseTextOptions = true;
            this.TabMain.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(10, 10);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedTabPage = this.pageReserv;
            this.TabMain.Size = new System.Drawing.Size(1180, 680);
            this.TabMain.TabIndex = 11;
            this.TabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageReserv,
            this.pagePort,
            this.pageLog});
            this.TabMain.TabPageWidth = 160;
            // 
            // pageReserv
            // 
            this.pageReserv.Controls.Add(this.splitContainerControl);
            this.pageReserv.Controls.Add(this.grpReservation);
            this.pageReserv.Name = "pageReserv";
            this.pageReserv.Size = new System.Drawing.Size(1175, 652);
            this.pageReserv.Text = "Reservation";
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 152);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.btnExport);
            this.splitContainerControl.Panel1.Controls.Add(this.grdReserv);
            this.splitContainerControl.Panel1.Text = "PanelGrid";
            this.splitContainerControl.Panel2.Controls.Add(this.txtReservLog);
            this.splitContainerControl.Panel2.Text = "PanelLog";
            this.splitContainerControl.Size = new System.Drawing.Size(1175, 500);
            this.splitContainerControl.SplitterPosition = 344;
            this.splitContainerControl.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Appearance.BackColor = System.Drawing.Color.Chartreuse;
            this.btnExport.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(701, 2);
            this.btnExport.LookAndFeel.SkinName = "Glass Oceans";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 30);
            this.btnExport.TabIndex = 68;
            this.btnExport.TabStop = false;
            this.btnExport.Tag = "ActionButton";
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grdReserv
            // 
            this.grdReserv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReserv.Location = new System.Drawing.Point(0, 0);
            this.grdReserv.MainView = this.grdReservView;
            this.grdReserv.Name = "grdReserv";
            this.grdReserv.Size = new System.Drawing.Size(825, 500);
            this.grdReserv.TabIndex = 8;
            this.grdReserv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdReservView});
            // 
            // grdReservView
            // 
            this.grdReservView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdReservView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdReservView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdReservView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdReservView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdReservView.Appearance.Row.Options.UseFont = true;
            this.grdReservView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdReservView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdReservView.GridControl = this.grdReserv;
            this.grdReservView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdReservView.Name = "grdReservView";
            this.grdReservView.OptionsBehavior.Editable = false;
            this.grdReservView.OptionsBehavior.ReadOnly = true;
            this.grdReservView.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdReservView.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdReservView.OptionsLayout.Columns.StoreAppearance = true;
            this.grdReservView.OptionsLayout.StoreAllOptions = true;
            this.grdReservView.OptionsLayout.StoreAppearance = true;
            this.grdReservView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdReservView.OptionsSelection.MultiSelect = true;
            this.grdReservView.OptionsView.EnableAppearanceOddRow = true;
            this.grdReservView.OptionsView.ShowAutoFilterRow = true;
            this.grdReservView.ViewCaption = "Tables";
            this.grdReservView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdReservView_RowCellStyle);
            this.grdReservView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdReservView_RowStyle);
            this.grdReservView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grdReservView_ShowingEditor);
            this.grdReservView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdReservView_FocusedRowChanged);
            this.grdReservView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdReservView_MouseUp);
            // 
            // txtReservLog
            // 
            this.txtReservLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReservLog.Location = new System.Drawing.Point(0, 0);
            this.txtReservLog.Name = "txtReservLog";
            this.txtReservLog.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtReservLog.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReservLog.Properties.Appearance.Options.UseBackColor = true;
            this.txtReservLog.Properties.Appearance.Options.UseFont = true;
            this.txtReservLog.Properties.ReadOnly = true;
            this.txtReservLog.Size = new System.Drawing.Size(344, 500);
            this.txtReservLog.TabIndex = 10;
            // 
            // grpReservation
            // 
            this.grpReservation.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpReservation.AppearanceCaption.Options.UseFont = true;
            this.grpReservation.AppearanceCaption.Options.UseTextOptions = true;
            this.grpReservation.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpReservation.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpReservation.Controls.Add(this.picAVEA);
            this.grpReservation.Controls.Add(this.btnReservList);
            this.grpReservation.Controls.Add(this.btnReservCancel);
            this.grpReservation.Controls.Add(this.btnReserv);
            this.grpReservation.Controls.Add(this.btnRequestCancel);
            this.grpReservation.Controls.Add(this.btnRequest);
            this.grpReservation.Controls.Add(this.lbStatus);
            this.grpReservation.Controls.Add(this.txtPortStatus);
            this.grpReservation.Controls.Add(this.lbSiteName);
            this.grpReservation.Controls.Add(this.txtSiteNameV1);
            this.grpReservation.Controls.Add(this.btnRefreshPorts);
            this.grpReservation.Controls.Add(this.btnReservClear);
            this.grpReservation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReservation.Location = new System.Drawing.Point(0, 0);
            this.grpReservation.Name = "grpReservation";
            this.grpReservation.Size = new System.Drawing.Size(1175, 152);
            this.grpReservation.TabIndex = 10;
            // 
            // picAVEA
            // 
            this.picAVEA.EditValue = global::PortMan2014.Properties.Resources.HUAWEI;
            this.picAVEA.Location = new System.Drawing.Point(43, 30);
            this.picAVEA.MenuManager = this.barManager;
            this.picAVEA.Name = "picAVEA";
            this.picAVEA.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.picAVEA.Properties.Appearance.Options.UseBackColor = true;
            this.picAVEA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picAVEA.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picAVEA.Size = new System.Drawing.Size(98, 94);
            this.picAVEA.TabIndex = 66;
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menu1SelectALL,
            this.menu2UnSelectALL,
            this.menuLine,
            this.menu3Comment});
            this.barManager.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(10, 10);
            this.barDockControlTop.Size = new System.Drawing.Size(1180, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(10, 690);
            this.barDockControlBottom.Size = new System.Drawing.Size(1180, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(10, 10);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 680);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1190, 10);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 680);
            // 
            // menu1SelectALL
            // 
            this.menu1SelectALL.Caption = "1-)  Select ALL";
            this.menu1SelectALL.Id = 0;
            this.menu1SelectALL.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menu1SelectALL.ItemAppearance.Normal.Options.UseFont = true;
            this.menu1SelectALL.Name = "menu1SelectALL";
            this.menu1SelectALL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menu1SelectALL_ItemClick);
            // 
            // menu2UnSelectALL
            // 
            this.menu2UnSelectALL.Caption = "2-)  UnSelect ALL";
            this.menu2UnSelectALL.Id = 1;
            this.menu2UnSelectALL.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menu2UnSelectALL.ItemAppearance.Normal.Options.UseFont = true;
            this.menu2UnSelectALL.Name = "menu2UnSelectALL";
            this.menu2UnSelectALL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menu2UnSelectALL_ItemClick);
            // 
            // menuLine
            // 
            this.menuLine.Caption = "-----------------------";
            this.menuLine.Id = 2;
            this.menuLine.Name = "menuLine";
            // 
            // menu3Comment
            // 
            this.menu3Comment.Caption = "3-)  Hide Comment";
            this.menu3Comment.Id = 3;
            this.menu3Comment.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menu3Comment.ItemAppearance.Normal.Options.UseFont = true;
            this.menu3Comment.Name = "menu3Comment";
            this.menu3Comment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menu3Comment_ItemClick);
            // 
            // btnReservList
            // 
            this.btnReservList.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReservList.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnReservList.Appearance.Options.UseFont = true;
            this.btnReservList.Appearance.Options.UseForeColor = true;
            this.btnReservList.Location = new System.Drawing.Point(427, 30);
            this.btnReservList.LookAndFeel.SkinName = "Glass Oceans";
            this.btnReservList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReservList.Name = "btnReservList";
            this.btnReservList.Size = new System.Drawing.Size(100, 60);
            this.btnReservList.TabIndex = 65;
            this.btnReservList.TabStop = false;
            this.btnReservList.Tag = "ActionButton";
            this.btnReservList.Text = "LIST";
            this.btnReservList.Click += new System.EventHandler(this.btnReservList_Click);
            // 
            // btnReservCancel
            // 
            this.btnReservCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReservCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnReservCancel.Appearance.Options.UseFont = true;
            this.btnReservCancel.Appearance.Options.UseForeColor = true;
            this.btnReservCancel.Location = new System.Drawing.Point(745, 96);
            this.btnReservCancel.LookAndFeel.SkinName = "Glass Oceans";
            this.btnReservCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReservCancel.Name = "btnReservCancel";
            this.btnReservCancel.Size = new System.Drawing.Size(100, 30);
            this.btnReservCancel.TabIndex = 64;
            this.btnReservCancel.TabStop = false;
            this.btnReservCancel.Tag = "ActionButton";
            this.btnReservCancel.Text = "Rollback";
            this.btnReservCancel.Click += new System.EventHandler(this.btnReservCancel_Click);
            // 
            // btnReserv
            // 
            this.btnReserv.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReserv.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnReserv.Appearance.Options.UseFont = true;
            this.btnReserv.Appearance.Options.UseForeColor = true;
            this.btnReserv.Location = new System.Drawing.Point(745, 30);
            this.btnReserv.LookAndFeel.SkinName = "Glass Oceans";
            this.btnReserv.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReserv.Name = "btnReserv";
            this.btnReserv.Size = new System.Drawing.Size(100, 60);
            this.btnReserv.TabIndex = 63;
            this.btnReserv.TabStop = false;
            this.btnReserv.Tag = "ActionButton";
            this.btnReserv.Text = "RESERV";
            this.btnReserv.Click += new System.EventHandler(this.btnReserv_Click);
            // 
            // btnRequestCancel
            // 
            this.btnRequestCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRequestCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRequestCancel.Appearance.Options.UseFont = true;
            this.btnRequestCancel.Appearance.Options.UseForeColor = true;
            this.btnRequestCancel.Location = new System.Drawing.Point(639, 96);
            this.btnRequestCancel.LookAndFeel.SkinName = "Glass Oceans";
            this.btnRequestCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRequestCancel.Name = "btnRequestCancel";
            this.btnRequestCancel.Size = new System.Drawing.Size(100, 30);
            this.btnRequestCancel.TabIndex = 62;
            this.btnRequestCancel.TabStop = false;
            this.btnRequestCancel.Tag = "ActionButton";
            this.btnRequestCancel.Text = "Rollback";
            this.btnRequestCancel.ToolTip = "Ctrl + Enter";
            this.btnRequestCancel.Click += new System.EventHandler(this.btnRequestCancel_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Appearance.BackColor = System.Drawing.Color.Chartreuse;
            this.btnRequest.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRequest.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRequest.Appearance.Options.UseBackColor = true;
            this.btnRequest.Appearance.Options.UseFont = true;
            this.btnRequest.Appearance.Options.UseForeColor = true;
            this.btnRequest.Location = new System.Drawing.Point(639, 30);
            this.btnRequest.LookAndFeel.SkinName = "Glass Oceans";
            this.btnRequest.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(100, 60);
            this.btnRequest.TabIndex = 61;
            this.btnRequest.TabStop = false;
            this.btnRequest.Tag = "ActionButton";
            this.btnRequest.Text = "REQUEST";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbStatus.Location = new System.Drawing.Point(162, 105);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(35, 14);
            this.lbStatus.TabIndex = 60;
            this.lbStatus.Text = "Port :";
            // 
            // txtPortStatus
            // 
            this.txtPortStatus.EnterMoveNextControl = true;
            this.txtPortStatus.Location = new System.Drawing.Point(203, 103);
            this.txtPortStatus.Name = "txtPortStatus";
            this.txtPortStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPortStatus.Properties.Appearance.Options.UseFont = true;
            this.txtPortStatus.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtPortStatus.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPortStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPortStatus.Properties.DropDownRows = 15;
            this.txtPortStatus.Properties.Items.AddRange(new object[] {
            "ALL",
            "USED",
            "FREE",
            "DELETED",
            "REQUEST",
            "RESERVED"});
            this.txtPortStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtPortStatus.Size = new System.Drawing.Size(207, 20);
            this.txtPortStatus.TabIndex = 59;
            this.txtPortStatus.SelectedIndexChanged += new System.EventHandler(this.txtPortStatus_SelectedIndexChanged);
            // 
            // lbSiteName
            // 
            this.lbSiteName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSiteName.Location = new System.Drawing.Point(165, 41);
            this.lbSiteName.Name = "lbSiteName";
            this.lbSiteName.Size = new System.Drawing.Size(32, 14);
            this.lbSiteName.TabIndex = 58;
            this.lbSiteName.Text = "Site :";
            // 
            // txtSiteNameV1
            // 
            this.txtSiteNameV1.EnterMoveNextControl = true;
            this.txtSiteNameV1.Location = new System.Drawing.Point(203, 38);
            this.txtSiteNameV1.Name = "txtSiteNameV1";
            this.txtSiteNameV1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSiteNameV1.Properties.Appearance.Options.UseFont = true;
            this.txtSiteNameV1.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtSiteNameV1.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSiteNameV1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSiteNameV1.Properties.DropDownRows = 15;
            this.txtSiteNameV1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtSiteNameV1.Size = new System.Drawing.Size(207, 20);
            this.txtSiteNameV1.TabIndex = 57;
            this.txtSiteNameV1.SelectedIndexChanged += new System.EventHandler(this.txtSiteNameV1_SelectedIndexChanged);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnRefreshPorts.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRefreshPorts.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefreshPorts.Appearance.Options.UseBackColor = true;
            this.btnRefreshPorts.Appearance.Options.UseFont = true;
            this.btnRefreshPorts.Appearance.Options.UseForeColor = true;
            this.btnRefreshPorts.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnRefreshPorts.Location = new System.Drawing.Point(533, 30);
            this.btnRefreshPorts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(100, 96);
            this.btnRefreshPorts.TabIndex = 56;
            this.btnRefreshPorts.TabStop = false;
            this.btnRefreshPorts.Tag = "ColorButton";
            this.btnRefreshPorts.Text = "REFRESH\r\n\r\nPorts";
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // btnReservClear
            // 
            this.btnReservClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReservClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnReservClear.Appearance.Options.UseFont = true;
            this.btnReservClear.Appearance.Options.UseForeColor = true;
            this.btnReservClear.Location = new System.Drawing.Point(427, 96);
            this.btnReservClear.LookAndFeel.SkinName = "Sharp";
            this.btnReservClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnReservClear.Name = "btnReservClear";
            this.btnReservClear.Size = new System.Drawing.Size(100, 30);
            this.btnReservClear.TabIndex = 50;
            this.btnReservClear.TabStop = false;
            this.btnReservClear.Tag = "";
            this.btnReservClear.Text = "Clear";
            this.btnReservClear.ToolTip = "Ctrl + Enter";
            this.btnReservClear.Click += new System.EventHandler(this.btnReservClear_Click);
            // 
            // pagePort
            // 
            this.pagePort.Controls.Add(this.btnUpdateConnection);
            this.pagePort.Controls.Add(this.txtConnection);
            this.pagePort.Controls.Add(this.btnPortsClear);
            this.pagePort.Controls.Add(this.txtSiteNameV2);
            this.pagePort.Controls.Add(this.btnPorts);
            this.pagePort.Controls.Add(this.grdPort);
            this.pagePort.Name = "pagePort";
            this.pagePort.Size = new System.Drawing.Size(1175, 652);
            this.pagePort.Text = "Ports";
            // 
            // btnUpdateConnection
            // 
            this.btnUpdateConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateConnection.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateConnection.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateConnection.Appearance.Options.UseFont = true;
            this.btnUpdateConnection.Appearance.Options.UseForeColor = true;
            this.btnUpdateConnection.Location = new System.Drawing.Point(520, 3);
            this.btnUpdateConnection.LookAndFeel.SkinName = "Glass Oceans";
            this.btnUpdateConnection.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpdateConnection.Name = "btnUpdateConnection";
            this.btnUpdateConnection.Size = new System.Drawing.Size(97, 31);
            this.btnUpdateConnection.TabIndex = 70;
            this.btnUpdateConnection.TabStop = false;
            this.btnUpdateConnection.Tag = "ActionButton";
            this.btnUpdateConnection.Text = "Update";
            this.btnUpdateConnection.Click += new System.EventHandler(this.btnUpdateConnection_Click);
            // 
            // txtConnection
            // 
            this.txtConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnection.EnterMoveNextControl = true;
            this.txtConnection.Location = new System.Drawing.Point(623, 7);
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtConnection.Properties.Appearance.Options.UseFont = true;
            this.txtConnection.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtConnection.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtConnection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtConnection.Properties.Items.AddRange(new object[] {
            "TEL",
            "SSH"});
            this.txtConnection.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtConnection.Size = new System.Drawing.Size(65, 20);
            this.txtConnection.TabIndex = 69;
            // 
            // btnPortsClear
            // 
            this.btnPortsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPortsClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPortsClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPortsClear.Appearance.Options.UseFont = true;
            this.btnPortsClear.Appearance.Options.UseForeColor = true;
            this.btnPortsClear.Location = new System.Drawing.Point(1010, 4);
            this.btnPortsClear.LookAndFeel.SkinName = "Sharp";
            this.btnPortsClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPortsClear.Name = "btnPortsClear";
            this.btnPortsClear.Size = new System.Drawing.Size(100, 30);
            this.btnPortsClear.TabIndex = 68;
            this.btnPortsClear.TabStop = false;
            this.btnPortsClear.Tag = "";
            this.btnPortsClear.Text = "Clear";
            this.btnPortsClear.ToolTip = "Ctrl + Enter";
            this.btnPortsClear.Click += new System.EventHandler(this.btnPortsClear_Click);
            // 
            // txtSiteNameV2
            // 
            this.txtSiteNameV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteNameV2.EnterMoveNextControl = true;
            this.txtSiteNameV2.Location = new System.Drawing.Point(694, 7);
            this.txtSiteNameV2.Name = "txtSiteNameV2";
            this.txtSiteNameV2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSiteNameV2.Properties.Appearance.Options.UseFont = true;
            this.txtSiteNameV2.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtSiteNameV2.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSiteNameV2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSiteNameV2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtSiteNameV2.Size = new System.Drawing.Size(207, 20);
            this.txtSiteNameV2.TabIndex = 67;
            this.txtSiteNameV2.SelectedIndexChanged += new System.EventHandler(this.txtSiteNameV2_SelectedIndexChanged);
            // 
            // btnPorts
            // 
            this.btnPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPorts.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPorts.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnPorts.Appearance.Options.UseFont = true;
            this.btnPorts.Appearance.Options.UseForeColor = true;
            this.btnPorts.Location = new System.Drawing.Point(907, 3);
            this.btnPorts.LookAndFeel.SkinName = "Glass Oceans";
            this.btnPorts.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPorts.Name = "btnPorts";
            this.btnPorts.Size = new System.Drawing.Size(97, 31);
            this.btnPorts.TabIndex = 66;
            this.btnPorts.TabStop = false;
            this.btnPorts.Tag = "ActionButton";
            this.btnPorts.Text = "PORTS";
            this.btnPorts.Click += new System.EventHandler(this.btnPorts_Click);
            // 
            // grdPort
            // 
            this.grdPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPort.Location = new System.Drawing.Point(0, 0);
            this.grdPort.MainView = this.grdPortView;
            this.grdPort.Name = "grdPort";
            this.grdPort.Size = new System.Drawing.Size(1175, 652);
            this.grdPort.TabIndex = 9;
            this.grdPort.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPortView});
            // 
            // grdPortView
            // 
            this.grdPortView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdPortView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdPortView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdPortView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdPortView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdPortView.Appearance.Row.Options.UseFont = true;
            this.grdPortView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdPortView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdPortView.GridControl = this.grdPort;
            this.grdPortView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdPortView.Name = "grdPortView";
            this.grdPortView.OptionsBehavior.Editable = false;
            this.grdPortView.OptionsBehavior.ReadOnly = true;
            this.grdPortView.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdPortView.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdPortView.OptionsLayout.Columns.StoreAppearance = true;
            this.grdPortView.OptionsLayout.StoreAllOptions = true;
            this.grdPortView.OptionsLayout.StoreAppearance = true;
            this.grdPortView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdPortView.OptionsSelection.MultiSelect = true;
            this.grdPortView.OptionsView.EnableAppearanceOddRow = true;
            this.grdPortView.OptionsView.ShowAutoFilterRow = true;
            this.grdPortView.ViewCaption = "Tables";
            // 
            // pageLog
            // 
            this.pageLog.Controls.Add(this.txtTerminal);
            this.pageLog.Name = "pageLog";
            this.pageLog.Size = new System.Drawing.Size(1175, 652);
            this.pageLog.Text = "Terminal";
            // 
            // txtTerminal
            // 
            this.txtTerminal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTerminal.Location = new System.Drawing.Point(0, 0);
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtTerminal.Properties.Appearance.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminal.Properties.Appearance.ForeColor = System.Drawing.Color.Aqua;
            this.txtTerminal.Properties.Appearance.Options.UseBackColor = true;
            this.txtTerminal.Properties.Appearance.Options.UseFont = true;
            this.txtTerminal.Properties.Appearance.Options.UseForeColor = true;
            this.txtTerminal.Properties.ReadOnly = true;
            this.txtTerminal.Size = new System.Drawing.Size(1175, 652);
            this.txtTerminal.TabIndex = 11;
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menu1SelectALL),
            new DevExpress.XtraBars.LinkPersistInfo(this.menu2UnSelectALL),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.menu3Comment)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 200;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // FrmPageHuawei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.TabMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageHuawei";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmAlcatel";
            ((System.ComponentModel.ISupportInitialize)(this.TabMain)).EndInit();
            this.TabMain.ResumeLayout(false);
            this.pageReserv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReserv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReservView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReservLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpReservation)).EndInit();
            this.grpReservation.ResumeLayout(false);
            this.grpReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAVEA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNameV1.Properties)).EndInit();
            this.pagePort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConnection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSiteNameV2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPortView)).EndInit();
            this.pageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl TabMain;
        private DevExpress.XtraEditors.MemoEdit txtTerminal;
        private DevExpress.XtraTab.XtraTabPage pageLog;
        private DevExpress.XtraTab.XtraTabPage pageReserv;
        private DevExpress.XtraEditors.GroupControl grpReservation;
        private DevExpress.XtraEditors.SimpleButton btnReservCancel;
        private DevExpress.XtraEditors.SimpleButton btnReserv;
        private DevExpress.XtraEditors.SimpleButton btnRequestCancel;
        private DevExpress.XtraEditors.SimpleButton btnRequest;
        private DevExpress.XtraEditors.LabelControl lbStatus;
        private DevExpress.XtraEditors.ComboBoxEdit txtPortStatus;
        private DevExpress.XtraEditors.LabelControl lbSiteName;
        private DevExpress.XtraEditors.ComboBoxEdit txtSiteNameV1;
        private DevExpress.XtraEditors.SimpleButton btnRefreshPorts;
        private DevExpress.XtraEditors.SimpleButton btnReservClear;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraGrid.GridControl grdReserv;
        private DevExpress.XtraGrid.Views.Grid.GridView grdReservView;
        private DevExpress.XtraEditors.MemoEdit txtReservLog;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem menu1SelectALL;
        private DevExpress.XtraBars.BarButtonItem menu2UnSelectALL;
        private DevExpress.XtraBars.BarButtonItem menuLine;
        private DevExpress.XtraBars.BarButtonItem menu3Comment;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabPage pagePort;
        private DevExpress.XtraGrid.GridControl grdPort;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPortView;
        private DevExpress.XtraEditors.SimpleButton btnPorts;
        private DevExpress.XtraEditors.ComboBoxEdit txtSiteNameV2;
        private DevExpress.XtraEditors.SimpleButton btnPortsClear;
        private DevExpress.XtraEditors.SimpleButton btnReservList;
        private DevExpress.XtraEditors.PictureEdit picAVEA;
        private System.Windows.Forms.Timer MainTimer;
        private DevExpress.XtraEditors.ComboBoxEdit txtConnection;
        private DevExpress.XtraEditors.SimpleButton btnUpdateConnection;
        private DevExpress.XtraEditors.SimpleButton btnExport;

    }
}