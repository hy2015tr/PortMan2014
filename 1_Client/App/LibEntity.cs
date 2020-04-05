using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading;
using System.Data.Common;
using System.Data.Entity;
using System.Configuration;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Threading.Tasks;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity.Core.EntityClient;


namespace PortMan2014
{

    #region //----------- AlfaDS -----------//

    //===============================================================================//

    public class alfaDS : IDisposable
    {
        // Context
        public PORTMAN2014Entities Context = null;

        // ConnStr
        public static string m_ConnStr = null;

        //--------------------------------------------------------------------//

        public alfaDS()
        {
            if (alfaDS.m_ConnStr == null)
            {
                // Get Connection
                alfaDS.m_ConnStr = alfaEntity.ConnStr_DeCrypt();

                if (alfaDS.m_ConnStr == null)
                {
                    // Message
                    alfaMsg.Error("ERROR = SQL ConnectionString is Not Valid ...!");

                    // Close Application
                    System.Environment.Exit(1);
                }
            }

            // Create Entity Context
            this.Context = new PORTMAN2014Entities();

            // Disable LazyLoading
            this.Context.Configuration.LazyLoadingEnabled = false;

            // Create Connection
            alfaConStr p_Connection = new alfaConStr(alfaDS.m_ConnStr);

            // Set Connection String 
            this.Context.Database.Connection.ConnectionString = p_Connection.sbDB.ConnectionString;
        }

        //--------------------------------------------------------------------//

        public alfaDS(string p_ConnStr)
        {
            // Create Entity Context
            this.Context = new PORTMAN2014Entities();

            // Disable LazyLoading
            this.Context.Configuration.LazyLoadingEnabled = false;

            // Create Connection
            alfaConStr p_Connection = new alfaConStr(p_ConnStr);

            // Set Connection String 
            this.Context.Database.Connection.ConnectionString = p_Connection.sbDB.ConnectionString;
        }

        //--------------------------------------------------------------------//

        public void Dispose()
        {
            // Dispose
            this.Context.Dispose();
        }

        //--------------------------------------------------------------------//
    }

    //===============================================================================//


    # endregion 

    

    #region //----------- AlfaModel --------//

    //---------------------------------------------------------------//

    public partial class TablePortAvea
    {
        public bool Check { get; set; }
    }

    //---------------------------------------------------------------//

    public class PortAvea
    {
        public int ID { get; set; }
        public string SiteName { get; set; }
        public string PortName { get; set; }
        public string OprState { get; set; }
        public string AdmState { get; set; }
        public string Description { get; set; }
        public string PRTType { get; set; }
        public string SFPType { get; set; }
    }    

    //---------------------------------------------------------------//

    public class PortAlcatel
    {
        public bool Check { get; set; }
        public int ID { get; set; }
        public string SnmpPortId { get; set; }
        public string SiteName { get; set; }
        public string SiteId { get; set; }
        public string DisplayedName { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string OperationalState { get; set; }
        public string AdministrativeState { get; set; }
        public string SfpOpticalCompliance { get; set; }
        public string SpecificType { get; set; }
        public string SfpStatus { get; set; }
        public string Status { get; set; }
        public string ReservDescription { get; set; }
    } 

    //---------------------------------------------------------------//


    public class DataLOG
    {
        public string ITEM_NAME { get; set; }
        public string ERROR_TEXT { get; set; }
        public string DATETIME { get; set; }
        public string USERNAME { get; set; }
    }

    //---------------------------------------------------------------//


    #endregion  
     
    

    #region //----------- AlfaConStr -------//


    class alfaConStr
    {
        // SB SQLConnection
        public DbConnectionStringBuilder sbDB = new DbConnectionStringBuilder();
        
        // SB EntityConnection
        public EntityConnectionStringBuilder sbENT = new EntityConnectionStringBuilder();

