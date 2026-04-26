using System;
using System.Data;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;



using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using File = System.IO.File;
using Microsoft.Win32;


using System.Data.SqlClient;
using System.Configuration;

using System.Text.RegularExpressions; // لإزالة GO

namespace ZAD_Sales.Forms
{
    public partial class Connection : Form
    {

        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);


        private string ConnectionString = "Integrated Security=SSPI;" + "Initial Catalog=;" + "Data Source=.\\SQLEXPRESS;";

        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;

        OpenFileDialog ofd;
        string folderName;
        public Connection()
        {
            InitializeComponent();
            ofd = new OpenFileDialog();
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "2042017")
            {
                TabControl.Visible = true;
            }
            else
            {
                TabControl.Visible = false;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            string connectionstring = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", combServer.Text, textDatabase.Text);
            try
            {
                SqlHelper Helper = new SqlHelper(connectionstring);
                if (Helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveconnctionString("ConnectionStringData", connectionstring);

                    setting.SaveconnctionString("ZAD_Sales.Properties.Settings.ZADConnectionString", connectionstring);

                    //setting.SaveconnctionString("ZAD_Sales.Properties.Settings.constring", connectionstring);

                    //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


                    MessageBox.Show("تم الاتصال بنجاج", "الاتصال");

                }
            }
            catch
            {
                MessageBox.Show("   فشل الاتصال    ", "الاتصال");


            }

            Properties.Settings.Default.DataName = textDatabase.Text;
            Properties.Settings.Default.Save();

            //string connectionstring = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", combServer.Text, textDatabase.Text);
            //try
            //{
            //    SqlHelper Helper = new SqlHelper(connectionstring);
            //    if (Helper.IsConnection)
            //    {
            //        AppSetting setting = new AppSetting();
            //        setting.SaveconnctionString("elwesifConnectionString", connectionstring);
            //        setting.SaveconnctionString("إدارة_المخازن.Properties.Settings.elwesifConnectionString", connectionstring);

            //        //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


            //        MessageBox.Show("yes connection", "yes suc");

            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("noooooooooooooooooooooo connection", "no suc");


            //}
        }

        private void butSecurity_Click(object sender, EventArgs e)
        {
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            string connectionstring = string.Format("Data Source={0};Initial Catalog={1};Integrated Security={2};User Id={3};Password={4}", combServerSecurity.Text, textDatabaseSec.Text, textSecurity.Text, textUserSecu.Text, textPasswordSec.Text);
            try
            {
                SqlHelper Helper = new SqlHelper(connectionstring);
                if (Helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveconnctionString("ConnectionStringData", connectionstring);

                    setting.SaveconnctionString("ZAD_Sales.Properties.Settings.ZADConnectionString", connectionstring);

                    // setting.SaveconnctionString("إدارة_المخازن.Properties.Settings.elwesifConnectionString", connectionstring);

                    //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


                    //ZAD_Sales.Properties.Settings.ZADConnectionString

                    MessageBox.Show("تم الاتصال بنجاج", "الاتصال");

                }

                Properties.Settings.Default.DataName = textDatabaseSec.Text;
                Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("   فشل الاتصال    ", "الاتصال");


            }


        }

        private void butSecurityIP_Click(object sender, EventArgs e)
        {
            //Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;
            string connectionstring = string.Format("Data Source={0};Network Library={1};Initial Catalog={2};Integrated Security={3};User Id={4};Password={5}", combServerSecurityIP.Text + "," + textPort.Text, textLibrary.Text, textDatabaseSecIP.Text, textSecurityIP.Text, textUserSecuIP.Text, textPasswordSecIP.Text);
            textConnectionStringSecIP.Text = connectionstring ;

            try
            {
                SqlHelper Helper = new SqlHelper(connectionstring);
                if (Helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveconnctionString("ConnectionStringData", connectionstring);

                    setting.SaveconnctionString("ZAD_Sales.Properties.Settings.ZADConnectionString", connectionstring);

                    //setting.SaveconnctionString("ZAD_Sales.Properties.Settings.constring", connectionstring);

                    // setting.SaveconnctionString("إدارة_المخازن.Properties.Settings.elwesifConnectionString", connectionstring);

                    //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


                    MessageBox.Show("تم الاتصال بنجاج", "الاتصال");

                }


                Properties.Settings.Default.DataName = textDatabaseSecIP.Text;
                Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("   فشل الاتصال    ", "الاتصال");


            }

        }

