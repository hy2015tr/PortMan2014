using System;
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
    public partial class FrmPageSetting : XtraForm
    {

        //-----------------------------------------------------------------------------------------------------------------------------------------//
        
        public FrmPageSetting()
        {
            // Initialize
            InitializeComponent();

            // Prepare for Page
            this.Visible = true;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;

            // Tables
            this.Admin_Tables_Items();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Items()
        {
            // Clear List
            listAdminTables.Items.Clear();

            // Add Items
            listAdminTables.Items.Add(new alfaItem(" ( 1 )  -  USERS             ", "TableUser"));
            listAdminTables.Items.Add(new alfaItem(" ( 2 )  -  GROUPS            ", "TableGroup"));
            listAdminTables.Items.Add(new alfaItem(" ( 3 )  -  PARAMS            ", "TableParams"));
            listAdminTables.Items.Add(new alfaItem(" ( 4 )  -  ROUTERS - CISCO   ", "TableRouterCisco"));
            listAdminTables.Items.Add(new alfaItem(" ( 5 )  -  ROUTERS - HUAWEI  ", "TableRouterHuawei"));
            listAdminTables.Items.Add(new alfaItem(" ( 6 )  -  ROUTERS - ALCATEL ", "TableRouterAlcatel"));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Refresh()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Get Item
                var p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Clear
                grdAdminView.Columns.Clear();

                // Set Datasource
                switch (p_Item.Name)
                {
                    case "TableParams": grdAdmin.DataSource = alfaEntity.TablePrms_GetList(); break;
                    case "TableUser": grdAdmin.DataSource = alfaEntity.TableUser_GetList(null, null); break;
                    case "TableGroup": grdAdmin.DataSource = alfaEntity.TableGroup_GetList(null, null); break;
                    case "TableRouterCisco": grdAdmin.DataSource = alfaEntity.TableRouterCisco_GetList(); break;
                    case "TableRouterHuawei": grdAdmin.DataSource = alfaEntity.TableRouterHuawei_GetList(); break;
                    case "TableRouterAlcatel": grdAdmin.DataSource = alfaEntity.TableRouterAlcatel_GetList(); break;
                }

                // Set GridView
                alfaGrid.SetView(grdAdminView, grdAdmin.DataSource, true);

                // Set Buttons
                alfaCtrl.SetButton(btnAdminUpdate, (grdAdminView.RowCount > 0));
                alfaCtrl.SetButton(btnAdminDelete, (grdAdminView.RowCount > 0));
                alfaCtrl.EnableControl(btnAdminInsert);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Update()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Object
                Object objEntity = null;

                // Check
                if (grdAdminView.FocusedRowHandle < 0) return;

                // Get ID
                var p_ID = Convert.ToInt32(grdAdminView.GetRowCellValue(grdAdminView.FocusedRowHandle, "ID"));

                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Assign Object
                switch (p_Item.Name)
                {
                    case "TableUser": objEntity = DS.Context.TableUser.First(tt => tt.ID == p_ID); break;
                    case "TableGroup": objEntity = DS.Context.TableGroup.First(tt => tt.ID == p_ID); break;
                    case "TableParams": objEntity = DS.Context.TableParameter.First(tt => tt.ID == p_ID); break;
                    case "TableRouterCisco": objEntity = DS.Context.TableRouterCisco.First(tt => tt.ID == p_ID); break;
                    case "TableRouterHuawei": objEntity = DS.Context.TableRouterHuawei.First(tt => tt.ID == p_ID); break;
                    case "TableRouterAlcatel": objEntity = DS.Context.TableRouterAlcatel.First(tt => tt.ID == p_ID); break;
                }

                // Create Form
                FrmRecord frm = new FrmRecord(p_Item.ToString(), objEntity);

                // Confirmation
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // SaveChanges
                    DS.Context.SaveChanges();

                    // Refresh
                    this.Admin_Tables_Refresh();

                    // Get Row
                    int p_RowHandle = grdAdminView.LocateByValue("ID", p_ID, null);

                    // Select Row
                    alfaGrid.SelectRow(grdAdminView, p_RowHandle);

                    // Parameters
                    alfaNET.Set_Parameters_FromDB();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Insert()
        {
            using (alfaDS ent = new alfaDS())
            {
                // Create Object
                Object objEntity = null;

                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Assign Object
                switch (p_Item.Name)
                {
                    case "TableUser": objEntity = new TableUser(); break;
                    case "TableGroup": objEntity = new TableGroup(); break;
                    case "TableParams": objEntity = new TableParameter(); break; 
                    case "TableRouterCisco": objEntity = new TableRouterCisco(); break; 
                    case "TableRouterHuawei": objEntity = new TableRouterHuawei(); break; 
                    case "TableRouterAlcatel": objEntity = new TableRouterAlcatel(); break; 
                }

                // Create Form
                FrmRecord frm = new FrmRecord(p_Item.ToString(), objEntity);

                // Confirmation
                if (frm.ShowDialog() != DialogResult.OK) return;

                // Add Record
                switch (p_Item.Name)
                {
                    case "TableUser": ent.Context.TableUser.Add(objEntity as TableUser); break;
                    case "TableGroup": ent.Context.TableGroup.Add(objEntity as TableGroup); break;
                    case "TableParams": ent.Context.TableParameter.Add(objEntity as TableParameter); break; 
                    case "TableRouterCisco": ent.Context.TableRouterCisco.Add(objEntity as TableRouterCisco); break; 
                    case "TableRouterHuawei": ent.Context.TableRouterHuawei.Add(objEntity as TableRouterHuawei); break; 
                    case "TableRouterAlcatel": ent.Context.TableRouterAlcatel.Add(objEntity as TableRouterAlcatel); break; 
                }

                // SaveChanges
                ent.Context.SaveChanges();
            }

            // DataSource
            this.Admin_Tables_Refresh();

            // Select Row
            alfaGrid.SelectRow(grdAdminView, grdAdminView.RowCount - 1);

            // Parameters
            alfaNET.Set_Parameters_FromDB();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Admin_Tables_Delete()
        {
            // Confirmation
            if (alfaMsg.Quest("Are You Sure to Delete the Selected Record ?") == DialogResult.No) return;

            using (alfaDS ent = new alfaDS())
            {
                // Get Item
                alfaItem p_Item = (alfaItem)listAdminTables.SelectedItem;

                // Get ID
                int p_ID =  Convert.ToInt32(grdAdminView.GetRowCellValue(grdAdminView.FocusedRowHandle, "ID"));

                // Delete Object
                switch (p_Item.Name)
                {
                    case "TableUser": ent.Context.TableUser.Remove(ent.Context.TableUser.First(tt => tt.ID == p_ID)); break;
                    case "TableGroup": ent.Context.TableGroup.Remove(ent.Context.TableGroup.First(tt => tt.ID == p_ID)); break;
                    case "TableParams": ent.Context.TableParameter.Remove(ent.Context.TableParameter.First(tt => tt.ID == p_ID)); break; 
                    case "TableRouterCisco": ent.Context.TableRouterCisco.Remove(ent.Context.TableRouterCisco.First(tt => tt.ID == p_ID)); break; 
                    case "TableRouterHuawei": ent.Context.TableRouterHuawei.Remove(ent.Context.TableRouterHuawei.First(tt => tt.ID == p_ID)); break; 
                    case "TableRouterAlcatel": ent.Context.TableRouterAlcatel.Remove(ent.Context.TableRouterAlcatel.First(tt => tt.ID == p_ID)); break; 
                }

                // SaveChanges
                ent.Context.SaveChanges();
            }

            // DataSource
            this.Admin_Tables_Refresh();

            //Focus
            grdAdminView.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Update Record
                this.Admin_Tables_Update();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Add Record
                this.Admin_Tables_Insert();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnAdminDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete Record
                this.Admin_Tables_Delete();
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void listAdminTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get Tables
            this.Admin_Tables_Refresh();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdAdminView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                // Update 
                if (e.KeyCode == Keys.Enter && btnAdminUpdate.Enabled) this.btnAdminUpdate_Click(null, null);

                // Delete
                if (e.KeyCode == Keys.Delete && btnAdminDelete.Enabled) this.btnAdminDelete_Click(null, null);

                // Insert
                if (e.KeyCode == Keys.Insert && btnAdminInsert.Enabled) this.btnAdminInsert_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void grdAdminView_DoubleClick(object sender, EventArgs e)
        {
            // Update
            this.btnAdminUpdate_Click(null, null);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//
    }
}
