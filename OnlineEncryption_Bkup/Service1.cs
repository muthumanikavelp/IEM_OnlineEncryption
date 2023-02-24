using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Configuration;

namespace OnlineEncryption
{
    public partial class Service1 : ServiceBase
    {
        string LogFile = "ErrorLogs.txt";
        private System.Timers.Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer(5000D);  // 5000 milliseconds = 5 seconds
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }

        protected override void OnStop()
        {
            this.timer.Stop();
            this.timer = null;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.timer.Stop();
            OnlineFileEncryption();
            this.timer.Start();
        }

        public void OnlineFileEncryption()
        {
            CreateLog("Online File Encryption", "Process Started", "");
            ProcessStartInfo processInfo;
            System.Diagnostics.Process process;
            processInfo = new ProcessStartInfo("C:\\GenericEncryption_Client\\GenericEncryption_Client\\encryptdaemon.bat");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            process = System.Diagnostics.Process.Start(processInfo);
            CreateLog("Online File Encryption", "Error", process.StandardError.ReadToEnd());
            CreateLog("Online File Encryption", "Output", process.StandardOutput.ReadToEnd());
            CreateLog("Online File Encryption", "Process Ended", "");

            string sourcePath = @"C:\GenericEncryption_Client\GenericEncryption_Client\datafiles\encfiles", targetPath = "", fileName = "";
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    targetPath = @"E:\IEM\EFTOnline\Download";
                    //targetPath = System.Configuration.ConfigurationSettings.AppSettings["target"].ToString();
                    fileName = System.IO.Path.GetFileName(s);
                    string[] str = fileName.Split('~');
                    for (int i = 0; i < str.Length - 1; i++)
                        targetPath += @"\" + str[i];
                    if (!System.IO.Directory.Exists(targetPath))
                        System.IO.Directory.CreateDirectory(targetPath);
                    targetPath = System.IO.Path.Combine(targetPath, str[str.Length - 1]);
                 //   System.IO.File.Move(s, targetPath.Remove(targetPath.Length-4, 4));
                    System.IO.File.Move(s, targetPath);
                }
            }
        }

        private void CreateLog(string FileName, string MethodName, string ErrMsg)
        {
            StreamWriter sw = null;
            try
            {
                //if (EnableLogs == false || (string.IsNullOrEmpty(ErrMsg.Trim()))) return;
                if (string.IsNullOrEmpty(ErrMsg.Trim())) { }
                else
                {
                    //FileStream fs = new FileStream(LogFile,true);
                    //StreamWriter sw = new StreamWriter(fs);
                    sw = new StreamWriter(LogFile, true);
                    sw.WriteLine(ErrMsg);
                    //sw.BaseStream.Seek(0, SeekOrigin.End);

                    sw.WriteLine(DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt --> ") + "File: " + FileName + ", Method: " + MethodName + ", Error: " + ErrMsg);
                    sw.Flush();
                }
                //sw.Close();
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
