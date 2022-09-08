using DEXSTER;
using DEXSTER.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEXSTER_SMART
{
    public partial class Setting : Form
    {
        int i;
        private string SP;
        private string ST;
        private string SX;
        public Setting()
        {
            InitializeComponent();
        }

        public static string SetValueForOpenGLSwitch = "";
        public static string SetValueForDirectXSwitch = "";
        public static string SetValueForAuto = "";
        public static string SetValueForRenderedCahceSwitch = "";
        public static string SetValueForGlobalCacheSwitch = "";
        public static string SetValueForDedicatedSwitch = "";
        public static string SetValueForRenderdOptimizationSwitch = "";
        public static string SetValueForVerticalSwitch = "";
        public static string SetValueForAntiAlisingSwitch = "";
        public static string SetValueForMemorySwitch = "";
        public static string SetValueForProcessorSwitch = "";
        public static string SetValueForResulationSwitch = "";
        public static string SetValueForDPISwitch = "";
        public static string SetValueForSDswtich = "";
        public static string SetValueForHDSwitch = "";
        public static string SetValueForswith2k = "";
        public static string SetValueForSmoothSwitch = "";
        public static string SetValueForHDRswitch= "";
        public static string SetValueForfps90Switch = "";
        public static string SetValueForHDR90Switch = "";
        public static string Key = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\";

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize,
        Protection flNewProtect, out Protection lpflOldProtect);

        public enum Protection
        {
            PAGE_NOACCESS = 0x01,
            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_WRITECOPY = 0x08,
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80,

            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200,
            PAGE_WRITECOMBINE = 0x400
        }
        private void DEXSTER_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (!Directory.Exists(Key))
            {
                Directory.CreateDirectory(Key);
            }
            else
            {
                auto_save();
            }
        }
        private void auto_save()
        {
            string Path = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\OpenGLSwitch.txt";
            string Path1 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\DirectXSwitch.txt";
            string Path2 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\Auto.txt";
            string Path3 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\RenderedCahceSwitch.txt";
            string Path4 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\GlobalCacheSwitch.txt";
            string Path5 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\DedicatedSwitch.txt";
            string Path6 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\RenderdOptimizationSwitch.txt";
            string Path7 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\VerticalSwitch.txt";
            string Path8 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\AntiAlisingSwitch.txt";
            string Path9 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\MemorySwitch.txt";
            string Path10 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\ProcessorSwitch.txt";
            string Path11 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\ResulationSwitch.txt";
            string Path12 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\DPISwitch.txt";
            string Path13 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\SDswtich.txt";
            string Path14 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\HDSwitch.txt";
            string Path15 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\swith2k.txt";
            string Path16 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\SmoothSwitch.txt";
            string Path17 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\HDRswitch.txt";
            string Path18 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\fps90Switch.txt";
            string Path19 = "C:\\Program Files\\DEXSTER_SMART_ANTIBAN\\HDR90.txt";
            if (File.Exists(Path))
            {
                string text = File.ReadAllText(Path);
                if (text == "1")
                {
                    OpenGLSwitch.Checked = true;
                }
                else
                {
                    OpenGLSwitch.Checked = false;
                }
            }
            if (File.Exists(Path1))
            {
                string text1 = File.ReadAllText(Path1);
                if (text1 == "1")
                {
                    DirectXSwitch.Checked = true;
                }
                else
                {
                    DirectXSwitch.Checked = false;
                }
            }
            if (File.Exists(Path2))
            {
                string text2 = File.ReadAllText(Path2);
                if (text2 == "1")
                {
                    Auto.Checked = true;
                }
                else
                {
                    Auto.Checked = false;
                }
            }
            if (File.Exists(Path3))
            {
                string text3 = File.ReadAllText(Path3);
                if (text3 == "1")
                {
                    RenderedCahceSwitch.Checked = true;
                }
                else
                {
                    RenderedCahceSwitch.Checked = false;
                }
            }
            if (File.Exists(Path4))
            {
                string text4 = File.ReadAllText(Path4);
                if (text4 == "1")
                {
                    GlobalCacheSwitch.Checked = true;
                }
                else
                {
                    GlobalCacheSwitch.Checked = false;
                }
            }
            if (File.Exists(Path5))
            {
                string text5 = File.ReadAllText(Path5);
                if (text5 == "1")
                {
                    DedicatedSwitch.Checked = true;
                }
                else
                {
                    DedicatedSwitch.Checked = false;
                }
            }
            if (File.Exists(Path6))
            {
                string text6 = File.ReadAllText(Path6);
                if (text6 == "1")
                {
                    RenderdOptimizationSwitch.Checked = true;
                }
                else
                {
                    RenderdOptimizationSwitch.Checked = false;
                }
            }
            if (File.Exists(Path7))
            {
                string text7 = File.ReadAllText(Path7);
                if (text7 == "1")
                {
                    VerticalSwitch.Checked = true;
                }
                else
                {
                    VerticalSwitch.Checked = false;
                }
            }
            if (File.Exists(Path8))
            {
                string text8 = File.ReadAllText(Path8);
                AntiAlisingSwitch.Text = text8;
            }
            if (File.Exists(Path9))
            {
                string text9 = File.ReadAllText(Path9);
                MemorySwitch.Text = text9;
            }
            if (File.Exists(Path10))
            {
                string text10 = File.ReadAllText(Path10);
                ProcessorSwitch.Text = text10;
            }
            if (File.Exists(Path11))
            {
                string text11 = File.ReadAllText(Path11);
                ResulationSwitch.Text = text11;
            }
            if (File.Exists(Path12))
            {
                string text12 = File.ReadAllText(Path12);
                DPISwitch.Text = text12;
            }
            if (File.Exists(Path13))
            {
                string text13 = File.ReadAllText(Path13);
                if (text13 == "1")
                {
                    SDswtich.Checked = true;
                }
                else
                {
                    SDswtich.Checked = false;
                }
            }
            if (File.Exists(Path14))
            {
                string text14 = File.ReadAllText(Path14);
                if (text14 == "1")
                {
                    HDSwitch.Checked = true;
                }
                else
                {
                    HDSwitch.Checked = false;
                }
            }
            if (File.Exists(Path15))
            {
                string text15 = File.ReadAllText(Path15);
                if (text15 == "1")
                {
                    swith2k.Checked = true;
                }
                else
                {
                    swith2k.Checked = false;
                }
            }
            if (File.Exists(Path16))
            {
                string text16 = File.ReadAllText(Path16);
                if (text16 == "1")
                {
                    SmoothSwitch.Checked = true;
                }
                else
                {
                    SmoothSwitch.Checked = false;
                }
            }
            if (File.Exists(Path17))
            {
                string text17 = File.ReadAllText(Path17);
                if (text17 == "1")
                {
                    HDRswitch.Checked = true;
                }
                else
                {
                    HDRswitch.Checked = false;
                }
            }
            if (File.Exists(Path18))
            {
                string text18 = File.ReadAllText(Path18);
                if (text18 == "1")
                {
                    fps90Switch.Checked = true;
                }
                else
                {
                    fps90Switch.Checked = false;
                }
            }
            if (File.Exists(Path19))
            {
                string text19 = File.ReadAllText(Path19);
                if (text19 == "1")
                {
                    HDR90.Checked = true;
                }
                else
                {
                    HDR90.Checked = false;
                }
            }

        }
        private void OpenGLSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenGLSwitch.Checked)
            {
                OpenGLSwitch.Text = "1";
                DirectXSwitch.Checked = false;
                Auto.Checked = false;
                File.WriteAllText(Path.Combine(Key, "OpenGLSwitch.txt"), OpenGLSwitch.Text);
                Openlabal.ForeColor = Color.Lime;
            }
            else
            {
                OpenGLSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "OpenGLSwitch.txt"), OpenGLSwitch.Text);
                Openlabal.ForeColor = Color.White;
            }
        }

        private void DirectXSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(DirectXSwitch.Checked)
            {
                DirectXSwitch.Text = "1";
                OpenGLSwitch.Checked = false;
                Auto.Checked = false;
                File.WriteAllText(Path.Combine(Key, "DirectXSwitch.txt"), DirectXSwitch.Text);
                DirectXLabal.ForeColor = Color.Lime;
            }
            else
            {
                DirectXSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "DirectXSwitch.txt"), DirectXSwitch.Text);
                DirectXLabal.ForeColor = Color.White;
            }
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        private void Auto_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto.Checked)
            {
                Auto.Text = "1";
                OpenGLSwitch.Checked = false;
                DirectXSwitch.Checked = false;
                File.WriteAllText(Path.Combine(Key, "Auto.txt"), Auto.Text);
                AutoLabal.ForeColor = Color.Lime;
            }
            else
            {
                Auto.Text = "0";
                File.WriteAllText(Path.Combine(Key, "Auto.txt"), Auto.Text);
                AutoLabal.ForeColor = Color.White;
            }
        }
        private void RenderedCahceSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(RenderedCahceSwitch.Checked)
            {
                RenderedCahceSwitch.Text = "1";
                File.WriteAllText(Path.Combine(Key, "RenderedCahceSwitch.txt"), RenderedCahceSwitch.Text);
                EnableRenderdCacheLabal.ForeColor = Color.Lime;
            }
            else
            {
                RenderedCahceSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "RenderedCahceSwitch.txt"), RenderedCahceSwitch.Text);
                EnableRenderdCacheLabal.ForeColor = Color.White;
            }
        }
        private void GlobalCacheSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(GlobalCacheSwitch.Checked)
            {
                GlobalCacheSwitch.Text = "1";
                File.WriteAllText(Path.Combine(Key, "GlobalCacheSwitch.txt"), GlobalCacheSwitch.Text);
                ForceGlobalLabal.ForeColor = Color.Lime;
            }
            else
            {
                GlobalCacheSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "GlobalCacheSwitch.txt"), GlobalCacheSwitch.Text);
                ForceGlobalLabal.ForeColor = Color.White;
            }

        }

        private void DedicatedSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(DedicatedSwitch.Checked)
            {
                DedicatedSwitch.Text = "1";
                File.WriteAllText(Path.Combine(Key, "DedicatedSwitch.txt"), DedicatedSwitch.Text);
                ProtizeLabal.ForeColor = Color.Lime;
            }
            else
            {
                DedicatedSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "DedicatedSwitch.txt"), DedicatedSwitch.Text);
                ProtizeLabal.ForeColor = Color.White;
            }
        }

        private void RenderdOptimizationSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(RenderdOptimizationSwitch.Checked)
            {
                RenderdOptimizationSwitch.Text = "1";
                File.WriteAllText(Path.Combine(Key, "RenderdOptimizationSwitch.txt"), RenderdOptimizationSwitch.Text);
                RenderedOptimizationLabal.ForeColor = Color.Lime;
            }
            else
            {
                RenderdOptimizationSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "RenderdOptimizationSwitch.txt"), RenderdOptimizationSwitch.Text);
                RenderedOptimizationLabal.ForeColor = Color.White;
            }
        }

        private void VerticalSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(VerticalSwitch.Checked)
            {
                VerticalSwitch.Text = "1";
                File.WriteAllText(Path.Combine(Key, "VerticalSwitch.txt"),VerticalSwitch.Text);
                VerticalLabal.ForeColor = Color.Lime;
            }
            else
            {
                VerticalSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "VerticalSwitch.txt"),VerticalSwitch.Text);
                VerticalLabal.ForeColor = Color.White;
            }
        }

        private void AntiAlisingSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
           File.WriteAllText(Path.Combine(Key, "AntiAlisingSwitch.txt"), AntiAlisingSwitch.Text);


        }

        private void MemorySwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Key, "MemorySwitch.txt"), MemorySwitch.Text);
        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void ProcessorSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Key, "ProcessorSwitch.txt"), ProcessorSwitch.Text);
        }

        private void ResulationSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Key, "ResulationSwitch.txt"), ResulationSwitch.Text);
        }

        private void DPISwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Key, "DPISwitch.txt"), DPISwitch.Text);
        }

        private void SDswtich_CheckedChanged(object sender, EventArgs e)
        {
            if(SDswtich.Checked)
            {
                SDswtich.Text = "1";
                HDSwitch.Checked = false;
                swith2k.Checked = false;
                File.WriteAllText(Path.Combine(Key, "SDswtich.txt"), SDswtich.Text);
                SDlabal.ForeColor = Color.Lime;
            }
            else
            {
                SDswtich.Text = "0";
                File.WriteAllText(Path.Combine(Key, "SDswtich.txt"), SDswtich.Text);
                SDlabal.ForeColor = Color.White;
            }
        }

        private void HDSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if(HDSwitch.Checked)
            {
                HDSwitch.Text = "1";
                SDswtich.Checked = false;
                swith2k.Checked = false;
                File.WriteAllText(Path.Combine(Key, "HDSwitch.txt"),HDSwitch.Text);
                HDLabal.ForeColor = Color.Lime;
            }
            else
            {
                HDSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "HDSwitch.txt"), HDSwitch.Text);
                HDLabal.ForeColor = Color.White;
            }
        }

        private void swith2k_CheckedChanged(object sender, EventArgs e)
        {
            if(swith2k.Checked)
            {
                swith2k.Text = "1";
                SDswtich.Checked = false;
                HDSwitch.Checked = false;
                File.WriteAllText(Path.Combine(Key, "swith2k.txt"), swith2k.Text);
                labal2k.ForeColor = Color.Lime;
            }
            else
            {
                swith2k.Text = "0";
                File.WriteAllText(Path.Combine(Key, "swith2k.txt"), swith2k.Text);
                labal2k.ForeColor = Color.White;
            }
        }

        private void SmoothSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (SmoothSwitch.Checked)
            {
                SmoothSwitch.Text = "1";
                HDRswitch.Checked = false;
                fps90Switch.Checked = false;
                HDR90.Checked = false;
                File.WriteAllText(Path.Combine(Key, "SmoothSwitch.txt"), SmoothSwitch.Text);
                smoothlabal.ForeColor = Color.Lime;
            }
            else
            {
                SmoothSwitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "SmoothSwitch.txt"), SmoothSwitch.Text);
                smoothlabal.ForeColor = Color.White;
            }
        }

        private void HDRswitch_CheckedChanged(object sender, EventArgs e)
        {
            if(HDRswitch.Checked)
            {
                HDRswitch.Text = "1";
                SmoothSwitch.Checked = false;
                fps90Switch.Checked = false;
                HDR90.Checked = false;
                File.WriteAllText(Path.Combine(Key, "HDRswitch.txt"), HDRswitch.Text);
                HDRlabl.ForeColor = Color.Lime;
            }
            else
            {
                HDRswitch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "HDRswitch.txt"), HDRswitch.Text);
                HDRlabl.ForeColor = Color.White;
            }

        }

        private void fps90Switch_CheckedChanged(object sender, EventArgs e)
        {
            if(fps90Switch.Checked)
            {
                fps90Switch.Text = "1";
                SmoothSwitch.Checked = false;
                HDRswitch.Checked = false;
                HDR90.Checked = false;
                File.WriteAllText(Path.Combine(Key, "fps90Switch.txt"), fps90Switch.Text);
                labal90fps.ForeColor = Color.Lime;
            }
            else
            {
                fps90Switch.Text = "0";
                File.WriteAllText(Path.Combine(Key, "fps90Switch.txt"), fps90Switch.Text);
                labal90fps.ForeColor = Color.White;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Setting_Apply_Click(object sender, EventArgs e)
        {
            SetValueForOpenGLSwitch = OpenGLSwitch.Text;
            SetValueForDirectXSwitch = DirectXSwitch.Text;
            SetValueForAuto = Auto.Text;
            SetValueForRenderedCahceSwitch = RenderedCahceSwitch.Text;
            SetValueForGlobalCacheSwitch = GlobalCacheSwitch.Text;
            SetValueForDedicatedSwitch = DedicatedSwitch.Text;
            SetValueForRenderdOptimizationSwitch = RenderdOptimizationSwitch.Text;
            SetValueForVerticalSwitch = VerticalSwitch.Text;
            SetValueForAntiAlisingSwitch = AntiAlisingSwitch.Text;
            SetValueForMemorySwitch = MemorySwitch.Text;
            SetValueForProcessorSwitch = ProcessorSwitch.Text;
            SetValueForResulationSwitch = ResulationSwitch.Text;
            SetValueForDPISwitch = DPISwitch.Text;
            SetValueForSDswtich = SDswtich.Text;
            SetValueForHDSwitch = HDSwitch.Text;
            SetValueForswith2k = swith2k.Text;
            SetValueForSmoothSwitch = SmoothSwitch.Text;
            SetValueForHDRswitch = HDRswitch.Text;
            SetValueForfps90Switch = fps90Switch.Text;
            SetValueForHDR90Switch = HDR90.Text;
            this.Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DirectXLabal_Click(object sender, EventArgs e)
        {
            DirectXSwitch.Checked = true;
        }

        private void Openlabal_Click(object sender, EventArgs e)
        {
            OpenGLSwitch.Checked = true;
        }

        private void AutoLabal_Click(object sender, EventArgs e)
        {
            Auto.Checked = true;
        }

        private void EnableRenderdCacheLabal_Click(object sender, EventArgs e)
        {
            RenderedCahceSwitch.Checked = true;
        }

        private void ForceGlobalLabal_Click(object sender, EventArgs e)
        {
            GlobalCacheSwitch.Checked = true;
        }

        private void ProtizeLabal_Click(object sender, EventArgs e)
        {
            DedicatedSwitch.Checked = true;
        }

        private void RenderedOptimizationLabal_Click(object sender, EventArgs e)
        {
            RenderdOptimizationSwitch.Checked = true;
        }

        private void VerticalLabal_Click(object sender, EventArgs e)
        {
            VerticalSwitch.Checked = true;
        }

        private void SDlabal_Click(object sender, EventArgs e)
        {
            SDswtich.Checked = true;
        }

        private void HDLabal_Click(object sender, EventArgs e)
        {
            HDSwitch.Checked = true;
        }

        private void labal2k_Click(object sender, EventArgs e)
        {
            swith2k.Checked = true;
        }

        private void smoothlabal_Click(object sender, EventArgs e)
        {
            SmoothSwitch.Checked = true;
        }

        private void HDRlabl_Click(object sender, EventArgs e)
        {
            HDRswitch.Checked = true;
        }

        private void labal90fps_Click(object sender, EventArgs e)
        {
            fps90Switch.Checked = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetValueForOpenGLSwitch = OpenGLSwitch.Text;
            SetValueForDirectXSwitch = DirectXSwitch.Text;
            SetValueForAuto = Auto.Text;
            SetValueForRenderedCahceSwitch = RenderedCahceSwitch.Text;
            SetValueForGlobalCacheSwitch = GlobalCacheSwitch.Text;
            SetValueForDedicatedSwitch = DedicatedSwitch.Text;
            SetValueForRenderdOptimizationSwitch = RenderdOptimizationSwitch.Text;
            SetValueForVerticalSwitch = VerticalSwitch.Text;
            SetValueForAntiAlisingSwitch = AntiAlisingSwitch.Text;
            SetValueForMemorySwitch = MemorySwitch.Text;
            SetValueForProcessorSwitch = ProcessorSwitch.Text;
            SetValueForResulationSwitch = ResulationSwitch.Text;
            SetValueForDPISwitch = DPISwitch.Text;
            SetValueForSDswtich = SDswtich.Text;
            SetValueForHDSwitch = HDSwitch.Text;
            SetValueForswith2k = swith2k.Text;
            SetValueForSmoothSwitch = SmoothSwitch.Text;
            SetValueForHDRswitch = HDRswitch.Text;
            SetValueForfps90Switch = fps90Switch.Text;
        }

        private void Game_Install_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
                string SourcePath;
                SourcePath = dlg.FileName;
                string TargetPath;
                TargetPath = @"C:\Windows\com_tencent_ig.apk";
                string root1 = @"C:\Windows\com_tencent_ig.apk";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(root1))
                    {
                        File.Delete((root1));
                        File.Copy(dlg.FileName, TargetPath);
                        Do();

                    }
                    else
                    {
                        File.Copy(dlg.FileName, TargetPath);
                        Do();

                    }

                }

            }
            else
            {
                MessageBox.Show("Please Open Emu in Normal Mode", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Do()
        {
            for (i = 0; i <= 20; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => CheackingResourcesInstall());
            for (i = 0; i <= 50; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => Install());
            for (i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
            }
        }
        private void CheackingResourcesInstall()
        {
            if (File.Exists(@"adb.exe"))
            {

            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }

        }
        private void Install()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = false,
                RedirectStandardInput = true,
                UseShellExecute = false
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 uninstall com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 install C:\\Windows\\com_tencent_ig.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            string message = "Please Wait , When Done apk will auto open";
            string title = "Team DEXSTER";
            MessageBox.Show(message, title);
        }
        private void Reset_Guest_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                Reset();
                MessageBox.Show("Game Will Auto Open", "Team DEXSTER",
                MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Run The Emulator in Normlall Mode First", "Environment Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Reset()
        {
            for (i = 0; i <= 50; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => DEXGUESTV1());
            for (i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
            }
        }
        private void DEXGUESTV1()
        {
            if (File.Exists(@"adb.exe"))
            {

            }
            else
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

            }
            else
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }
            File.WriteAllBytes("DEXGUESTV1.exe", Resources.DEXGUESTV1);
            ProcessStartInfo DEX = new ProcessStartInfo();
            DEX.FileName = @"DEXGUESTV1.exe";
            DEX.WindowStyle = ProcessWindowStyle.Hidden;
            Process proc = Process.Start(DEX);

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private async void Deep_Uninstal_Click(object sender, EventArgs e)
        {
            for (i = 0; i <= 10; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => EMU_KILL());
            for (i = 0; i <= 20; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => FakeRegistry());
            for (i = 0; i <= 40; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => RegistryDelete());
            for (i = 0; i <= 60; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => DeleteResources());
            for (i = 0; i <= 80; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => DeleteDerectoryPermanent());
            for (i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
            }
        }
        private void DeleteDerectoryPermanent()
        {
            string root = @"C:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root))
            {
                Directory.Delete(root, true);
            }
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root1))
            {
                Directory.Delete(root1, true);
            }
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root2))
            {
                Directory.Delete(root2, true);
            }
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root3))
            {
                Directory.Delete(root3, true);
            }
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root4))
            {
                Directory.Delete(root4, true);
            }
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root5))
            {
                Directory.Delete(root5, true);
            }
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root6))
            {
                Directory.Delete(root6, true);
            }
            string root9 = @"C:\\TxGameAssistant";
            if (Directory.Exists(root9))
            {
                Directory.Delete(root9, true);
            }
            string root10 = @"D:\\TxGameAssistant";
            if (Directory.Exists(root10))
            {
                Directory.Delete(root10, true);
            }
            string root11 = @"E:\\TxGameAssistant";
            if (Directory.Exists(root11))
            {
                Directory.Delete(root1, true);
            }
            string root12 = @"F:\\TxGameAssistant";
            if (Directory.Exists(root12))
            {
                Directory.Delete(root12, true);
            }
            string root13 = @"G:\\TxGameAssistant";
            if (Directory.Exists(root13))
            {
                Directory.Delete(root13, true);
            }
            string root14 = @"H:\\TxGameAssistant";
            if (Directory.Exists(root14))
            {
                Directory.Delete(root14, true);
            }
            string root15 = @"I:\\TxGameAssistant";
            if (Directory.Exists(root15))
            {
                Directory.Delete(root15, true);
            }
            string root19 = @"D:\\Temp";
            if (Directory.Exists(root19))
            {
                Directory.Delete(root19, true);
            }
            string root20 = @"E:\\Temp";
            if (Directory.Exists(root20))
            {
                Directory.Delete(root20, true);
            }
            string root21 = @"F:\\Temp";
            if (Directory.Exists(root21))
            {
                Directory.Delete(root21, true);
            }
            string root22 = @"G:\\Temp";
            if (Directory.Exists(root22))
            {
                Directory.Delete(root22, true);
            }
            string root23 = @"H:\\Temp";
            if (Directory.Exists(root23))
            {
                Directory.Delete(root23, true);
            }
            string root24 = @"I:\\Temp";
            if (Directory.Exists(root24))
            {
                Directory.Delete(root24, true);
            }
            string root27 = @"C:\\Temp";
            if (Directory.Exists(root27))
            {
                Directory.Delete(root27, true);
            }
            string message = "Done";
            string title = "Team DEXSTER";
            MessageBox.Show(message, title);
        }

        private void EMU_KILL()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("taskkill /F /im AndroidEmulator.exe");
                standardInput.WriteLine("taskkill /F /im AndroidEmulatorEn.exe");
                standardInput.WriteLine("taskkill /F /im AndroidEmulatorEx.exe");
                standardInput.WriteLine("taskkill /F /im TBSWebRenderer.exe");
                standardInput.WriteLine("taskkill /F /im AppMarket.exe");
                standardInput.WriteLine("taskkill /f /im tensafe_1.exe");
                standardInput.WriteLine("taskkill /f /im tensafe_2.exe");
                standardInput.WriteLine("taskkill /f /im tencentdl.exe");
                standardInput.WriteLine("taskkill /f /im conime.exe");
                standardInput.WriteLine("taskkill /f /im QQDL.EXE");
                standardInput.WriteLine("taskkill /f /im qqlogin.exe");
                standardInput.WriteLine("taskkill /f /im dnfchina.exe");
                standardInput.WriteLine("taskkill /f /im dnfchinatest.exe");
                standardInput.WriteLine("taskkill /f /im txplatform.exe");
                standardInput.WriteLine("taskkill /f /im aow_exe.exe");
                standardInput.WriteLine("taskkill /F /IM TitanService.exe");
                standardInput.WriteLine("taskkill /F /IM ProjectTitan.exe");
                standardInput.WriteLine("taskkill /F /IM Auxillary.exe");
                standardInput.WriteLine("taskkill /F /IM TP3Helper.exe");
                standardInput.WriteLine("taskkill /F /IM tp3helper.data");
                standardInput.WriteLine("TaskKill /F /IM QMEmulatorService.exe");
                standardInput.WriteLine("TaskKill /F /IM RuntimeBroker.exe");
                standardInput.WriteLine("taskkill /F /im adb.exe");
                standardInput.WriteLine("taskkill /F /im GmeLoader.exe");
                standardInput.WriteLine("taskkill /F /im cef_frame_render.exe");
                standardInput.WriteLine("taskkill /F /im syzs_dl_svr.exe");
                standardInput.WriteLine("taskkill /f /im adb.exe");
                standardInput.WriteLine("net stop aow_drv");
                standardInput.WriteLine("net stop aow_drv_x64_ev");
                standardInput.WriteLine("net stop AOW_DRV_X64");
                standardInput.WriteLine("net stop QMEmulatorService");
                standardInput.WriteLine("net stop Tensafe");
                standardInput.WriteLine("net stop UniFairy_x64");
                standardInput.WriteLine("net stop UniFairy");
                standardInput.WriteLine("net stop UniSafe");
                standardInput.WriteLine("net stop libEGL");
                standardInput.WriteLine("net stop libGLESv1");
                standardInput.WriteLine("net stop libGLESv2");
                standardInput.WriteLine("net stop libOpenglRenderV3");
                standardInput.WriteLine("/ c sc stop KProcessHacker & sc delete KProcessHacker &sc stop KProcessHacker2 &sc delete KProcessHacker2 &sc stop KProcessHacker3 &sc delete KProcessHacker3 &sc stop KProcessHacker1 &sc delete KProcessHacker1 &sc stop aow_drv &sc delete aow_drv & sc stop AndroidKernel");
                standardInput.WriteLine("del C:\\aow_drv.log");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.WriteLine("del /s /f /q %USERPROFILE%\\Appdata\\local\temp\\*.*");
                standardInput.WriteLine("ipconfig /flushdns");
                standardInput.WriteLine("ipconfig /registerdns");
                standardInput.WriteLine("netsh firewall reset");
                standardInput.WriteLine("netsh int ip reset");
                standardInput.WriteLine("netsh winsock reset");
                standardInput.WriteLine("netsh interface ipv4 reset");
                standardInput.WriteLine("netsh interface ipv6 reset");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void FakeRegistry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent");
            key.SetValue("1", "1");
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("1", "1");
            key.Close();
        }
        private void RegistryDelete()
        {
            string explorerKeyPath = @"SOFTWARE\\";
            using (RegistryKey explorerKey = Registry.CurrentUser.OpenSubKey(explorerKeyPath, writable: true))
            {
                if (explorerKey != null)
                {
                    explorerKey.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }
            }
            string explorerKeyPath1 = @"SOFTWARE\\";
            using (RegistryKey explorerKey1 = Registry.LocalMachine.OpenSubKey(explorerKeyPath1, writable: true))
            {
                if (explorerKey1 != null)
                {
                    explorerKey1.DeleteSubKeyTree("Tencent");
                }
                else
                {

                }
            }
        }
        private void DeleteResources()
        {
            if (File.Exists(@"adb.exe"))
            {

                File.Delete("adb.exe");
            }
            else
            {
                File.Delete("adb.exe");
            }
            if (File.Exists(@"AdbWinApi.dll"))
            {

                File.Delete("AdbWinApi.dll");
            }
            else
            {
                File.Delete("AdbWinApi.dll");
            }
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Start7()
        {
            string start = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            Process.Start(Path.Combine(start) + "/AndroidEmulator.exe", "-vm 100");
            string message = "Done";
            string title = "Team DEXSTER";
            MessageBox.Show(message, title);
        }
        private async void Installl_Emu_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            string SourcePath;
            SourcePath = dlg.FileName;
            string TargetPath;
            TargetPath = "C:\\Windows\\AOW_Rootfs_100.zip";
            string zipPath = @"C:\Windows\AOW_Rootfs_100.zip";
            string extractPath = @"C:\TxGameAssistant\AOW_Rootfs_100\";
            string root = @"C:\\Program Files\\TxGameAssistant";
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            string root7 = @"J:\\Program Files\\TxGameAssistant";
            string root8 = @"K:\\Program Files\\TxGameAssistant";
            string root9 = @"C:\\TxGameAssistant";
            string root10 = @"D:\\TxGameAssistant";
            string root11 = @"E:\\TxGameAssistant";
            string root12 = @"F:\\TxGameAssistant";
            string root13 = @"G:\\TxGameAssistant";
            string root14 = @"H:\\TxGameAssistant";
            string root15 = @"I:\\TxGameAssistant";
            string root16 = @"J:\\TxGameAssistant";
            string root17 = @"K:\\TxGameAssistant";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EMU_KILL();
                for (i = 0; i <= 10; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                if (File.Exists(zipPath))
                {
                    File.Delete((zipPath));
                }
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
                for (i = 0; i <= 20; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                if (Directory.Exists(root1))
                {
                    Directory.Delete(root1, true);
                }
                for (i = 0; i <= 30; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                for (i = 0; i <= 40; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                if (Directory.Exists(root2))
                {
                    Directory.Delete(root2, true);
                }
                for (i = 0; i <= 50; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                if (Directory.Exists(root3))
                {
                    Directory.Delete(root3, true);
                }
                if (Directory.Exists(root4))
                {
                    Directory.Delete(root4, true);
                }
                if (Directory.Exists(root5))
                {
                    Directory.Delete(root5, true);
                }
                if (Directory.Exists(root6))
                {
                    Directory.Delete(root6, true);
                }
                if (Directory.Exists(root7))
                {
                    Directory.Delete(root7, true);
                }
                if (Directory.Exists(root8))
                {
                    Directory.Delete(root8, true);
                }
                if (Directory.Exists(root9))
                {
                    Directory.Delete(root9, true);
                }
                if (Directory.Exists(root10))
                {
                    Directory.Delete(root10, true);
                }
                if (Directory.Exists(root11))
                {
                    Directory.Delete(root1, true);
                }
                if (Directory.Exists(root12))
                {
                    Directory.Delete(root12, true);
                }
                if (Directory.Exists(root13))
                {
                    Directory.Delete(root13, true);
                }
                if (Directory.Exists(root14))
                {
                    Directory.Delete(root14, true);
                }
                for (i = 0; i <= 60; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                if (Directory.Exists(root15))
                {
                    Directory.Delete(root15, true);
                }
                if (Directory.Exists(root16))
                {
                    Directory.Delete(root16, true);
                }
                if (Directory.Exists(root17))
                {
                    Directory.Delete(root17, true);
                }
                if (File.Exists(TargetPath))
                {
                    File.Delete((TargetPath));
                }
                for (i = 0; i <= 70; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                File.Copy(dlg.FileName, TargetPath);
                for (i = 0; i <= 80; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                Directory.CreateDirectory("C:\\TxGameAssistant\\AOW_Rootfs_100");
                for (i = 0; i <= 90; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                for (i = 0; i <= 100; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => EMU_KILL());
                for (i = 0; i <= 10; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                Task.Run(() => FakeRegistry());
                for (i = 0; i <= 20; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                Task.Run(() => RegistryDelete());
                for (i = 0; i <= 30; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => Resources_Directory_REPLACE());
                for (i = 0; i <= 40; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => DEXSTERLOOP_IN_OUT());
                for (i = 0; i <= 50; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => Registry_Create());
                for (i = 0; i <= 60; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => Start7());
                for (i = 0; i <= 100; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
            }
        }
        private void Resources_Directory_REPLACE()
        {
            if (!File.Exists(@"adb.exe"))
            {
                File.WriteAllBytes("adb.exe", Resources.adb);
                File.SetAttributes("adb.exe", FileAttributes.Hidden);
            }
            if (!File.Exists(@"AdbWinApi.dll"))
            {
                File.WriteAllBytes("AdbWinApi.dll", Resources.AdbWinApi);
                File.SetAttributes("AdbWinApi.dll", FileAttributes.Hidden);
            }
            if (!File.Exists(@"C:\\Windows\\SystemDEXV13.zip"))
            {
                if (File.Exists("DEXSTER_Services_V13.dll"))
                {
                    string TargetPath;
                    TargetPath = "C:\\Windows\\SystemDEXV13.zip";
                    File.Copy("DEXSTER_Services_V13.dll", TargetPath);
                    File.SetAttributes("C:\\Windows\\SystemDEXV13.zip", FileAttributes.Hidden);
                }
                else
                {
                    MessageBox.Show("Load Driver Failed");
                }
            }
            NewDirectory();
            UI_REPLACE();
        }
        private void UI_REPLACE()
        {
            string root28 = @"C:\\TxGameAssistant\\ui";
            if (Directory.Exists(root28))
            {
                MessageBox.Show("Unknown Error Occured", "Team DEXSTER",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Directory.CreateDirectory("C:\\TxGameAssistant\\");
                string zipPath = @"C:\Windows\SystemDEXV13.zip";
                string extractPath = @"C:\TxGameAssistant\";
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            }
        }
        private void NewDirectory()
        {
            string Anti1 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\0";
            if (File.Exists(Anti1))
            {
                File.Delete((Anti1));
            }
            string Anti2 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\0.ini";
            if (File.Exists(Anti2))
            {
                File.Delete((Anti2));
            }
            string Anti3 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\30";
            if (File.Exists(Anti3))
            {
                File.Delete((Anti3));
            }
            string Anti4 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\30.ini";
            if (File.Exists(Anti4))
            {
                File.Delete((Anti4));
            }
            string Anti5 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\367";
            if (File.Exists(Anti5))
            {
                File.Delete((Anti5));
            }
            string Anti6 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\367.ini";
            if (File.Exists(Anti6))
            {
                File.Delete((Anti6));
            }
            string Anti7 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\300";
            if (File.Exists(Anti7))
            {
                File.Delete((Anti7));
            }
            string Anti8 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\300.ini";
            if (File.Exists(Anti8))
            {
                File.Delete((Anti8));
            }
            string Anti9 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\188";
            if (File.Exists(Anti9))
            {
                File.Delete((Anti9));
            }
            string Anti10 = @"C:\TxGameAssistant\AOW_Rootfs_100\0\188.ini";
            if (File.Exists(Anti10))
            {
                File.Delete((Anti10));
            }
            string root = @"C:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root))
            {
                Directory.Delete(root, true);
            }
            string root1 = @"D:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root1))
            {
                Directory.Delete(root1, true);
            }
            string root2 = @"E:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root2))
            {
                Directory.Delete(root2, true);
            }
            string root3 = @"F:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root3))
            {
                Directory.Delete(root3, true);
            }
            string root4 = @"G:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root4))
            {
                Directory.Delete(root4, true);
            }
            string root5 = @"H:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root5))
            {
                Directory.Delete(root5, true);
            }
            string root6 = @"I:\\Program Files\\TxGameAssistant";
            if (Directory.Exists(root6))
            {
                Directory.Delete(root6, true);
            }
            string root9 = @"C:\\TxGameAssistant\\ui";
            if (Directory.Exists(root9))
            {
                Directory.Delete(root9, true);
            }
            string root10 = @"D:\\TxGameAssistant";
            if (Directory.Exists(root10))
            {
                Directory.Delete(root10, true);
            }
            string root11 = @"E:\\TxGameAssistant";
            if (Directory.Exists(root11))
            {
                Directory.Delete(root1, true);
            }
            string root12 = @"F:\\TxGameAssistant";
            if (Directory.Exists(root12))
            {
                Directory.Delete(root12, true);
            }
            string root13 = @"G:\\TxGameAssistant";
            if (Directory.Exists(root13))
            {
                Directory.Delete(root13, true);
            }
            string root14 = @"H:\\TxGameAssistant";
            if (Directory.Exists(root14))
            {
                Directory.Delete(root14, true);
            }
            string root15 = @"I:\\TxGameAssistant";
            if (Directory.Exists(root15))
            {
                Directory.Delete(root15, true);
            }
            string root110 = @"C:\\TxGameAssistant\\AppMarket";
            if (Directory.Exists(root110))
            {
                Directory.Delete(root110, true);
            }
            string root19 = @"D:\\Temp";
            if (Directory.Exists(root19))
            {
                Directory.Delete(root19, true);
            }
            string root20 = @"E:\\Temp";
            if (Directory.Exists(root20))
            {
                Directory.Delete(root20, true);
            }
            string root21 = @"F:\\Temp";
            if (Directory.Exists(root21))
            {
                Directory.Delete(root21, true);
            }
            string root22 = @"G:\\Temp";
            if (Directory.Exists(root22))
            {
                Directory.Delete(root22, true);
            }
            string root23 = @"H:\\Temp";
            if (Directory.Exists(root23))
            {
                Directory.Delete(root23, true);
            }
            string root24 = @"I:\\Temp";
            if (Directory.Exists(root24))
            {
                Directory.Delete(root24, true);
            }
            string root27 = @"C:\\Temp";
            if (Directory.Exists(root27))
            {
                Directory.Delete(root27, true);
            }
        }
        private void DEXSTERLOOP_IN_OUT()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK1 program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=in remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK3 program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=ANY dir=out remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK5 protocol=ANY dir=in remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK9 protocol=ANY dir=out remoteip=203.205.239.243 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK5 protocol=ANY dir=in remoteip=123.151.71.34 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK9 protocol=ANY dir=out remoteip=123.151.71.34 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK5 protocol=ANY dir=in remoteip=101.89.38.116 action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UPBLOCK9 protocol=ANY dir=out remoteip=101.89.38.116 action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            TCP_IN();
            UDP_IN();
        }
        private void TCP_IN()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN1 protocol=TCP remoteport=53 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN2 protocol=TCP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN3 protocol=TCP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN4 protocol=TCP remoteport=1-21,23-24,26-49,52-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN5 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN6 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN7 protocol=TCP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN8 protocol=TCP remoteport=5228,58741,8013,8080,8081,8006,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN9 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN10 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN11 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN12 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN13 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_IN14 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void UDP_IN()
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
            };
            process.Start();
            using (StreamWriter standardInput = process.StandardInput)
            {
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN1 protocol=UDP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN2 protocol=UDP remoteport=1-21,23-24,26-49,52-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN3 protocol=UDP remoteport=53 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN4 protocol=UDP remoteport=80,443 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN5 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN6 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN7 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN8 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN9 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN10 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,20000-25000,18000-20000,10000-15000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN11 protocol=UDP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN12 protocol=UDP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-20000 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN13 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_IN14 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCK protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Registry_Create()
        {
            Install_Registry();
            Registry_1st_box();
            Reigistry_2nd_box();
            Registry_3rd_box();
        }
        private void Install_Registry()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\AOW_Rootfs_100");
            key.SetValue("InstallPath", "C:\\TxGameAssistant\\AOW_Rootfs_100");
            key.SetValue("Version", "4.1.25.90");
            key.SetValue("InstallDone", 1, RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UI");
            key.SetValue("InstallPath", "C:\\TxGameAssistant\\UI");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Tencent\\MobileGamePC\\UIData");
            key.SetValue("Version", "4.1.25.90");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            key.SetValue("UserLanguage", "en");
        }
        private void Registry_1st_box()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            if (Setting.SetValueForDedicatedSwitch == "1")
            {
                key.SetValue("GraphicsCardEnabled", Setting.SetValueForDedicatedSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("GraphicsCardEnabled", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForGlobalCacheSwitch == "1")
            {
                key.SetValue("LocalShaderCacheEnabled", Setting.SetValueForGlobalCacheSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("LocalShaderCacheEnabled", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForOpenGLSwitch == "1")
            {
                key.SetValue("EnableGLESv3", Setting.SetValueForOpenGLSwitch, RegistryValueKind.DWord);
                key.SetValue("ForceDirectX", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForDirectXSwitch == "1")
            {
                key.SetValue("ForceDirectX", Setting.SetValueForDirectXSwitch, RegistryValueKind.DWord);
                key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForAuto == "1")
            {
                key.SetValue("ForceDirectX", 3, RegistryValueKind.DWord);
                key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForRenderdOptimizationSwitch == "1")
            {
                key.SetValue("RenderOptimizeEnabled", Setting.SetValueForRenderdOptimizationSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("RenderOptimizeEnabled", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForRenderedCahceSwitch == "1")
            {
                key.SetValue("ShaderCacheEnabled", Setting.SetValueForRenderedCahceSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("ShaderCacheEnabled", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForVerticalSwitch == "1")
            {
                key.SetValue("VSyncEnabled", Setting.SetValueForVerticalSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("VSyncEnabled", 0, RegistryValueKind.DWord);
            }
            key.SetValue("AdbDisable", 0, RegistryValueKind.DWord);

        }
        private void Reigistry_2nd_box()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            if (Setting.SetValueForAntiAlisingSwitch == "1")
            {
                key.SetValue("FxaaQuality", Setting.SetValueForAntiAlisingSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("FxaaQuality", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForProcessorSwitch == "2")
            {
                key.SetValue("VMCpuCount", Setting.SetValueForProcessorSwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForProcessorSwitch == "4")
            {
                key.SetValue("VMCpuCount", Setting.SetValueForProcessorSwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForProcessorSwitch == "8")
            {
                key.SetValue("VMCpuCount", Setting.SetValueForProcessorSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("VMCpuCount", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForMemorySwitch == "8192")
            {
                key.SetValue("VMMemorySizeInMB", Setting.SetValueForMemorySwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForMemorySwitch == "4096")
            {
                key.SetValue("VMMemorySizeInMB", Setting.SetValueForMemorySwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForMemorySwitch == "2048")
            {
                key.SetValue("VMMemorySizeInMB", Setting.SetValueForMemorySwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("VMMemorySizeInMB", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForDPISwitch == "480")
            {
                key.SetValue("VMDPI", Setting.SetValueForDPISwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForDPISwitch == "320")
            {
                key.SetValue("VMDPI", Setting.SetValueForDPISwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForDPISwitch == "240")
            {
                key.SetValue("VMDPI", Setting.SetValueForDPISwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForDPISwitch == "180")
            {
                key.SetValue("VMDPI", Setting.SetValueForDPISwitch, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForDPISwitch == "120")
            {
                key.SetValue("VMDPI", Setting.SetValueForDPISwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("VMDPI", 240, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForResulationSwitch == "1920 × 1080")
            {
                key.SetValue("VMResWidth", 1920, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 1080, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForResulationSwitch == "1600 × 900")
            {
                key.SetValue("VMResWidth", 1600, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 900, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForResulationSwitch == "1366 × 768")
            {
                key.SetValue("VMResWidth", 1366, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 768, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForResulationSwitch == "1280 × 800")
            {
                key.SetValue("VMResWidth", 128, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 800, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForResulationSwitch == "1024 × 768")
            {
                key.SetValue("VMResWidth", 1024, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 768, RegistryValueKind.DWord);
            }
            else if (Setting.SetValueForResulationSwitch == "800  × 600")
            {
                key.SetValue("VMResWidth", 800, RegistryValueKind.DWord);
                key.SetValue("VMResHeight", 600, RegistryValueKind.DWord);
            }
        }
        private void Registry_3rd_box()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Tencent\\MobileGamePC");
            if (Setting.SetValueForSDswtich == "1")
            {
                key.SetValue("com.tencent.ig_ContentScale", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForHDSwitch == "1")
            {
                key.SetValue("com.tencent.ig_ContentScale", 1, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForswith2k == "1")
            {
                key.SetValue("com.tencent.ig_ContentScale", 2, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForSmoothSwitch == "1")
            {
                key.SetValue("VMDeviceModel", "SM-S908B");
                key.SetValue("com.tencent.ig_RenderQuality", 0, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForHDRswitch == "1")
            {
                key.SetValue("VMDeviceModel", "SM-S908B");
                key.SetValue("com.tencent.ig_RenderQuality", 2, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForfps90Switch == "1")
            {
                key.SetValue("VMDeviceModel", "ASUS_I001DA");
                key.SetValue("com.tencent.ig_RenderQuality", 0, RegistryValueKind.DWord);
            }
        }
        private async void Emu_Install_Process()
        {

        }

        private async void Do_Task()
        {

        }
        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HDR90_CheckedChanged(object sender, EventArgs e)
        {
            if (HDR90.Checked)
            {
                HDR90.Text = "1";
                HDRswitch.Checked = false;
                fps90Switch.Checked = false;
                SmoothSwitch.Checked = false;
                File.WriteAllText(Path.Combine(Key, "HDR90.txt"), HDR90.Text);
                guna2HtmlLabel1.ForeColor = Color.Lime;
            }
            else
            {
                HDR90.Text = "0";
                File.WriteAllText(Path.Combine(Key, "HDR90.txt"), HDR90.Text);
                guna2HtmlLabel1.ForeColor = Color.White;
            }
        }

        private void AntiAlisingLabal_Click(object sender, EventArgs e)
        {

        }

        private void MemoryLabal_Click(object sender, EventArgs e)
        {

        }

        private void ProcessorLabal_Click(object sender, EventArgs e)
        {

        }

        private void ResulationLbal_Click(object sender, EventArgs e)
        {

        }

        private void DPIlabal_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
