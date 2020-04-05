namespace PortMan2014
{
    partial class FrmPageSetting
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
            this.grdAdmin = new DevExpress.XtraGrid.GridControl();
            this.grdAdminView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpAdmin = new DevExpress.XtraEditors.GroupControl();
            this.btnAdminUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdminDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdminInsert = new DevExpress.XtraEditors.SimpleButton();
            this.listAdminTables = new DevExpress.XtraEditors.ListBoxControl();
            this.pnGap = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdminView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).BeginInit();
            this.grpAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listAdminTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGap)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAdmin
            // 
            this.grdAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAdmin.Location = new System.Drawing.Point(10, 224);
            this.grdAdmin.MainView = this.grdAdminView;
            this.grdAdmin.Name = "grdAdmin";
            this.grdAdmin.Size = new System.Drawing.Size(880, 466);
            this.grdAdmin.TabIndex = 4;
            this.grdAdmin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdAdminView});
            // 
            // grdAdminView
            // 
            this.grdAdminView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdAdminView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdAdminView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdAdminView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdAdminView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdAdminView.Appearance.Row.Options.UseFont = true;
            this.grdAdminView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdAdminView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdAdminView.GridControl = this.grdAdmin;
            this.grdAdminView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdAdminView.Name = "grdAdminView";
            this.grdAdminView.OptionsBehavior.Editable = false;
            this.grdAdminView.OptionsBehavior.ReadOnly = true;
            this.grdAdminView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdAdminView.OptionsSelection.MultiSelect = true;
            this.grdAdminView.OptionsView.EnableAppearanceOddRow = true;
            this.grdAdminView.ViewCaption = "Tables";
            this.grdAdminView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdAdminView_KeyUp);
            this.grdAdminView.DoubleClick += new System.EventHandler(this.grdAdminView_DoubleClick);
            // 
            // grpAdmin
            // 
            this.grpAdmin.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpAdmin.AppearanceCaption.Options.UseFont = true;
            this.grpAdmin.AppearanceCaption.Options.UseTextOptions = true;
            this.grpAdmin.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grpAdmin.CaptionLocation = DevExpress.Utils.Locations.Left;
            this.grpAdmin.Controls.Add(this.btnAdminUpdate);
            this.grpAdmin.Controls.Add(this.btnAdminDelete);
            this.grpAdmin.Controls.Add(this.btnAdminInsert);
            this.grpAdmin.Controls.Add(this.listAdminTables);
            this.grpAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAdmin.Location = new System.Drawing.Point(10, 10);
            this.grpAdmin.Name = "grpAdmin";
            this.grpAdmin.Size = new System.Drawing.Size(880, 199);
            this.grpAdmin.TabIndex = 5;
            this.grpAdmin.Text = "Application  Settings";
            // 
            // btnAdminUpdate
            // 
            this.btnAdminUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdminUpdate.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdminUpdate.Appearance.Options.UseFont = true;
            this.btnAdminUpdate.Appearance.Options.UseForeColor = true;
            this.btnAdminUpdate.Location = new System.Drawing.Point(315, 40);
            this.btnAdminUpdate.LookAndFeel.SkinName = "Sharp";
            this.btnAdminUpdate.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdminUpdate.Name = "btnAdminUpdate";
            this.btnAdminUpdate.Size = new System.Drawing.Size(110, 30);
            this.btnAdminUpdate.TabIndex = 27;
            this.btnAdminUpdate.Tag = "ActionButton";
            this.btnAdminUpdate.Text = "Update";
            this.btnAdminUpdate.ToolTip = "Ctrl + Enter";
            this.btnAdminUpdate.Click += new System.EventHandler(this.btnAdminUpdate_Click);
            // 
            // btnAdminDelete
            // 
            this.btnAdminDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdminDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdminDelete.Appearance.Options.UseFont = true;
            this.btnAdminDelete.Appearance.Options.UseForeColor = true;
            this.btnAdminDelete.Location = new System.Drawing.Point(315, 131);
            this.btnAdminDelete.LookAndFeel.SkinName = "Sharp";
            this.btnAdminDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdminDelete.Name = "btnAdminDelete";
            this.btnAdminDelete.Size = new System.Drawing.Size(110, 30);
            this.btnAdminDelete.TabIndex = 26;
            this.btnAdminDelete.Tag = "ActionButton";
            this.btnAdminDelete.Text = "Delete";
            this.btnAdminDelete.ToolTip = "Ctrl + Delete";
            this.btnAdminDelete.Click += new System.EventHandler(this.btnAdminDelete_Click);
            // 
            // btnAdminInsert
            // 
            this.btnAdminInsert.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdminInsert.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdminInsert.Appearance.Options.UseFont = true;
            this.btnAdminInsert.Appearance.Options.UseForeColor = true;
            this.btnAdminInsert.Location = new System.Drawing.Point(315, 86);
            this.btnAdminInsert.LookAndFeel.SkinName = "Sharp";
            this.btnAdminInsert.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdminInsert.Name = "btnAdminInsert";
            this.btnAdminInsert.Size = new System.Drawing.Size(110, 30);
            this.btnAdminInsert.TabIndex = 25;
            this.btnAdminInsert.Tag = "ActionButton";
            this.btnAdminInsert.Text = "Insert";
            this.btnAdminInsert.ToolTip = "Ctrl + Insert";
            this.btnAdminInsert.Click += new System.EventHandler(this.btnAdminInsert_Click);
            // 
            // listAdminTables
            // 
            this.listAdminTables.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listAdminTables.Appearance.Options.UseFont = true;
            this.listAdminTables.Items.AddRange(new object[] {
            " ( 1 )  -  USERS",
            " ( 2 )  -  SUBNET"});
            this.listAdminTables.Location = new System.Drawing.Point(57, 39);
            this.listAdminTables.Name = "listAdminTables";
            this.listAdminTables.Size = new System.Drawing.Size(229, 124);
            this.listAdminTables.TabIndex = 0;
            this.listAdminTables.SelectedIndexChanged += new System.EventHandler(this.listAdminTables_SelectedIndexChanged);
            // 
            // pnGap
            // 
            this.pnGap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnGap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnGap.Location = new System.Drawing.Point(10, 209);
            this.pnGap.Name = "pnGap";
            this.pnGap.Size = new System.Drawing.Size(880, 15);
            this.pnGap.TabIndex = 13;
            // 
            // FrmPageSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.grdAdmin);
            this.Controls.Add(this.pnGap);
            this.Controls.Add(this.grpAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageSetting";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.grdAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAdminView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdmin)).EndInit();
            this.grpAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listAdminTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnGap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAdmin;
        private DevExpress.XtraGrid.Views.Grid.GridView grdAdminView;
        private DevExpress.XtraEditors.GroupControl grpAdmin;
        private DevExpress.XtraEditors.SimpleButton btnAdminUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdminDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdminInsert;
        private DevExpress.XtraEditors.ListBoxControl listAdminTables;
        private DevExpress.XtraEditors.PanelControl pnGap;


    }
}