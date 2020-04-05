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
using DevExpress.XtraPrinting;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;


namespace PortMan2014
{
    public partial class FrmPageReport : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageReport()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Clear
            this.btnClear01_Click(null, null);
            this.btnClear02_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnList01_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();
            
            // Clear
            grdReport01.DataSource = null;
            grdReport01View.Columns.Clear();

            // Get Report
            var p_ResultTable = alfaEntity.Alcatel_Report_A(txtSiteName01.Text, txtPortStatus01.Text);

            // Trim Columns
            alfaEntity.TrimTableColumns(p_ResultTable);

            /*

            // Combine Columns
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-T", new string[] { "MDI GIGE-T", "MDX GIGE-T" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "MDI-MDX", new string[] { "MDI", "MDX" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "10GBASE-LR", new string[] { "10GBASE-LR 10*", "xgige 10GBASE-LR 10*" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "10GBASE-SR", new string[] { "10GBASE-SR 10G*" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-LX", new string[] { "GIGE-LX 10KM", "GIGE-LX 15KM", "xcme GIGE-LX 10KM" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-SX", new string[] { "xcme GIGE-SX"});

            // Delete Columns
            alfaEntity.DeleteTableColumns(p_ResultTable, new string[] { "OC12-IR-1 15KM"});
            
            */

            // Delete Columns
            alfaEntity.DeleteZeroTableColumns(p_ResultTable);

            // Set Grid
            alfaGrid.SetView(grdReport01View, p_ResultTable, true);
            alfaGrid.ColumnTextCenter(grdReport01View);

            // Set Button
            alfaCtrl.SetButton(btnExport01, grdReport01View.RowCount > 0);

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnList02_Click(object sender, EventArgs e)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Clear
            grdReport02.DataSource = null;
            grdReport02View.Columns.Clear();

            // Get Report
            var p_ResultTable = alfaEntity.Alcatel_Report_B(txtSiteType02.Text, txtPortStatus02.Text);

            // Trim Columns
            alfaEntity.TrimTableColumns(p_ResultTable);

            /*

            // Combine Columns
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-T", new string[] { "MDI GIGE-T", "MDX GIGE-T" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "MDI-MDX", new string[] { "MDI", "MDX" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "10GBASE-LR", new string[] { "10GBASE-LR 10*", "xgige 10GBASE-LR 10*" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "10GBASE-SR", new string[] { "10GBASE-SR 10G*" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-LX", new string[] { "GIGE-LX 10KM", "GIGE-LX 15KM", "xcme GIGE-LX 10KM" });
            p_ResultTable = alfaEntity.CombineTableColumns(p_ResultTable, "GIGE-SX", new string[] { "xcme GIGE-SX"});
            
            // Delete Columns
            alfaEntity.DeleteTableColumns(p_ResultTable, new string[] { "OC12-IR-1 15KM"});

             */

            // Delete Columns
            alfaEntity.DeleteZeroTableColumns(p_ResultTable);
              
            // Set Grid
            alfaGrid.SetView(grdReport02View, p_ResultTable, true);
            alfaGrid.ColumnTextCenter(grdReport02View);

            // Set Button
            alfaCtrl.SetButton(btnExport02, grdReport02View.RowCount > 0);

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClear01_Click(object sender, EventArgs e)
        {
            // Fill Values
            alfaEntity.Fill_ComboBox_Field(txtSiteName01, false, "TableRouterAlcatel", "SiteName");

            // Reset Values
            txtSiteName01.SelectedIndex = 0;
            txtPortStatus01.SelectedIndex = 0;

            // Clear
            grdReport01.DataSource = null;
            grdReport01View.Columns.Clear();

            // Set Button
            alfaCtrl.SetButton(btnExport01, grdReport01View.RowCount > 0);

            // Focus
            grdReport01View.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClear02_Click(object sender, EventArgs e)
        {
            // Clear Items
            txtSiteType02.Properties.Items.Clear();
            txtPortStatus02.Properties.Items.Clear();

            // Fill Values
            txtPortStatus02.Properties.Items.AddRange(new string[] { "FREE", "NON-FREE"});
            txtSiteType02.Properties.Items.AddRange(new string[] { "ALL", "ART", "DRT", "PSR", "CRT" });

            // Reset Values
            txtSiteType02.SelectedIndex = 0;
            txtPortStatus02.SelectedIndex = 0;

            // Clear
            grdReport02.DataSource = null;
            grdReport02View.Columns.Clear();

            // Set Button
            alfaCtrl.SetButton(btnExport02, grdReport02View.RowCount > 0);

            // Focus
            grdReport02View.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdView01_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // GridView
            GridView p_GridView = sender as GridView;

            // Check
            if (e.RowHandle < 0) return;

            // Check Focused Row
            if (e.RowHandle == p_GridView.FocusedRowHandle) return;

            if (e.Column.ColumnType == typeof(int))
            {
                // Get Text
                string p_CellValue = p_GridView.GetRowCellDisplayText(e.RowHandle, p_GridView.Columns[e.Column.FieldName]);

                // Check
                if (string.IsNullOrEmpty(p_CellValue)) return;

                // Get Int
                var p_Value = int.Parse(p_CellValue);

                // Set Fonts
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);

                // Set Color
                if (p_Value > 0) e.Appearance.BackColor = Color.Blue;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdView02_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // GridView
            GridView p_GridView = sender as GridView;

            // Check
            if (e.RowHandle < 0) return;

            // Check Focused Row
            if (e.RowHandle == p_GridView.FocusedRowHandle) return;

            if (e.Column.ColumnType == typeof(int))
            {
                // Get Text
                string p_CellValue = p_GridView.GetRowCellDisplayText(e.RowHandle, p_GridView.Columns[e.Column.FieldName]);

                if (!string.IsNullOrEmpty(p_CellValue))
                {
                    // Get Int
                    var p_Value = int.Parse(p_CellValue);

                    // Set Fonts
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);

                    // Set Color
                    if (p_Value > int.Parse(alfaNET.m_AlcMinV)) e.Appearance.BackColor = Color.Blue; else e.Appearance.BackColor = Color.OrangeRed;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnExport01_Click(object sender, EventArgs e)
        {
            // Export
            this.ExportFile(grdReport01View);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnExport02_Click(object sender, EventArgs e)
        {
            // Export
            this.ExportFile(grdReport02View);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnExport03_Click(object sender, EventArgs e)
        {
            // Export
            this.ExportFile(grdReport03View);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void ExportFile(GridView p_GridView)
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
            p_GridView.OptionsPrint.AutoWidth = false;

            // Export to Target
            p_GridView.ExportToXls(sf.FileName);

            // Result Message
            alfaMsg.Info("Exporting List is Successfully Done ... !");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}