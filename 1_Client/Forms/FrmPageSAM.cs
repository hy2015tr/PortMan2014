using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using Rebex.TerminalEmulation;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace PortMan2014
{
    public partial class FrmPageSAM : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageSAM()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnClearRun_Click(null, null);
            this.btnReservClear_Click(null, null);
            this.menu3Comment_ItemClick(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh
            this.Refresh_Process();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private async void Refresh_Process()
        {
            try
            {
                // Log
                alfaLog.Clear();

                // Start Process
                alfaNET.Start(MainTimer, alfaNET.FrmMain.pageSAM);

                // Log
                alfaLog.Add("[ START ]");

                // Disable Controls
                grpSelection.Enabled = false;

                // Reset Grids
                grdResult01.DataSource = null;
                grdResult01View.Columns.Clear();

                //=========== QUERY_01 ===========//

                // Call Service
                string p_FileName01 = await alfaNET.Alcatel_PortData01();

                // Get FileName
                var p_AlfaItem01 = alfaNET.Alcatel_Step02_FTP_GetFileNames().Where(tt => tt.Name.StartsWith(p_FileName01)).Single();

                // Download File
                var p_LocalFile01 = await alfaNET.Alcatel_Step03_FTP_DownloadFile(p_AlfaItem01.Name);

                // Process File
                var p_ResultDS01 = await alfaNET.Alcatel_Step04_ProcessFile(p_LocalFile01);
                
                //=========== QUERY_02 ===========//

                // Call Service
                string p_FileName02 = await alfaNET.Alcatel_PortData02();

                // Get FileName
                var p_AlfaItem02 = alfaNET.Alcatel_Step02_FTP_GetFileNames().Where(tt => tt.Name.StartsWith(p_FileName02)).Single();

                // Download File
                var p_LocalFile02 = await alfaNET.Alcatel_Step03_FTP_DownloadFile(p_AlfaItem02.Name);

                // Process File
                var p_ResultDS02 = await alfaNET.Alcatel_Step04_ProcessFile(p_LocalFile02);

                //=========== RESULT ===========//

                var p_ResultList01 = await alfaNET.Alcatel_MergeResult(p_ResultDS01.Tables[1], p_ResultDS02.Tables[0]);
                var p_ResultList02 = await alfaNET.Alcatel_SaveResult(p_ResultList01);

                // SetView
                alfaGrid.SetView(grdResult01View, p_ResultDS01.Tables[1], true);
                alfaGrid.SetView(grdResult02View, p_ResultDS02.Tables[0], true);
                alfaGrid.SetView(grdResult03View, p_ResultList02, true);

                // Log
                alfaLog.Add("[ FINISH ]");

                // Set Page
                TabMain.SelectedTabPage = page03;
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }

            finally
            {
                // Stop Process
                alfaNET.Stop();

                // Enable Controls
                grpSelection.Enabled = true;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnListFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // Cursor
                alfaMsg.CursorWait();

                // Start Process
                alfaNET.Start(MainTimer, alfaNET.FrmMain.pageSAM);

                // Clear Items
                lbOutputFiles.Items.Clear();

                // Get FileNames
                List<alfaItem> p_ItemList = alfaNET.Alcatel_Step02_FTP_GetFileNames();

                // Add to List
                lbOutputFiles.Items.AddRange(p_ItemList.ToArray());

                // Set Last Item
                if (lbOutputFiles.Items.Count > 0) lbOutputFiles.SelectedIndex = lbOutputFiles.Items.Count - 1;

                // Status
                alfaNET.Status_OK();
            }

            catch (Exception ex)
            {
                // Status
                alfaNET.Status_ERROR(ex.Message);
            }

            finally
            {
                // Stop
                alfaNET.Stop();

                // Cursor
                alfaMsg.CursorDefult();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnDeleteFiles_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear Items
                lbOutputFiles.Items.Clear();

                // Delete Files
                alfaNET.Alcatel_FTP_DeleteFiles();

                // Status
                alfaNET.Status_OK();
            }

            catch (Exception ex)
            {
                // Status
                alfaNET.Status_ERROR(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClearRun_Click(object sender, EventArgs e)
        {
            // Reset Logs
            alfaLog.Clear();
            this.txtLog.Text = string.Empty;

            // Reset Grids
            grdResult01.DataSource = null;
            grdResult02.DataSource = null;
            grdResult03.DataSource = null;
            grdResult01View.Columns.Clear();
            grdResult02View.Columns.Clear();
            grdResult03View.Columns.Clear();

            // Clear Items
            lbOutputFiles.Items.Clear();

            // Reset Status
            alfaNET.Status_OK();

            // Focus
            grpSelection.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // Set LogText
            this.txtLog.Text = alfaLog.LogText;
            
            // Status
            alfaNET.Status_RUNNING();

            // Get Values
            int p_Value = Convert.ToInt32(alfaNET.FrmMain.statusProgress.EditValue);

            // Increase Value
            p_Value = p_Value + 10;

            // Take Mode
            p_Value = p_Value % 100;

            // Set Value
            alfaNET.FrmMain.statusProgress.EditValue = p_Value;

            if (!alfaNET.IsRunning)
            {
                // Stop Timer
                this.MainTimer.Stop();

                // ProgressBar
                alfaNET.FrmMain.statusProgress.EditValue = 100;

                // Finish
                alfaNET.Status_OK();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdResult03View_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // GridView
            GridView p_GridView = sender as GridView;

            // Check
            if (e.RowHandle < 0) return;

            // Check Focused Row
            if (e.RowHandle == p_GridView.FocusedRowHandle) return;

            // Get Check Value
            bool p_Check = Convert.ToBoolean(grdReservView.GetRowCellValue(e.RowHandle, "Check"));

            // Check Value
            if (p_Check) return;

            if ("Status".Contains(e.Column.FieldName))
            {
                // Get Text
                string p_CellValue = p_GridView.GetRowCellDisplayText(e.RowHandle, p_GridView.Columns[e.Column.FieldName]);

                // Set Fonts
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);

                // Set Color
                     if (p_CellValue == alfaStr.FREE) e.Appearance.BackColor = Color.Green;
                else if (p_CellValue == alfaStr.USED) e.Appearance.BackColor = Color.RoyalBlue;
                else if (p_CellValue == alfaStr.ERROR) e.Appearance.BackColor = Color.Red;
                else if (p_CellValue == alfaStr.REQUEST) e.Appearance.BackColor = Color.Brown;
                else if (p_CellValue == alfaStr.RESERVED) e.Appearance.BackColor = Color.LimeGreen;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnFinalList_Click(object sender, EventArgs e)
        {
            // Get List
            var p_Result = alfaEntity.TablePortAlcatel_GetList();

            // Set View
            alfaGrid.SetView( grdResult03View, p_Result, true);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnFinalClear_Click(object sender, EventArgs e)
        {
            // Reset Grid
            grdResult03.DataSource = null;
            grdResult03View.Columns.Clear();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservClear_Click(object sender, EventArgs e)
        {
            // Fill Values
            alfaEntity.Fill_ComboBox_Field(txtSiteName, true, "TablePortAlcatel", "SiteName");

            // Reset Values
            txtReservStatus.SelectedIndex = 0;
            txtSiteName.SelectedIndex = 0;

            // Clear Grid
            grdReserv.DataSource = null;
            grdReservView.Columns.Clear();

            // Set Button
            alfaCtrl.SetButton(btnRequestCancel, false);
            alfaCtrl.SetButton(btnReservCancel, false);
            alfaCtrl.SetButton(btnRequest, false);
            alfaCtrl.SetButton(btnReserv, false);
            alfaCtrl.SetButton(btnExport, false);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservList_Click(object sender, EventArgs e)
        {
            // GetList
            var p_Result = alfaEntity.TablePortAlcatel_GetList(txtSiteName.Text, txtReservStatus.Text);

            // SetView
            alfaGrid.SetView(grdReservView, (object)p_Result, false);

            // Hide Columns
            alfaGrid.ColumnHide(grdReservView, "SnmpPortId");

            // Set Button            
            alfaCtrl.SetButton(btnExport, grdReservView.RowCount > 0);
            alfaCtrl.SetButton(btnRequest, grdReservView.RowCount > 0 && txtReservStatus.Text == alfaStr.FREE);
            alfaCtrl.SetButton(btnRequestCancel, grdReservView.RowCount > 0 && txtReservStatus.Text == alfaStr.REQUEST);
            alfaCtrl.SetButton(btnReserv, grdReservView.RowCount > 0 && txtReservStatus.Text == alfaStr.REQUEST && alfaSession.Group == alfaStr.GroupDesign);
            alfaCtrl.SetButton(btnReservCancel, grdReservView.RowCount > 0 && txtReservStatus.Text == alfaStr.RESERVED && alfaSession.Group == alfaStr.GroupDesign);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRequest_Click(object sender, EventArgs e)
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Request the Selected Ports ?") != DialogResult.Yes) return;

            // Get DataSource
            var p_List = (List<PortAlcatel>)grdReserv.DataSource;

            // Get only Checked and Free
            p_List = p_List.Where(tt=> tt.Check == true && tt.Status == alfaStr.FREE).ToList();

            foreach (var p_Port in p_List)
            {
                // Reserve Port
                alfaEntity.TablePortAlcatel_Update(p_Port, alfaStr.REQUEST);
            }

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRequestCancel_Click(object sender, EventArgs e)
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Rollback the Requested Ports ?") != DialogResult.Yes) return;

            // Get DataSource
            var p_List = (List<PortAlcatel>)grdReserv.DataSource;

            // Get only Checked and Reserved
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.REQUEST).ToList();

            foreach (var p_Port in p_List)
            {
                // Reset Description
                p_Port.ReservDescription = string.Empty;

                // Reserve Port
                alfaEntity.TablePortAlcatel_Update(p_Port, alfaStr.FREE);
            }

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReserv_Click(object sender, EventArgs e)
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Reserve the Selected Ports ?") != DialogResult.Yes) return;

            // Cursor
            alfaMsg.CursorWait();

            // DataSource
            var p_List = (List<PortAlcatel>)grdReserv.DataSource;

            // Get only Checked and Reserved
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.REQUEST).ToList();

            // Ssh Client
            using (var p_Rebex = new Rebex.Net.Ssh())
            {
                // Connect
                p_Rebex.Connect("10.19.43.72");

                // Login
                p_Rebex.Login("pbndata", "Formula12");

                // Scripting
                var p_Script = p_Rebex.StartScripting();

                // Prompt
                p_Script.DetectPrompt();

                foreach (var p_Port in p_List)
                {
                    // Router Login 
                    alfaNET.Alcatel_RouterLogin(p_Script, p_Port.SiteId);

                    // Router Update
                    alfaNET.Alcatel_RouterUpdate(p_Script, p_Port.DisplayedName, p_Port.ReservDescription);
                    {
                        // Update Status
                        alfaEntity.TablePortAlcatel_Update(p_Port, alfaStr.RESERVED);
                    }

                    // Router Logout
                    alfaNET.Alcatel_RouterLogout(p_Script);
                }

                // Disconnect
                p_Rebex.Disconnect();
            }

            // Cursor
            alfaMsg.CursorDefult();

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservCancel_Click(object sender, EventArgs e)
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Rollback the Selected Ports ?") != DialogResult.Yes) return;

            // DataSource
            var p_List = (List<PortAlcatel>)grdReserv.DataSource;

            // Get only Checked and Reserved
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.RESERVED).ToList();

            // Ssh Client
            var p_Rebex = new Rebex.Net.Ssh();

            // Connect
            p_Rebex.Connect("10.19.43.72");

            // Login
            p_Rebex.Login("pbndata", "Formula12");

            // Scripting
            var p_Script = p_Rebex.StartScripting();

            // Prompt
            p_Script.DetectPrompt();

            foreach (var p_Port in p_List)
            {
                // Router Login 
                alfaNET.Alcatel_RouterLogin(p_Script, p_Port.SiteId);

                // Router Update
                if (alfaNET.Alcatel_RouterUpdate(p_Script, p_Port.DisplayedName, p_Port.Description))
                {
                    // Reset Desc
                    p_Port.ReservDescription = string.Empty;

                    // Update Status
                    alfaEntity.TablePortAlcatel_Update(p_Port, alfaStr.FREE);
                }

                // Router Logout
                alfaNET.Alcatel_RouterLogout(p_Script);
            }

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menu1SelectALL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Select ALL
            this.SelectItems(true);
        }

       //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menu2UnSelectALL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // UnSelect ALL
            this.SelectItems(false);
        }

       //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menu3Comment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Hide <---> Show
            if (menu3Comment.Caption.Contains("Hide"))
            {
                splitContainerControl.SplitterPosition = 0;
                menu3Comment.Caption = menu3Comment.Caption.Replace("Hide", "Show");
            }
            else
            {
                splitContainerControl.SplitterPosition = 600;
                menu3Comment.Caption = menu3Comment.Caption.Replace("Show", "Hide");
            }
        }

       //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void SelectItems(bool p_Status)
        {
            for (int li = 0; li < this.grdReservView.RowCount; li++)
            {
                // Get Value
                var strValue = (string)grdReservView.GetRowCellValue(li, "Status");

                if (strValue != alfaStr.USED)
                {
                    this.grdReservView.SetRowCellValue(li, "Check", p_Status);
                }
            }

            // Refresh
            this.grdReservView.RefreshEditor(true);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdALLView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check for Empty Records
                if (grdReservView.DataRowCount == 0) return;

                // Get HitInfo
                GridHitInfo hitInfo = this.grdReservView.CalcHitInfo(e.Location);

                if (hitInfo.InRow)
                {
                    // Popup Menu
                    popupMenu.ShowPopup(Control.MousePosition);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdReservView_ShowingEditor(object sender, CancelEventArgs e)
        {
            // Get Status
            var p_Status = Convert.ToString(grdReservView.GetRowCellValue(grdReservView.FocusedRowHandle, "Status"));

            // Check Used Values
            if ( p_Status == alfaStr.USED) e.Cancel = true;

            // Enable Edit for "Check"
            else if (grdReservView.FocusedColumn.FieldName == "Check")
            {
                // Enable
                e.Cancel = false;
            }

            // Enable Edit for "ReservDescription"
            else if (grdReservView.FocusedColumn.FieldName == "ReservDescription")
            {
                // Get Check
                var p_Check = Convert.ToBoolean(grdReservView.GetRowCellValue(grdReservView.FocusedRowHandle, "Check"));

                // Enable
                if (p_Check) e.Cancel = false; else e.Cancel = true;
            }

            // else
            else e.Cancel = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdReservView_RowStyle(object sender, RowStyleEventArgs e)
        {
            // Check
            if (e.RowHandle < 0) return;

            // HighPriority
            e.HighPriority = true;

            // Get Check
            bool p_Check = Convert.ToBoolean(grdReservView.GetRowCellValue(e.RowHandle, "Check"));

            if (p_Check == true)
            {
                // Selected Item
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.DarkRed;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Regular);
            }

            else if (e.RowHandle == grdReservView.FocusedRowHandle)
            {
                // Focused Item
                e.Appearance.ForeColor = Color.White;
                e.Appearance.BackColor = Color.Blue;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);
            }

            else if ((string)grdReservView.GetRowCellValue(e.RowHandle, "Status") != "USED")
            {
                // NULL
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void FrmPageAlcatel_SetButtons()
        {
            // Set Pages
            page00.PageVisible = (alfaSession.Group == alfaStr.GroupDesign);
            page01.PageVisible = (alfaSession.Group == alfaStr.GroupDesign);
            page02.PageVisible = (alfaSession.Group == alfaStr.GroupDesign);
            page03.PageVisible = (alfaSession.Group == alfaStr.GroupDesign);

            // Set Buttons
            alfaCtrl.SetButton(btnRefresh, alfaSession.Group == alfaStr.GroupDesign);
            alfaCtrl.SetButton(btnListFiles, alfaSession.Group == alfaStr.GroupDesign);
            alfaCtrl.SetButton(btnDeleteFiles, alfaSession.Group == alfaStr.GroupDesign);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdReservView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                // Get ID
                int p_ID = Convert.ToInt32(grdReservView.GetRowCellValue(e.FocusedRowHandle, "ID"));

                // Set Log
                txtReservLog.Text = alfaEntity.GetRequestLog_V1(p_ID);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnExport_Click(object sender, EventArgs e)
        {
            // SaveDialog
            SaveFileDialog sf = new SaveFileDialog();

            // Set Properties
            sf.Filter = "XLS Files (*.xls)|*.xls";
 
            // Check for Cancel
            if (sf.ShowDialog() != DialogResult.OK) return;

            // Update UI
            this.Update();

            // Auto Width
            grdReservView.OptionsPrint.AutoWidth = false;

            // Export to Target
            grdReservView.ExportToXls(sf.FileName);

            // Result Message
            alfaMsg.Info("Exporting List is Successfully Done ... !");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}