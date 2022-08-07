using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using AutoUpdaterDotNET;

namespace MW2_Patch_Converter
{
    public partial class Form1 : Office2007Form
    {
        public string FFLocation = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFastfileDia = new OpenFileDialog();
            openFastfileDia.Title = "Select a PS3 fast file...";
            openFastfileDia.Filter = "Fast File|*.ff";
            OpenFileDialog openFileDialog2 = openFastfileDia;
            if (openFileDialog2.ShowDialog() != DialogResult.OK)
                return;
            this.FFLocation = openFileDialog2.FileName;
            this.fileName.Text = this.FFLocation;
            Form1.CopyFolder(".\\Dont-Delete", "C:\\patch-temp");
            FileStream fileStream1 = File.OpenRead(openFileDialog2.FileName);
            FileStream fileStream2 = File.OpenWrite("c:\\patch-temp\\tools\\temp_mp.ff");
            int num;
            while ((num = fileStream1.ReadByte()) > -1)
                fileStream2.WriteByte((byte)num);
            fileStream2.Flush();
            fileStream2.Close();
            fileStream1.Close();
        }

        private void ps3xbox_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo1 = new ProcessStartInfo();
                startInfo1.CreateNoWindow = true;
                startInfo1.UseShellExecute = false;
                startInfo1.FileName = "c:\\patch-temp\\tools\\ps3-xbox-1.cmd";
                startInfo1.Arguments = "";
                startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo2 = new ProcessStartInfo();
                startInfo2.CreateNoWindow = true;
                startInfo2.UseShellExecute = false;
                startInfo2.FileName = "C:\\patch-temp\\tools\\zlibc.exe";
                startInfo2.Arguments = "-k c:\\patch-temp\\tools\\xbox-patch_mp-extract.dat c:\\patch-temp\\tools\\xbox-cut-2.dat 9";
                startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.FileName = "c:\\patch-temp\\tools\\ps3-xbox-2.cmd";
                startInfo3.Arguments = "";
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo1))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo2))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo3))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\patch_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\ps3-to-xbox-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("ps3-to-xbox-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            foreach (string file in Directory.GetFiles(sourceFolder))
            {
                string fileName = Path.GetFileName(file);
                string destFileName = Path.Combine(destFolder, fileName);
                File.Copy(file, destFileName);
            }
            foreach (string directory in Directory.GetDirectories(sourceFolder))
            {
                string fileName = Path.GetFileName(directory);
                string destFolder1 = Path.Combine(destFolder, fileName);
                Form1.CopyFolder(directory, destFolder1);
            }
        }

        private void xboxtopc_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\xbox-dump.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                Directory.CreateDirectory(".\\gscdump");
                Form1.CopyFolder("c:\\patch-temp\\tools\\gscdump", ".\\gscdump");
                int num2 = (int)MessageBox.Show("gsc files saved in the app\\gscdump folder, delete or move gscdump folder before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void ps3pc_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\ps3-dump.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                Directory.CreateDirectory(".\\gscdump");
                Form1.CopyFolder("c:\\patch-temp\\tools\\gscdump", ".\\gscdump");
                int num2 = (int)MessageBox.Show("gsc files saved in the app\\gscdump folder, delete or move gscdump folder before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void xboxps3_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo1 = new ProcessStartInfo();
                startInfo1.CreateNoWindow = true;
                startInfo1.UseShellExecute = false;
                startInfo1.FileName = "c:\\patch-temp\\tools\\xbox-ps3-1.cmd";
                startInfo1.Arguments = "";
                startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo2 = new ProcessStartInfo();
                startInfo2.CreateNoWindow = true;
                startInfo2.UseShellExecute = false;
                startInfo2.FileName = "C:\\patch-temp\\tools\\zlibc.exe";
                startInfo2.Arguments = "-k c:\\patch-temp\\tools\\1.dat c:\\patch-temp\\tools\\1.zlp 9";
                startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.FileName = "C:\\patch-temp\\tools\\zlibc.exe";
                startInfo3.Arguments = "-k c:\\patch-temp\\tools\\2.dat c:\\patch-temp\\tools\\2.zlp 9";
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.FileName = "C:\\patch-temp\\tools\\zlibc.exe";
                startInfo4.Arguments = "-k c:\\patch-temp\\tools\\3.dat c:\\patch-temp\\tools\\3.zlp 9";
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo startInfo5 = new ProcessStartInfo();
                startInfo5.CreateNoWindow = true;
                startInfo5.UseShellExecute = false;
                startInfo5.FileName = "c:\\patch-temp\\tools\\xbox-ps3-2.cmd";
                startInfo5.Arguments = "";
                startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo1))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo2))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo3))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo4))
                        process.WaitForExit();
                    using (Process process = Process.Start(startInfo5))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\patch_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\xbox-to-ps3-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("xbox-to-ps3-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void bles00684_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\bles00684.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\temp_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\bles00684-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("bles00684-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void blus30377_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\blus30377.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\temp_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\blus30377-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("blus30377-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void bles00685_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\bles00685.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\temp_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\bles00685-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("bles00685-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void bles00686_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\bles00686.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\temp_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\bles00686-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("bles00686-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void bles00687_Click(object sender, EventArgs e)
        {
            if (this.FFLocation == string.Empty)
            {
                int num1 = (int)MessageBox.Show("Please open a fast file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "c:\\patch-temp\\tools\\bles00687.cmd";
                startInfo.Arguments = "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using (Process process = Process.Start(startInfo))
                        process.WaitForExit();
                }
                catch
                {
                }
                FileStream fileStream1 = File.OpenRead("c:\\patch-temp\\tools\\temp_mp.ff");
                FileStream fileStream2 = File.OpenWrite(".\\bles00687-patch_mp.ff");
                int num2;
                while ((num2 = fileStream1.ReadByte()) > -1)
                    fileStream2.WriteByte((byte)num2);
                fileStream2.Flush();
                fileStream2.Close();
                fileStream1.Close();
                int num3 = (int)MessageBox.Show("bles00687-patch_mp.ff saved in the app folder, delete or move before next use.", "Fast File Converted!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Directory.Delete("c:\\patch-temp", true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("downloads/tools/patchconverter/autoupdate.xml");
        }
    }
}
