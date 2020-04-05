using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using DevExpress.XtraTab;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using Rebex.TerminalEmulation;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;


namespace PortMan2014
{
    class alfaNET
    {

    #region //----------- FIELDS --------//

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string m_AlcMinV = "3";                                       // Alcatel User
        public static string m_AlcUser = "pbndata";                                 // Alcatel User
        public static string m_AlcPass = "Formula12";                               // Alcatel Pass
        public static string m_AlcAdd1 = "10.19.43.72";                             // Alcatel Address1
        public static string m_AlcAdd2 = "172.28.138.72";                           // Alcatel Address2
        public static string m_RtrUser = "portman";                                 // Router User
        public static string m_RtrPass = "Nwdesing12!";                             // Router Pass
        public static string m_SamUser = "pbndata";                                 // SAM User
        public static string m_SamPass = "89a37cbff1d93fed3850a9d02874b952";        // SAM Pass
        public static string m_SamAdd1 = "http://10.19.43.72:8080/xmlapi/invoke";   // SAM Address
        public static string m_SamAdd2 = "http://172.28.138.72:8080/xmlapi/invoke"; // SAM Address
        public static string m_FtpUser = "pbn";                                     // FTP User
        public static string m_FtpPass = "pbn";                                     // FTP Pass
        public static string m_FtpAdd1 = "10.19.43.72";                             // FTP Address1
        public static string m_FtpAdd2 = "172.28.138.72";                           // FTP Address2
        public static string m_FtpPath = "/opt/5620sam/server/xml_output/PBNDATA/"; // FTP Path
        public static string m_LocPath = "D:\\SAM\\";                               // Local Path
        public static string FileName { get; set; }                                 // Processing FileName
        public static string FileNameRem { get; set; }                              // Processing FileName Remote
        public static string FileNameLoc { get; set; }                              // Processing FileName Local
        public static FrmMain FrmMain { get; set; }                                 // Application Main Form
        public static bool IsRunning { get; set; }                                  // Runnig Process
        public static string BreakMessage = "AutoRun is Stopped by";                // Break Message
        public static string BreakUser { get; set; }                                // Break User

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        #endregion



