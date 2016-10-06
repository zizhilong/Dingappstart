using Cn.Ubingo.Security.RSA.Core;
using Cn.Ubingo.Security.RSA.Data;
using Cn.Ubingo.Security.RSA.Key;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Win32;
public  class startServer
{
    HttpListener httpListener;
    Thread Thread;
    public void stop()
    {
        this.Thread.Abort();
        this.httpListener.Stop();
    //this.httpListener.Close();
    }
    public void start()
    { 
        this.httpListener = new HttpListener();

        this.httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
        this.httpListener.Prefixes.Add("http://localhost:8081/");
        this.httpListener.Start();
        this.Thread=new Thread(new ThreadStart(delegate
                {
                    while (httpListener.IsListening)
                    {
                         

                            HttpListenerContext httpListenerContext = this.httpListener.GetContext();
    httpListenerContext.Response.StatusCode = 200;
                             using (StreamWriter writer = new StreamWriter(httpListenerContext.Response.OutputStream))
                            {
                                if(httpListenerContext.Request.RawUrl!= "/favicon.ico" && httpListenerContext.Request.RawUrl!="")
                                {
                                    
                                    KeyWorker privateWorker = new KeyWorker(@"-----BEGIN PRIVATE KEY-----
MIICdQIBADANBgkqhkiG9w0BAQEFAASCAl8wggJbAgEAAoGBANAmvTXYnG25TKQ1
7v9ANz5DTe3XEY/rOu5SHrS7ujtn+SUZCAwQ+dsQigxbL6L5+toVSytWDRkv3mUB
bnSfa3hLBis6AiCQ6ycbGl2Cik3oY+2VjUs8GYqkNeTPpoKTF/Ov0BgAn9ml7K9o
Yq97NHfLe6DX1ARMcjunvPnGakBdAgMBAAECgYBosYNriOatHY1Z7rKl+eOPUoTo
wsrXi2YZpn5BQ0bZSGN88Ekm4Ib7UydMLbUZEQjGFf2371EpQPVn8j9fMyv27fXO
ogRuyMQ0jmrA88H7nKzNwpTG+Vp76Hx2SCaIuDNO4DAgH/YRj4itff19ZNj9e36D
QOPjImqwiKONGoDiYQJBAOgsuEKNpdjxx21uYRgzHumvWRau7AFtJVoIhia3iAjP
pn154v2v9Guiilp71YidDJSfz2AI9jGyJ8gq1PE0LdUCQQDlguuaBq5i3Q4smAIc
o6+1TZKND60B6+/2+WJSIZW0bgmOY/dslo5JiHIXNLaP0x2cHZHN+XtTv5i0jYJo
i6RpAkBuSUfhvV1plzgPQF5421e006ly//Z1mv4iLWhkHcxNuy2v7uUncpydQGGO
J8LAGTHvq5YbXUZtRt5k1AvA4/NdAkAFd3XXKFuU/UDuLPy34+o2fk+ETqBHUHBZ
yJzf6e7f6lMN8jGdg4SGGdrl1JqYmGW3Jzkm189pMkIX4tr9VH4pAkBXV/wROfiZ
lyBI+Np3j5HwoTQH3SoAqHXRRLD1nZlRisGkOBKWzKsc5DgzVAx8lkM/uamP98+x
vvUrb0tU45sJ
-----END PRIVATE KEY-----", KeyFormat.PEM);
                                 string url = httpListenerContext.Request.RawUrl.Trim('/').Trim('?');
                                url = url.Remove(url.IndexOf('&'));
                                //url = "1A7F7E595BB3048BBAC1F45E365337332231F74C9130B0617CFBA52B7EECC3BAB3314D4E38456FBF197015EE485D15F3DA21B19956A8DA4A249C9D6FE523D61D66BB21766B360A19C7114BE24F51450AF8222A9AEF90DD67C7A009718EEE2E4A7EBFF7149149EA3F9586251C1DDAE37C028C6D041615A6F308F6C03D4AB0624A";
                                byte [] data = strToToHexByte(url);
                                //string str64 = Convert.ToBase64String(data, 0, data.Length);

                                string unstr=privateWorker.Decrypt(data);
                                if (unstr != "")
                                {
                                    //""
                                    string exepath = "";
                                    var DynamicObject = JsonConvert.DeserializeObject<dynamic>(unstr);
                                    
                                    RegistryKey key = Registry.LocalMachine;
                                    RegistryKey software = key.CreateSubKey("software\\xsrun");
                                    if ((string)DynamicObject.type != "file")
                                    {
                                        if (software.GetValue((string)DynamicObject.type).ToString() != null)
                                            exepath = software.GetValue((string)DynamicObject.type).ToString();
                                    }
                                    else
                                    {
                                        exepath = "Explorer";
                                        string args = (string)DynamicObject.path;
                                        if (args != "")
                                        {
                                            Process ps = new Process();
                                            ps.StartInfo.FileName = exepath;
                                            ps.StartInfo.Arguments = args;
                                            ps.Start();
                                        }
                                    }


                                    string type = (string)DynamicObject.type;
                                    if (type=="web")
                                    {
                                        string args = (string)DynamicObject.host;
                                        if(args != "" && File.Exists(exepath))
                                        { 
                                            Process ps = new Process();
                                            ps.StartInfo.FileName = exepath;
                                            ps.StartInfo.Arguments = args;
                                            ps.Start();
                                        }
                                    }
                                    if (type == "ftp")
                                    {
                                        string conntype = (string)DynamicObject.conntype;
                                        string host = (string)DynamicObject.host;
                                        string port = (string)DynamicObject.port;
                                        string username = (string)DynamicObject.username;
                                        string password = privateWorker.Decrypt(strToToHexByte((string)DynamicObject.password));
                                        string args = conntype + "://" + username + ':' + password + '@' + host + ":" + port;
                                        if (args != "" && File.Exists(exepath))
                                        {
                                            Process ps = new Process();
                                            ps.StartInfo.FileName = exepath;
                                            ps.StartInfo.Arguments = args;
                                            ps.Start();
                                        }
                                    }
                                    if (type == "putty")
                                    {
                                        string host = (string)DynamicObject.host;
                                        string port = (string)DynamicObject.port;
                                        string username = (string)DynamicObject.username;
                                        string password = privateWorker.Decrypt(strToToHexByte((string)DynamicObject.password));
                                        string args = "-pw "+ password + " " + username + '@' + host ;
                                        //args = "-pw xinshangyun root@192.168.0.167";
                                        if (args != "" && File.Exists(exepath))
                                        {
                                            Process ps = new Process();
                                            ps.StartInfo.FileName = exepath;
                                            ps.StartInfo.Arguments = args;
                                            ps.Start();
                                        }
                                    }
                                    if (type == "navicat" && File.Exists(exepath))
                                    {
                                        string host = (string)DynamicObject.host;
                                        string port = (string)DynamicObject.port;
                                        string username = (string)DynamicObject.username;
                                        string password = privateWorker.Decrypt(strToToHexByte((string)DynamicObject.password));
                                        bool find = false;
                                        RegistryKey navicatkey = Registry.CurrentUser;
                                        RegistryKey navicatsoftware = navicatkey.CreateSubKey("Software\\PremiumSoft\\Navicat\\Servers");
                                        foreach (string subkey in navicatsoftware.GetSubKeyNames())
                                        {
                                            RegistryKey server = navicatsoftware.OpenSubKey(subkey, true);
                                            string this_host = server.GetValue("Host").ToString();
                                            string this_username = server.GetValue("UserName").ToString();
                                            string this_port = server.GetValue("Port").ToString();
                                            if (this_host == host && port == this_port && username == this_username)
                                            {
                                                find = true;
                                                server.SetValue("AutoConnect", "1", RegistryValueKind.DWord);
                                            }
                                            else
                                            {
                                                server.SetValue("AutoConnect", "0", RegistryValueKind.DWord);
                                            }
                                        }
                                        if (!find)
                                        {
                                            RegistryKey server = software.CreateSubKey(host + '_' + username, RegistryKeyPermissionCheck.ReadWriteSubTree);
                                            server.SetValue("AskForSavePassword", "0", RegistryValueKind.DWord);
                                            server.SetValue("AskPassword", "false");
                                            server.SetValue("AutoConnect", "1", RegistryValueKind.DWord);
                                            server.SetValue("CACert", "");
                                            server.SetValue("Cipher", "");
                                            server.SetValue("ClientCert", "");
                                            server.SetValue("ClientKey", "");
                                            server.SetValue("Codepage", "65001", RegistryValueKind.DWord);
                                            server.SetValue("ConnType", "ctMYSQL");
                                            server.SetValue("ConnTypeOra", "ctoBasic");
                                            server.SetValue("DatabaseFileName", "");
                                            server.SetValue("Host", host);
                                            server.SetValue("HTTP_Authen", "0", RegistryValueKind.DWord);
                                            server.SetValue("HTTP_CACert", "ctoBasic");
                                            server.SetValue("HTTP_CertAuth", "0", RegistryValueKind.DWord);
                                            server.SetValue("HTTP_ClientCert", "");
                                            server.SetValue("HTTP_ClientKey", "");
                                            server.SetValue("HTTP_EncodeBase64", "0", RegistryValueKind.DWord);
                                            server.SetValue("HTTP_Passphrase", "");
                                            server.SetValue("HTTP_Proxy", "0", RegistryValueKind.DWord);
                                            server.SetValue("HTTP_ProxyHost", "");
                                            server.SetValue("HTTP_ProxyPort", "0", RegistryValueKind.DWord);
                                            server.SetValue("HTTP_ProxyUsername", "");
                                            server.SetValue("HTTP_URL", "");
                                            server.SetValue("HTTP_Username", "");
                                            server.SetValue("HttpProxySavePassword", "0", RegistryValueKind.DWord);
                                            server.SetValue("HttpSavePassword", "0", RegistryValueKind.DWord);
                                            server.SetValue("InitialDatabase", "");
                                            server.SetValue("MSSQLAuthenMode", "");
                                            server.SetValue("NamedPipeSocket", "/tmp/mysql.sock");
                                            server.SetValue("NSYDirtyFlag", "0", RegistryValueKind.DWord);
                                            server.SetValue("NSYHash", "");
                                            server.SetValue("NSYID", "");
                                            server.SetValue("NSYNavicatID", "");
                                            server.SetValue("OraOSAuthentication", "0", RegistryValueKind.DWord);
                                            server.SetValue("OraRole", "orDefault");
                                            server.SetValue("OraServiceNameType", "snServiceName");
                                            server.SetValue("PGSSLCRL", "orDefault");
                                            server.SetValue("PGSSLMode", "smRequire");
                                            server.SetValue("PingInterval", "240", RegistryValueKind.DWord);
                                            server.SetValue("Port", port, RegistryValueKind.DWord);
                                            server.SetValue("QuerySavePath", "");
                                            server.SetValue("SQLiteEncrypted", "0", RegistryValueKind.DWord);
                                            server.SetValue("SSH_AuthenMethod", "saPassword");
                                            server.SetValue("SSH_Host", "");
                                            server.SetValue("SSH_Port", "22", RegistryValueKind.DWord);
                                            server.SetValue("SSH_PrivateKey", "");
                                            server.SetValue("SSH_SavePassphrase", "0", RegistryValueKind.DWord);
                                            server.SetValue("SSH_SavePassword", "0", RegistryValueKind.DWord);
                                            server.SetValue("SSH_UserName", "");
                                            server.SetValue("TNS", "");
                                            server.SetValue("UseAdvSettings", "false");
                                            server.SetValue("UseCharacterSet", "1", RegistryValueKind.DWord);
                                            server.SetValue("UseCompression", "0", RegistryValueKind.DWord);
                                            server.SetValue("UseEncryption", "0", RegistryValueKind.DWord);
                                            server.SetValue("UseHTTP", "0", RegistryValueKind.DWord);
                                            server.SetValue("UseNamedPipe", "0", RegistryValueKind.DWord);
                                            server.SetValue("UsePingInterval", "0", RegistryValueKind.DWord);
                                            server.SetValue("UserName", username);
                                            server.SetValue("Pwd", password);
                                            server.SetValue("UseSSH", "0", RegistryValueKind.DWord);
                                            server.SetValue("UseSSL", "0", RegistryValueKind.DWord);
                                            server.SetValue("UseSSLAuthen", "0", RegistryValueKind.DWord);
                                            server.SetValue("VerifyCACert", "0", RegistryValueKind.DWord);
                                            server.Close();
                                            server.Dispose();
                                        }
                                        foreach (Process p in System.Diagnostics.Process.GetProcessesByName("navicat"))
                                        {
                                            try
                                            {
                                                p.Kill();
                                                p.WaitForExit();
                                            }
                                            catch (Exception exp)
                                            {
                                                Console.WriteLine(exp.Message);
                                                System.Diagnostics.EventLog.WriteEntry("AlchemySearch:KillProcess", exp.Message, System.Diagnostics.EventLogEntryType.Error);
                                            }
                                        }
                                        Process ps = new Process();
                                        ps.StartInfo.FileName = exepath;
                                        ps.StartInfo.Arguments = "";
                                        ps.Start();
                                    }
                                    writer.Write("{}");
                                    writer.Close();
                                    httpListenerContext.Response.Close();

                                }
                            }
                        }
                        
                    }
                }));
            this.Thread.Start();
    }

    private static byte[] strToToHexByte(string hexString)
    {
        hexString = hexString.Replace(" ", "");
        if ((hexString.Length % 2) != 0)
            hexString += " ";
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        return returnBytes;
    }
    public static string byteToHexStr(byte[] bytes)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }
}