        // Password
        public string Password
        {
            get
            {
                return sbDB["Password"].ToString();
            }
            set
            {
                this.sbDB["Password"] = value;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public alfaConStr(string p_ConStr)
        {
            // ENT Connection
            this.sbENT.ConnectionString = p_ConStr;

            // DB Connection
            this.sbDB.ConnectionString = this.sbENT.ProviderConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetPassword(string p_Password)
        {
            // Set Password
            this.sbDB["Password"] = p_Password;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetTimeOut(string p_TimeOut)
        {
            // Set DataSourxe
            this.sbDB["Connection Timeout"] = p_TimeOut;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetDataSource(string p_DataSource)
        {
            // Set DataSourxe
            this.sbDB["Data Source"] = p_DataSource;

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetClearPassword()
        {
            // Set Clear Password
            this.Password = alfaSec.DeCrypt(this.Password);

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public void SetEncryptedPassword()
        {
            // Set Encrypted Password
            this.Password = alfaSec.EnCrypt(this.Password);

            // Set ENT Connection
            this.sbENT.ProviderConnectionString = this.sbDB.ConnectionString;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public string GetClearPassword()
        {
            // Get Encrypted Password
            string p_Password = this.sbDB["Password"].ToString();

            // Return Decrypted Password
            return alfaSec.DeCrypt(p_Password);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public string GetPassword()
        {
            // Return Password
            return this.sbDB["Password"].ToString();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }

    # endregion 


       
    #region //---------- AlfaEntity --------//

    class alfaEntity
    {

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TablePortAvea> m_List_Alcatel_Routers = null;

        //-----------------------------------------------------------------------------------------------------------------------------------------//
        
        public static string EntityObjectName = "PORTMAN2014Entities";

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool UpdateUserPassword(string p_User, string p_PassOld, string p_PassNew)
        {
            try
            {
                using (alfaDS ent = new alfaDS())
                {
                    // CursorWait
                    alfaMsg.CursorWait();

                    // Query
                    var qry = from tt in ent.Context.TableUser
                              where tt.UserName == p_User
                                 && tt.Password == p_PassOld
                              select tt;

                    List<TableUser> tbUser = qry.ToList();

                    // CursorDefult
                    alfaMsg.CursorDefult();

                    // Check User
                    if (tbUser.Count == 0)
                    {
                        alfaMsg.Error("Old Password is Incorrect ...!"); return false;
                    }

                    // Set New Password
                    tbUser[0].Password = p_PassNew;

                    // Save
                    ent.Context.SaveChanges();

                    // Sucess
                    alfaMsg.Info("Yave have Successfully Changed Your Password ...!");  return true;
                }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool CheckUserLogin(string p_User, string p_Pass)
        {
            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Query
                    var qry = from tt in DS.Context.TableUser
                              where tt.UserName == p_User
                                 && tt.Active == true
                              select new { tt.TableGroup.Name, tt.Admin, tt.Email, tt.FullName, tt.Password };

                    var tbUser = qry.ToList();

                    // Check User
                    if (tbUser.Count == 0)
                    {
                        alfaMsg.Error("User Name Could not be Found  ...!"); return false;
                    }

                    // Check Pass
                    else if (tbUser[0].Password != p_Pass)
                    {
                        alfaMsg.Error("You Entered Wrong Password ...!"); return false;
                    }

                    // Set GroupName
                    alfaSession.UserName = p_User;
                    alfaSession.Group = tbUser[0].Name;
                    alfaSession.Admin = tbUser[0].Admin == true;
                    alfaSession.FullName = tbUser[0].FullName;
                    alfaSession.Email = tbUser[0].Email;
                    alfaSession.UserAtGroup = String.Format("{0} @ {1}", alfaSession.UserName, alfaSession.Group);

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string GetUserEmail(string p_UserName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableUser
                          where tt.UserName == p_UserName
                          select tt;

                if (qry.Count() != 1) return null; else return qry.First().Email;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static dynamic TableUser_GetList(int? p_ID, bool? p_Active)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableUser
                          select new
                          {
                              tt.ID,
                              tt.UserName,
                              tt.Password,
                              tt.FullName,
                              tt.Email,
                              GROUP = tt.TableGroup.Name,
                              tt.Admin,
                              tt.Active,
                          };

                // Optional Prm1
                if (p_ID != null) qry = qry.Where(tt => tt.ID == p_ID);

                // Optional Prm2
                if (p_Active != null) qry = qry.Where(tt => tt.Active == p_Active);

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static TableGroup TableGroup_Get(string p_Name)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableGroup
                          where tt.Name == p_Name
                          select tt;

                // Return
                return qry.First();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string TableGroup_GetMail(string p_Name)
        {
            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Query
                    var qry = from tt in DS.Context.TableGroup
                              where tt.Name == p_Name
                              select tt;

                    // Return
                    return qry.First().Email;
                }
            }

            catch (Exception ex)
            {
                // Message
                alfaMsg.Error(ex); return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableGroup> TableGroup_GetList(int? p_ID, bool? p_Active)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableGroup select tt;

                // Optional Prm1
                if (p_ID != null) qry = qry.Where(tt => tt.ID == p_ID);

                // Optional Prm2
                if (p_Active != null) qry = qry.Where(tt => tt.Active == p_Active);

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableParameter> TablePrms_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableParameter select tt;

                // Return
                return qry.OrderBy(tt => tt.Name).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableRouterCisco> TableRouterCisco_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableRouterCisco select tt;

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableRouterHuawei> TableRouterHuawei_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableRouterHuawei select tt;

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableRouterAlcatel> TableRouterAlcatel_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableRouterAlcatel select tt;

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static int TablePortAlcatel_Count()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                int p_Count = DS.Context.TablePortAlcatel.Count();

                // Return
                return p_Count;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TablePortAlcatel> TablePortAlcatel_GetList()
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAlcatel select tt;

                // Return
                return qry.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<PortAlcatel> TablePortAlcatel_GetList(string p_SiteName, string p_ReservStatus)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAlcatel
                          select new PortAlcatel
                              {
                                  SnmpPortId = tt.SnmpPortId,
                                  AdministrativeState = tt.AdministrativeState,
                                  Check = false,
                                  Description = tt.Description,
                                  DisplayedName = tt.DisplayedName,
                                  ID = tt.ID,
                                  OperationalState = tt.OperationalState,
                                  SfpOpticalCompliance = tt.SfpOpticalCompliance,
                                  SfpStatus = tt.SfpStatus,
                                  SiteName = tt.SiteName,
                                  SiteId = tt.SiteId,
                                  SpecificType = tt.SpecificType,
                                  State = tt.State,
                                  Status = tt.Status,
                                  ReservDescription = tt.ReservDescription,
                              };

                // Parameter I
                if (p_SiteName != "ALL")
                {
                    qry = qry.Where(tt => tt.SiteName == p_SiteName);
                }

                // Parameter II
                if (p_ReservStatus != "ALL")
                {
                    qry = qry.Where(tt => tt.Status == p_ReservStatus);
                }

                // Return
                return qry.OrderBy(tt => tt.SnmpPortId).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TablePortAlcatel_Update(PortAlcatel p_Port, string p_Status)
        {
            using (alfaDS DS = new alfaDS())
            {
                try
                {
                    // Query
                    var p_PortDB = DS.Context.TablePortAlcatel.Where(tt => tt.ID == p_Port.ID).Single();

                    // Copy Object
                    alfaEntity.Copy(p_Port, p_PortDB);

                    // Set Log
                    p_PortDB.Logs = alfaEntity.AddLogV1(p_PortDB.Logs, p_Status);

                    // Set Status
                    p_PortDB.Status = p_Status;

                    // Save
                    DS.Context.SaveChanges();
                }

                catch (Exception ex)
                {
                    // Error
                    alfaMsg.Error(ex);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool TablePortAvea_Update(TablePortAvea p_Port, string p_Status, string p_StatusExt, bool p_TrackDesc)
        {
            using (alfaDS DS = new alfaDS())
            {
                try
                {
                    // Query
                    var p_PortDB = DS.Context.TablePortAvea.Where(tt => tt.ID == p_Port.ID).Single();

                    // Copy Object
                    alfaEntity.Copy(p_Port, p_PortDB);

                    // Set Log
                    if (p_TrackDesc) 
                         p_PortDB.Logs = alfaEntity.AddLogV2(p_PortDB.Logs, p_Status + p_StatusExt, p_PortDB.Description, p_PortDB.ReservDescription);
                    else p_PortDB.Logs = alfaEntity.AddLogV1(p_PortDB.Logs, p_Status + p_StatusExt);

                    // Set Status
                    p_PortDB.Status = p_Status;

                    if (p_Status == alfaStr.REQUEST)
                    {
                        // Set Request User
                        p_PortDB.RequestUser = alfaSession.UserName;
                    }
                    else if (p_Status == alfaStr.FREE)
                    {
                        // Clear Request User
                        p_PortDB.RequestUser = string.Empty;
                    }

                    // Save
                    DS.Context.SaveChanges();

                    // Return
                    return true;
                }

                catch (Exception ex)
                {
                    // Error
                    alfaMsg.Error(ex); return false;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string AddLogV1(string p_LogText, string p_Status)
        {
            // Get Text
            var lstr = string.Format("{0:yyyy/MM/dd HH:mm:ss} ({1}) Port --> {2} ", DateTime.Now, alfaSession.UserGroup(), p_Status);

            // Add Log
            p_LogText += Environment.NewLine + lstr;

            // Return
            return p_LogText;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string AddLogV2(string p_LogText, string p_Status, string p_DescOld, string p_DescNew)
        { 
            // Get Text
            var lstr = string.Format("{0:yyyy/MM/dd HH:mm:ss} ({1}) Port --> {2} / [{3}] --> [{4}]", DateTime.Now, alfaSession.UserGroup(), p_Status, p_DescOld, p_DescNew);

            // Add Log
            p_LogText += Environment.NewLine + lstr;

            // Return
            return p_LogText;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string GetRequestLog_V1(int p_ID)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAlcatel where tt.ID == p_ID select tt;

                // Fail
                if (qry.Count() == 0) return null;

                // Return
                else return qry.First().Logs;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string GetRequestLog_V2(int p_ID)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAvea where tt.ID == p_ID select tt;

                // Fail
                if (qry.Count() == 0) return null;

                // Return
                else return qry.First().Logs;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TablePrms_SetAppValue(string p_Name, ref string p_Variable)
        { 
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableParameter
                          where tt.Name == p_Name
                          select tt;

                // Set Variable
                if (qry.Count() == 1) p_Variable = qry.First().Value;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TablePrms_SetDBValue(string p_Name, string p_Value)
        { 
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableParameter
                          where tt.Name == p_Name
                          select tt;

                // Set Variable
                if (qry.Count() == 1) qry.First().Value = p_Value;

                // Save
                DS.Context.SaveChanges();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static dynamic Entity_Get(string p_DataSource)
        {
            using (alfaDS DS = new alfaDS())
            {
                switch (p_DataSource)
                {
                    case "TableGroup" : return DS.Context.TableGroup.Select(tt => new { tt.ID, tt.Name }).OrderBy(tt=> tt.ID).ToList();
                    case "TableUser"  : return DS.Context.TableUser.Where(tt => tt.TableGroup.Name == "NMS").Select(tt => new { tt.FullName }).OrderBy(tt => tt.FullName).ToList();

                    default: return null;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string ConnStr_DeCrypt()
        {
            try
            {
                // Config File
                Configuration cfgFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Get ConnStr
                string p_ConnStr = cfgFile.ConnectionStrings.ConnectionStrings[alfaEntity.EntityObjectName].ConnectionString;

                // alfaConStr
                alfaConStr p_Connection = new alfaConStr(p_ConnStr);

                // Clear Password
                p_Connection.SetClearPassword();

                // Return
                return p_Connection.sbENT.ConnectionString;
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void ConnStr_EnCrypt(string p_ConnStr)
        {
            try
            {
                // alfaConStr
                alfaConStr p_Connection = new alfaConStr(p_ConnStr);

                // Encrypt Password
                p_Connection.SetEncryptedPassword();

                // Config File
                Configuration cfgFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Set Properties
                cfgFile.ConnectionStrings.ConnectionStrings[alfaEntity.EntityObjectName].ConnectionString = p_Connection.sbENT.ConnectionString;

                // Save Changes to File
                cfgFile.Save(ConfigurationSaveMode.Modified);

                // Force Reload
                ConfigurationManager.RefreshSection("connectionStrings");

                // Refresh
                alfaDS.m_ConnStr = null;

            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); 
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string ConnStr_Test(string p_DataSource, out string p_Result)
        {
            try
            {
                // alfa ConStr
                alfaConStr p_Connection = new alfaConStr(alfaEntity.ConnStr_DeCrypt());

                // Set Datasource
                p_Connection.SetDataSource(p_DataSource);

                // Set TimeOut
                p_Connection.SetTimeOut("5");

                // Test Connection
                using (alfaDS ent = new alfaDS(p_Connection.sbENT.ConnectionString))
                {
                    // Wait
                    alfaMsg.CursorWait();

                    // Test
                    var qry = ent.Context.TableUser.ToList();

                    // Default
                    alfaMsg.CursorDefult();

                    // Message
                    p_Result = " SQL Server was Successfully Tested ...!";

                    // Pass
                    return p_Connection.sbENT.ConnectionString;
                }
            }
            catch (Exception ex)
            {
                // Set Message
                p_Result = ex.Message;

                // Return
                return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Copy(Object p_Source, Object p_Target)
        {
            try
            {
                // Copy Properties
                foreach (var prop in p_Source.GetType().GetProperties() )
	            {
                    // Check Name
                    if (prop.Name == "EntityState" || prop.Name == "EntityKey") continue;

                    // Get Value
                    var newValue = prop.GetValue(p_Source, null);

                    // Check
                    if (p_Target.GetType().GetProperty(prop.Name) != null)
                    {
                        // Set Value
                        p_Target.GetType().GetProperty(prop.Name).SetValue(p_Target, newValue, null);
                    }
	            }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Copy(Object p_Source, Object p_Target, string p_SkipFields)
        {
            try
            {
                // Copy Properties
                foreach (var prop in p_Source.GetType().GetProperties() )
	            {
                    // Check Name
                    if (prop.Name == "EntityState" || prop.Name == "EntityKey" || p_SkipFields.Contains(prop.Name)) continue;

                    // Get Value
                    var newValue = prop.GetValue(p_Source, null);

                    // Check
                    if (p_Target.GetType().GetProperty(prop.Name) != null)
                    {
                        // Set Value
                        p_Target.GetType().GetProperty(prop.Name).SetValue(p_Target, newValue, null);
                    }
	            }
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Check(Object p_Source, Object p_Target)
        {
            try
            { 
                // Copy Properties
                foreach (var prop in p_Source.GetType().GetProperties())
	            {
                    // Check
                    if (prop.Name == "EntityState" || prop.Name == "EntityKey") continue;

                    // Get Value Source
                    var p_ValueSource = prop.GetValue(p_Source, null);

                    // Get Value Target
                    var p_ValueTarget = p_Target.GetType().GetProperty(prop.Name).GetValue(p_Target, null);

                    // Check1
                    if (p_ValueTarget == null && p_ValueSource == null) continue;

                    // Check2
                    else if (p_ValueTarget == null && p_ValueSource != null) return false;

                    // Check3
                    else if (p_ValueTarget != null && p_ValueSource == null) return false;

                    // Check4
                    if (!p_ValueSource.Equals(p_ValueTarget)) return false;
	            }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return false;
            }
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Fill_ComboBox_Field(ComboBoxEdit p_ComboBox, bool p_AddAll, string p_Table, string p_Field)
        { 
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = alfaEntity.Table_GetDistinctValues_Field(p_Table, p_Field);

                // Clear
                p_ComboBox.Properties.Items.Clear();

                // Add First Item
                if (p_AddAll) p_ComboBox.Properties.Items.Add("ALL");

                // Add to Combo
                foreach (var row in qry.ToList())
                {
                    // Add Item
                    if (!string.IsNullOrEmpty(row)) p_ComboBox.Properties.Items.Add(row);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<string> Table_GetDistinctValues_Field(string p_Table, string p_Field)
        {  
            // SQL String
            string p_SQL = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {1} IS NOT NULL ORDER BY {1}", p_Table, p_Field);

            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Query
                    var qry = DS.Context.Database.SqlQuery<string>(p_SQL).ToList();

                    // Return
                    return qry;
                }
            }
            catch
            {
                // Error
                return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TableSession> TableSession_GetList(DateTime p_DateStart, DateTime p_DateFinish)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TableSession where tt.SessionStart >= p_DateStart && tt.SessionStart <= p_DateFinish select tt;

                // Return
                return qry.OrderBy(tt => tt.Status).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableSession_Add()
        {
            // Check Admin
            if (alfaSession.UserName == "ADMIN") return;

            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Create
                    TableSession p_Session = new TableSession();

                    // Set Properties
                    p_Session.SessionStart = DateTime.Now;
                    p_Session.SessionFinish = null;
                    p_Session.ElapsedTime = null;
                    p_Session.IPAddress = alfaSession.LocIP;
                    p_Session.AppVersion = alfaSession.AppVer;
                    p_Session.NetVersion = alfaSession.NetVer;
                    p_Session.PCName = alfaSession.PC;
                    p_Session.Status = alfaStr.ACTIVE;
                    p_Session.UserName = alfaSession.UserAtGroup;

                    // Add
                    DS.Context.TableSession.Add(p_Session);

                    // Save
                    DS.Context.SaveChanges();

                    // Set ID
                    alfaSession.SessionID = p_Session.ID;
                }
            }

            catch
            {
                // NULL
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableSession_Close()
        {
            // Check
            if (alfaSession.SessionID == 0) return;

            // Check Admin
            if (alfaSession.UserName == "ADMIN") return;

            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    // Get Record
                    var p_Session = DS.Context.TableSession.Where(tt => tt.ID == alfaSession.SessionID).Single();

                    // Set Properties
                    p_Session.SessionFinish = DateTime.Now;

                    // Set Properties
                    DateTime p_DateTime01 = Convert.ToDateTime(p_Session.SessionStart.Value);
                    DateTime p_DateTime02 = Convert.ToDateTime(p_Session.SessionFinish.Value);

                    // Set ElapsedTime
                    p_Session.ElapsedTime = Convert.ToInt64((p_DateTime02 - p_DateTime01).TotalSeconds);

                    // Close Session
                    p_Session.Status = alfaStr.CLOSED;

                    // Save
                    DS.Context.SaveChanges();
                }
            }

            catch
            {
                // NULL
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterCisco_InsertUpdate(TableRouterCisco p_Row, List<DataLOG> p_ListLOG, ref int p_Insert, ref int p_Update)
        {
            using (alfaDS DS = new alfaDS())
            {
                try
                {
                    // =============== ALARM ======================//

                    // Create Router
                    var p_Router = new TableRouterCisco();

                    // Copy Fields
                    alfaEntity.Copy(p_Row, p_Router);

                    // Select Record
                    var qry = DS.Context.TableRouterCisco.Where(tt => tt.SiteName == p_Row.SiteName);

                    // Check Record
                    if (qry.Count() == 0)
                    {
                        // Add 
                        DS.Context.TableRouterCisco.Add(p_Router);

                        // Count Insert
                        p_Insert++;
                    }
                    else
                    {
                        // Get
                        var p_RouterDB = qry.First();

                        // Copy Fields
                        alfaEntity.Copy(p_Router, p_RouterDB, "ID");

                        // Count Update
                        p_Update++;
                    }

                    // Save
                    DS.Context.SaveChanges();
                }

                catch (Exception ex)
                {
                    // AddLog
                    alfaEntity.AddLog(p_Row.ID.ToString(), ex.ToString(), p_ListLOG);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterHuawei_InsertUpdate(TableRouterCisco p_Row, List<DataLOG> p_ListLOG, ref int p_Insert, ref int p_Update)
        {
            using (alfaDS DS = new alfaDS())
            {
                try
                {
                    // =============== ALARM ======================//

                    // Create Router
                    var p_Router = new TableRouterHuawei();

                    // Copy Fields
                    alfaEntity.Copy(p_Row, p_Router);

                    // Select Record
                    var qry = DS.Context.TableRouterHuawei.Where(tt => tt.SiteName == p_Row.SiteName);

                    // Check Record
                    if (qry.Count() == 0)
                    {
                        // Add 
                        DS.Context.TableRouterHuawei.Add(p_Router);

                        // Count Insert
                        p_Insert++;
                    }
                    else
                    {
                        // Get
                        var p_RouterDB = qry.First();

                        // Copy Fields
                        alfaEntity.Copy(p_Router, p_RouterDB, "ID");

                        // Count Update
                        p_Update++;
                    }

                    // Save
                    DS.Context.SaveChanges();
                }

                catch (Exception ex)
                {
                    // AddLog
                    alfaEntity.AddLog(p_Row.ID.ToString(), ex.ToString(), p_ListLOG);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterAlcatel_InsertUpdate(TableRouterCisco p_Row, List<DataLOG> p_ListLOG, ref int p_Insert, ref int p_Update)
        {
            using (alfaDS DS = new alfaDS())
            {
                try
                {
                    // =============== ALARM ======================//

                    // Create Router
                    var p_Router = new TableRouterAlcatel();

                    // Copy Fields
                    alfaEntity.Copy(p_Row, p_Router);

                    // Select Record
                    var qry = DS.Context.TableRouterAlcatel.Where(tt => tt.SiteName == p_Row.SiteName);

                    // Check Record
                    if (qry.Count() == 0)
                    {
                        // Add 
                        DS.Context.TableRouterAlcatel.Add(p_Router);

                        // Count Insert
                        p_Insert++;
                    }
                    else
                    {
                        // Get
                        var p_RouterDB = qry.First();

                        // Copy Fields
                        alfaEntity.Copy(p_Router, p_RouterDB, "ID");

                        // Count Update
                        p_Update++;
                    }

                    // Save
                    DS.Context.SaveChanges();
                }

                catch (Exception ex)
                {
                    // AddLog
                    alfaEntity.AddLog(p_Row.ID.ToString(), ex.ToString(), p_ListLOG);
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void AddLog(string p_Name, string p_Message, List<DataLOG> p_ListLOG)
        {
            // Create
            DataLOG p_Log = new DataLOG();

            // Assign
            p_Log.ITEM_NAME = p_Name;
            p_Log.ERROR_TEXT = p_Message;
            p_Log.USERNAME = alfaSession.UserAtGroup;
            p_Log.DATETIME = DateTime.Now.ToString();

            // Add
            p_ListLOG.Add(p_Log);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static TableRouterCisco TableRouterCisco_Get(string p_SiteName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterCisco.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() == 0) return null; else return p_Query.First();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static TableRouterHuawei TableRouterHuawei_Get(string p_SiteName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterHuawei.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() == 0) return null; else return p_Query.First();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static TableRouterAlcatel TableRouterAlcatel_Get(string p_SiteName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterAlcatel.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() == 0) return null; else return p_Query.First();

            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterCisco_UpdateConnection(string p_SiteName, string p_Connection)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterCisco.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() > 0)
                {
                    // Get Port
                    var p_Port = p_Query.First();

                    // Set Connection
                    p_Port.Connection = p_Connection;

                    // Save
                    DS.Context.SaveChanges();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterHuawei_UpdateConnection(string p_SiteName, string p_Connection)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterHuawei.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() > 0)
                {
                    // Get Port
                    var p_Port = p_Query.First();

                    // Set Connection
                    p_Port.Connection = p_Connection;

                    // Save
                    DS.Context.SaveChanges();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void TableRouterAlcatel_UpdateConnection(string p_SiteName, string p_Connection)
        {
            using (alfaDS DS = new alfaDS())
            {
                // query
                var p_Query = DS.Context.TableRouterAlcatel.Where(tt => tt.SiteName == p_SiteName);

                // Return
                if (p_Query.Count() > 0)
                {
                    // Get Port
                    var p_Port = p_Query.First();

                    // Set Connection
                    p_Port.Connection = p_Connection;

                    // Save
                    DS.Context.SaveChanges();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static TablePortAvea TablePortAvea_Get(string p_PortType, string p_SiteName)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAvea
                          where tt.PortType == p_PortType
                          && tt.SiteName == p_SiteName
                          select tt;

                // Return
                if (qry.Count() > 0) return qry.First(); else return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TablePortAvea> TablePortAvea_GetList(string p_PortType, string p_SiteName, string p_Status)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = DS.Context.TablePortAvea.Where(tt => tt.PortType == p_PortType);

                // Parameter I
                if (p_SiteName != "ALL")
                {
                    qry = qry.Where(tt => tt.SiteName == p_SiteName);
                }

                // Parameter II
                if (p_Status != "ALL")
                {
                    qry = qry.Where(tt => tt.Status == p_Status);
                }
                else
                {
                    qry = qry.Where(tt => tt.Status != alfaStr.DELETED);
                }

                // Return
                return qry.OrderBy(tt => tt.ID).ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> TablePortAvea_SaveHuawei_Task(List<PortAvea> p_List, TableRouterHuawei p_Router)
        {
            // Return Async Result
            return Task.Run<string>(() => { return alfaEntity.TablePortAvea_SaveHuawei(p_List, p_Router); });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string TablePortAvea_SaveHuawei(List<PortAvea> p_List, TableRouterHuawei p_Router)
        {
            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    //______________________________STATUS = DELETED________________________________//

                    // Get List
                    var qryUpdate = DS.Context.TablePortAvea.Where(tt => tt.SiteName == p_Router.SiteName).ToList();

                    // Set Deleted
                    foreach (var p_Port in qryUpdate) p_Port.Status = alfaStr.DELETED;

                    // Save Changes
                    DS.Context.SaveChanges();

                    //______________________________________________________________________________//

                    foreach (var p_Port in p_List)
                    {
                        // Query
                        var qry = from tt in DS.Context.TablePortAvea
                                  where tt.PortType == "HUAWEI"
                                  && tt.SiteName == p_Port.SiteName
                                  && tt.PortName == p_Port.PortName
                                  select tt;

                        if (qry.Count() > 0) // UPDATE
                        {
                            // Port
                            var p_PortAvea_DB = qry.First();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Set Log
                            p_PortAvea_DB.Logs = alfaEntity.AddLogV2(p_PortAvea_DB.Logs, alfaStr.REFRESHED, p_PortAvea_DB.Description, p_Port.Description);

                            // Assign
                            p_PortAvea_DB.Description = p_Port.Description;
                            p_PortAvea_DB.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_DB.OprState = p_Port.OprState.ToUpper();

                            // Set Status
                            p_PortAvea_DB.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_DB);

                            // Clear Reserv Text
                            if (p_PortAvea_DB.Status != alfaStr.REQUEST) p_PortAvea_DB.ReservDescription = string.Empty;

                            // Set DateTime
                            p_PortAvea_DB.UpdateDatetime = DateTime.Now;
                            p_PortAvea_DB.UpdateUsername = alfaSession.UserAtGroup;
                        }

                        else // INSERT
                        {
                            // Create
                            var p_PortAvea_New = new TablePortAvea();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Assign
                            p_PortAvea_New.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_New.OprState = p_Port.OprState.ToUpper();
                            p_PortAvea_New.Description = p_Port.Description;
                            p_PortAvea_New.PortName = p_Port.PortName;
                            p_PortAvea_New.PortType = "HUAWEI";
                            p_PortAvea_New.SiteIP = p_Router.SiteIP;
                            p_PortAvea_New.SiteName = p_Router.SiteName;

                            // Set Status
                            p_PortAvea_New.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_New);

                            // Set Log
                            p_PortAvea_New.Logs = alfaEntity.AddLogV1(p_PortAvea_New.Logs, "INSERTED");

                            // Set DateTime
                            p_PortAvea_New.UpdateDatetime = DateTime.Now;
                            p_PortAvea_New.UpdateUsername = alfaSession.UserAtGroup;

                            // Add
                            DS.Context.TablePortAvea.Add(p_PortAvea_New);
                        }

                        // Save
                        DS.Context.SaveChanges();
                    }
                }

                // Return
                return "OK";
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return "FAIL";
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> TablePortAvea_SaveCisco_Task(List<PortAvea> p_List, TableRouterCisco p_Router)
        {
            // Return Async Result
            return Task.Run<string>(() => { return alfaEntity.TablePortAvea_SaveCisco(p_List, p_Router); });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string TablePortAvea_SaveCisco(List<PortAvea> p_List, TableRouterCisco p_Router)
        {
            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    //______________________________STATUS = DELETED________________________________//

                    // Get List
                    var qryUpdate = DS.Context.TablePortAvea.Where(tt => tt.SiteName == p_Router.SiteName).ToList();

                    // Set Deleted
                    foreach (var p_Port in qryUpdate) p_Port.Status = alfaStr.DELETED;

                    // Save Changes
                    DS.Context.SaveChanges();

                    //______________________________________________________________________________//

                    foreach (var p_Port in p_List)
                    {
                        // Query
                        var qry = from tt in DS.Context.TablePortAvea
                                  where tt.PortType == "CISCO"
                                  && tt.SiteName == p_Port.SiteName
                                  && tt.PortName == p_Port.PortName
                                  select tt;

                        if (qry.Count() > 0) // UPDATE
                        {
                            // Port
                            var p_PortAvea_DB = qry.First();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Set Log
                            p_PortAvea_DB.Logs = alfaEntity.AddLogV2(p_PortAvea_DB.Logs, alfaStr.REFRESHED, p_PortAvea_DB.Description, p_Port.Description);

                            // Assign
                            p_PortAvea_DB.PortType = "CISCO";
                            p_PortAvea_DB.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_DB.OprState = p_Port.OprState.ToUpper();
                            p_PortAvea_DB.Description = p_Port.Description;

                            // Set Status
                            p_PortAvea_DB.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_DB);

                            // Clear Reserv Text
                            if (p_PortAvea_DB.Status != alfaStr.REQUEST) p_PortAvea_DB.ReservDescription = string.Empty;

                            // Set DateTime
                            p_PortAvea_DB.UpdateDatetime = DateTime.Now;
                            p_PortAvea_DB.UpdateUsername = alfaSession.UserAtGroup;
                        }

                        else // INSERT
                        {
                            // Create
                            var p_PortAvea_New = new TablePortAvea();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Assign
                            p_PortAvea_New.PortType = "CISCO";
                            p_PortAvea_New.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_New.OprState = p_Port.OprState.ToUpper();
                            p_PortAvea_New.Description = p_Port.Description;
                            p_PortAvea_New.PortName = p_Port.PortName;
                            p_PortAvea_New.SiteIP = p_Router.SiteIP;
                            p_PortAvea_New.SiteName = p_Router.SiteName;

                            // Set Status
                            p_PortAvea_New.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_New);

                            // Set Log
                            p_PortAvea_New.Logs = alfaEntity.AddLogV1(p_PortAvea_New.Logs, "INSERTED");

                            // Set DateTime
                            p_PortAvea_New.UpdateDatetime = DateTime.Now;
                            p_PortAvea_New.UpdateUsername = alfaSession.UserAtGroup;

                            // Add
                            DS.Context.TablePortAvea.Add(p_PortAvea_New);
                        }

                        // Save
                        DS.Context.SaveChanges();
                    }
                }

                // Return
                return "OK";
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return "FAIL";
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> TablePortAvea_SaveAlcatel_Task(List<PortAvea> p_List, TableRouterAlcatel p_Router)
        {
            // Return Async Result
            return Task.Run<string>(() => { return alfaEntity.TablePortAvea_SaveAlcatel(p_List, p_Router); });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string TablePortAvea_SaveAlcatel(List<PortAvea> p_List, TableRouterAlcatel p_Router)
        {
            try
            {
                using (alfaDS DS = new alfaDS())
                {
                    //______________________________STATUS = DELETED________________________________//

                    // Get List
                    var qryUpdate = DS.Context.TablePortAvea.Where(tt => tt.SiteName == p_Router.SiteName).ToList();

                    // Set Deleted
                    foreach (var p_Port in qryUpdate) p_Port.Status = alfaStr.DELETED;

                    // Save Changes
                    DS.Context.SaveChanges();

                    //______________________________________________________________________________//

                    foreach (var p_Port in p_List)
                    {
                        // Query
                        var qry = from tt in DS.Context.TablePortAvea
                                  where tt.PortType == "ALCATEL"
                                  && tt.SiteName == p_Port.SiteName
                                  && tt.PortName == p_Port.PortName
                                  select tt;

                        if (qry.Count() > 0) // UPDATE
                        {
                            // Port
                            var p_PortAvea_DB = qry.First();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Set Log
                            p_PortAvea_DB.Logs = alfaEntity.AddLogV2(p_PortAvea_DB.Logs, alfaStr.REFRESHED, p_PortAvea_DB.Description, p_Port.Description);

                            // Assign
                            p_PortAvea_DB.PortType = "ALCATEL";
                            p_PortAvea_DB.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_DB.OprState = p_Port.OprState.ToUpper();
                            p_PortAvea_DB.Description = p_Port.Description;
                            p_PortAvea_DB.SFPType = p_Port.SFPType;
                            p_PortAvea_DB.PRTType = p_Port.PRTType;

                            // Set Status
                            p_PortAvea_DB.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_DB);

                            // Clear Reserv Text
                            if (p_PortAvea_DB.Status != alfaStr.REQUEST) p_PortAvea_DB.ReservDescription = string.Empty;

                            // Set DateTime
                            p_PortAvea_DB.UpdateDatetime = DateTime.Now;
                            p_PortAvea_DB.UpdateUsername = alfaSession.UserAtGroup;
                        }

                        else // INSERT
                        {
                            // Create
                            var p_PortAvea_New = new TablePortAvea();

                            // Trim Description
                            if (p_Port.Description != null) p_Port.Description = p_Port.Description.TrimEnd(' ');

                            // Assign
                            p_PortAvea_New.PortType = "ALCATEL";
                            p_PortAvea_New.AdmState = p_Port.AdmState.ToUpper();
                            p_PortAvea_New.OprState = p_Port.OprState.ToUpper();
                            p_PortAvea_New.Description = p_Port.Description;
                            p_PortAvea_New.PortName = p_Port.PortName;
                            p_PortAvea_New.SiteIP = p_Router.SiteIP;
                            p_PortAvea_New.SiteName = p_Router.SiteName;
                            p_PortAvea_New.SFPType = p_Port.SFPType;

                            // Set Status
                            p_PortAvea_New.Status = alfaNET.Avea_GetPortStatus(p_PortAvea_New);

                            // Set Log
                            p_PortAvea_New.Logs = alfaEntity.AddLogV1(p_PortAvea_New.Logs, "INSERTED");

                            // Set DateTime
                            p_PortAvea_New.UpdateDatetime = DateTime.Now;
                            p_PortAvea_New.UpdateUsername = alfaSession.UserAtGroup;

                            // Add
                            DS.Context.TablePortAvea.Add(p_PortAvea_New);
                        }

                        // Save
                        DS.Context.SaveChanges();
                    }
                }

                // Return
                return "OK";
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return "FAIL";
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable Alcatel_Report_A(string p_SiteName, string p_PortStatusFiter)
        {
            try
            {
                // Get Lists
                var p_ListStatus = alfaEntity.Table_GetDistinctValues_Field("TablePortAvea", "Status");
                var p_ListSfpTye = alfaEntity.Table_GetDistinctValues_Field("TablePortAvea", "SfpType");

                // Trim Values
                for (int li = 0; li < p_ListSfpTye.Count - 1; li++) p_ListSfpTye[li] = p_ListSfpTye[li].TrimEnd();

                // Result Table
                DataTable p_ResultTable = new DataTable();

                // Add Column    
                p_ResultTable.Columns.Add("SiteName");
                p_ResultTable.Columns.Add("PortStatus");

                // Add SfpTypes
                foreach (var p_SfpType in p_ListSfpTye) p_ResultTable.Columns.Add(p_SfpType, typeof(int));

                foreach (var p_PortStatus in p_ListStatus)
                {
                    // Check
                    if (p_PortStatusFiter != "ALL" && p_PortStatusFiter != p_PortStatus) continue;

                    // Check
                    if (p_PortStatus == alfaStr.DELETED) continue;

                    // NewRow
                    var p_NewRow = p_ResultTable.NewRow();

                    p_NewRow["SiteName"] = p_SiteName;
                    p_NewRow["PortStatus"] = p_PortStatus;

                    foreach (var p_SfpType in p_ListSfpTye)
                    {
                        // Get Count
                        p_NewRow[p_SfpType] = alfaEntity.TablePortAvea_GetCount_V1("ALCATEL", p_SiteName, p_PortStatus, p_SfpType);
                    }

                    // Add Row
                    p_ResultTable.Rows.Add(p_NewRow);
                }

                // Return
                return p_ResultTable;
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable Alcatel_Report_B(string p_SiteType, string p_PortStatus)
        {
            try
            {
                // Get Lists
                var p_List_Sites = alfaEntity.Table_GetDistinctValues_Field("TableRouterAlcatel", "SiteName");
                var p_List_SfpTyes = alfaEntity.Table_GetDistinctValues_Field("TablePortAvea", "SfpType");

                // SiteType
                p_SiteType = string.Format("_{0}_", p_SiteType);

                // Filter Sites
                if (p_SiteType != "_ALL_") p_List_Sites = p_List_Sites.Where(tt => tt.Contains(p_SiteType)).ToList();

                // Result Table
                DataTable p_ResultTable = new DataTable();

                // Add Column    
                p_ResultTable.Columns.Add("SiteName");

                // Add SfpTypes
                foreach (var p_SfpType in p_List_SfpTyes) p_ResultTable.Columns.Add(p_SfpType, typeof(int));

                // Casche Source
                alfaEntity.m_List_Alcatel_Routers = alfaEntity.TablePortAvea_GetAlcatel(p_SiteType);

                foreach (var p_SiteName in p_List_Sites)
                {
                    // NewRow
                    var p_NewRow = p_ResultTable.NewRow();

                    p_NewRow["SiteName"] = p_SiteName;

                    foreach (var p_SfpType in p_List_SfpTyes)
                    {
                        // Get Count
                        p_NewRow[p_SfpType] = alfaEntity.TablePortAvea_GetCount_V2("ALCATEL", p_SiteName, p_PortStatus, p_SfpType);
                    }

                    // Add Row
                    p_ResultTable.Rows.Add(p_NewRow);
                }

                // Return
                return p_ResultTable;
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex); return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static int TablePortAvea_GetCount_V1(string p_PortType, string p_SiteName, string p_PortStatus, string p_SfpType)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAvea
                          where tt.PortType == p_PortType
                          && tt.SiteName == p_SiteName
                          && tt.Status == p_PortStatus
                          && tt.Status != alfaStr.DELETED
                          && tt.SFPType == p_SfpType
                          select tt;

                // return
                return qry.Count();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static int TablePortAvea_GetCount_V2(string p_PortType, string p_SiteName, string p_PortStatus, string p_SfpType)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = //from tt in DS.Context.TablePortAvea
                          from tt in alfaEntity.m_List_Alcatel_Routers
                          where tt.PortType == p_PortType
                          && tt.SiteName == p_SiteName
                          && tt.Status != alfaStr.DELETED
                          && tt.SFPType == p_SfpType
                          select tt;

                // FREE Ports
                if (p_PortStatus == "FREE") qry = qry.Where(tt => tt.Status == "FREE");
                                       else qry = qry.Where(tt => tt.Status != "FREE");


                // return
                return qry.Count();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<TablePortAvea> TablePortAvea_GetAlcatel(string p_SiteType)
        {
            using (alfaDS DS = new alfaDS())
            {
                // Query
                var qry = from tt in DS.Context.TablePortAvea
                          where tt.PortType == "ALCATEL"
                          select tt;

                // Filter
                if (p_SiteType != "_ALL_") qry = qry.Where(tt => tt.SiteName.Contains(p_SiteType));

                // return
                return qry.ToList();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable CombineTableColumns(DataTable p_Table, string p_Field, string[] p_ListCols)
        {
            if (!p_Table.Columns.Contains(p_Field))
            {
                // Add Field
                p_Table.Columns.Add(p_Field, typeof(int));
            }

            foreach (DataRow p_Row in p_Table.Rows)
            {
                foreach (var p_Col in p_ListCols)
                {
                    // Add Values
                    if (p_Table.Columns.Contains(p_Col))
                    {
                        // Check
                        if (p_Row[p_Field] == DBNull.Value) p_Row[p_Field] = 0;

                        // Assign
                        p_Row[p_Field] = (int)p_Row[p_Field] + (int)p_Row[p_Col];
                    }
                }
            }

            // Delete Columns
            alfaEntity.DeleteTableColumns(p_Table, p_ListCols);

            // return
            return p_Table;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable DeleteTableColumns(DataTable p_Table, string[] p_ListCols)
        {
            foreach (var p_Col in p_ListCols)
            {
                // Remove Columns
                if (p_Table.Columns.Contains(p_Col)) p_Table.Columns.Remove(p_Col);
            }

            // return
            return p_Table;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable DeleteTableColumns(DataTable p_Table, List<string> p_ListCols)
        {
            foreach (var p_Col in p_ListCols)
            {
                // Remove Columns
                if (p_Table.Columns.Contains(p_Col)) p_Table.Columns.Remove(p_Col);
            }

            // return
            return p_Table;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void DeleteZeroTableColumns(DataTable p_Table)
        {
            // Create
            var p_ListCols = new List<string>();

            foreach (DataColumn p_Col in p_Table.Columns)
            {
                // Check
                int p_Check = 0;

                // Check Int Value
                if  (!alfaEntity.IsValueNumeric(p_Col)) continue;

                foreach (DataRow p_Row in p_Table.Rows)
                {
                    p_Check += int.Parse(p_Row[p_Col].ToString());
                }

                // Add Delete List
                if (p_Check == 0) p_ListCols.Add(p_Col.ColumnName);
            }

            // Delete Columns
            alfaEntity.DeleteTableColumns(p_Table, p_ListCols);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool IsValueNumeric(DataColumn p_Col)
        {
            // Check
            if (p_Col == null) return false;

            // Make this const
            var numericTypes = new[] { typeof(Byte), typeof(Decimal), typeof(Double), typeof(Int16), typeof(Int32), typeof(Int64), typeof(SByte), typeof(Single), typeof(UInt16), typeof(UInt32), typeof(UInt64) };

            // Return
            return numericTypes.Contains(p_Col.DataType);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static DataTable TrimTableColumns(DataTable p_Table)
        {
            for (int li = 0; li < p_Table.Columns.Count; li++)
            {
                // Trim Column Name
                p_Table.Columns[li].ColumnName = p_Table.Columns[li].ColumnName.TrimEnd();
            }

            // return
            return p_Table;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    }

    # endregion 

}