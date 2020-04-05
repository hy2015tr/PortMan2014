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


namespace PortMan2014
{
    public partial class FrmPageSession : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmPageSession()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Clear
            this.btnSessionClear_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnSessionList_Click(object sender, EventArgs e)
        {
            // Get List            
            var ListReq = alfaEntity.TableSession_GetList(txtSession01.DateTime, txtSession02.DateTime);
            
            // Set GridView
            alfaGrid.SetView(grdSessionView, ListReq, true);
            grdSessionView.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnSessionClear_Click(object sender, EventArgs e)
        {
            // DateTime
            DateTime dtNow = DateTime.Now;
            dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

            // Reset Values
            txtSession01.DateTime = dtNow.AddDays(-2);
            txtSession02.DateTime = dtNow.AddDays(+2);

            // Clear Grid
            grdSessionView.Columns.Clear();
            grdSessionView.GridControl.DataSource = null;

            // Focus
            grdSessionView.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdSessionView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // GridView
            GridView p_GridView = sender as GridView;

            // Check
            if (e.RowHandle < 0) return;

            // Check Focused Row
            if (e.RowHandle == p_GridView.FocusedRowHandle) return;

            if ("Status".Contains(e.Column.FieldName))
            {
                // Get Text
                string p_CellValue = p_GridView.GetRowCellDisplayText(e.RowHandle, p_GridView.Columns[e.Column.FieldName]);

                // Set Fonts
                e.Appearance.ForeColor = Color.White;
                e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);

                // Set Color
                     if (p_CellValue == alfaStr.CLOSED) e.Appearance.BackColor = Color.Green;
                else if (p_CellValue == alfaStr.ACTIVE) e.Appearance.BackColor = Color.Red;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdSessionView_RowStyle(object sender, RowStyleEventArgs e)
        {
            //// GridView
            //GridView p_GridView = sender as GridView;

            //// Check
            //if (e.RowHandle < 0) return;

            //// HighPriority
            //e.HighPriority = true;

            //if (e.RowHandle == p_GridView.FocusedRowHandle)
            //{
            //    // Focused Item
            //    e.Appearance.ForeColor = Color.White;
            //    e.Appearance.BackColor = Color.RoyalBlue;
            //    e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Bold);
            //}
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }
}