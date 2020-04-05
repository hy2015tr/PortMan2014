namespace PortMan2014
{
    partial class FrmPageImport
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
            this.grdDAT = new DevExpress.XtraGrid.GridControl();
            this.grdDATView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpAdmin = new DevExpress.XtraEditors.GroupControl();
            this.lbRouterType = new DevExpress.XtraEditors.LabelControl();
            this.radioRouter = new DevExpress.XtraEditors.RadioGroup();
            this.btnFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.lbFileName = new DevExpress.XtraEditors.LabelControl();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageLog = new DevExpress.XtraTab.XtraTabPage();
            this.grdLOG = new DevExpress.XtraGrid.GridControl();
            this.grdLOGView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pageData = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.grdDAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDATView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).BeginInit();
            this.grpAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioRouter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLOGView)).BeginInit();
            this.pageData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDAT
            // 
            this.grdDAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDAT.Location = new System.Drawing.Point(0, 0);
            this.grdDAT.MainView = this.grdDATView;
            this.grdDAT.Name = "grdDAT";
            this.grdDAT.Size = new System.Drawing.Size(872, 441);
            this.grdDAT.TabIndex = 4;
            this.grdDAT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDATView});
            // 
            // grdDATView
            // 
            this.grdDATView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdDATView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdDATView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdDATView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdDATView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdDATView.Appearance.Row.Options.UseFont = true;
            this.grdDATView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdDATView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdDATView.GridControl = this.grdDAT;
            this.grdDATView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdDATView.Name = "grdDATView";
            this.grdDATView.OptionsBehavior.Editable = false;
            this.grdDATView.OptionsBehavior.ReadOnly = true;
            this.grdDATView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdDATView.OptionsSelection.MultiSelect = true;
            this.grdDATView.OptionsView.EnableAppearanceOddRow = true;
            this.grdDATView.OptionsView.ShowAutoFilterRow = true;
            this.grdDATView.ViewCaption = "Tables";
            // 
            // grpAdmin
            // 
            this.grpAdmin.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpAdmin.AppearanceCaption.Options.UseFont = true;
            this.grpAdmin.AppearanceCaption.Options.UseTextOptions = true;
            this.grpAdmin.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpAdmin.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpAdmin.Controls.Add(this.lbRouterType);
            this.grpAdmin.Controls.Add(this.radioRouter);
            this.grpAdmin.Controls.Add(this.btnFile);
            this.grpAdmin.Controls.Add(this.btnClear);
            this.grpAdmin.Controls.Add(this.btnRun);
            this.grpAdmin.Controls.Add(this.txtFileName);
            this.grpAdmin.Controls.Add(this.lbFileName);
            this.grpAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAdmin.Location = new System.Drawing.Point(10, 10);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(880, 206);
            this.grpAdmin.TabIndex = 5;
            this.grpAdmin.Text = "Parameters";
            // 
            // lbRouterType
            // 
            this.lbRouterType.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbRouterType.Location = new System.Drawing.Point(44, 113);
            this.lbRouterType.Name = "lbRouterType";
            this.lbRouterType.Size = new System.Drawing.Size(84, 14);
            this.lbRouterType.TabIndex = 31;
            this.lbRouterType.Text = "Router Type :";
            // 
            // radioRouter
            // 
            this.radioRouter.Location = new System.Drawing.Point(137, 71);
            this.radioRouter.Name = "radioRouter";
            this.radioRouter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioRouter.Properties.Appearance.Options.UseFont = true;
            this.radioRouter.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CISCO", "  CISCO Routers"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("HUAWEI", "  HUAWEI Routers"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("ALCATEL", "  ALCATEL Routers")});
            this.radioRouter.Properties.LookAndFeel.SkinName = "McSkin";
            this.radioRouter.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioRouter.Size = new System.Drawing.Size(163, 94);
            this.radioRouter.TabIndex = 30;
            // 
            // btnFile
            // 
            this.btnFile.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFile.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnFile.Appearance.Options.UseFont = true;
            this.btnFile.Appearance.Options.UseForeColor = true;
            this.btnFile.Location = new System.Drawing.Point(314, 71);
            this.btnFile.LookAndFeel.SkinName = "Glass Oceans";
            this.btnFile.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(146, 54);
            this.btnFile.TabIndex = 29;
            this.btnFile.TabStop = false;
            this.btnFile.Tag = "ActionButton";
            this.btnFile.Text = "( 1 )  FILE";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.Location = new System.Drawing.Point(314, 131);
            this.btnClear.LookAndFeel.SkinName = "Sharp";
            this.btnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(146, 34);
            this.btnClear.TabIndex = 28;
            this.btnClear.TabStop = false;
            this.btnClear.Tag = "";
            this.btnClear.Text = "( 3 )  Clear";
            this.btnClear.ToolTip = "Ctrl + Enter";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRun
            // 
            this.btnRun.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRun.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRun.Appearance.Options.UseFont = true;
            this.btnRun.Appearance.Options.UseForeColor = true;
            this.btnRun.Location = new System.Drawing.Point(466, 71);
            this.btnRun.LookAndFeel.SkinName = "Glass Oceans";
            this.btnRun.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(111, 94);
            this.btnRun.TabIndex = 27;
            this.btnRun.TabStop = false;
            this.btnRun.Tag = "ActionButton";
            this.btnRun.Text = "RUN\r\n\r\n( 2 )";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.EditValue = "";
            this.txtFileName.Location = new System.Drawing.Point(137, 35);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtFileName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFileName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Properties.Appearance.Options.UseBackColor = true;
            this.txtFileName.Properties.Appearance.Options.UseFont = true;
            this.txtFileName.Properties.Appearance.Options.UseForeColor = true;
            this.txtFileName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtFileName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFileName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFileName.Properties.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(710, 20);
            this.txtFileName.TabIndex = 25;
            // 
            // lbFileName
            // 
            this.lbFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFileName.Location = new System.Drawing.Point(67, 38);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(61, 14);
            this.lbFileName.TabIndex = 26;
            this.lbFileName.Text = "Excel File :";
            // 
            // tabMain
            // 
            this.tabMain.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabMain.AppearancePage.Header.Options.UseFont = true;
            this.tabMain.AppearancePage.Header.Options.UseTextOptions = true;
            this.tabMain.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(10, 216);
            this.tabMain.LookAndFeel.SkinName = "McSkin";
            this.tabMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabMain.MultiLine = DevExpress.Utils.DefaultBoolean.False;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.pageLog;
            this.tabMain.Size = new System.Drawing.Size(880, 474);
            this.tabMain.TabIndex = 41;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageData,
            this.pageLog});
            this.tabMain.TabPageWidth = 300;
            // 
            // pageLog
            // 
            this.pageLog.Controls.Add(this.grdLOG);
            this.pageLog.Name = "pageLog";
            this.pageLog.Size = new System.Drawing.Size(872, 441);
            this.pageLog.Text = "Log";
            // 
            // grdLOG
            // 
            this.grdLOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLOG.Location = new System.Drawing.Point(0, 0);
            this.grdLOG.MainView = this.grdLOGView;
            this.grdLOG.Name = "grdLOG";
            this.grdLOG.Size = new System.Drawing.Size(872, 441);
            this.grdLOG.TabIndex = 5;
            this.grdLOG.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLOGView});
            // 
            // grdLOGView
            // 
            this.grdLOGView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdLOGView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdLOGView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdLOGView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdLOGView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdLOGView.Appearance.Row.Options.UseFont = true;
            this.grdLOGView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdLOGView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdLOGView.GridControl = this.grdLOG;
            this.grdLOGView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdLOGView.Name = "grdLOGView";
            this.grdLOGView.OptionsBehavior.Editable = false;
            this.grdLOGView.OptionsBehavior.ReadOnly = true;
            this.grdLOGView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdLOGView.OptionsSelection.MultiSelect = true;
            this.grdLOGView.OptionsView.EnableAppearanceOddRow = true;
            this.grdLOGView.ViewCaption = "Tables";
            // 
            // pageData
            // 
            this.pageData.Controls.Add(this.grdDAT);
            this.pageData.ImageIndex = 3;
            this.pageData.Name = "pageData";
            this.pageData.Size = new System.Drawing.Size(872, 441);
            this.pageData.Text = "Data";
            // 
            // FrmPageImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.grpAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageImport";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "FrmAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.grdDAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDATView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).EndInit();
            this.grpAdmin.ResumeLayout(false);
            this.grpAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioRouter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLOGView)).EndInit();
            this.pageData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDAT;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDATView;
        private DevExpress.XtraEditors.GroupControl grpAdmin;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.LabelControl lbFileName;
        private DevExpress.XtraEditors.SimpleButton btnFile;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnRun;
        public DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraTab.XtraTabPage pageLog;
        private DevExpress.XtraTab.XtraTabPage pageData;
        private DevExpress.XtraGrid.GridControl grdLOG;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLOGView;
        private DevExpress.XtraEditors.LabelControl lbRouterType;
        private DevExpress.XtraEditors.RadioGroup radioRouter;


    }
}