    #region //----------- SYSTEM --------//

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string Avea_GetPortStatus(TablePortAvea p_Port)
        {
            // Get Status
            if (p_Port.OprState.Contains("DOWN") && p_Port.AdmState.Contains("DOWN"))
            {
                if (p_Port.Status == "RESERVED") return "RESERVED";
                else if (p_Port.Description != null && p_Port.Description.ToUpper().Contains("RESERV")) return "RESERVED"; else return "FREE";
            }

            else if (p_Port.OprState.Contains("UP") && p_Port.AdmState.Contains("DOWN")) return "FREE";
            else if (p_Port.OprState.Contains("UP") && p_Port.AdmState.Contains("UP")) return "USED";
            else if (p_Port.OprState.Contains("DOWN") && p_Port.AdmState.Contains("UP") && !string.IsNullOrEmpty(p_Port.Description)) return "USED";
            else return "ERROR";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Start(XtraTabPage p_PageActive)
        {
            // Start
            alfaNET.IsRunning = true;

            // Set TabPage
            alfaNET.SetTabPage(p_PageActive);

            // Parameters
            alfaNET.Set_Parameters_FromDB();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Start(Timer p_Timer, XtraTabPage p_PageActive)
        {
            // Start
            alfaNET.IsRunning = true;

            // Set TabPage
            alfaNET.SetTabPage(p_PageActive);

            // Start Timer
            p_Timer.Start();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetTabPage(XtraTabPage p_PageActive)
        {
            foreach (var p_Page in alfaNET.FrmMain.tabMain.TabPages.ToList())
            {
                // Disable All Pages
                if (p_Page != p_PageActive) p_Page.PageEnabled = false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Stop()
        {
            if (alfaNET.FrmMain.InvokeRequired)
            {
                // Thread Safe
                alfaNET.FrmMain.Invoke(new MethodInvoker(() => { alfaNET.Stop(); }));
            }
            else
            {
                // Start
                alfaNET.IsRunning = false;

                // Enable Pages
                alfaNET.FrmMain.tabMain.TabPages.ToList().ForEach(tt => tt.PageEnabled = true);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Set_Parameters_FromDB()
        {
            // Set Parameters

            alfaEntity.TablePrms_SetAppValue("AlcMinV", ref alfaNET.m_AlcMinV);
            alfaEntity.TablePrms_SetAppValue("AlcUser", ref alfaNET.m_AlcUser);
            alfaEntity.TablePrms_SetAppValue("AlcPass", ref alfaNET.m_AlcPass);
            alfaEntity.TablePrms_SetAppValue("AlcAdd1", ref alfaNET.m_AlcAdd1);
            alfaEntity.TablePrms_SetAppValue("AlcAdd2", ref alfaNET.m_AlcAdd2);
            alfaEntity.TablePrms_SetAppValue("RtrUser", ref alfaNET.m_RtrUser);
            alfaEntity.TablePrms_SetAppValue("RtrPass", ref alfaNET.m_RtrPass);
            alfaEntity.TablePrms_SetAppValue("SamUser", ref alfaNET.m_SamUser);
            alfaEntity.TablePrms_SetAppValue("SamPass", ref alfaNET.m_SamPass);
            alfaEntity.TablePrms_SetAppValue("SamAdd1", ref alfaNET.m_SamAdd1);
            alfaEntity.TablePrms_SetAppValue("SamAdd2", ref alfaNET.m_SamAdd2);
            alfaEntity.TablePrms_SetAppValue("FtpUser", ref alfaNET.m_FtpUser);
            alfaEntity.TablePrms_SetAppValue("FtpPass", ref alfaNET.m_FtpPass);
            alfaEntity.TablePrms_SetAppValue("FtpPath", ref alfaNET.m_FtpPath);
            alfaEntity.TablePrms_SetAppValue("FtpAdd1", ref alfaNET.m_FtpAdd1);
            alfaEntity.TablePrms_SetAppValue("FtpAdd2", ref alfaNET.m_FtpAdd2);
            alfaEntity.TablePrms_SetAppValue("LocPath", ref alfaNET.m_LocPath);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_OK()
        {
            // Stop    
            alfaNET.Stop();

            // Set OK
            //alfaNET.Status_Text("OK", alfaNET.PortCount, alfaNET.PortTotal, Color.Green);
            alfaNET.Status_Text("OK", Color.Green);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_Text(string p_Text, Color p_Color)
        {
            if (alfaNET.FrmMain !=null)
            {
                // Caption
                string p_Caption = string.Format("{0}", p_Text);

                // Status
                alfaCtrl.SetText(alfaNET.FrmMain.statusResult, p_Caption, p_Color);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetConnection(string p_Text)
        {
            if (alfaNET.FrmMain !=null)
            {
                // Caption
                string p_Caption = string.Format("{0}", p_Text);

                // Status
                alfaCtrl.SetText(alfaNET.FrmMain.statusConnection, p_Caption, Color.Lime);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_Text(string p_Text, int p_Count, int p_Total, Color p_Color)
        {
            if (alfaNET.FrmMain.InvokeRequired)
            {
                // Thread Safe
                alfaNET.FrmMain.Invoke(new MethodInvoker(() => { alfaNET.Status_Text(p_Text, p_Count, p_Total, p_Color); }));
            }
            else
            if (alfaNET.FrmMain !=null)
            {
                // Caption
                string p_Caption = string.Format("{0} ( Ports = {1} / {2} )", p_Text, p_Count, p_Total);

                // Status
                alfaCtrl.SetText(alfaNET.FrmMain.statusResult, p_Caption, p_Color);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_ERROR(string p_Message)
        {
            // Stop
            alfaNET.Stop();

            // Error
            alfaMsg.Error(p_Message);

            // Status
            alfaCtrl.SetText(alfaNET.FrmMain.statusResult, p_Message, Color.Red);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_STOPPED()
        {
            // Status
            alfaCtrl.SetText(alfaNET.FrmMain.statusResult, " STOPPED ", Color.Red);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Status_RUNNING()
        {
            // Set Running
            //alfaNET.Status_Text("RUNNING ... ! ", alfaNET.PortCount, alfaNET.PortTotal, Color.Lime);
            alfaNET.Status_Text("RUNNING ... ! ", Color.Lime);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Rebex_Run_V1(Scripting p_Script, string p_Text, string p_Wait)
        {
            // Set Timeout
            p_Script.Timeout = 5000;

            // Send Command
            p_Script.SendCommand(alfaStr.GetEnglishText(p_Text));

            // WaitCommand
            var p_Result = p_Script.WaitFor(ScriptEvent.FromString(p_Wait));

            // Return FAIL
            if (p_Script.ReceivedData.ToUpper().Contains("ERROR") || p_Script.ReceivedData.ToUpper().Contains("FAIL"))
            {
                throw new Exception(p_Script.ReceivedData);
            }

            // Return PASS
            else return p_Result.Success;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Rebex_Run_V2(Scripting p_Script, string p_Cmd1, string p_Wait1, string p_Wait2, string p_Cmd2)
        {
            // Set Timeout
            p_Script.Timeout = 5000;

            // Send Command
            p_Script.SendCommand(alfaStr.GetEnglishText(p_Cmd1));

            // WaitCommand
            var p_Result = p_Script.WaitFor(ScriptEvent.FromString(p_Wait1) | ScriptEvent.FromString(p_Wait2));

            // Return Fail
            if (p_Script.ReceivedData.ToUpper().Contains("ERROR") || p_Script.ReceivedData.ToUpper().Contains("FAIL"))
            {
                // Throw Exception
                throw new Exception(p_Script.ReceivedData);
            }

            else if (p_Script.ReceivedData.Contains(p_Wait2))
            {
                // Second Call
                return alfaNET.Rebex_Run_V1(p_Script, p_Cmd2, p_Wait1);
            }

            // Return PASS
            else return p_Result.Success;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void DetectPrompt(Scripting p_Script)
        {
            // Prompth
            string promptLine = "";

            while (true)
            {
                // Line
                string p_Line = p_Script.ReadUntil(ScriptEvent.FromRegex("[>$#]") & ScriptEvent.Delay(300));

                // Trim
                p_Line = p_Line.TrimStart();

                if (p_Line != promptLine)
                {
                    p_Script.Send(FunctionKey.Enter);
                    promptLine = p_Line;
                }
                else
                {
                    // Return
                    p_Script.Prompt = "string:" + promptLine; break;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    #endregion



    #region //----------- CISCO ---------//

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<bool> F1_Cisco_GetRouterPorts_Task(TableRouterCisco p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Return Async Result
            return Task.Run<bool>(() => { return alfaNET.F2_Cisco_GetRouterPorts(p_Router, p_GridView, p_MemoEdit); });
        }
         
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F2_Cisco_GetRouterPorts(TableRouterCisco p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Result
            bool p_Result = false;

            // Reset Values
            p_MemoEdit.Text = string.Empty;
            alfaGrid.SetView(p_GridView, null, true);

            // Outs
            string p_LogText = null;
            List<PortAvea> p_DataSource = null;

            // Get Router Ports
            p_Result = alfaNET.F3_Cisco_GetRouterPorts_SSH(p_Router, out p_DataSource, out p_LogText);

            // GridView
            alfaGrid.SetView(p_GridView, p_DataSource, true);

            // Logs
            alfaCtrl.SetText(p_MemoEdit, p_LogText);

            // Return
            return p_Result;
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F3_Cisco_GetRouterPorts_SSH(TableRouterCisco p_Router, out List<PortAvea> p_DataSource, out string p_LogText)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Connect
                    p_Rebex.Connect(p_Router.SiteIP);

                    // Login
                    p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                    // Scripting
                    Scripting p_Script = p_Rebex.StartScripting();

                    // DetectPrompt
                    alfaNET.DetectPrompt(p_Script);

                    // Run Command
                    alfaNET.Rebex_Run_V1(p_Script, "terminal width 0", "#");
                    alfaNET.Rebex_Run_V1(p_Script, "terminal length 0", "#");
                    alfaNET.Rebex_Run_V1(p_Script, "show interfaces description", "#");

                    // Get Lines
                    var p_Lines = p_Script.ReceivedData.Split('\n');

                    // Create List
                    var p_ListPorts = new List<PortAvea>();

                    for (int li = 1; li < p_Lines.Length - 1; li++)
                    {
                        // Port
                        var p_Port = new PortAvea();

                        // Tokens
                        var p_Tokens = p_Lines[li].Split(new string[] { " ", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                        // Parsing
                        for (int la = 0; la < p_Tokens.Length; la++)
                        {
                                 if (la == 0) p_Port.PortName = p_Tokens[la];
                            else if (la == 1) p_Port.AdmState = p_Tokens[la];
                            else if (la == 2) p_Port.OprState = p_Tokens[la];
                            else if (la >= 3) p_Port.Description += p_Tokens[la] + " ";
                        }

                        // PortID
                        p_Port.ID = p_ListPorts.Count() + 1;

                        // SiteName
                        p_Port.SiteName = p_Router.SiteName;

                        // Add
                        p_ListPorts.Add(p_Port);
                    }

                    // Set Outs
                    p_DataSource = p_ListPorts;
                    p_LogText = p_Script.ReceivedData;

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Set Outs
                p_DataSource = null;
                p_LogText = ex.Message;

                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F4_Cisco_ReservePorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    // Scripting
                    Scripting p_Script = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Connect
                            p_Rebex.Connect(p_Router_SiteIP);

                            // Login
                            p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                            // Scripting
                            p_Script = p_Rebex.StartScripting();

                            // DetectPrompt
                            alfaNET.DetectPrompt(p_Script);

                            // Command-I
                            if (!alfaNET.Rebex_Run_V1(p_Script, "configure terminal", "#")) return false;
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("interface GigabitEthernet {0}", p_Port.PortName.Substring(2));
                        var p_Cmd2 = string.Format("description  {0}", p_Port.ReservDescription);

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "#");
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd2, "#");
                        alfaNET.Rebex_Run_V1(p_Script, "exit", "#");

                        // Update Table                             
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.RESERVED, null, true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F5_Cisco_RollbackPorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    // Scripting
                    Scripting p_Script = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Connect
                            p_Rebex.Connect(p_Router_SiteIP);

                            // Login
                            p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                            // Scripting
                            p_Script = p_Rebex.StartScripting();

                            // DetectPrompt
                            alfaNET.DetectPrompt(p_Script);

                            // Command-I
                            if (!alfaNET.Rebex_Run_V1(p_Script, "configure terminal", "#")) return false;
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("interface GigabitEthernet {0}", p_Port.PortName.Substring(2));
                        var p_Cmd2 = string.Format("no description");

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "#");
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd2, "#");
                        alfaNET.Rebex_Run_V1(p_Script, "exit", "#");

                        // Update Table
                        p_Port.ReservDescription = string.Empty;
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.FREE, " (RollBack)", true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//


    #endregion



    #region //----------- HUAWEI --------//

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<bool> F1_Huawei_GetRouterPorts_Task(TableRouterHuawei p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Return Async Result
            return Task.Run<bool>(() => { return alfaNET.F2_Huawei_GetRouterPorts(p_Router, p_GridView, p_MemoEdit); });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F2_Huawei_GetRouterPorts(TableRouterHuawei p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Result
            bool p_Result = false;

            // Reset Values
            p_MemoEdit.Text = string.Empty;
            alfaGrid.SetView(p_GridView, null, true);

            // Outs
            string p_LogText = null;
            List<PortAvea> p_DataSource = null;

            // Get Router Ports
            //  if (p_Router.Connection == "SSH") 
            //     p_Result = alfaNET.Huawei_GetRouterPorts_SSH(p_Router, out p_DataSource, out p_LogText);
            //else p_Result = alfaNET.Huawei_GetRouterPorts_TEL(p_Router, out p_DataSource, out p_LogText);

            // Result
            p_Result = alfaNET.F3_Huawei_GetRouterPorts_SSH(p_Router, out p_DataSource, out p_LogText);

            // GridView
            alfaGrid.SetView(p_GridView, p_DataSource, true);

            // Logs
            alfaCtrl.SetText(p_MemoEdit, p_LogText);

            // Return
            return p_Result;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Huawei_GetRouterPorts_TEL(TableRouterHuawei p_Router, out List<PortAvea> p_DataSource, out string p_LogText)
        {
            // Script
            Scripting p_Script = null;

            try
            {
                // Status
                alfaNET.SetConnection("Connection : TEL");

                // Rebex
                var p_Rebex = new Rebex.Net.Telnet(p_Router.SiteIP);

                // Scripting
                p_Script = p_Rebex.StartScripting();

                // Run Command
                alfaNET.Rebex_Run_V1(p_Script, alfaNET.m_RtrUser, "password:");
                alfaNET.Rebex_Run_V1(p_Script, alfaNET.m_RtrPass, ">");

                // Run Command
                alfaNET.Rebex_Run_V1(p_Script, "system-view", "]");
                alfaNET.Rebex_Run_V1(p_Script, "user-interface current", "]");
                alfaNET.Rebex_Run_V1(p_Script, "screen-length 0", "]");
                alfaNET.Rebex_Run_V1(p_Script, "screen-width 200", "]");
                alfaNET.Rebex_Run_V1(p_Script, "y", "]");
                alfaNET.Rebex_Run_V1(p_Script, "display inter description", "]");

                // Get Lines
                var p_Lines = p_Script.ReceivedData.Split('\n');

                // Create List
                var p_ListPorts = new List<PortAvea>();

                for (int li = 11; li < p_Lines.Length - 1; li++)
                {
                    // Port
                    var p_Port = new PortAvea();

                    // Tokens
                    var p_Tokens = p_Lines[li].Split(new string[] { " ", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                    // Parsing
                    for (int la = 0; la < p_Tokens.Length; la++)
                    {
                        if (la == 0) p_Port.PortName = p_Tokens[la];
                        else if (la == 1) p_Port.AdmState = p_Tokens[la];
                        else if (la == 2) p_Port.OprState = p_Tokens[la];
                        else if (la >= 3) p_Port.Description += p_Tokens[la] + " ";
                    }

                    // PortID
                    p_Port.ID = p_ListPorts.Count() + 1;

                    // SiteName
                    p_Port.SiteName = p_Router.SiteName;

                    // Add
                    p_ListPorts.Add(p_Port);
                }

                // Set Outs
                p_DataSource = p_ListPorts;
                p_LogText = p_Script.ReceivedData;

                // Finish
                alfaNET.Status_OK();

                // Return
                return true;
            }

            catch (Exception ex)
            {
                // Set Outs
                p_LogText = ex.Message;
                p_DataSource = null;

                // Error
                alfaNET.Status_ERROR(ex.Message);
                
                // Return
                return false;
            }

            finally
            {
                // Close
                if (p_Script != null) p_Script.Close();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F3_Huawei_GetRouterPorts_SSH(TableRouterHuawei p_Router, out List<PortAvea> p_DataSource, out string p_LogText)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Connect
                    p_Rebex.Connect(p_Router.SiteIP);

                    // Login
                    p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                    // Scripting
                    Scripting p_Script = p_Rebex.StartScripting();

                    // DetectPrompt
                    p_Script.DetectPrompt();

                    // Run Command
                    alfaNET.Rebex_Run_V1(p_Script, "system-view", "]");
                    alfaNET.Rebex_Run_V1(p_Script, "user-interface current", "]");
                    alfaNET.Rebex_Run_V1(p_Script, "screen-length 0", "]");
                    alfaNET.Rebex_Run_V1(p_Script, "screen-width 200", "]");
                    alfaNET.Rebex_Run_V1(p_Script, "y", "]");
                    alfaNET.Rebex_Run_V1(p_Script, "display inter description", "]");

                    // Get Lines
                    var p_Lines = p_Script.ReceivedData.Split('\n');

                    // Create List
                    var p_ListPorts = new List<PortAvea>();

                    for (int li = 11; li < p_Lines.Length - 1; li++)
                    {
                        // Port
                        var p_Port = new PortAvea();

                        // Tokens
                        var p_Tokens = p_Lines[li].Split(new string[] { " ", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                        // Parsing
                        for (int la = 0; la < p_Tokens.Length; la++)
                        {
                            if (la == 0) p_Port.PortName = p_Tokens[la];
                            else if (la == 1) p_Port.AdmState = p_Tokens[la];
                            else if (la == 2) p_Port.OprState = p_Tokens[la];
                            else if (la >= 3) p_Port.Description += p_Tokens[la] + " ";
                        }

                        // PortID
                        p_Port.ID = p_ListPorts.Count() + 1;

                        // SiteName
                        p_Port.SiteName = p_Router.SiteName;

                        // Add
                        p_ListPorts.Add(p_Port);
                    }

                    // Set Outs
                    p_DataSource = p_ListPorts;
                    p_LogText = p_Script.ReceivedData;

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Set Outs
                p_DataSource = null;
                p_LogText = ex.Message;

                // Error
                alfaNET.Status_ERROR(ex.Message);
                
                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F4_Huawei_ReservePorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    // Scripting
                    Scripting p_Script = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Connect
                            p_Rebex.Connect(p_Router_SiteIP);

                            // Login
                            p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                            // Scripting
                            p_Script = p_Rebex.StartScripting();

                            // Command-I
                            if (!alfaNET.Rebex_Run_V1(p_Script, "system-view", "]")) return false;
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("interface GigabitEthernet {0}", p_Port.PortName.Substring(2));
                        var p_Cmd2 = string.Format("description {0}", p_Port.ReservDescription);

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "]");
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd2, "]");
                        alfaNET.Rebex_Run_V1(p_Script, "q", "]");

                        // Update Table                             
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.RESERVED, null, true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F5_Huawei_RollbackPorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    // Scripting
                    Scripting p_Script = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Connect
                            p_Rebex.Connect(p_Router_SiteIP);

                            // Login
                            p_Rebex.Login(alfaNET.m_RtrUser, alfaNET.m_RtrPass);

                            // Scripting
                            p_Script = p_Rebex.StartScripting();

                            // Command-I
                            if (!alfaNET.Rebex_Run_V1(p_Script, "system-view", "]")) return false;
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("interface GigabitEthernet {0}", p_Port.PortName.Substring(2));
                        var p_Cmd2 = string.Format("undo description");

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "]");
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd2, "]");
                        alfaNET.Rebex_Run_V1(p_Script, "q", "]");

                        // Update Table
                        p_Port.ReservDescription = string.Empty;
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.FREE,  " (RollBack)", true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    #endregion



    #region //----------- ALCATEL -------//


        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<bool> F1_Alcatel_GetRouterPorts_Task(TableRouterAlcatel p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Return Async Result
            return Task.Run<bool>(() => { return alfaNET.F2_Alcatel_GetRouterPorts(p_Router, p_GridView, p_MemoEdit); });
        }
         
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F2_Alcatel_GetRouterPorts(TableRouterAlcatel p_Router, GridView p_GridView, MemoEdit p_MemoEdit)
        {
            // Result
            bool p_Result = false;

            // Reset Values
            p_MemoEdit.Text = string.Empty;
            alfaGrid.SetView(p_GridView, null, true);

            // Outs
            string p_LogText = null;
            List<PortAvea> p_DataSource = null;

            // Get Router Ports
            p_Result = alfaNET.F3_Alcatel_GetRouterPorts_SSH(p_Router, out p_DataSource, out p_LogText);

            // GridView
            alfaGrid.SetView(p_GridView, p_DataSource, true);
            
            // Logs
            alfaCtrl.SetText(p_MemoEdit, p_LogText);

            // Return
            return p_Result;
        }
        
        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F3_Alcatel_GetRouterPorts_SSH(TableRouterAlcatel p_Router, out List<PortAvea> p_DataSource, out string p_LogText)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Connect
                    p_Rebex.Connect(alfaNET.m_AlcAdd1);  // ADDR1 <----> ADDR2

                    // Login
                    p_Rebex.Login(alfaNET.m_AlcUser, alfaNET.m_AlcPass);
                    
                    // Scripting
                    Scripting p_Script = p_Rebex.StartScripting();

                    // DetectPrompt
                    alfaNET.DetectPrompt(p_Script);

                    // Login Command
                    string p_CmdLogin = string.Format("ssh {0}@{1}", alfaNET.m_RtrUser, p_Router.SiteIP);

                    // Logins
                    alfaNET.Rebex_Run_V2(p_Script, p_CmdLogin, "password:", "(yes/no)?", "yes");
                    alfaNET.Rebex_Run_V1(p_Script, alfaNET.m_RtrPass, "#");
                    alfaNET.Rebex_Run_V1(p_Script, "environment no more", "#");

                    //===================================================== PART (1) ====================================//

                    // Command (1)
                    alfaNET.Rebex_Run_V1(p_Script, "show mda", "#");

                    // Set Log
                    var p_LogText1 = p_Script.ReceivedData;

                    //===================================================== PART (2) ====================================//

                    // Command (2)
                    alfaNET.Rebex_Run_V1(p_Script, "show port description", "#");

                    // Set Log
                    var p_LogText2 = p_Script.ReceivedData;

                    // Get Lines
                    var p_LinesV1 = p_Script.ReceivedData.Split('\n');

                    // Create List
                    var p_ListPortsV1 = new List<PortAvea>();

                    for (int li = 0; li < p_LinesV1.Length - 1; li++)
                    {
                        // Check Line
                        if (p_LinesV1[li].Length > 0) if (!Regex.IsMatch(p_LinesV1[li].Substring(0,1), @"^\d+$")) continue;

                        // Port
                        var p_Port = new PortAvea();

                        // Tokens
                        var p_Tokens = p_LinesV1[li].Split(new string[] { " ", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                        // Parsing
                        for (int la = 0; la < p_Tokens.Length; la++)
                        {
                                 if (la == 0) p_Port.PortName = p_Tokens[la];
                            else if (la >= 1) p_Port.Description += p_Tokens[la] + " ";
                        }

                        // Check PortName Pattern = "dd/dd/dd"
                        if (!Regex.IsMatch(p_Port.PortName, @"^[0-9]+/[0-9]+/[0-9]+$")) continue;

                        // PortID
                        p_Port.ID = p_ListPortsV1.Count() + 1;

                        // SiteName
                        p_Port.SiteName = p_Router.SiteName;

                        // Add
                        p_ListPortsV1.Add(p_Port);
                    }

                    //===================================================== PART (3) ====================================//

                    // Command (3)
                    alfaNET.Rebex_Run_V1(p_Script, "show port", "#");

                    // Set Log
                    var p_LogText3 = p_Script.ReceivedData;

                    // Get Lines
                    var p_LinesV2 = p_Script.ReceivedData.Split('\n');

                    // Create List
                    var p_ListPortsV2 = new List<PortAvea>();

                    for (int li = 0; li < p_LinesV2.Length - 1; li++)
                    {
                        // Check Line
                        if (p_LinesV2[li].Length > 0) if (!Regex.IsMatch(p_LinesV2[li].Substring(0,1), @"^\d+$")) continue;

                        // Port
                        var p_Port = new PortAvea();

                        // Tokens
                        var p_Tokens = p_LinesV2[li].Split(new string[] { " ", "\r" }, StringSplitOptions.RemoveEmptyEntries);

                        // Parsing
                        for (int la = 0; la < p_Tokens.Length; la++)
                        {
                                 if (la == 00) p_Port.PortName = p_Tokens[la];
                            else if (la == 01) p_Port.AdmState = p_Tokens[la];
                            else if (la == 03) p_Port.OprState = p_Tokens[la];
                            else if (la == 09) p_Port.PRTType  = p_Tokens[la]; 
                            else if (la >= 10) p_Port.SFPType += p_Tokens[la] + " ";
                        }

                        // Empty SfpTypes
                        if (string.IsNullOrEmpty(p_Port.SFPType)) p_Port.SFPType = "NOT_EQUIPPED";

                        // Empty PrtTypes
                        if (string.IsNullOrEmpty(p_Port.PRTType)) p_Port.PRTType = "NA";

                        // Join Types
                        p_Port.SFPType = p_Port.PRTType + "_" + p_Port.SFPType;

                        // Check PortName Pattern = "dd/dd/dd"
                        if (!Regex.IsMatch(p_Port.PortName, @"^[0-9]+/[0-9]+/[0-9]+$")) continue;

                        // PortID
                        p_Port.ID = p_ListPortsV2.Count() + 1;

                        // SiteName
                        p_Port.SiteName = p_Router.SiteName;

                        // Add
                        p_ListPortsV2.Add(p_Port);
                    }

                    //======================================================== MERGE ====================================//

                    foreach (var p_PortAvea in p_ListPortsV2)
                    {
                        // Set Descriprion
                        p_PortAvea.Description = p_ListPortsV1.Where(tt => tt.PortName == p_PortAvea.PortName).First().Description;
                    }

                    //======================================================== RESULT ===================================//

                    // Set DataSource
                    p_DataSource = p_ListPortsV2;

                    // Set LogText
                    string p_Line1 = "______________________________________________________________________________________________________________________ SCRIPT (1)______";
                    string p_Line2 = "______________________________________________________________________________________________________________________ SCRIPT (2)______";
                    string p_Line3 = "______________________________________________________________________________________________________________________ SCRIPT (3)______";
                    
                    // Set LogText
                    string p_Enter = "\r\n\r\n";
                    p_LogText = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", p_Enter, p_Line1, p_LogText1, p_Line2, p_LogText2, p_Line3, p_LogText3);

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;

                    //===================================================================================================//

                }
            }

            catch (Exception ex)
            {
                // Set Outs
                p_DataSource = null;
                p_LogText = ex.Message;

                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F4_Alcatel_ReservePorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Connect
                    p_Rebex.Connect(alfaNET.m_AlcAdd1);  // ADDR1 <----> ADDR2

                    // Login
                    p_Rebex.Login(alfaNET.m_AlcUser, alfaNET.m_AlcPass);

                    // Scripting
                    Scripting p_Script = p_Rebex.StartScripting();

                    // DetectPrompt
                    alfaNET.DetectPrompt(p_Script);

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Login Command
                            string p_CmdLogin = string.Format("ssh {0}@{1}", alfaNET.m_RtrUser, p_Router_SiteIP);

                            // Logins
                            alfaNET.Rebex_Run_V2(p_Script, p_CmdLogin, "password:", "(yes/no)?", "yes");
                            alfaNET.Rebex_Run_V1(p_Script, alfaNET.m_RtrPass, "#");
                            alfaNET.Rebex_Run_V1(p_Script, "environment no more", "#");
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("configure port {0} description {1}", p_Port.PortName, p_Port.ReservDescription);

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "#");

                        // Update Table                             
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.RESERVED, null, true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool F5_Alcatel_RollbackPorts_SSH(List<TablePortAvea> p_List)
        {
            try
            {
                using (var p_Rebex = new Rebex.Net.Ssh())
                {
                    // Status
                    alfaNET.SetConnection("Connection : SSH");

                    // Connect
                    p_Rebex.Connect(alfaNET.m_AlcAdd1);  // ADDR1 <----> ADDR2

                    // Login
                    p_Rebex.Login(alfaNET.m_AlcUser, alfaNET.m_AlcPass);
                    
                    // Scripting
                    Scripting p_Script = p_Rebex.StartScripting();

                    // DetectPrompt
                    alfaNET.DetectPrompt(p_Script);

                    // Router SiteIP    
                    string p_Router_SiteIP = null;

                    foreach (var p_Port in p_List)
                    {
                        if (p_Router_SiteIP != p_Port.SiteIP)
                        {
                            // Assign
                            p_Router_SiteIP = p_Port.SiteIP;

                            // Login Command
                            string p_CmdLogin = string.Format("ssh {0}@{1}", alfaNET.m_RtrUser, p_Router_SiteIP);

                            // Logins
                            alfaNET.Rebex_Run_V2(p_Script, p_CmdLogin, "password:", "(yes/no)?", "yes");
                            alfaNET.Rebex_Run_V1(p_Script, alfaNET.m_RtrPass, "#");
                            alfaNET.Rebex_Run_V1(p_Script, "environment no more", "#");
                        }

                        // Set Commands
                        var p_Cmd1 = string.Format("configure port {0} no description", p_Port.PortName, p_Port.ReservDescription);

                        // Run Commands
                        alfaNET.Rebex_Run_V1(p_Script, p_Cmd1, "#");

                        // Update Table
                        p_Port.ReservDescription = string.Empty;
                        alfaEntity.TablePortAvea_Update(p_Port, alfaStr.FREE, " (RollBack)", true);
                    }

                    // Finish
                    alfaNET.Status_OK();

                    // Return
                    return true;
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaNET.Status_ERROR(ex.Message);

                // Return
                return false;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    #endregion



    #region //----------- SAMSRV --------//


        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static List<alfaItem> Alcatel_Step02_FTP_GetFileNames()
        {
            // Break
            if (!alfaNET.IsRunning) throw new Exception(alfaNET.BreakMessage);

            // Start
            DateTime p_Start = DateTime.Now;

            // Log
            alfaLog.Add("(FTP) Server = " + alfaNET.m_FtpAdd1 + alfaNET.m_FtpPath);
            alfaLog.Add("(FTP) Getting FileNames ... [ Start ]");

            // FTP
            Rebex.Net.Ftp ftp = alfaFtp.Get();

            // File Names
            string[] p_FileList = ftp.GetNameList();

            // Create List
            List<alfaItem> p_ItemList = new List<alfaItem>();

            // Index
            int p_Index = 0;

            foreach (string p_File in p_FileList)
            {
                // Inc Index
                p_Index = p_Index + 1;

                // FileName
                string p_FileName = string.Format("[{0:000}]  {1}  ( {2} Bytes )", p_Index, p_File, ftp.GetFileLength(p_File));

                // Add to List
                p_ItemList.Add(new alfaItem(p_FileName, p_File));
            }

            // Log
            alfaLog.Add("(FTP) Getting FileNames ...", alfaDate.GetSec(p_Start));

            // Return
            return p_ItemList;
        }        

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> Alcatel_Step03_FTP_DownloadFile(string p_FileName)
        {
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Break
                    if (!alfaNET.IsRunning) throw new Exception(alfaNET.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(FTP) Server = " + alfaNET.m_FtpAdd1 + alfaNET.m_FtpPath);
                    alfaLog.Add("(FTP) Downloading File ... [ Start ]");

                    // FTP
                    var p_ftp = alfaFtp.Get();

                    // Remote FileName
                    alfaNET.FileNameRem = alfaNET.m_FtpPath + p_FileName;

                    // Local FileName
                    alfaNET.FileNameLoc = alfaNET.m_LocPath + p_FileName;

                    // Check Directory Local
                    if (!Directory.Exists(alfaNET.m_LocPath)) Directory.CreateDirectory(alfaNET.m_LocPath);

                    // Download File
                    p_ftp.GetFile(alfaNET.FileNameRem, alfaNET.FileNameLoc);

                    // FileName
                    string p_FileWithSize = string.Format("(FTP) {0} ( {1} Bytes )", p_FileName, p_ftp.GetFileLength(alfaNET.FileNameRem));

                    // Log
                    alfaLog.Add(p_FileWithSize);
                    alfaLog.Add("(FTP) Downloading File ...", alfaDate.GetSec(p_Start));

                    // Return
                    return alfaNET.FileNameLoc;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<DataSet> Alcatel_Step04_ProcessFile(string p_FileName)
        {
            // Return Async Result
            return Task.Run<DataSet>(() =>
                {
                    // Break
                    if (!alfaNET.IsRunning) throw new Exception(alfaNET.BreakMessage);

                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(APP) Processing File (Generating RawData) ... [ Start ]");

                    // DataSet
                    DataSet ds = new DataSet();

                    // Read XML
                    ds.ReadXml(p_FileName);

                    // Check
                    if (ds.Tables.Count == 0)
                    {
                        // Log
                        alfaLog.Add("(APP) No Data Found ... !"); return null;
                    }

                    // Log
                    alfaLog.Add("(APP) Processing File (Generating RawData) is Done", alfaDate.GetSec(p_Start));

                    // Return
                    return ds;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Alcatel_FTP_DeleteFiles()
        {
            // FTP
            Rebex.Net.Ftp ftp = alfaFtp.Get();

            // File Names
            string[] p_FileList = ftp.GetNameList();

            // Create List
            List<alfaItem> p_ItemList = new List<alfaItem>();

            foreach (string p_File in p_FileList)
            {
                // DeleteFile
                ftp.DeleteFile(p_File);
            }
        }   

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> Alcatel_PortData01()
        { 
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // XML Query I
                    string p_XmlQry1 = @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        <SOAP:Header>
                                               <header xmlns=""xmlapi_1.0"">
                                                       <security> <user>{0}</user> <password>{1}</password> </security>
                                                       <requestID>clientName@requestId</requestID>
                                               </header>
                                        </SOAP:Header>
                                        <SOAP:Body>

                                            <findToFile xmlns=""xmlapi_1.0"">
                                            <timeStamp>true</timeStamp>

                                            <fullClassName>equipment.Port</fullClassName>

                                               <filter>
                                                  <and> <equal name=""portCategory"" value=""ethernet""/> </and>
                                               </filter>

                                              <resultFilter>

                                                <attribute>siteName</attribute>
                                                <attribute>siteId</attribute>
                                                <attribute>snmpPortId</attribute>
                                                <attribute>sfpStatus</attribute>
                                                <attribute>portCategory</attribute>
                                                <attribute>description</attribute>
                                                <attribute>displayedName</attribute>
                                                <attribute>state</attribute> 
                                                <attribute>specificType</attribute>    
                                                <attribute>operationalState</attribute>
                                                <attribute>administrativeState</attribute>

                                                <children/>

                                              </resultFilter>

                                            <fileName>PBNDATA/{2}.xml</fileName>
                                            </findToFile>
                                        </SOAP:Body>
                                </SOAP:Envelope>";

                    // Set FileName             
                    string p_FileName = string.Format("FILE_{0}", alfaDate.GetDate_V4(DateTime.Now));  

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ... [ Start ]");
                    alfaLog.Add("(XML) Server = " + alfaNET.m_SamAdd1);
                    alfaLog.Add("(XML) FileName = " + p_FileName);

                    // Query
                    string p_Query = string.Format(p_XmlQry1, alfaNET.m_SamUser, alfaNET.m_SamPass, p_FileName);

                    // Result
                    var p_Result = alfaWeb.GetWebRequest(p_Query);

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_FileName;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<string> Alcatel_PortData02()
        { 
            // Return Async Result
            return Task.Run<string>(() =>
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // XML Query II
                    string p_XmlQry2 = @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/"">
                                        <SOAP:Header>
                                               <header xmlns=""xmlapi_1.0"">
                                                       <security> <user>{0}</user> <password>{1}</password> </security>
                                                       <requestID>clientName@requestId</requestID>
                                               </header>
                                        </SOAP:Header>
                                        <SOAP:Body>
                                            <findToFile xmlns=""xmlapi_1.0"">
                                            <timeStamp>true</timeStamp>

                                            <fullClassName>equipment.MediaAdaptor</fullClassName>

                                              <resultFilter>

                                                <attribute>siteName</attribute>
                                                <attribute>snmpPortId</attribute>
                                                <attribute>sfpOpticalCompliance</attribute>

                                                <children/>

                                              </resultFilter>


                                            <fileName>PBNDATA/{2}.xml</fileName>
                                            </findToFile>
                                        </SOAP:Body>
                                </SOAP:Envelope>";

                    // Set FileName             
                    string p_FileName = string.Format("FILE_{0}", alfaDate.GetDate_V4(DateTime.Now));  
                    
                    // Log
                    alfaLog.Add("(XML) XML Service Calling ... [ Start ]");
                    alfaLog.Add("(XML) Server = " + alfaNET.m_SamAdd1);
                    alfaLog.Add("(XML) FileName = " + p_FileName);

                    // Query
                    string p_Query = string.Format(p_XmlQry2, alfaNET.m_SamUser, alfaNET.m_SamPass, p_FileName);

                    // Result
                    var p_Result = alfaWeb.GetWebRequest(p_Query);

                    // Log
                    alfaLog.Add("(XML) XML Service Calling ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_FileName;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<List<TablePortAlcatel>> Alcatel_MergeResult(DataTable p_Table1, DataTable p_Table2)
        {
            // Return Async Result
            return Task.Run<List<TablePortAlcatel>>(() =>
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(APP) Merging Alcatel Tables ... [ Start ]");

                    // Result List
                    var p_ResultList = new List<TablePortAlcatel>();

                    // Reset Count
                    //alfaNET.PortCount = 0;
                    //alfaNET.PortTotal = p_Table1.Rows.Count;

                    foreach (DataRow p_Row in p_Table1.Rows)
                    {
                        // Count                        
                        //alfaNET.PortCount++;

                        // Crealte Line
                        var p_PortAlcatel = new TablePortAlcatel();

                        // Get Table Values
                        string p_SiteName = p_Row["siteName"].ToString();
                        string p_SnmpPortId = p_Row["snmpPortId"].ToString();

                        // Search for Values
                        var p_Result = p_Table2.AsEnumerable().Where(tt => tt.Field<string>("siteName") == p_SiteName &&
                                                                           tt.Field<string>("snmpPortId") == p_SnmpPortId);

                        if (p_Result.Count() > 0)
                        {
                            // Assign Values
                            p_PortAlcatel.SiteId = p_Row["siteId"].ToString();
                            p_PortAlcatel.SiteName = p_Row["siteName"].ToString();
                            p_PortAlcatel.SnmpPortId = p_Row["snmpPortId"].ToString();
                            p_PortAlcatel.Description = p_Row["description"].ToString();
                            p_PortAlcatel.DisplayedName =  p_Row["displayedName"].ToString();
                            p_PortAlcatel.OperationalState = p_Row["operationalState"].ToString();
                            p_PortAlcatel.AdministrativeState = p_Row["administrativeState"].ToString();
                            p_PortAlcatel.SfpStatus = p_Row["sfpStatus"].ToString();
                            p_PortAlcatel.PortCategory = p_Row["portCategory"].ToString();
                            p_PortAlcatel.SpecificType = p_Row["specificType"].ToString();
                            p_PortAlcatel.State = p_Row["state"].ToString();
                            p_PortAlcatel.SfpOpticalCompliance = p_Result.First().Field<string>("sfpOpticalCompliance");
                        }

                        if (!string.IsNullOrEmpty(p_PortAlcatel.SnmpPortId) && !string.IsNullOrEmpty(p_PortAlcatel.SiteName))
                        {
                            // Add Result
                            p_ResultList.Add(p_PortAlcatel);
                        }
                    }

                    // Log
                    alfaLog.Add("(APP) Merging Alcatel Tables is Done ...", alfaDate.GetSec(p_Start));

                    // Return
                    return p_ResultList;
                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static Task<List<TablePortAlcatel>> Alcatel_SaveResult(List<TablePortAlcatel> p_ResultList)
        {
            // Return Async Result
            return Task.Run<List<TablePortAlcatel>>(() =>
                {
                    // Start
                    DateTime p_Start = DateTime.Now;

                    // Log
                    alfaLog.Add("(APP) Saving Alcatel Result ... [ Start ]");

                    using (alfaDS DS = new alfaDS())
                    {
                        // Reset Count
                        //alfaNET.PortCount = 0;
                        //alfaNET.PortTotal = p_ResultList.Count();

                        foreach (TablePortAlcatel p_Row in p_ResultList)
                        {
                            // Count                        
                            //alfaNET.PortCount++;

                            // Create Score
                            var p_PortAlcatel = new TablePortAlcatel();

                            // Copy Fields
                            alfaEntity.Copy(p_Row, p_PortAlcatel);

                            // Set Update Values
                            p_PortAlcatel.UpdateDatetime = DateTime.Now;
                            p_PortAlcatel.UpdateUsername = alfaSession.UserAtGroup;

                            // Set Logs
                            p_PortAlcatel.Logs = alfaEntity.AddLogV1(p_PortAlcatel.Logs, alfaStr.REFRESHED);

                            // Select Record
                            var qry = from tt in DS.Context.TablePortAlcatel
                                      where tt.SiteName == p_Row.SiteName
                                         && tt.SnmpPortId == p_Row.SnmpPortId
                                      select tt;

                            // Check Record
                            if (qry.Count() == 0)
                            {
                                // Set Status
                                p_PortAlcatel.Status = alfaNET.Alcatel_GetPortStatus(p_Row);

                                // Add 
                                DS.Context.TablePortAlcatel.Add(p_PortAlcatel);
                            }
                            else
                            {
                                // Get
                                var p_AlcatelDB = qry.First();

                                // Copy Fields
                                alfaEntity.Copy(p_PortAlcatel, p_AlcatelDB, "ID-Status-ReservDescription");
                            }

                            try
                            {
                                // Save
                                DS.Context.SaveChanges();
                            }
                            catch 
                            { 
                                //Null
                            } 
                        }

                        // Log
                        alfaLog.Add("(APP) Saving Alcatel Result is Done ...", alfaDate.GetSec(p_Start));

                        // Return
                        return DS.Context.TablePortAlcatel.ToList();
                    }

                });
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string Alcatel_GetPortStatus( TablePortAlcatel p_Port)
        {
            // Get Status
            if (p_Port.OperationalState == "portOutOfService" && p_Port.AdministrativeState == "portOutOfService")
            {
                if (p_Port.Description.ToUpper().Contains("RESERV")) return "RESERVED"; else return "FREE";
            }

            else if (p_Port.OperationalState == "portInService" && p_Port.AdministrativeState == "portOutOfService") return "FREE";
            else if (p_Port.OperationalState == "portInService" && p_Port.AdministrativeState == "portInService") return "USED";
            else if (p_Port.OperationalState == "portOutOfService" && p_Port.AdministrativeState == "portInService" && !string.IsNullOrEmpty(p_Port.Description)) return "USED";
            else return "ERROR";
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Alcatel_RouterLogin(Scripting p_Script, string p_Router)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Telnet
            alfaNET.Rebex_Run_V1(p_Script, "telnet " + p_Router, "Login: ");

            // User
            alfaNET.Rebex_Run_V1(p_Script, "portman", "Password: ");

            // Pass
            alfaNET.Rebex_Run_V1(p_Script, "Nwdesing12!", "#");

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void Alcatel_RouterLogout(Scripting p_Script)
        {
            // Cursor
            alfaMsg.CursorWait();

            // Logout
            alfaNET.Rebex_Run_V1(p_Script, "logout", "$");

            // Cursor
            alfaMsg.CursorDefult();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

        public static bool Alcatel_RouterUpdate(Scripting p_Script, string p_PortName, string p_Description)
        {
            // Command
            var p_Text = string.Format("configure {0} description \"{1}\"", p_PortName.ToLower(), p_Description);

            // Logout
            return alfaNET.Rebex_Run_V1(p_Script, p_Text, "#");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------//

    #endregion

    }
}