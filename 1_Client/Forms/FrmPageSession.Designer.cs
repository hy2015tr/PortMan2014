namespace PortMan2014
{
    partial class FrmPageSession
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
            this.grdSession = new DevExpress.XtraGrid.GridControl();
            this.grdSessionView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpSession = new DevExpress.XtraEditors.GroupControl();
            this.btnSessionList = new DevExpress.XtraEditors.SimpleButton();
            this.txtSession02 = new DevExpress.XtraEditors.DateEdit();
            this.txtSession01 = new DevExpress.XtraEditors.DateEdit();
            this.lbSessionFinish = new DevExpress.XtraEditors.LabelControl();
            this.lbSessionStart = new DevExpress.XtraEditors.LabelControl();
            this.btnSessionClear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSessionView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSession)).BeginInit();
            this.grpSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession02.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession02.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession01.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession01.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSession
            // 
            this.grdSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSession.Location = new System.Drawing.Point(10, 191);
            this.grdSession.MainView = this.grdSessionView;
            this.grdSession.Name = "grdSession";
            this.grdSession.Size = new System.Drawing.Size(984, 415);
            this.grdSession.TabIndex = 14;
            this.grdSession.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSessionView});
            // 
            // grdSessionView
            // 
            this.grdSessionView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdSessionView.Appearance.FooterPanel.Options.UseFont = true;
            this.grdSessionView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdSessionView.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdSessionView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdSessionView.Appearance.Row.Options.UseFont = true;
            this.grdSessionView.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grdSessionView.Appearance.ViewCaption.Options.UseFont = true;
            this.grdSessionView.GridControl = this.grdSession;
            this.grdSessionView.GroupPanelText = "NOTE :  Use This Section for Field Grouping.";
            this.grdSessionView.Name = "grdSessionView";
            this.grdSessionView.OptionsBehavior.Editable = false;
            this.grdSessionView.OptionsBehavior.ReadOnly = true;
            this.grdSessionView.OptionsLayout.Columns.RemoveOldColumns = false;
            this.grdSessionView.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdSessionView.OptionsLayout.Columns.StoreAppearance = true;
            this.grdSessionView.OptionsLayout.StoreAllOptions = true;
            this.grdSessionView.OptionsLayout.StoreAppearance = true;
            this.grdSessionView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdSessionView.OptionsSelection.MultiSelect = true;
            this.grdSessionView.OptionsView.EnableAppearanceOddRow = true;
            this.grdSessionView.OptionsView.ShowAutoFilterRow = true;
            this.grdSessionView.ViewCaption = "Tables";
            this.grdSessionView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdSessionView_RowCellStyle);
            this.grdSessionView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdSessionView_RowStyle);
            // 
            // grpSession
            // 
            this.grpSession.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSession.AppearanceCaption.Options.UseFont = true;
            this.grpSession.Controls.Add(this.btnSessionList);
            this.grpSession.Controls.Add(this.txtSession02);
            this.grpSession.Controls.Add(this.txtSession01);
            this.grpSession.Controls.Add(this.lbSessionFinish);
            this.grpSession.Controls.Add(this.lbSessionStart);
            this.grpSession.Controls.Add(this.btnSessionClear);
            this.grpSession.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSession.Location = new System.Drawing.Point(10, 10);
            this.grpSession.Name = "grpSession";
            this.grpSession.Size = new System.Drawing.Size(984, 181);
            this.grpSession.TabIndex = 13;
            this.grpSession.Text = "Selection Parameters";
            // 
            // btnSessionList
            // 
            this.btnSessionList.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSessionList.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSessionList.Appearance.Options.UseFont = true;
            this.btnSessionList.Appearance.Options.UseForeColor = true;
            this.btnSessionList.Location = new System.Drawing.Point(340, 50);
            this.btnSessionList.LookAndFeel.SkinName = "Glass Oceans";
            this.btnSessionList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSessionList.Name = "btnSessionList";
            this.btnSessionList.Size = new System.Drawing.Size(110, 50);
            this.btnSessionList.TabIndex = 4;
            this.btnSessionList.Tag = "ActionButton";
            this.btnSessionList.Text = "List";
            this.btnSessionList.Click += new System.EventHandler(this.btnSessionList_Click);
            // 
            // txtSession02
            // 
            this.txtSession02.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.txtSession02.Location = new System.Drawing.Point(104, 123);
            this.txtSession02.Name = "txtSession02";
            this.txtSession02.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSession02.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSession02.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtSession02.Properties.Appearance.Options.UseBackColor = true;
            this.txtSession02.Properties.Appearance.Options.UseFont = true;
            this.txtSession02.Properties.Appearance.Options.UseForeColor = true;
            this.txtSession02.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtSession02.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSession02.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSession02.Properties.DisplayFormat.FormatString = "G";
            this.txtSession02.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSession02.Properties.EditFormat.FormatString = "G";
            this.txtSession02.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSession02.Properties.Mask.EditMask = "G";
            this.txtSession02.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSession02.Size = new System.Drawing.Size(197, 20);
            this.txtSession02.TabIndex = 1;
            // 
            // txtSession01
            // 
            this.txtSession01.EditValue = new System.DateTime(2012, 9, 28, 17, 1, 16, 88);
            this.txtSession01.Location = new System.Drawing.Point(104, 51);
            this.txtSession01.Name = "txtSession01";
            this.txtSession01.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtSession01.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSession01.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtSession01.Properties.Appearance.Options.UseBackColor = true;
            this.txtSession01.Properties.Appearance.Options.UseFont = true;
            this.txtSession01.Properties.Appearance.Options.UseForeColor = true;
            this.txtSession01.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Yellow;
            this.txtSession01.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtSession01.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSession01.Properties.DisplayFormat.FormatString = "G";
            this.txtSession01.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSession01.Properties.EditFormat.FormatString = "G";
            this.txtSession01.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtSession01.Properties.Mask.EditMask = "G";
            this.txtSession01.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSession01.Size = new System.Drawing.Size(197, 20);
            this.txtSession01.TabIndex = 0;
            // 
            // lbSessionFinish
            // 
            this.lbSessionFinish.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSessionFinish.Location = new System.Drawing.Point(42, 129);
            this.lbSessionFinish.Name = "lbSessionFinish";
            this.lbSessionFinish.Size = new System.Drawing.Size(42, 14);
            this.lbSessionFinish.TabIndex = 38;
            this.lbSessionFinish.Text = "Finish :";
            // 
            // lbSessionStart
            // 
            this.lbSessionStart.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSessionStart.Location = new System.Drawing.Point(44, 54);
            this.lbSessionStart.Name = "lbSessionStart";
            this.lbSessionStart.Size = new System.Drawing.Size(40, 14);
            this.lbSessionStart.TabIndex = 37;
            this.lbSessionStart.Text = "Start :";
            // 
            // btnSessionClear
            // 
            this.btnSessionClear.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSessionClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSessionClear.Appearance.Options.UseFont = true;
            this.btnSessionClear.Appearance.Options.UseForeColor = true;
            this.btnSessionClear.Location = new System.Drawing.Point(340, 111);
            this.btnSessionClear.LookAndFeel.SkinName = "Sharp";
            this.btnSessionClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSessionClear.Name = "btnSessionClear";
            this.btnSessionClear.Size = new System.Drawing.Size(110, 32);
            this.btnSessionClear.TabIndex = 5;
            this.btnSessionClear.Text = "Clear";
            this.btnSessionClear.Click += new System.EventHandler(this.btnSessionClear_Click);
            // 
            // FrmPageSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 616);
            this.Controls.Add(this.grdSession);
            this.Controls.Add(this.grpSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPageSession";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmAlcatel";
            ((System.ComponentModel.ISupportInitialize)(this.grdSession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSessionView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSession)).EndInit();
            this.grpSession.ResumeLayout(false);
            this.grpSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession02.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession02.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession01.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSession01.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSession;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSessionView;
        private DevExpress.XtraEditors.GroupControl grpSession;
        private DevExpress.XtraEditors.SimpleButton btnSessionList;
        private DevExpress.XtraEditors.DateEdit txtSession02;
        private DevExpress.XtraEditors.DateEdit txtSession01;
        private DevExpress.XtraEditors.LabelControl lbSessionFinish;
        private DevExpress.XtraEditors.LabelControl lbSessionStart;
        private DevExpress.XtraEditors.SimpleButton btnSessionClear;

    }
}