        private void Connection_Load(object sender, EventArgs e)
        {
            textUser.Text = AppSetting.user;


            combServer.Items.Add(".");
            combServer.Items.Add("(local)");
            combServer.Items.Add(@".\SQLEXPESS");
            combServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            combServer.SelectedIndex = 3;

            //----------------------------------
            combServerSecurity.Items.Add(".");
            combServerSecurity.Items.Add("(local)");
            combServerSecurity.Items.Add(@".\SQLEXPESS");
            combServerSecurity.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            combServerSecurity.SelectedIndex = 3;
            //----------------------------------
            combServerSecurityIP.Items.Add(".");
            combServerSecurityIP.Items.Add("(local)");
            combServerSecurityIP.Items.Add(@".\SQLEXPESS");
            combServerSecurityIP.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            combServerSecurityIP.SelectedIndex = 3;
            //----------------------------------
            comboServers.Items.Add(".");
            comboServers.Items.Add("(local)");
            comboServers.Items.Add(@".\SQLEXPESS");
            comboServers.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            comboServers.SelectedIndex = 3;
            //-------------------------------------------
            textConnectionString.Text = Properties.Settings.Default.constring;
            textConnectionStringSec.Text = Properties.Settings.Default.constring;
            textConnectionStringSecIP.Text = Properties.Settings.Default.constring;


            //----------- ServerName ----------------------
            combServerName.Items.Add(".");
            combServerName.Items.Add("(local)");
            combServerName.Items.Add(string.Format(@"{0}", Environment.MachineName));
            combServerName.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            combServerName.SelectedIndex = 3;
            //----------- ServerName ----------------------
            comServerCreatData.Items.Add(".");
            comServerCreatData.Items.Add("(local)");
            comServerCreatData.Items.Add(string.Format(@"{0}", Environment.MachineName));
            comServerCreatData.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            comServerCreatData.SelectedIndex = 3;
            //----------- ServerName ----------------------
            combServerNameAttach.Items.Add(".");
            combServerNameAttach.Items.Add("(local)");
            combServerNameAttach.Items.Add(string.Format(@"{0}", Environment.MachineName));
            combServerNameAttach.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            combServerNameAttach.SelectedIndex = 3;

            //----------- Database ----------------------
            combDatabase.Items.Add("ZAD");
            combDatabase.Items.Add("elwesif");
            combDatabase.Items.Add("Pharmacy");
        }

