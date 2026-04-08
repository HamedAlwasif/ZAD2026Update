using System;
using System.Data;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;



using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using File = System.IO.File;
using Microsoft.Win32;

namespace ZAD_Sales.Forms
{
    public partial class Connection : Form
    {
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
                    //setting.SaveconnctionString("ZAD_Sales.Properties.Settings.constring", connectionstring);

                    // setting.SaveconnctionString("إدارة_المخازن.Properties.Settings.elwesifConnectionString", connectionstring);

                    //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


                    MessageBox.Show("تم الاتصال بنجاج", "الاتصال");

                }
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
            try
            {
                SqlHelper Helper = new SqlHelper(connectionstring);
                if (Helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveconnctionString("ConnectionStringData", connectionstring);
                    //setting.SaveconnctionString("ZAD_Sales.Properties.Settings.constring", connectionstring);

                    // setting.SaveconnctionString("إدارة_المخازن.Properties.Settings.elwesifConnectionString", connectionstring);

                    //setting.SaveconnctionString("elwesifConnectionStringforweb", connectionstring);


                    MessageBox.Show("تم الاتصال بنجاج", "الاتصال");

                }
            }
            catch
            {
                MessageBox.Show("   فشل الاتصال    ", "الاتصال");


            }

        }

        private void Connection_Load(object sender, EventArgs e)
        {
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
                textAddBath.Text = folderName + "\\" + textBox5.Text;
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

            str = "CREATE DATABASE " + textBox5.Text + " ON PRIMARY " +
              "(NAME = MyDatabase_Data, " +
              "FILENAME = '" + textAddBath.Text + ".mdf', " +
              "SIZE = 3MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
              "LOG ON (NAME = " + textBox5.Text + ", " +
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

            string cons = null;
            if (radioButton1.Checked)
            {
                cons = @"Server=" + comServerCreatData.Text + ";Initial Catalog=" + "master" +
                ";User ID=" + txtusername.Text + ";password=" + txtpassword.Text + ";Persist Security Info=False";

            }
            else
            {
                cons = @"Data Source=" + comServerCreatData.Text + ";Initial Catalog=" + "master" +
                  ";Integrated Security=SSPI";
            }


            SqlConnection cnxc = new SqlConnection(cons);

            string sqlConnectionString = cons;


            string script = @"use [" + textBox5.Text + "]" + Environment.NewLine + "  Go  " + Environment.NewLine + textTables.Text;

            SqlConnection conn = new SqlConnection(sqlConnectionString);

            Server server = new Server(new ServerConnection(conn));

            //try
            //{
            server.ConnectionContext.ExecuteNonQuery(script);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textAddBath.Text = folderName + "\\" + textBox5.Text;

           // textBox5.Text = textBox5.Text;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            if(textTables.Visible==true)
            {
                textTables.Visible = false;
            }
            else
            {
                textTables.Visible = true;
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
                textTables.Text = textTablesWin10.Text;
            }
            else if (radioButton4.Checked == true)
            {
                textTables.Text = textTablesWin7.Text;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textTables.Text = textTablesWin10.Text;
            }
            else if (radioButton4.Checked == true)
            {
                textTables.Text = textTablesWin7.Text;
            }
        }
    }
}
