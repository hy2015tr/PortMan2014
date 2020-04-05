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
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace PortMan2014
{
    public partial class FrmPageHuawei : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageHuawei()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Reset
            this.btnPortsClear_Click(null, null);
            this.btnReservClear_Click(null, null);
            this.menu3Comment_ItemClick(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservClear_Click(object sender, EventArgs e)
        {
            // Fill Values
            alfaEntity.Fill_ComboBox_Field(txtSiteNameV1, true, "TableRouterHuawei", "SiteName");
            alfaEntity.Fill_ComboBox_Field(txtSiteNameV2, false, "TableRouterHuawei", "SiteName");

            // Reset Values
            txtSiteNameV1.SelectedIndex = 0;
            txtSiteNameV2.SelectedIndex = 0;
            txtPortStatus.SelectedIndex = 0;

            // Reset Log
            txtTerminal.Text = string.Empty;
            txtReservLog.Text = string.Empty;

            // Clear Grids
            grdPort.DataSource = null;
            grdReserv.DataSource = null;
            grdPortView.Columns.Clear();
            grdReservView.Columns.Clear();

            // Set Button
            alfaCtrl.SetButton(btnRequestCancel, false);
            alfaCtrl.SetButton(btnRefreshPorts, false);
            alfaCtrl.SetButton(btnReservCancel, false);
            alfaCtrl.SetButton(btnRequest, false);
            alfaCtrl.SetButton(btnReserv, false);
            alfaCtrl.SetButton(btnExport, false);

            if (sender != null)
            {
                // Status
                alfaCtrl.SetText(alfaNET.FrmMain.statusResult, "OK", Color.Green);

                // ProgressBar
                alfaNET.FrmMain.statusProgress.EditValue = 0;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservList_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Set Status
            txtPortStatus.Tag = txtPortStatus.Text;

            // GetList
            var p_Result = alfaEntity.TablePortAvea_GetList("HUAWEI", txtSiteNameV1.Text, txtPortStatus.Text);

            // SetView
            alfaGrid.SetView(grdReservView, (object)p_Result, false);

            // Hide Columns
            alfaGrid.ColumnHide(grdReservView, "Logs-UpdateDatetime-UpdateUsername-PortType");

            // Set Button            
            alfaCtrl.SetButton(btnReservList, true);
            alfaCtrl.SetButton(btnReservClear, true);
            alfaCtrl.SetButton(btnExport, grdReservView.RowCount > 0);
            alfaCtrl.SetButton(btnRefreshPorts, txtSiteNameV1.Text != "ALL" && txtPortStatus.Text == "ALL");
            alfaCtrl.SetButton(btnRequest, grdReservView.RowCount > 0 && txtPortStatus.Text == alfaStr.FREE);
            alfaCtrl.SetButton(btnRequestCancel, grdReservView.RowCount > 0 && txtPortStatus.Text == alfaStr.REQUEST);
            alfaCtrl.SetButton(btnReserv, grdReservView.RowCount > 0 && txtPortStatus.Text == alfaStr.REQUEST && alfaSession.Group == alfaStr.GroupDesign);
            alfaCtrl.SetButton(btnReservCancel, grdReservView.RowCount > 0 && txtPortStatus.Text == alfaStr.RESERVED && alfaSession.Group == alfaStr.GroupDesign);

            // Focus
            btnReservList.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private async void btnRefreshPorts_Click(object sender, EventArgs e)
        {
            // Parameters
            alfaNET.Set_Parameters_FromDB();
            
            // Start Process
            alfaNET.Start(MainTimer, alfaNET.FrmMain.pageHuawei);

            // Set TabPage
            pagePort.PageEnabled = false;
            pageLog.PageEnabled = false;

            // Set Status
            grpReservation.Enabled = false;

            // Disable Buttons
            alfaCtrl.DisableButtons(grpReservation);

            // Clear Log
            txtTerminal.Text = string.Empty;

            // Get Router
            var p_Router = alfaEntity.TableRouterHuawei_Get(txtSiteNameV1.Text);

            // Get Ports
            if (await alfaNET.F1_Huawei_GetRouterPorts_Task(p_Router, grdPortView, txtTerminal))
            {
                // Save List
                await alfaEntity.TablePortAvea_SaveHuawei_Task((List<PortAvea>)grdPort.DataSource, p_Router);

                // Message
                alfaMsg.Info("Refreshing Ports is Done ... !");
            }

            // Refresh List
            this.btnReservList_Click(null, null);

            // Set Status
            grpReservation.Enabled = true;

            // Set TabPage
            pagePort.PageEnabled = true;
            pageLog.PageEnabled = true;

            // Stop Process
            alfaNET.Stop();
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

        private void btnPorts_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Parameters
            alfaNET.Set_Parameters_FromDB();

            // Reset Grid
            grdPort.DataSource = null;
            grdPortView.Columns.Clear();

            // Refresh
            Application.DoEvents();

            // Router
            var p_Router = alfaEntity.TableRouterHuawei_Get(txtSiteNameV2.Text);

            // Set Connection
            p_Router.Connection = txtConnection.Text;

            // Get Ports
            alfaNET.F2_Huawei_GetRouterPorts(p_Router, grdPortView, txtTerminal);

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnPortsClear_Click(object sender, EventArgs e)
        {
            // Reset Router
            txtSiteNameV2.SelectedIndex = 0;

            // Clear Grids
            grdPort.DataSource = null;
            grdPortView.Columns.Clear();

            // Hide
            txtConnection.Visible = false;
            btnUpdateConnection.Visible = false;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdReservView_MouseUp(object sender, MouseEventArgs e)
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
            if ("USED-ALL".Contains(txtPortStatus.Tag.ToString())) e.Cancel = true;

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

        private void grdReservView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                // Get ID
                int p_ID = Convert.ToInt32(grdReservView.GetRowCellValue(e.FocusedRowHandle, "ID"));

                // Set Log
                txtReservLog.Text = alfaEntity.GetRequestLog_V2(p_ID);
            }
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

        private void grdReservView_RowCellStyle(object sender, RowCellStyleEventArgs e)
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
                else if (p_CellValue == alfaStr.RESERVED) e.Appearance.BackColor = Color.OrangeRed;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (alfaNET.IsRunning)
            {
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
            }
            else 
            {
                // Stop Timer
                this.MainTimer.Stop();

                // ProgressBar
                alfaNET.FrmMain.statusProgress.EditValue = 100;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnUpdateConnection_Click(object sender, EventArgs e)
        {
            // Router
            var p_Router = alfaEntity.TableRouterHuawei_Get(txtSiteNameV2.Text);

            // Update Connection
            alfaEntity.TableRouterHuawei_UpdateConnection(p_Router.SiteName, txtConnection.Text);

            // Message
            alfaMsg.Info("Connection Type Updated Successfully ... !");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtSiteNameV2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Router
            var p_Router = alfaEntity.TableRouterHuawei_Get(txtSiteNameV2.Text);

            // Connection
            txtConnection.Text = p_Router.Connection;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRequest_Click(object sender, EventArgs e)
        {
            // Get DataSource
            var p_List = (List<TablePortAvea>)grdReserv.DataSource;

            // Get only Checked and Free
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.FREE).ToList();

            // Check
            if (p_List.Count() == 0) return;

            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Request the Selected Ports ?") != DialogResult.Yes) return;

            // Cursor
            alfaMsg.CursorWait();

            // Parameters
            alfaNET.Set_Parameters_FromDB();

            foreach (var p_Port in p_List)
            {
                // Reserve Port
                alfaEntity.TablePortAvea_Update(p_Port, alfaStr.REQUEST, null, false);
            }

            // Selected List
            grdReserv.DataSource = p_List;

            // ToAddress
            string p_To = alfaEntity.TableGroup_GetMail("Design");

            // SendMail
            alfaMail.Send(p_To, alfaSession.Email, "PortMan2014 - Ports Requested / HUAWEI", "Please Check With Attached File ... !", grdReservView);

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRequestCancel_Click(object sender, EventArgs e)
        {
            // Get DataSource
            var p_List = (List<TablePortAvea>)grdReserv.DataSource;

            // Get only Checked and Requested
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.REQUEST).ToList();

            // Check
            if (p_List.Count() == 0) return;

            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Rollback the Requested Ports ?") != DialogResult.Yes) return;

            // Cursor
            alfaMsg.CursorWait();

            // Parameters
            alfaNET.Set_Parameters_FromDB();

            foreach (var p_Port in p_List)
            {
                // Reset Description
                p_Port.ReservDescription = string.Empty;

                // Reserve Port
                alfaEntity.TablePortAvea_Update(p_Port, alfaStr.FREE, " (RollBack)", false);
            }

            // Refresh
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtPortStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset Log
            txtTerminal.Text = string.Empty;

            // Clear Grids
            grdPort.DataSource = null;
            grdReserv.DataSource = null;
            grdPortView.Columns.Clear();
            grdReservView.Columns.Clear();

            // List
            this.btnReservList_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReserv_Click(object sender, EventArgs e)
        {
            // DataSource
            var p_List = (List<TablePortAvea>)grdReserv.DataSource;

            // Get only Checked and Reserved
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.REQUEST).ToList();

            // Check
            if (p_List.Count() == 0) return;

            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Reserve the Selected Ports ?") != DialogResult.Yes) return;

            // Cursor
            alfaMsg.CursorWait();

            // Parameters
            alfaNET.Set_Parameters_FromDB();

            // Reserve Ports
            if (alfaNET.F4_Huawei_ReservePorts_SSH(p_List))
            {
                // Selected List
                grdReserv.DataSource = p_List;

                // ToAddress
                string p_To = alfaEntity.TableGroup_GetMail("PBO");

                // SendMail
                alfaMail.Send(p_To, alfaSession.Email, "PortMan2014 - Ports Reserverd / HUAWEI", "Please Check With Attached File ... !", grdReservView);

                // Refresh
                this.btnReservList_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnReservCancel_Click(object sender, EventArgs e)
        {
            // DataSource
            var p_List = (List<TablePortAvea>)grdReserv.DataSource;

            // Get only Checked and Reserved
            p_List = p_List.Where(tt => tt.Check == true && tt.Status == alfaStr.RESERVED).ToList();

            // Check
            if (p_List.Count() == 0) return;

            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Rollback the Selected Ports ?") != DialogResult.Yes) return;

            // Cursor
            alfaMsg.CursorWait();

            // Parameters
            alfaNET.Set_Parameters_FromDB();

            // Reserve Ports
            alfaNET.F5_Huawei_RollbackPorts_SSH(p_List);

            // Refresh
            this.btnReservList_Click(null, null);
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

        private void menu1SelectALL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Select ALL
            this.SelectItems(true);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menu2UnSelectALL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Deselect ALL
            this.SelectItems(false);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtSiteNameV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset Log
            txtTerminal.Text = string.Empty;

            // Clear Grids
            grdPort.DataSource = null;
            grdReserv.DataSource = null;
            grdPortView.Columns.Clear();
            grdReservView.Columns.Clear();

            // List
            this.btnReservList_Click(null, null);
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