        private void butAttach_Click(object sender, EventArgs e)
        {
            if (combDatabase.Text == "" || combServerName.Text == "")
            {
                MessageBox.Show(" من فضلك اختار اسم السرفر و اسم قاعدة البيانات", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                SqlConnection conDB = new SqlConnection(@"Data Source='" + combServerName.Text + "';Initial Catalog=master;Integrated Security=True;");
                try
                {
                    //Open Master Database
                    if (conDB.State == ConnectionState.Closed)
                        conDB.Open();

                    //   SqlCommand com = new SqlCommand("select count(*) from sys.databases WHERE name='elwesif'", conDB);
                    openFileDialog1.Filter = "sql|*.mdf";
                    // openFileDialog1.CheckFileExists = true;
                    // openFileDialog1.CheckPathExists = true;
                    openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory(); // لجعلها ان تفتح فى مكان البرنامج ويمكننا وضع مسار افتراضى
                    SqlCommand com = new SqlCommand("select count(*) from sys.databases WHERE name='" + combDatabase.Text + "'", conDB);
                    if (((int)com.ExecuteScalar()) == 0)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            // textBox4.Text = openFileDialog1.FileName;
                            DriveInfo oDrive = new DriveInfo(openFileDialog1.FileName.Substring(0, 1).ToString());
                            if (oDrive.DriveType != DriveType.Fixed)
                                MessageBox.Show("Copy the Backup File To Local Hard Disk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            else
                            {
                                //ATTACH DB
                                // com.CommandText = "CREATE DATABASE [elwesif] ON ( FILENAME = N'" + openFileDialog1.FileName.ToString() + "' ) FOR ATTACH";

                                com.CommandText = "CREATE DATABASE [" + combDatabase.Text + "] ON ( FILENAME = N'" + openFileDialog1.FileName.ToString() + "' ) FOR ATTACH";

                                com.ExecuteNonQuery();



                                MessageBox.Show("تم ارفاق قاعدة البيانات بنجاح", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("  الداتا بيز موجودة من قبل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conDB.Close();

                }
        }
        }

        private void butAddBath_Click(object sender, EventArgs e)
        {
            string folderName;

            var folderBrowserDialog1 = new FolderBrowserDialog();

            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                textAddBath.Text = folderName + "\\" + textDBName.Text;
            }
        }

        private void butCreatData_Click(object sender, EventArgs e)
        {
            //================== CreatDatabse ===============================
            String str;
            SqlConnection myConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");



            //str = "CREATE DATABASE " + textBox1.Text + " ON PRIMARY " +
            //  "(NAME = MyDatabase_Data, " +
            //  "FILENAME = 'E:\\Alwasif\\Data\\" + textBox1.Text + ".mdf', " +
            //  "SIZE = 3MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            //  "LOG ON (NAME = " + textBox1.Text + ", " +
            //  "FILENAME = 'E:\\Alwasif\\Data\\" + textBox1.Text + ".ldf', " +
            //  "SIZE = 1MB, " +
            //  "MAXSIZE = 5MB, " +
            //  "FILEGROWTH = 10% ) COLLATE Arabic_CI_AS ";

            str = "CREATE DATABASE " + textDBName.Text + " ON PRIMARY " +
              "(NAME = MyDatabase_Data, " +
              "FILENAME = '" + textAddBath.Text + ".mdf', " +
              "SIZE = 3MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
              "LOG ON (NAME = " + textDBName.Text + ", " +
              "FILENAME = '" + textAddBath.Text + ".ldf', " +
              "SIZE = 1MB, " +
              "MAXSIZE = 5MB, " +
              "FILEGROWTH = 10% ) COLLATE Arabic_CI_AS ";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "Creat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                //label3.Text = "Error occured.+ " + ex.Message.ToString();
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

            //====================== CreatTables  =============================

            //string cons = null;
            //if (radioButton1.Checked)
            //{
            //    cons = @"Server=" + comServerCreatData.Text + ";Initial Catalog=" + "master" +
            //    ";User ID=" + txtusername.Text + ";password=" + txtpassword.Text + ";Persist Security Info=False";

            //}
            //else
            //{
            //    cons = @"Data Source=" + comServerCreatData.Text + ";Initial Catalog=" + "master" +
            //      ";Integrated Security=SSPI";
            //}


            //SqlConnection cnxc = new SqlConnection(cons);

            //string sqlConnectionString = cons;


            //string script = @"use [" + textDBName.Text + "]" + Environment.NewLine + "  Go  " + Environment.NewLine + txtSqlScript.Text;

            //SqlConnection conn = new SqlConnection(sqlConnectionString);

            //Server server = new Server(new ServerConnection(conn));

            ////try
            ////{
            //server.ConnectionContext.ExecuteNonQuery(script);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textAddBath.Text = folderName + "\\" + textDBName.Text;

           // textBox5.Text = textBox5.Text;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if(txtSqlScript.Visible==true)
            {
                txtSqlScript.Visible = false;
            }
            else
            {
                txtSqlScript.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combDatabaseAttach.Text == "" || combServerNameAttach.Text == "")
            {
                MessageBox.Show(" من فضلك اختار اسم السرفر و اسم قاعدة البيانات", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                SqlConnection conDB = new SqlConnection(@"Data Source='" + combServerNameAttach.Text + "';Initial Catalog=master;Integrated Security=True;");
                try
                {
                    //Open Master Database
                    if (conDB.State == ConnectionState.Closed)
                        conDB.Open();

                    //   SqlCommand com = new SqlCommand("select count(*) from sys.databases WHERE name='elwesif'", conDB);
                    openFileDialog1.Filter = "sql|*.mdf";
                    // openFileDialog1.CheckFileExists = true;
                    // openFileDialog1.CheckPathExists = true;
                    openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory(); // لجعلها ان تفتح فى مكان البرنامج ويمكننا وضع مسار افتراضى
                    SqlCommand com = new SqlCommand("select count(*) from sys.databases WHERE name='" + combDatabaseAttach.Text + "'", conDB);
                    if (((int)com.ExecuteScalar()) == 0)
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            // textBox4.Text = openFileDialog1.FileName;
                            DriveInfo oDrive = new DriveInfo(openFileDialog1.FileName.Substring(0, 1).ToString());
                            if (oDrive.DriveType != DriveType.Fixed)
                                MessageBox.Show("Copy the Backup File To Local Hard Disk", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            else
                            {
                                //ATTACH DB
                                // com.CommandText = "CREATE DATABASE [elwesif] ON ( FILENAME = N'" + openFileDialog1.FileName.ToString() + "' ) FOR ATTACH";

                                com.CommandText = "CREATE DATABASE [" + combDatabaseAttach.Text + "] ON ( FILENAME = N'" + openFileDialog1.FileName.ToString() + "' ) FOR ATTACH";

                                com.ExecuteNonQuery();



                                MessageBox.Show("تم ارفاق قاعدة البيانات بنجاح", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("    قاعدة البيانات موجودة بالفعل   ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conDB.Close();

                }
            }

        }

        private void radioCreatDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (radioCreatDataBase.Checked == true)
            {
                groupCreatDataBase.Enabled = true;
                groupAttach.Enabled = false;
            }
            else
            {
                groupCreatDataBase.Enabled = false;
                groupAttach.Enabled = true;

            }
        }

        private void radioAttach_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAttach.Checked == true)
            {
                groupCreatDataBase.Enabled = false;
                groupAttach.Enabled = true;
            }
            else
            {
                groupCreatDataBase.Enabled = true;
                groupAttach.Enabled = false;

            }
        }

        private void butCreatUser_Click(object sender, EventArgs e)
        {
            string cons = null;




            cons = @"Data Source=" + comServerCreatData.Text + ";Initial Catalog=" + "master" +
                  ";Integrated Security=SSPI";

            string sqlConnectionString = cons;

            //    string script = @"[" + textBox2.Text + "]" ;
            //  string script = @"use [master]" + Environment.NewLine + "  Go  " + Environment.NewLine + textBox2.Text;

            string script = @"CREATE LOGIN [" + textBoxUserName.Text + "] WITH PASSWORD=N'" + textBoxPassword.Text + "', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF" + Environment.NewLine + "  Go  " + Environment.NewLine + "ALTER LOGIN [" + textBoxUserName.Text + "] ENABLE" + Environment.NewLine + "  Go  " + Environment.NewLine + "ALTER SERVER ROLE [sysadmin] ADD MEMBER [" + textBoxUserName.Text + "]" + Environment.NewLine + "  Go  ";


            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            //try
            //{

            server.ConnectionContext.ExecuteNonQuery(script);

            //}
            //catch (Exception)
            //{

            //}




            //

            MessageBox.Show("تم انشاء الامستخدم بنجاح  ", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked==true)
            {
                txtSqlScript.Text = textTablesWin10.Text;
            }
            else if (radioButton4.Checked == true)
            {
                txtSqlScript.Text = textTablesWin7.Text;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                txtSqlScript.Text = textTablesWin10.Text;
            }
            else if (radioButton4.Checked == true)
            {
                txtSqlScript.Text = textTablesWin7.Text;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            // التحقق من المدخلات
            if (string.IsNullOrWhiteSpace(comServerCreatData.Text))
            {
                MessageBox.Show("يرجى إدخال اسم السيرفر أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textDBName.Text))
            {
                MessageBox.Show("يرجى إدخال اسم قاعدة البيانات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSqlScript.Text))
            {
                MessageBox.Show("يرجى إدخال سكريبت SQL.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // بناء نص الاتصال
            string connectionString = $"Server={comServerCreatData.Text};Database={textDBName.Text};Integrated Security=True;";
            string script = txtSqlScript.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // تقسيم السكريبت حسب كلمة GO
                    string[] commands = script.Split(new string[] { "\r\nGO", "\nGO", "\rGO" }, StringSplitOptions.RemoveEmptyEntries);

                    int executed = 0;

                    foreach (string rawCommand in commands)
                    {
                        string command = rawCommand.Trim();
                        if (string.IsNullOrWhiteSpace(command))
                            continue;

                        using (SqlCommand cmd = new SqlCommand(command, conn))
                        {
                            cmd.CommandTimeout = 0; // تعطيل المهلة الزمنية
                            try
                            {
                                cmd.ExecuteNonQuery();
                                executed++;
                            }
                            catch (Exception exInner)
                            {
                                MessageBox.Show($"⚠️ خطأ أثناء تنفيذ أمر SQL:\n\n{command}\n\nالرسالة:\n{exInner.Message}",
                                    "خطأ في التنفيذ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    MessageBox.Show($"✅ تم تنفيذ السكريبت بنجاح.\nعدد الأوامر المنفذة: {executed}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ حدث خطأ أثناء الاتصال أو التنفيذ:\n\n" + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=True;"; // عدّل حسب السيرفر
            //string script = txtSqlScript.Text;

            //if (string.IsNullOrWhiteSpace(script))
            //{
            //    MessageBox.Show("الرجاء إدخال سكريبت SQL أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();

            //        // نقسم السكريبت حسب GO
            //        string[] commands = script.Split(new string[] { "\r\nGO", "\nGO", "\rGO" }, StringSplitOptions.RemoveEmptyEntries);

            //        string currentDb = "master"; // نبدأ من master افتراضيًا

            //        foreach (string rawCommand in commands)
            //        {
            //            string command = rawCommand.Trim();

            //            if (string.IsNullOrWhiteSpace(command))
            //                continue;

            //            // لو كان فيه USE [DatabaseName]
            //            if (command.StartsWith("USE ", StringComparison.OrdinalIgnoreCase))
            //            {
            //                int start = command.IndexOf("[") + 1;
            //                int end = command.IndexOf("]");
            //                if (start > 0 && end > start)
            //                {
            //                    currentDb = command.Substring(start, end - start);
            //                }
            //                continue; // لا ننفذه كـ SQL
            //            }

            //            using (SqlCommand cmd = new SqlCommand(command, conn))
            //            {
            //                cmd.CommandTimeout = 0;

            //                // نبدّل قاعدة البيانات إذا تغيرت
            //                cmd.Connection.ChangeDatabase(currentDb);

            //                try
            //                {
            //                    cmd.ExecuteNonQuery();
            //                }
            //                catch (Exception exInner)
            //                {
            //                    MessageBox.Show($"خطأ في تنفيذ الأمر:\n{command}\n\nالرسالة:\n{exInner.Message}",
            //                        "خطأ في السكريبت", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }

            //        MessageBox.Show("✅ تم تنفيذ السكريبت بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("حدث خطأ أثناء الاتصال أو التنفيذ:\n" + ex.Message,
            //        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}






            ////// 1. تحديد سلسلة الاتصال (Connection String)
            ////// هام: يجب الاتصال بقاعدة بيانات 'master' لكي تتمكن من إنشاء قاعدة بيانات جديدة.
            ////// قم بتغيير 'Your_Server_Name' إلى اسم السيرفر الخاص بك
            ////// (مثال: . , localhost, (localdb)\MSSQLLocalDB, أو اسم السيرفر كاملاً)
            ////string connectionString = "Server=Your_Server_Name;Integrated Security=True;Database=master";

            ////// 2. قراءة السكريبت من الـ TextBox
            ////string script = txtSqlScript.Text;

            ////// 3. معالجة كلمة 'GO' لأنها غير مفهومة لـ ADO.NET
            ////// نقوم بتقسيم السكريبت إلى أجزاء عند كل كلمة GO
            ////IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
            ////                                   RegexOptions.Multiline | RegexOptions.IgnoreCase);

            ////try
            ////{
            ////    using (SqlConnection connection = new SqlConnection(connectionString))
            ////    {
            ////        connection.Open();
            ////        foreach (string commandString in commandStrings)
            ////        {
            ////            // تجاهل الأجزاء الفارغة
            ////            if (string.IsNullOrWhiteSpace(commandString)) continue;

            ////            using (SqlCommand command = new SqlCommand(commandString, connection))
            ////            {
            ////                // ExecuteNonQuery يُستخدم للأوامر التي لا تُرجع بيانات (مثل CREATE, INSERT, UPDATE)
            ////                command.ExecuteNonQuery();
            ////            }
            ////        }
            ////    }
            ////    MessageBox.Show("تم تنفيذ السكريبت بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////}
            ////catch (Exception ex)
            ////{
            ////    // في حالة حدوث أي خطأ، يتم عرضه هنا
            ////    MessageBox.Show("حدث خطأ أثناء تنفيذ السكريبت: \n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShow.Checked==true)
            {
                txtSqlScript.Visible = true;
            }
            else
            {
                txtSqlScript.Visible = false;

            }
        }


        //======== 3. دالة الحفظ
        void SaveUpdate(string connectionString, string version, string description, string script,
                  DateTime date, string user, bool isSuccess, string errorMessage)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO DB_Versions
            (VersionNo, Description, ScriptContent, AppliedDate, AppliedBy, IsSuccess, ErrorMessage)
            VALUES
            (@Version, @Description, @Script, @Date, @User, @IsSuccess, @Error)
        ", con);

                cmd.Parameters.AddWithValue("@Version", version);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Script", script);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@User", user);
                cmd.Parameters.AddWithValue("@IsSuccess", isSuccess);

                if (errorMessage == null)
                    cmd.Parameters.AddWithValue("@Error", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Error", errorMessage);

                cmd.ExecuteNonQuery();
            }
        }

        //===== 2. دالة تنفيذ السكربت


        //void ExecuteScript(string connectionString, string script)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand(script, con);
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        void ExecuteScript(string connectionString, string script)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    var commands = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                    foreach (var commandText in commands)
                    {
                        if (string.IsNullOrWhiteSpace(commandText))
                            continue;

                        using (SqlCommand cmd = new SqlCommand(commandText, con, trans))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }


        //=== دالة التاكد من عدم تكرار التحديث
        bool IsVersionExists(string connectionString, string version)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM DB_Versions WHERE VersionNo = @Version", con);

                cmd.Parameters.AddWithValue("@Version", version);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void butUpdateData_Click(object sender, EventArgs e)
        {
            string connectionString = $"Server={comboServers.Text};Database={comboDatabases.Text};Integrated Security=True;";

            string conn = connectionString ;

            string version = combVersionsUpdate.Text;
            string description = textDescription.Text;
            string script = txtSqlScriptUpdateData.Text;
            DateTime date = dateTimePicker1.Value;
            string user = textUser.Text;

            // 🔹 تحقق من البيانات
            if (string.IsNullOrWhiteSpace(version) || string.IsNullOrWhiteSpace(script))
            {
                MessageBox.Show("بيانات غير مكتملة");
                return;
            }

            // ============================================
            // 🔥 هنا المكان الصحيح لمنع التكرار
            // ============================================
            if (IsVersionExists(conn, version))
            {
                MessageBox.Show("هذا الإصدار تم تطبيقه مسبقاً");
                return; // ⛔ وقف التنفيذ بالكامل
            }

            try
            {
                // 🔹 تنفيذ السكربت
                ExecuteScript(conn, script);

                // 🔹 حفظ نجاح العملية
                SaveUpdate(conn, version, description, script, date, user, true, null);

                MessageBox.Show("تم التنفيذ بنجاح");
            }
            catch (Exception ex)
            {
                // 🔹 حفظ الخطأ
                SaveUpdate(conn, version, description, script, date, user, false, ex.Message);

                MessageBox.Show("خطأ: " + ex.Message);
            }

        }

        private void butUpdateData_Click_1(object sender, EventArgs e)
        {

            // التحقق من المدخلات
            if (string.IsNullOrWhiteSpace(comboServers.Text))
            {
                MessageBox.Show("يرجى إدخال اسم السيرفر أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboDatabases.Text))
            {
                MessageBox.Show("يرجى إدخال اسم قاعدة البيانات.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSqlScriptUpdateData.Text))
            {
                MessageBox.Show("يرجى إدخال سكريبت SQL.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // بناء نص الاتصال
            string connectionString = $"Server={comboServers.Text};Database={comboDatabases.Text};Integrated Security=True;";
            string script = txtSqlScriptUpdateData.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // تقسيم السكريبت حسب كلمة GO
                    string[] commands = script.Split(new string[] { "\r\nGO", "\nGO", "\rGO" }, StringSplitOptions.RemoveEmptyEntries);

                    int executed = 0;

                    foreach (string rawCommand in commands)
                    {
                        string command = rawCommand.Trim();
                        if (string.IsNullOrWhiteSpace(command))
                            continue;

                        using (SqlCommand cmd = new SqlCommand(command, conn))
                        {
                            cmd.CommandTimeout = 0; // تعطيل المهلة الزمنية
                            try
                            {
                                cmd.ExecuteNonQuery();
                                executed++;
                            }
                            catch (Exception exInner)
                            {
                                MessageBox.Show($"⚠️ خطأ أثناء تنفيذ أمر SQL:\n\n{command}\n\nالرسالة:\n{exInner.Message}",
                                    "خطأ في التنفيذ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    MessageBox.Show($"✅ تم تنفيذ السكريبت بنجاح.\nعدد الأوامر المنفذة: {executed}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            //    // ============================================
            //    // 💾 ثانياً: حفظ بيانات التحديث في جدول DB_Versions
            //    // ============================================
            //    // الهدف من الخطوة دي:
            //    // 1- تسجيل إن التحديث تم تنفيذه
            //    // 2- منع تكرار نفس الإصدار مستقبلاً
            //    // 3- الاحتفاظ بالسكربت للمراجعة
            //    // 4- معرفة مين نفذ التحديث وامتى

            //    SqlCommand insertCmd = new SqlCommand(@"
            //    INSERT INTO DB_Versions
            //    (VersionNo, ScriptContent, AppliedBy, AppliedDate, IsSuccess)
            //    VALUES
            //    (@Version, @Script, @User, GETDATE(), 1)
            //", cn, trans);

            //    insertCmd.Parameters.AddWithValue("@Version", version);
            //    insertCmd.Parameters.AddWithValue("@Script", script);
            //    insertCmd.Parameters.AddWithValue("@User", userName);

            //    insertCmd.ExecuteNonQuery();


            //    // ============================================
            //    // ✅ ثالثاً: تأكيد العملية (Commit)
            //    // ============================================
            //    // لو كل حاجة تمت بنجاح (تنفيذ السكربت + الحفظ)
            //    // يتم حفظ التغييرات بشكل نهائي في الداتا بيز

            //    trans.Commit();

            //    MessageBox.Show("تم تنفيذ التحديث وحفظه بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ حدث خطأ أثناء الاتصال أو التنفيذ:\n\n" + ex.Message,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioSqlAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if(radioSqlAuthentication.Checked==true)
            {
                textUserName.Visible = true;
                textPassword.Visible = true;
                labUserName.Visible = true;
                labPassword.Visible = true;
            }
            else
            {
                textUserName.Visible = false;
                textPassword.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
            }
        }

        private void radioWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSqlAuthentication.Checked == true)
            {
                textUserName.Visible = true;
                textPassword.Visible = true;
                labUserName.Visible = true;
                labPassword.Visible = true;
            }
            else
            {
                textUserName.Visible = false;
                textPassword.Visible = false;
                labUserName.Visible = false;
                labPassword.Visible = false;
            }
        }

        private void combVersionsUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combVersionsUpdate.Text== "Occasions")
            {
                txtSqlScriptUpdateData.Text = textOccasions.Text;
            }
            else if (combVersionsUpdate.Text== "UsersUpdate")
            {
                txtSqlScriptUpdateData.Text = textUsersUpdate.Text;
            }
            else if (combVersionsUpdate.Text == "ProfitRate")
            {
                txtSqlScriptUpdateData.Text = textProfitRate.Text;
            }
            else if (combVersionsUpdate.Text == "TextToNvarchar")
            {
                txtSqlScriptUpdateData.Text = textTextToNvarchar.Text;
            }
            else if (combVersionsUpdate.Text == "Version16")
            {
                txtSqlScriptUpdateData.Text = textVersion16.Text;
            }
            else if (combVersionsUpdate.Text == "DB_Versions")
            {
                txtSqlScriptUpdateData.Text = textDB_Versions.Text;
            }
            else
            {
               // txtSqlScriptUpdateData.Text = textOccasions.Text;
            }
        }
    }
}
