using System;
using Rebex.Net;
using System.IO;
using System.Xml;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using DevExpress.Utils;
using System.Reflection;
using DevExpress.XtraTab;
using System.Diagnostics;
using DevExpress.XtraBars;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraVerticalGrid;
using System.Security.Cryptography;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraEditors.Repository;



namespace PortMan2014
{

    #region //-----------alfaItem-----------//

    public class alfaItem
	{
		// Fields
		private string m_EntityName;
		private string m_EntityText;

		// Properties
		public string Log { get; set; }
		public string Name { get { return this.m_EntityName;  }  }
		public string Text { get { return this.m_EntityText;  }  }


		// Constructor
		public alfaItem( string p_EntityText, string p_EntityName )
		{
			this.m_EntityName = p_EntityName;
			this.m_EntityText = p_EntityText;
		}

		// Override Method
		public override string ToString() { return this.m_EntityText; }
	}

	#endregion    


	#region //-----------alfaEnum-----------//

	public static class alfaResult
	{
		public static int None = 0;
		public static int Pass = 1;
		public static int Fail = 2;
	}

	# endregion


	#region //-----------alfaSec------------//

	public class alfaSec
	{
		//-------------------------------------------------------------------------------------------------//

		public static string Crypt(string s_Data, string s_Password, bool b_Encrypt) // Encryption & Decryption
		{
			byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

			PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(s_Password, u8_Salt);

			Rijndael i_Alg = Rijndael.Create();
			i_Alg.Key = i_Pass.GetBytes(32);
			i_Alg.IV = i_Pass.GetBytes(16);

			ICryptoTransform i_Trans = (b_Encrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

			MemoryStream i_Mem = new MemoryStream();
			CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);

			byte[] u8_Data;

			try
			{
				if (b_Encrypt) u8_Data = Encoding.Unicode.GetBytes(s_Data);
				else u8_Data = Convert.FromBase64String(s_Data);

				i_Crypt.Write(u8_Data, 0, u8_Data.Length);
				i_Crypt.Close();
			}
			catch { return null; }

			if (b_Encrypt) return Convert.ToBase64String(i_Mem.ToArray());
			else return Encoding.Unicode.GetString(i_Mem.ToArray());

		}

		//-------------------------------------------------------------------------------------------------//

		public static string EnCrypt(string  p_Message)
		{
			return alfaSec.Crypt(p_Message, "ALPHASOFT", true);
		}

		//-------------------------------------------------------------------------------------------------//

		public static string DeCrypt(string p_Message)
		{
			return alfaSec.Crypt(p_Message, "ALPHASOFT", false);
		}

		//-------------------------------------------------------------------------------------------------//
	}

	#endregion


	#region //-----------alfaMsg------------//

