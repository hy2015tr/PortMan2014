using System;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace PortMan2014
{
    public partial class FrmMain : XtraForm
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        #region //---Member Fields---//

        // Splash Form
        private static FrmSplash m_frmSplash = new FrmSplash();

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public FrmMain()
        {
            // Show Splash
            m_frmSplash.Show();
            m_frmSplash.Update();

            // Initializing
            this.InitializeComponent();

            // alfaSession
            alfaSession.Initialize();

            // Set Main
            alfaNET.FrmMain = this;

            // Hide Panels
            pnMain.Hide();

            // Set LookAndFeel
            this.SetDefaultLook(menuSkinDarkSide);

            // Maximized
            this.WindowState = FormWindowState.Maximized;

            // Set Version
            this.lbVersion.Text = alfaStr.GetAppVersion(true);

            // Select Test-Prod
            radioSystem.SelectedIndex = 0;
            radioSystem.Properties.Items[0].Enabled = true;
            radioSystem.Properties.Items[1].Enabled = false;

            // Set Page Title
            pageCisco.Text = "CISCO\n\n(1)";
            pageHuawei.Text = "HUAWEI\n\n(2)";
            pageAlcatel.Text = "ALCATEL\n\n(3)";
            pageSAM.Text = "SAM\n\n(4)";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                // Update
                this.Update();

                // Close Splash
                m_frmSplash.Close();

                // Clear 
                this.btnLoginClear_Click(null, null);

                // Load UserName
                this.LoadUserNameFromAppSettings();
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void SetDefaultLook(DevExpress.XtraBars.BarButtonItem p_MenuItem)
        {
            // Add Check to ViewMenuItems
            foreach (Object Item in barMenu.Manager.Items)
            {
                // Check Item
                if (Item.GetType().ToString() != "DevExpress.XtraBars.BarButtonItem") continue;

                // Get Item
                BarButtonItem obj = (BarButtonItem)Item;

                if (obj.Name.Contains("Skin"))
                {
                    // Set Properties
                    obj.ButtonStyle = BarButtonStyle.Check;
                    obj.AllowAllUp = true;
                    obj.GroupIndex = 1;
                }
            }

            // Set Default LookAndFeel
            defaultLookAndFeel.LookAndFeel.SkinName = p_MenuItem.Caption;
            p_MenuItem.Down = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menuAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Show Splash
            m_frmSplash = new FrmSplash();
            m_frmSplash.ShowDialog();

            //Hide Splash
            m_frmSplash.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void ViewItemALL_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Set LookAndFeel
            defaultLookAndFeel.LookAndFeel.SkinName = e.Item.Caption;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLoginClear_Click(object sender, EventArgs e)
        {
            // Disable Login
            alfaCtrl.DisableControl(btnLogin);

            // Clear Inputs
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;

            // Focus
            txtUser.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if ((txtUser.Text != string.Empty) && (txtPass.Text != string.Empty))
            {
                // Enable Login
                alfaCtrl.EnableControl(btnLogin);
            }
            else
            {
                // Disable Login
                alfaCtrl.DisableControl(btnLogin);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && btnLogin.Enabled == true)
            {
                // Enter
                this.btnLogin_Click(null, null);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // CursorWait
                alfaMsg.CursorWait();

                // alfaSession
                alfaSession.Initialize();

                if (alfaEntity.CheckUserLogin(txtUser.Text, txtPass.Text))
                {
                    // Add Pages
                    this.AddPages();

                    // Parameters
                    alfaNET.Set_Parameters_FromDB();

                    // Refresh ClientInfo
                    alfaSession.UserName = txtUser.Text;
                    alfaSession.RefreshLoginDateTime();

                    // Save UserName
                    PortMan2014.Properties.Settings.Default.UserName = txtUser.Text;
                    PortMan2014.Properties.Settings.Default.Save();

                    // Add Session
                    alfaEntity.TableSession_Add();

                    // Set Admin Page
                    pageImport.PageVisible = (alfaSession.Admin);
                    pageSetting.PageVisible = (alfaSession.Admin);
                    pageSAM.PageVisible = (alfaSession.Admin);

                    // Set Status
                    this.Set_Status_Fields();

                    // Set Buttons
                    ((FrmPageSAM)pageSAM.Controls[0]).FrmPageAlcatel_SetButtons();

                    // Panels
                    pnLogin.Hide();
                    pnMain.Show();
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void LoadUserNameFromAppSettings()
        {
            // Load UserName
            string p_Username = PortMan2014.Properties.Settings.Default.UserName;

            if (p_Username != string.Empty)
            {
                // Set UserName
                txtUser.Text = p_Username;

                // Focus Password
                txtPass.Focus();
            }
            // Focus UserName
            else txtUser.Focus();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void Set_Status_Fields()
        {
            try
            {
                // Satus Left Items
                statusName.Caption = String.Format("PC : {0}", alfaSession.PC);
                statusIP.Caption = String.Format("IP : {0}", alfaSession.LocIP);
                statusNet.Caption = String.Format("NET : {0}", alfaSession.NetVer);
                statusSQL.Caption = String.Format("SQL : {0}", alfaSession.DBName);

                // Set User
                statusUser.Caption = alfaSession.UserGroupAdmin();

                // Set Version
                this.lbVersion.Text = alfaSession.AppVer;
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex.Message);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void statusSQL_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            // Create Form
            FrmServer frm = new FrmServer();

            // Call Form
            if (frm.ShowDialog() == DialogResult.OK)
            {
                statusSQL.Caption = String.Format("SQL : {0}", alfaSession.DBName);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Restart
            Application.Restart();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void menuExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Close
            this.Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void statusUser_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            // Check UserName
            if (string.IsNullOrEmpty(txtUser.Text)) return;

            // Set UserName
            alfaSession.UserName = txtUser.Text;

            // Create Form
            FrmUser frm = new FrmUser();

            // Call Form
            if (frm.ShowDialog() == DialogResult.OK)
            {
                statusUser.Caption = String.Format("{0}", alfaSession.UserName);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void AddPages()
        {
            try
            {
                // Add Pages
                this.AddPage(pageCisco, new FrmPageCisco());
                this.AddPage(pageHuawei, new FrmPageHuawei());
                this.AddPage(pageAlcatel, new FrmPageAlcatel());
                this.AddPage(pageSAM, new FrmPageSAM());
                this.AddPage(pageReport, new FrmPageReport());
                this.AddPage(pageImport, new FrmPageImport());
                this.AddPage(pageSession, new FrmPageSession());
                this.AddPage(pageSetting, new FrmPageSetting());
            }

            catch (Exception ex)
            {
                // Close
                m_frmSplash.Close();

                // Error
                alfaMsg.Error(ex);

                // Exit
                Environment.Exit(0);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void AddPage(XtraTabPage p_Page, Control p_Object)
        {
            // Suspend
            this.SuspendLayout();

            // Create Admin Page
            p_Page.Controls.Add(p_Object);

            // Resume
            this.ResumeLayout();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close Session
            alfaEntity.TableSession_Close();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//
    }
}