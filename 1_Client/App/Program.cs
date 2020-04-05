using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;

namespace PortMan2014
{

    static class Program
    {

        //------------------------------------------------------------------------------------------------------//

        // Mutex
        private static Mutex m_Mutex = null;

        //------------------------------------------------------------------------------------------------------//

        [STAThread]
        static void Main()
        {
            // Check For Double Instance
            CheckProgramAlreadyRunning();

            // Set Current Culture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");

            // DevExpress Skins
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            
            // Applications
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }

        //------------------------------------------------------------------------------------------------------//

        private static void CheckProgramAlreadyRunning()
        {
            // Create Flag
            bool createdNew = false;

            // Create Mutex
            m_Mutex = new Mutex(false, Application.ProductName, out createdNew);
        }

        //------------------------------------------------------------------------------------------------------//

    }


}