	public class alfaMsg
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void CursorWait()
		{
			// Wait Cursor
			Cursor.Current = Cursors.WaitCursor;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void CursorDefult()
		{
			// Wait Cursor
			Cursor.Current = Cursors.Default;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static DialogResult Quest(string strMessage)
		{
			// Cursor
			Cursor.Current = Cursors.Default;

			// Show Message
			return MessageBox.Show(strMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static DialogResult Error(string strMessage)
		{
			// Cursor
			Cursor.Current = Cursors.Default;

			// Show Message
			return MessageBox.Show(strMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static DialogResult Error(Exception p_Exception)
		{
			// Cursor
			Cursor.Current = Cursors.Default;

			// Message
			string strMessage = null;

			// Get Message
			if (p_Exception.InnerException != null)
			{
				if (p_Exception.InnerException.InnerException != null)
				{
					strMessage = p_Exception.InnerException.InnerException.Message;
				}
				else strMessage = p_Exception.InnerException.Message;
			} 
			else strMessage = p_Exception.Message;

			// Show Message
			return MessageBox.Show(strMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static DialogResult Info(string strMessage)
		{
			// Cursor
			Cursor.Current = Cursors.Default;

			// Show Message
			return MessageBox.Show(strMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion


	#region //-----------alfaStr------------//

	public class alfaStr
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		#region //---Member Fields---//

		// Client Info

		public static string ALL = "ALL"; 
		public static string DONE = "DONE"; 
        public static string ERROR = "ERROR"; 
		public static string RUNNING = "RUNNING ...";
        public static string NULL = "__NULL__";
		public static string FREE = "FREE"; 
		public static string USED = "USED"; 
        public static string REQUEST = "REQUEST";
        public static string RESERVED = "RESERVED";
        public static string APPROVED = "APPROVED";
        public static string REFRESHED = "REFRESHED";
        public static string DELETED = "DELETED";
        public static string GroupDesign = "Design";
        public static string ACTIVE = "ACTIVE";
        public static string CLOSED = "CLOSED";

		#endregion

		//-----------------------------------------------------------------------------------------------------------------------------------------//
		
		public static void SetColumnsUpper( GridColumnCollection p_GridColumnCollection )
		{
			// Set UpperCase for Columns
			foreach( GridColumn col in p_GridColumnCollection ) 
			{                
				col.FieldName = col.FieldName.ToUpper( new CultureInfo("en-US") );
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetAppVersion(bool FullVersion)
		{
			// Get FileVersionInfo
			FileVersionInfo fi = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);

			// Get App Version
			if (FullVersion) return "v" + fi.FileVersion;
			else return "v" + fi.FileMajorPart + "." + fi.FileMinorPart;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string ByteArrayToStringV1(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);

			foreach (byte b in ba)
			{
				hex.AppendFormat("{0:x2}", b);
			}

			return hex.ToString();
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string ByteArrayToStringV2(byte[] ba)
		{
			string hex = BitConverter.ToString(ba);
			return hex.Replace("-", "");
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetEnglishText(string p_Text)
		{
			// Create Encodings
			Encoding iso = Encoding.GetEncoding("Cyrillic");
			Encoding utf8 = Encoding.UTF8;
			
			// Get Bytes
			byte[] utfBytes = utf8.GetBytes(p_Text);
			byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
						
			// Return
			return iso.GetString(isoBytes);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

	}

	#endregion


	#region //-----------alfaDate-----------//

	public class alfaDate
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static double GetSec(DateTime p_Start)  // Seconds
		{ 
			// Return
			return DateTime.Now.Subtract(p_Start).TotalSeconds;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V1(DateTime p_DateTime)  // YYYYMMDD
		{
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.Month.ToString("00");
			string day = p_DateTime.Day.ToString("00");

			// Return
			return yrs + mon + day;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V2(DateTime p_DateTime) // YYYY-MM-DD
		{
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.Month.ToString("00");
			string day = p_DateTime.Day.ToString("00");

			// Return
			return yrs + "-" + mon + "-" + day;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V3(DateTime p_DateTime) // YYYYMM
		{ 
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.ToString("MMMM", new CultureInfo("tr-TR", false)).ToUpper();

			// Return
			return yrs + " " + mon;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V4(DateTime p_DateTime) // YYYY_MM_DD_HHMMSS_sssss
		{ 
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.Month.ToString("00");
			string day = p_DateTime.Day.ToString("00");
			string hrs = p_DateTime.Hour.ToString("00");
			string min = p_DateTime.Minute.ToString("00");
			string sec = p_DateTime.Second.ToString("00");
			string mil = p_DateTime.Millisecond.ToString("000000");

			// Return  
			return string.Format("{0}{1}{2}_{3}{4}_{5}_{6}", yrs, mon, day, hrs, min, sec, mil);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V5(DateTime p_DateTime) // YYYY-MM-DD HH:MM:SS.SSSSS
		{  
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.Month.ToString("00");
			string day = p_DateTime.Day.ToString("00");
			string hrs = p_DateTime.Hour.ToString("00");
			string min = p_DateTime.Minute.ToString("00");
			string sec = p_DateTime.Second.ToString("00");
			string mil = p_DateTime.Millisecond.ToString("000000");

			// Return  
			return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", yrs, mon, day, hrs, min, sec, mil);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V6(DateTime p_DateTime) // YYYY-MM-DD HH:MM:SS
		{  
			// Get Values
			string yrs = p_DateTime.Year.ToString("0000");
			string mon = p_DateTime.Month.ToString("00");
			string day = p_DateTime.Day.ToString("00");
			string hrs = p_DateTime.Hour.ToString("00");
			string min = p_DateTime.Minute.ToString("00");
			string sec = p_DateTime.Second.ToString("00");

			// Return  
			return string.Format("{0}-{1}-{2} {3}:{4}:{5}", yrs, mon, day, hrs, min, sec);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetDate_V7(DateTime p_DateTime) // HH:MM:SS
		{  
			// Get Values
			string hrs = p_DateTime.Hour.ToString("00");
			string min = p_DateTime.Minute.ToString("00");
			string sec = p_DateTime.Second.ToString("00");

			// Return  
			return string.Format("{0}:{1}:{2}", hrs, min, sec);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetTime(DateTime p_DateTime)
		{
			// Get Values
			string hrs = p_DateTime.Hour.ToString("00");
			string min = p_DateTime.Minute.ToString("00");
			string sec = p_DateTime.Second.ToString("00");

			// Return
			return hrs + min + sec;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static int GetTotalSecs(DateTime p_DateTime)
		{
			// Get Values
			int sec_hrs = p_DateTime.Hour * 60 * 60;
			int sec_min = p_DateTime.Minute * 60;
			int sec_sec = p_DateTime.Second * 1;

			// Return
			return sec_hrs + sec_min + sec_sec;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static int GetNumberOfDays(DateTime p_DateTime)
		{
			// Return
			return DateTime.DaysInMonth(p_DateTime.Year, p_DateTime.Month);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string ToUnixDT(DateTime p_Value)
		{ 
			// the Unix Epoch
			TimeSpan p_Span = p_Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);

			// Integer Value
			double p_TotalMilliSeconds = Math.Floor(p_Span.TotalMilliseconds);

			// Return 
			return p_TotalMilliSeconds.ToString();
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static DateTime ToWinDT(double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

	}

	#endregion


	#region //-----------alfaVer------------//

	public class alfaVer
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string GetAppVersion()
		{
			// Get Versions
			int verMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
			int verMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
			int verBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
			int verRevis = Assembly.GetExecutingAssembly().GetName().Version.Revision;

			// Return
			return "v" + verMajor + "." + verMinor + "." + verBuild  + "." + verRevis;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion

	
	#region //-----------alfaCtrl-----------//

	public class alfaCtrl
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void DisablePages( XtraTabControl p_TabControl, XtraTabPage p_Page)
		{
			foreach (XtraTabPage page in p_TabControl.TabPages)
			{
				if ( page != p_Page)
				{
					page.PageEnabled = false;
				}
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void EnablePages(XtraTabControl p_TabControl)
		{
			foreach (XtraTabPage page in p_TabControl.TabPages)
			{
				page.PageEnabled = true;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void DisableButtons(Control p_Control)
		{
			foreach (Control ctrl in p_Control.Controls)
			{
				if (ctrl.GetType().ToString() == "DevExpress.XtraEditors.SimpleButton")
				{
					alfaCtrl.DisableControl((SimpleButton)ctrl);
				}
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void EnableButtons(Control p_Control)
		{
			foreach (Control ctrl in p_Control.Controls)
			{
				if (ctrl.GetType().ToString() == "DevExpress.XtraEditors.SimpleButton")
				{
					alfaCtrl.EnableControl((SimpleButton)ctrl);
				}
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetButton(SimpleButton p_Button, bool p_Flag)
		{
			if (p_Flag) alfaCtrl.EnableControl(p_Button); else alfaCtrl.DisableControl(p_Button);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void EnableControl(SimpleButton p_Button)
		{
			if (p_Button.Tag == (object)"ActionButton")
			{
				p_Button.LookAndFeel.SkinName = "Glass Oceans";
				p_Button.ForeColor = Color.Black;
			}

            else if (p_Button.Tag == (object)"ColorButton")
			{
                p_Button.ButtonStyle = BorderStyles.Simple;
				p_Button.ForeColor = Color.White;
			}

			else
			{
				p_Button.LookAndFeel.SkinName = "Sharp";
				p_Button.ForeColor = Color.White;
			}
			p_Button.LookAndFeel.UseDefaultLookAndFeel = false;
			p_Button.Enabled = true;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void DisableControl(SimpleButton p_Button)
		{
			p_Button.LookAndFeel.SkinName = "DevExpress Dark Style";
			p_Button.LookAndFeel.UseDefaultLookAndFeel = false;
            p_Button.ButtonStyle = BorderStyles.Default;
			p_Button.Enabled = false;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void EnableControl(Control p_Control, Color p_Color)
		{
			p_Control.Enabled = true;
			p_Control.BackColor = p_Color;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void DisableControl(Control p_Control, Color p_Color)
		{
			p_Control.Enabled = false;
			p_Control.BackColor = p_Color;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetText( BarStaticItem p_Control, string p_Message, bool p_Status )
		{
			// Set Message
			p_Control.Caption = p_Message;

			// Set Color
			if (p_Status) p_Control.ItemAppearance.Normal.ForeColor = Color.Lime;
					 else p_Control.ItemAppearance.Normal.ForeColor = Color.LightCoral;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetText(BarStaticItem p_Control, string p_Message, Color p_Color)
		{
			// Set Message
			p_Control.Caption = p_Message;

			// Set Color
			p_Control.ItemAppearance.Normal.ForeColor = p_Color;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	
		public static void SetResult( LabelControl p_txtResult, string p_ResultStr, int p_Status )
		{
			// Set Text
			p_txtResult.Text = p_ResultStr;

			// Set Colors
			switch ( p_Status )
			{
				case 0: p_txtResult.BackColor = Color.Gray; break;
				case 1: p_txtResult.BackColor = Color.Navy; break;
				case 2: p_txtResult.BackColor = Color.Red; break;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetText(MemoEdit p_MemoEdit, string p_Text)
        {
            if (p_MemoEdit.InvokeRequired)
            {
                // Thread Safe
                p_MemoEdit.Invoke(new MethodInvoker(() => { alfaCtrl.SetText(p_MemoEdit, p_Text); }));
            }
            else
            {
                // Set Test
                p_MemoEdit.Text = p_Text;
            }
        }

		//-----------------------------------------------------------------------------------------------------------------------------------------//

	}

	#endregion


	#region //-----------alfaGrid-----------//

	public class alfaGrid
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void SetView(GridView p_GridView, object p_DataSource, bool p_Status)
        {
            if (p_GridView.GridControl.InvokeRequired)
            {
                // Thread Safe
                p_GridView.GridControl.Invoke(new MethodInvoker(() => { alfaGrid.SetView(p_GridView, p_DataSource, p_Status); }));
            }
            else
            {
                // Set DataSource
                p_GridView.GridControl.DataSource = p_DataSource;

                // Make Editable
                p_GridView.OptionsBehavior.Editable = !p_Status;
                p_GridView.OptionsBehavior.ReadOnly = p_Status;

                // Set View
                alfaGrid.SetView(p_GridView);
            }
        }

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetView(GridView p_GridView)
		{
			// Check GridView
			if (p_GridView.Columns.Count == 0) return;

			// Hide Columns
			alfaGrid.ColumnHide(p_GridView, "TableUser");

			// Set RowCount Position
			p_GridView.Columns[0].SummaryItem.DisplayFormat = "Count: {0}";
			p_GridView.Columns[0].SummaryItem.FieldName = p_GridView.Columns[0].FieldName;
			p_GridView.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;

			// DateTime Values
			foreach (var p_Field in "INSERT_DATETIME-UPDATE_DATETIME-DT_WIN-timeRecordedNET-UpdateDatetime-SessionStart-SessionFinish".Split('-'))
			{
				if (p_GridView.Columns[p_Field] != null)
				{
					p_GridView.Columns[p_Field].DisplayFormat.FormatType = FormatType.DateTime;
					p_GridView.Columns[p_Field].DisplayFormat.FormatString = "yyyy-MM-dd  HH:mm:ss";
				}
			}

            // Check
            if (p_GridView.Columns["Check"] != null)
            {
                p_GridView.Columns["Check"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }

			// Column ID
			if (p_GridView.Columns["ID"] != null)
			{
				p_GridView.Columns["ID"].OptionsColumn.AllowEdit = false;
			}

			// Password
			foreach (var p_Field in "Password".Split('-'))
			{
				if (p_GridView.Columns[p_Field] != null)
				{
					RepositoryItemTextEdit repItem = new RepositoryItemTextEdit();
					repItem.UseSystemPasswordChar = true;
					p_GridView.Columns[p_Field].ColumnEdit = repItem;
				}
			}

            // Show Footer
			p_GridView.OptionsView.ShowFooter = true;

			// Set View
			p_GridView.OptionsView.ColumnAutoWidth = false;
			p_GridView.BestFitMaxRowCount = 100;
			p_GridView.BestFitColumns();
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static void ColumnTextCenter(GridView p_GridView)
        {
            foreach (GridColumn p_Col in p_GridView.Columns)
            {
                p_Col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }
        }

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void ColumnReadOnly(GridView p_GridView, string p_List, bool p_Status)
		{ 
			foreach (var str in p_List.Split('-'))
			{
				// Get Row
				var row = p_GridView.Columns[str];

				if (row != null)
				{
					// Make Readonly
					row.OptionsColumn.AllowEdit = !p_Status;
					row.OptionsColumn.ReadOnly = p_Status;
				}
			}
		}
		
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SelectRow(GridView p_GridView, int p_RowHandle)
		{
			// Unselect Current Row
			p_GridView.UnselectRow(p_GridView.FocusedRowHandle);

			// Set New Position
			p_GridView.SelectRow(p_RowHandle);
			p_GridView.FocusedRowHandle = p_RowHandle;

			// Focus
			p_GridView.Focus();
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void ColumnHide(GridView p_GridView, string p_Columns)
		{
			foreach (string strColName in p_Columns.Split('-'))
			{
				if (p_GridView.Columns[strColName] != null)
				{
					// Hide Columns
					p_GridView.Columns.ColumnByFieldName(strColName).Visible = false;
				}
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookup_Users(GridView p_Grid, string p_Value)
		{
			// Get Column
			var Col = p_Grid.Columns[p_Value];

			// Check
			if (Col == null) return;

			// Create Lookup
			RepositoryItemComboBox p_LookUpCombo = new RepositoryItemComboBox();

			// Get Data List
			using (alfaDS DS = new alfaDS())
			{
				// Get List
				var listUser = DS.Context.TableUser.Where(tt => tt.TableGroup.Name == "IT").Select(tt => tt);

				// Add Item
				 foreach (var user in listUser) p_LookUpCombo.Items.Add(user.FullName);
			}

			// Assign to Grid
			Col.ColumnEdit = p_LookUpCombo;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookup_Priority(GridView p_Grid, string p_Value)
		{
			// Get Column
			var Col = p_Grid.Columns[p_Value];

			// Check
			if (Col == null) return;

			// Create Lookup
			RepositoryItemComboBox p_LookUpCombo = new RepositoryItemComboBox();

			// Priorty Levels
			p_LookUpCombo.Items.Add("(1) LOW");
			p_LookUpCombo.Items.Add("(2) MEDIUM");
			p_LookUpCombo.Items.Add("(3) VERY HIGH");
			
			// Assign to Grid
			Col.ColumnEdit = p_LookUpCombo;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

	}

	#endregion


	#region //-----------alfaVGrid----------//

	public class alfaVGrid 
	{ 
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static bool m_LookupFlag = false;
		public static bool m_TexteditFlag = false;

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetPropertyGridV1(PropertyGridControl p_Grid, Object p_Object)
		{
			// Set Object
			p_Grid.Rows.Clear();
			p_Grid.RecordWidth = 140;
			p_Grid.SelectedObject = null;
			p_Grid.SelectedObject = p_Object;
			
			// Row Hide
			alfaVGrid.RowHide(p_Grid, "ID-TableGroup-TableUser");

			// Row Readonly
			alfaVGrid.RowReadOnly(p_Grid, "ID");

			// Add LookUp
			alfaVGrid.AddLookUp(p_Grid, "GroupID", "TableGroup", "ID", "Name");

			// Add LookUp
            alfaVGrid.AddLookup_ConnType(p_Grid, "Connection");

			// Add TextEdits
			alfaVGrid.AddTextEdits(p_Grid);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void SetPropertyGridV2(PropertyGridControl p_Grid, Object p_Object)
		{
			// Set Object
			//p_Grid.Rows.Clear();
			p_Grid.RecordWidth = 140;
			p_Grid.SelectedObject = p_Object;
			
			// Row Hide
			alfaVGrid.RowHide(p_Grid, "XX");

			// Row Readonly
			alfaVGrid.RowReadOnly(p_Grid, "ID-INSERT_USER-INSERT_DATETIME-UPDATE_USER-UPDATE_DATETIME");

			// Add TextEdits
			if (!alfaVGrid.m_LookupFlag) alfaVGrid.AddTextEdits(p_Grid);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookup_Groups(PropertyGridControl p_Grid, string p_Value)
		{
			// Get Row
			var row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(p_Value);

			// Check
			if (row == null) return;

			// Create Lookup
			RepositoryItemComboBox p_LookUpCombo = new RepositoryItemComboBox();

			// Get Data List
			using (alfaDS DS = new alfaDS())
			{
				// Get List
				var listGroups = DS.Context.TableGroup.Select(tt => tt);

				// Add Item
				foreach (var grp in listGroups) p_LookUpCombo.Items.Add(grp.Name);
			}

			// ReadOnly
			p_LookUpCombo.TextEditStyle = TextEditStyles.DisableTextEditor;

			// Assign to Grid
			row.Properties.RowEdit = p_LookUpCombo;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookup_ConnType(PropertyGridControl p_Grid, string p_Value)
		{
			// Get Row
			var row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(p_Value);

			// Check
			if (row == null) return;

			// Create Lookup
			RepositoryItemComboBox p_LookUpCombo = new RepositoryItemComboBox();

			// Poperties
			p_LookUpCombo.Items.Add("TEL");
			p_LookUpCombo.Items.Add("SSH");
			p_LookUpCombo.TextEditStyle = TextEditStyles.DisableTextEditor;
			
			// Assign to Grid
			row.Properties.RowEdit = p_LookUpCombo;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookup_Booolean(PropertyGridControl p_Grid, string p_Value)
		{
			// Get Row
			var row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(p_Value);

			// Check
			if (row == null) return;

			// Create Lookup
			RepositoryItemComboBox p_LookUpCombo = new RepositoryItemComboBox();

			// Poperties
			p_LookUpCombo.Items.Add("Y");
			p_LookUpCombo.Items.Add("N");
			p_LookUpCombo.TextEditStyle = TextEditStyles.DisableTextEditor;
			
			// Assign to Grid
			row.Properties.RowEdit = p_LookUpCombo;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddTextEdits(PropertyGridControl p_Grid)
		{
			foreach (BaseRow row in p_Grid.Rows[0].ChildRows)
			{
				// Check
				if ("GroupID-Active-Admin-Connection".Contains(row.Properties.Caption)) continue;

				// Add TextEdit
				alfaVGrid.AddTextEdit(p_Grid, row.Properties.Caption);
			}

			// Set Flag
			alfaVGrid.m_TexteditFlag = true;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddTextEdit(PropertyGridControl p_Grid, string p_Field)
		{
			// Check Count
			if (p_Grid.Rows.Count == 0) return;

			// Create Lookup
			RepositoryItemTextEdit repTextEdit = new RepositoryItemTextEdit();

			// Get Row
			var Row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(p_Field);

			if (Row != null)
			{
				// Password Char
				if ("Password".Contains(p_Field)) repTextEdit.UseSystemPasswordChar = true;

				// Assign to Grid
				Row.Properties.RowEdit = repTextEdit;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void RowReadOnly(PropertyGridControl p_Grid, string p_List)
		{ 
			// Check Count
			if (p_Grid.Rows.Count == 0) return;

			foreach (var str in p_List.Split('-'))
			{
				// Get Row
				var row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(str);

				// Make Readonly
				if (row != null) row.Properties.ReadOnly = true;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void RowHide(PropertyGridControl p_Grid, string p_List)
		{
			// Check Count
			if (p_Grid.Rows.Count == 0) return;

			foreach (var str in p_List.Split('-'))
			{
				// Get Row
				var row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(str);

				// Make Readonly
				if (row != null) row.Visible = false;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void AddLookUp(PropertyGridControl p_Grid, string p_Field, string p_DataSource, string p_ValueMember, string p_DisplayMember)
		{
			// Check Count
			if (p_Grid.Rows.Count == 0) return;

			// Create Lookup
			RepositoryItemLookUpEdit LookUp = new RepositoryItemLookUpEdit();

			// UpperCase
			LookUp.CharacterCasing = CharacterCasing.Upper;
			
			// Clear NullText
			LookUp.NullText = string.Empty;

			// Set LookUp Properties
			LookUp.ValueMember = p_ValueMember;
			LookUp.DisplayMember = p_DisplayMember;
			LookUp.SearchMode = SearchMode.AutoComplete;
			LookUp.TextEditStyle = TextEditStyles.Standard;
			LookUp.DataSource = alfaEntity.Entity_Get(p_DataSource);

			// Get Row
			var Row = p_Grid.Rows[0].ChildRows.GetRowByFieldName(p_Field);

			// Add Lookup
			if (Row != null) Row.Properties.RowEdit = LookUp;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion    


	#region //-----------alfaSession--------//

	public static class alfaSession
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static int SessionID;
        public static string PC;
		public static string DBName;
		public static string LocIP;
		public static string Active;
		public static string OsVer;
		public static string AppVer;
		public static string NetVer;
		public static string Group;
		public static string Email;
		public static string Date;
		public static string Time;
		public static bool Admin;
		public static string UserName;
		public static string FullName;
		public static string UserAtGroup;


		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void Initialize()
		{ 
			// PC
			PC = System.Net.Dns.GetHostName();

			// SQL Server
			using (alfaDS ent = new alfaDS())
			{
				DBName = ent.Context.Database.Connection.DataSource;
			}

			// IP Adress List
			System.Net.IPAddress[] ListIP = System.Net.Dns.GetHostEntry(PC).AddressList;

			// Local IP
			foreach (System.Net.IPAddress ip in ListIP)
			{
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					LocIP = ip.ToString();
				}
			}

			// Operating System Version
			OsVer = System.Environment.OSVersion.ToString();

			// Status
			Active = "Y";

			// Application Version
			AppVer = alfaVer.GetAppVersion();

			// Net Framework Version
			NetVer = System.Environment.Version.ToString();

			// UserName
			UserName = "?";

			// GetDT
			DateTime dtNow = DateTime.Now;

			// Date
			Date = alfaDate.GetDate_V1(dtNow);

			// Time
			Time = alfaDate.GetTime(dtNow);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string UserGroup()
		{
			// User + Group
			string p_String =  String.Format("{0} @ {1}", UserName, Group);

			// Return
			return p_String;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string UserGroupAdmin()
		{
			// User + Group
			string p_String =  String.Format("{0} @ {1}", UserName, Group);

			// Return with Admin
			if (Admin) return p_String + " [Admin]"; else return p_String;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void RefreshLoginDateTime()
		{
			// GetDT
			DateTime dtNow = DateTime.Now;

			// Get Date
			Date = alfaDate.GetDate_V1(dtNow);

			// Get Time
			Time = alfaDate.GetTime(dtNow);
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion
	

	#region //-----------alfaMail-----------//

	public class alfaMail
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string FileName = Application.UserAppDataPath + "\\PortMan2014_Mail_Attachment.xls";

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static string CreateBody(string p_TaskID, string p_ListIP, string p_ReqType, string p_Comment)
		{
			// Body Text
			string p_Body = "==================================================================\n";

			// TaskID
			p_Body += string.Format("TaskID \t: {0}\n", p_TaskID);

			// Submitter
			p_Body += string.Format("Submitter \t: {0} ({1}) \n", alfaSession.UserName, alfaSession.Group);

			// Request Type
			p_Body += string.Format("ReqType \t: {0}\n", p_ReqType);

			// Submit Time
			p_Body += string.Format("DateTime \t: {0} \n", DateTime.Now);

			// Affected Objects
			p_Body += string.Format("Objects \t: {0} \n", p_ListIP);

			// Comments
			p_Body += string.Format("Comment \t: {0} \n", p_Comment);

			// Version
			p_Body += string.Format("Version \t: {0} \n", alfaSession.AppVer);

			// Line
			p_Body += "==================================================================\n";

			//Return
			return p_Body;
		}
		
		//-----------------------------------------------------------------------------------------------------------------------------------------//
		 
		public static void Send(String p_To, String p_Cc, String p_Subject, String p_Body, GridView p_GridView)
		{
            try
            {
                // Smtp
                using (SmtpClient p_Smtp = new SmtpClient())
                {
                    // Message
                    MailMessage p_Message = new MailMessage();

                    // Set Properties
                    p_Message.From = new MailAddress("PortMan2014<PortMan2014@avea.com.tr>");
                    p_Message.Subject = p_Subject;

                    // Clear
                    p_Message.To.Clear();
                    p_Message.CC.Clear();

                    // Add TO
                    foreach (string p_mail in p_To.Split(';')) p_Message.To.Add(p_mail);

                    // Add CC
                    if (p_Cc != null) p_Message.CC.Add(p_Cc);

                    // Body
                    p_Message.Body = p_Body;
                    p_Message.IsBodyHtml = false;

                    // Auto Width
                    p_GridView.OptionsPrint.AutoWidth = false;

                    // Export to Target
                    p_GridView.ExportToXls(alfaMail.FileName);

                    // Attachment
                    var p_Attachment = new Attachment(alfaMail.FileName);

                    // Add Attachment
                    p_Message.Attachments.Add(p_Attachment);

                    // Set Properties
                    p_Smtp.Port = 25;
                    p_Smtp.Host = "intmailrelay.tt-tim.tr";
                    p_Smtp.Send(p_Message);

                    // Clear Attachment
                    p_Message.Attachments.Dispose();
                }
            }

            catch (Exception ex)
            {
                // Error
                alfaMsg.Error(ex);
            }

            finally
            {
                // Clear
                alfaMail.ClearAttachment();
            }
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static Attachment CreateAttachment(GridView p_GridView)
		{
			try
			{
                // Auto Width
                p_GridView.OptionsPrint.AutoWidth = false;

                // Export to Target
                p_GridView.ExportToXls(alfaMail.FileName);

                // Attachment
                var p_Attachment = new Attachment(alfaMail.FileName);

                // Return
                return p_Attachment;
			}

			catch (Exception ex)
			{
				// Error
                alfaMsg.Error(ex); return null;
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void ClearAttachment()
		{
			try
			{
                if (System.IO.File.Exists(alfaMail.FileName))
                {
                    // Delete File
                    System.IO.File.Delete(alfaMail.FileName);
                }
			}

			catch (Exception ex)
			{
				// Error
                alfaMsg.Error(ex); 
			}
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion


	#region //-----------alfaLog------------//

	public class alfaLog
	{
		public static string LogText = null;

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void Add(string p_Text)
		{
			// DateTime
			var dtNow = DateTime.Now;

			// Get Text
			var lstr = string.Format("[ {0} / {1} ] = {2} ", alfaDate.GetDate_V5(dtNow), alfaSession.UserGroupAdmin(), p_Text);

			// Add Log
			alfaLog.LogText += Environment.NewLine + lstr;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void Add(string p_Text, double p_Seconds)
		{
			// DateTime
			var dtNow = DateTime.Now;

			// Get Text
			var lstr = string.Format("[ {0} / {1} ] = {2} [ OK = {3:0.0} sec ]", alfaDate.GetDate_V5(dtNow), alfaSession.UserGroupAdmin(), p_Text, p_Seconds);

			// Add Log
			alfaLog.LogText += Environment.NewLine + lstr;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static void Clear()
		{ 
			// Clear Log
			alfaLog.LogText = string.Empty;
		}
	
		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion


	#region //-----------alfaFtp------------//

	public class alfaFtp
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static Ftp Create(string p_Address)
		{
            // FTP
            var ftp = new Rebex.Net.Ftp();

            // Connect-Login
            ftp.Connect(p_Address);
            ftp.Login(alfaNET.m_FtpUser, alfaNET.m_FtpPass);

            // Check Directory
            if (!ftp.DirectoryExists(alfaNET.m_FtpPath)) ftp.CreateDirectory(alfaNET.m_FtpPath);

            // Change Directory
            ftp.ChangeDirectory(alfaNET.m_FtpPath);

            // Return 
            return ftp;
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//

		public static Ftp Get()
		{
            try
            {
                // Try Server (1)
                return alfaFtp.Create(alfaNET.m_FtpAdd1);
            }

            catch
            {
                // Log    
                alfaLog.Add("(FTP) Server Switched ... !");
                alfaLog.Add("(FTP) Server = " + alfaNET.m_FtpAdd2);

                // Try Server (2)
                var p_Value = alfaFtp.Create(alfaNET.m_FtpAdd2);

                // Update DB Values
                alfaEntity.TablePrms_SetDBValue("SamAdd1", alfaNET.m_SamAdd2);
                alfaEntity.TablePrms_SetDBValue("SamAdd2", alfaNET.m_SamAdd1);
                alfaEntity.TablePrms_SetDBValue("FtpAdd1", alfaNET.m_FtpAdd2);
                alfaEntity.TablePrms_SetDBValue("FtpAdd2", alfaNET.m_FtpAdd1);

                // Return
                return p_Value;
            }
		}

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion


	#region //-----------alfaWeb------------//

	public class alfaWeb
	{
		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string Create(string p_Address, string p_XmlQry)
        {
            // Create
            HttpWebRequest p_Request = (HttpWebRequest)WebRequest.Create(p_Address);
            p_Request.Headers.Add(@"SOAP:Action");
            p_Request.ContentType = "text/xml;charset=\"utf-8\"";
            p_Request.Accept = "text/xml";
            p_Request.Method = "POST";

            // XmlDoc
            XmlDocument p_XmlDoc = new XmlDocument();

            // Load XML
            p_XmlDoc.LoadXml(p_XmlQry);

            // Save 
            using (Stream stream = p_Request.GetRequestStream())
            {
                p_XmlDoc.Save(stream);
            }

            using (StreamReader rd = new StreamReader(p_Request.GetResponse().GetResponseStream()))
            {
                // Get Result
                string p_Result = (rd.ReadToEnd());

                // Return
                return p_Result;
            }
        }

		//-----------------------------------------------------------------------------------------------------------------------------------------//

        public static string GetWebRequest(string p_XmlQry)
        {
            try
            {
                // Try Server (1)
                return alfaWeb.Create(alfaNET.m_SamAdd1, p_XmlQry);
            }

            catch
            {
                // Log    
                alfaLog.Add("(XML) Server Switched ... !");
                alfaLog.Add("(XML) Server = " + alfaNET.m_SamAdd2);

                // Try Server (2)
                var p_Value = alfaWeb.Create(alfaNET.m_SamAdd2, p_XmlQry);

                // Update DB Values
                alfaEntity.TablePrms_SetDBValue("SamAdd1", alfaNET.m_SamAdd2);
                alfaEntity.TablePrms_SetDBValue("SamAdd2", alfaNET.m_SamAdd1);
                alfaEntity.TablePrms_SetDBValue("FtpAdd1", alfaNET.m_FtpAdd2);
                alfaEntity.TablePrms_SetDBValue("FtpAdd2", alfaNET.m_FtpAdd1);

                // Return
                return p_Value;
            }
        }

		//-----------------------------------------------------------------------------------------------------------------------------------------//
	}

	#endregion

}