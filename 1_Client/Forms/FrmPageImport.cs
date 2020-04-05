using System;
using LinqToExcel;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace PortMan2014
{
    public partial class FrmPageImport : XtraForm
    {
        List<DataLOG> m_ListLOG = new List<DataLOG>();
        List<TableRouterCisco> m_ListPorts = new List<TableRouterCisco>();

        //-----------------------------------------------------------------------------------------------------------------------------------------//
        
        public FrmPageImport()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Clear
            this.btnClear_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Process
                this.ProcessFile();
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Process
            this.ProcessData();

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void ProcessFile()
        {
            // FileDialog
            OpenFileDialog fd = new OpenFileDialog();
            fd.FilterIndex = 1;
            fd.Filter = "EXCEL Files (*.xls)|*.xls*|ALL Files (*.*)|*.*";

            // Open File
            if (fd.ShowDialog() != DialogResult.OK) return;

            // Cursor
            alfaMsg.CursorWait();

            // FileName
            txtFileName.Text = fd.FileName;

            // Create Excel
            var excel = new ExcelQueryFactory(txtFileName.Text);

            // List Rows
            this.m_ListPorts = excel.Worksheet<TableRouterCisco>("DATA").ToList(); 

            // Set View
            alfaGrid.SetView(grdDATView, this.m_ListPorts, true);

            // Set Buttons
            alfaCtrl.DisableControl(btnFile);
            alfaCtrl.EnableControl(btnClear);
            alfaCtrl.EnableControl(btnRun);

            // Enable Selection
            radioRouter.Enabled = true;

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void ProcessData()
        {
            // Enable Selection
            radioRouter.Enabled = false;

            // Set Buttons
            alfaCtrl.DisableControl(btnFile);
            alfaCtrl.DisableControl(btnRun);
            alfaCtrl.EnableControl(btnClear);

            // Counts
            int p_Insert = 0;
            int p_Update = 0;

            // ================= ALARM ===================//


            if (radioRouter.SelectedIndex == 0) // CISCO
            {
                foreach (var p_Row in this.m_ListPorts)
                {
                    // UpdateInsert
                    alfaEntity.TableRouterCisco_InsertUpdate(p_Row, this.m_ListLOG, ref p_Insert, ref p_Update);
                }
            }

            else if (radioRouter.SelectedIndex == 1) // HUAWEI
            {
                foreach (var p_Row in this.m_ListPorts)
                {
                    // UpdateInsert
                    alfaEntity.TableRouterHuawei_InsertUpdate(p_Row, this.m_ListLOG, ref p_Insert, ref p_Update);
                }
            }

            else if (radioRouter.SelectedIndex == 2) // ALCATEL
            {
                foreach (var p_Row in this.m_ListPorts)
                {
                    // UpdateInsert
                    alfaEntity.TableRouterAlcatel_InsertUpdate(p_Row, this.m_ListLOG, ref p_Insert, ref p_Update);
                }
            }

            // ==================== RESULT ==============//

            // Message
            string p_Message = string.Format("RESULT =  Insert: ( {0} ) / Update: ( {1} )", p_Insert, p_Update);

            // AddLog
            alfaEntity.AddLog("RESULT", p_Message, this.m_ListLOG);

            // Assign to Grid
            grdLOG.DataSource = this.m_ListLOG;

            // Set View
            alfaGrid.SetView(grdLOGView);

            // Message
            alfaMsg.Info(p_Message);

            // Select Page
            tabMain.SelectedTabPage = pageLog;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClear_Click(object sender, EventArgs e)
        {
            // RadioSelection
            radioRouter.Enabled = false;
            radioRouter.SelectedIndex = 0;

            // Set Buttons
            alfaCtrl.EnableControl(btnFile);
            alfaCtrl.DisableControl(btnRun);
            alfaCtrl.DisableControl(btnClear);

            // Clear Text
            txtFileName.Text = string.Empty;

            // Clear Lists
            if (this.m_ListLOG != null) this.m_ListLOG.Clear();
            if (this.m_ListPorts != null) this.m_ListPorts.Clear();

            // Clear Grid
            grdDAT.DataSource = null;
            grdDATView.Columns.Clear();

            // Clear Grid
            grdLOG.DataSource = null;
            grdLOGView.Columns.Clear();

            // Select Page
            tabMain.SelectedTabPage = pageData;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }


}
