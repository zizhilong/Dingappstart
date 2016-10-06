using Cn.Ubingo.Security.RSA.Core;
using Cn.Ubingo.Security.RSA.Data;
using Cn.Ubingo.Security.RSA.Key;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Resources;
namespace xsrun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void 退出_Click(object sender, EventArgs e)
        {
            //Cn.Ubingo.Security.RSA.Core
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("xsrun", path);
                rk2.Close();
                rk.Close();
            }
            catch
            {

            }
            this.ShowInTaskbar = false;
            //生成公私钥对
            KeyPair keyPair = KeyGenerator.GenerateKeyPair();

            //转换成不同的格式
            KeyPair asnKeyPair = keyPair.ToASNKeyPair();
            KeyPair xmlKeyPair = asnKeyPair.ToXMLKeyPair();
            KeyPair pemKeyPair = xmlKeyPair.ToPEMKeyPair();

            //获取公私钥
            string privateKey = xmlKeyPair.PrivateKey;
            string publicKey = xmlKeyPair.PublicKey;

            //加解密

            //XML
            //KeyWorker privateWorker = new KeyWorker(privateKey, KeyFormat.XML);
            //KeyWorker publicWorker = new KeyWorker(publicKey, KeyFormat.XML);

            //Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            //Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));

            //ASN
            //privateWorker = new KeyWorker(asnKeyPair.PrivateKey, KeyFormat.ASN);
            //publicWorker = new KeyWorker(asnKeyPair.PublicKey, KeyFormat.ASN);

            //Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            //Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));

            //PEM
            //KeyWorker privateWorker = new KeyWorker(pemKeyPair.PrivateKey, KeyFormat.PEM);
            KeyWorker publicWorker = new KeyWorker(@"-----BEGIN PUBLIC KEY-----
MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDQJr012JxtuUykNe7/QDc+Q03t
1xGP6zruUh60u7o7Z/klGQgMEPnbEIoMWy+i+fraFUsrVg0ZL95lAW50n2t4SwYr
OgIgkOsnGxpdgopN6GPtlY1LPBmKpDXkz6aCkxfzr9AYAJ/ZpeyvaGKvezR3y3ug
19QETHI7p7z5xmpAXQIDAQAB
-----END PUBLIC KEY-----", KeyFormat.PEM);
            //string a = publicWorker.Encrypt("你好！世界");
            //textBox1.Text=(startServer.byteToHexStr(Convert.FromBase64String(publicWorker.Encrypt("{ \"Type\" : \"ftp\"}"))));
            //startServer.
            //MessageBox.Show(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            //Console.WriteLine(privateWorker.Decrypt(publicWorker.Encrypt("你好！世界")));
            //Console.WriteLine(publicWorker.Decrypt(privateWorker.Encrypt("你好！中国")));

            //Program rsa = new Program();
            //Cn.Ubingo.Security.RSA.Test.Program rsa = new Cn.Ubingo.Security.RSA.Test.Program();
            //MessageBox.Show(rsa.ToString);
            //rsa.e
            //System.Resources.ResourceManager rs = new System.Resources.ResourceManager("NetWebBrowser.Resource", typeof(Resource).Assembly);


            //MessageBox.Show(xsrun.Properties.Resources.ResourceManager.GetString("Rsa")); 
            RegistryKey key = Registry.LocalMachine;
            RegistryKey software = key.CreateSubKey("software\\xsrun");
            if (software.GetValue("ftp") != null)
                this.ftp_input.Text = software.GetValue("ftp").ToString();
            if (software.GetValue("web") != null)
                this.web_input.Text = software.GetValue("web").ToString();
            if (software.GetValue("navicat") != null)
                this.navicat_input.Text = software.GetValue("navicat").ToString();
            if (software.GetValue("putty") != null)
                this.putty_input.Text = software.GetValue("putty").ToString();
        }
        private void selectFile(string name)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "执行文件|*.exe";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RegistryKey key = Registry.LocalMachine;
                RegistryKey software = key.CreateSubKey("software\\xsrun");
                //this.ftp_input.Text
                string fName = openFileDialog.FileName;
                software.SetValue(name, fName);
                if (name == "ftp")
                    this.ftp_input.Text = fName;
                if (name == "web")
                    this.web_input.Text = fName;
                if (name == "navicat")
                    this.navicat_input.Text = fName;
                if (name == "putty")
                    this.putty_input.Text = fName;
            }
        }
        private void ftp_button_Click(object sender, EventArgs e)
        {
            this.selectFile("ftp");
        }

        private void naviocat_buitton_Click(object sender, EventArgs e)
        {
            this.selectFile("navicat");
        }

        private void web_button_Click(object sender, EventArgs e)
        {
            this.selectFile("web");
        }

        private void putty_button_Click(object sender, EventArgs e)
        {
            this.selectFile("putty");
        }

        private void navicat_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide(); //或者是this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void exitmenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出程序吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                Application.Exit();
                this.Close();
                this.Dispose();
                
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            { 
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                //this.notifyIcon1.Icon = this.Icon;
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string host = "211.211.211.211";
            //string username = "root";
            //string password = "root";
            //string port = "3306";

            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.CreateSubKey("Software\\PremiumSoft\\Navicat\\Servers");
            comboBox1.Items.Clear();
            //bool find = false;
            foreach (string subkey in software.GetSubKeyNames())
            {
                if (comboBox1.Text == "")
                {
                    comboBox1.Text = subkey;
                }
                comboBox1.Items.Add(subkey);

                //RegistryKey server = software.OpenSubKey(subkey, true);
                //string this_host = server.GetValue("Host").ToString();
                //string this_username = server.GetValue("UserName").ToString();
                //string this_port = server.GetValue("Port").ToString();
                //if (this_host == host && port == this_port && username == this_username)
                //{
                //    find = true;
                //    server.SetValue("AutoConnect", "1", RegistryValueKind.DWord);

                //}
                //else
                //{
                //    server.SetValue("AutoConnect", "0", RegistryValueKind.DWord);
                //}
                //MessageBox.Show(server.GetValue("AutoConnect").ToString());
                //string thishost=
                //MessageBox.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.CreateSubKey("Software\\PremiumSoft\\Navicat\\Servers");
            RegistryKey server = software.OpenSubKey(comboBox1.Text, true);
            textBox1.Text= server.GetValue("Pwd").ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
