using DEXSTER.Properties;
using DEXSTER_SMART;
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
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DEXSTER
{
    public partial class Main : Form
    {

        int i;
        private string SP;
        private string UI = "D:\\TxGameAssistant\\ui\\";
        public Main()
        {
            InitializeComponent();
        }
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
        private async void Form2_Load(object sender, EventArgs e)
        {
            var settingLoad = Application.OpenForms.OfType<Setting>().Select(t => t).FirstOrDefault();
            settingLoad = new Setting();
            settingLoad.Show();
            CHECKER();
        }
        private void CHECKER()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Elapsed += CHECKER_elapsed;
            timer.Start();
        }
        private void CHECKER_elapsed(object sender, ElapsedEventArgs e)
        {
            using (RegistryKey key3 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\SharedAccess\\Parameters\\FirewallPolicy\\PublicProfile"))
            {
                if (key3 == null)
                {
                    FIREWALLON();
                }
                else
                {
                    Object o = key3.GetValue("EnableFirewall");
                    if (o == null)
                    {
                        FIREWALLON();
                    }
                    else
                    {
                        int firewall = (int)o;
                        if (firewall == 1)
                        {

                        }
                        else
                        {
                            FIREWALLON();
                        }
                    }
                }
            }
        }
        private void FIREWALLON()
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
                standardInput.WriteLine("netsh advfirewall set allprofiles state on");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            var settingLoad = Application.OpenForms.OfType<Setting>().Select(t => t).FirstOrDefault();
            if (settingLoad!= null)
            {
                settingLoad.BringToFront();
            }
            else
            {
                settingLoad = new Setting();
                settingLoad.Show();
            }
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
            if(Setting.SetValueForDedicatedSwitch=="1")
            {
                key.SetValue("GraphicsCardEnabled", Setting.SetValueForDedicatedSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("GraphicsCardEnabled", 0, RegistryValueKind.DWord);
            }
            if(Setting.SetValueForGlobalCacheSwitch=="1")
            {
                key.SetValue("LocalShaderCacheEnabled", Setting.SetValueForGlobalCacheSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("LocalShaderCacheEnabled", 0, RegistryValueKind.DWord);
            }
            if(Setting.SetValueForOpenGLSwitch=="1")
            {
                key.SetValue("EnableGLESv3", Setting.SetValueForOpenGLSwitch, RegistryValueKind.DWord);
                key.SetValue("ForceDirectX", 0, RegistryValueKind.DWord);
            }
            if(Setting.SetValueForDirectXSwitch=="1")
            {
                key.SetValue("ForceDirectX", Setting.SetValueForDirectXSwitch, RegistryValueKind.DWord);
                key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForAuto == "1")
            {
                key.SetValue("ForceDirectX", 3, RegistryValueKind.DWord);
                key.SetValue("EnableGLESv3", 1, RegistryValueKind.DWord);
            }
            if (Setting.SetValueForRenderdOptimizationSwitch=="1")
            {
                key.SetValue("RenderOptimizeEnabled", Setting.SetValueForRenderdOptimizationSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("RenderOptimizeEnabled", 0, RegistryValueKind.DWord);
            }
            if(Setting.SetValueForRenderedCahceSwitch=="1")
            {
                key.SetValue("ShaderCacheEnabled", Setting.SetValueForRenderedCahceSwitch, RegistryValueKind.DWord);
            }
            else
            {
                key.SetValue("ShaderCacheEnabled", 0, RegistryValueKind.DWord);
            }
            if(Setting.SetValueForVerticalSwitch=="1")
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
            if(Setting.SetValueForAntiAlisingSwitch=="1")
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
            if (Setting.SetValueForMemorySwitch== "8192")
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
            if(Setting.SetValueForDPISwitch=="480")
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
            if (Setting.SetValueForHDR90Switch == "1")
            {
                key.SetValue("VMDeviceModel", "ASUS_I001DA");
                key.SetValue("com.tencent.ig_RenderQuality", 2, RegistryValueKind.DWord);
            }
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        private void Start_Click_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                MessageBox.Show("Emu Already Running Close Manually or use Safe Exit");
            }
            else
            {
                timer1.Enabled = true;
                Start_Task();
            }
        }
        private async void Start_Task()
        {
            await Task.Run(() => Start_Task_For_Emu());
            for (i = 0; i <=5; i++)
            {
                guna2ProgressBar1.Value = i;
            }
        }
        private async void Start_Task_For_Emu()
        {
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
        private void USAGE()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\AndroidEmulator.exe");
            key.Close();
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\AndroidEmulator.exe\\PerfOptions");
            key.SetValue("CpuPriorityClass", 3, RegistryValueKind.DWord);
            key.Close();
        }
        private async void Run_Pubg()
        {
            await Task.Run(() => Pubg());
        }
        private async void Pubg()
        {
            await Task.Run(() => CheckResources());
            for (i = 0; i <= 10; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            if (!Normal_Mode.Checked)
            {
                await Task.Run(() => DISABLED());
                for (i = 0; i <= 30; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => TCP_OUT());
                for (i = 0; i <= 40; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => UDP_OUT());
                for (i = 0; i <= 50; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => ENABLED());
                for (i = 0; i <= 60; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => DEXSTERLOOP_Device_ID());
                for (i = 0; i <= 70; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
                await Task.Run(() => StartingCode_V1());
                for (i = 0; i <= 100; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
            }
            else
            {
                Task.Delay(60000);
                await Task.Run(() => Game());
                for (i = 0; i <= 100; i++)
                {
                    guna2ProgressBar1.Value = i;
                }
            }

        }
        private void Game()
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
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Safe_Exit_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                SafeExit();
            }
            else
            {
                Auto_Mode();
            }
        }
        private async void Auto_Mode()
        {

            Task.Run(() => EMU_KILL());
            for (i = 0; i <= 05; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => release());
            for (i = 0; i <= 05; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => FakeRegistry());
            for (i = 0; i <= 60; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => RegistryDelete());
            for (i = 0; i <= 70; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => NewDirectory());
            for (i = 0; i <= 90; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => renew());
            for (i = 0; i <= 95; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => Terminate());
            for (i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
            }
        }
        private async void SafeExit()
        {

            Task.Run(() => release());
            for (i = 0; i <= 05; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => CheckResources());
            for (i = 0; i <= 20; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => Random_Device());
            for (i = 0; i <= 30; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => SafeShellV_1());
            for (i = 0; i <= 40; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => FakeRegistry());
            for (i = 0; i <= 60; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            Task.Run(() => RegistryDelete());
            for (i = 0; i <= 70; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => NewDirectory());
            for (i = 0; i <= 90; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => renew());
            for (i = 0; i <= 95; i++)
            {
                guna2ProgressBar1.Value = i;
            }
            await Task.Run(() => Terminate());
            for (i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
            }
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
            if (!Normal_Mode.Checked)
            {
                TCP_IN();
                UDP_IN();
            }
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKIN1 protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKIN2 protocol=TCP remoteport=17500,17000-17999 dir=in action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void TCP_OUT()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT1 protocol=TCP remoteport=1-20,23-24,26-49,52-79,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT2 protocol=TCP remoteport=1-21,23-24,26-49,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT3 protocol=TCP remoteport=53 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT4 program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=TCP remoteport=80 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT5 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT6 protocol=TCP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT7 protocol=TCP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT8 protocol=TCP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT9 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,19000-25000,18000-19000,10000-15000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT10 protocol=TCP remoteport=18081,20371,23946,27042,27043,35000,19000-25000,18000-19000,10000-15000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT11 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT12 protocol=TCP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT13 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=TCP_OUT14 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKOUT1 protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKOUT2 protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKIN3 protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKIN4 protocol=TCP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void UDP_OUT()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT1 protocol=UDP remoteport=1-21,23-24,26-49,52,54-79,81-118,120-122,124-142,501-545,548-562,564-988,991-1193,1195-1292,1294-1722,1724-4499,4501-5059 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT2 protocol=UDP remoteport=1-20,23-24,26-49,81-109,111-118,120-142,144-442,444-464,466-499,501-545,548-562,564-586,588-852,854-988,991-992,994,996-1193,1195-1292,1294-1700,1702-1722,1724-4499,4501-5059,5062-8079,8082-8085,8087,8089-8442,8444-8879 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT3 protocol=UDP remoteport=80,443 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT4 program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=UDP remoteport=53 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT5 program=C:\\TxGameAssistant\\ui\\AndroidEmulator.exe protocol=UDP remoteport=52-79 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT6 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT7 protocol=UDP remoteport=21,22,23,69,110,123,143,161,1900,3389,5353,11211 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT8 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT9 protocol=UDP remoteport=5228,58741,8013,8080,8081,8086,8088,8089,10404,10012,13003,13004,15692,16004 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT10 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,18000-19000,21000-25000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT11 protocol=UDP remoteport=18081,20371,23946,27042,27043,35000,18000-19000,21000-25000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT12 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT13 protocol=UDP remoteport=58000-60000,60000-62000,62000-64000,64000-65000,65501-65530,65531-65535 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT14 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=UDP_OUT15 protocol=TCP remoteport=30000-35000,35000-40000,40000-50000,10000-16999,17600-19000 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKOUT3 protocol=UDP remoteport=17500,17000-17999 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=ILANDBLOCKOUT4 protocol=UDP remoteport=17500,17000-17999 dir=out action=block enable=yes");
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
            USAGE();
        }
        private void Start7()
        {
            string start = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Tencent\\MobileGamePC\\UI", "InstallPath", "").ToString();
            Process.Start(Path.Combine(start) + "/AndroidEmulator.exe", "-vm 100");
        }
        private void CheckResources()
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
        private void DISABLED()
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
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=DISABLED");
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=DISABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void ENABLED()
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
                standardInput.WriteLine("netsh interface set interface name=Ethernet admin=ENABLED");
                standardInput.WriteLine("netsh interface set interface name=Wi-Fi admin=ENABLED");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void DEXSTERLOOP_Device_ID()
        {
            string path = "C:\\DEXSTERLOOP_Device_ID.txt";
            if (File.Exists(path))
            {
                string SP = File.ReadAllText(path);
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
                    standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.manufacturer " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.runtime.firstboot " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.device " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop android.device.id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.model " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.brand " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.name " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.mac_address " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop net.hostname " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.serialno " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop gaid " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell content insert --uri content://settings/secure --bind name:s:android_id --bind value:s:" + SP + "");
                    standardInput.Flush();
                    standardInput.Close();
                    process.WaitForExit();
                }
            }
            else
            {
                string validchars = "a5b3cd0efg8hij5k9lm6n8op3qr7s2tu6vw5xy4z";
                var sb = new StringBuilder();
                var rand = new Random();
                for (int i = 1; i <= 34; i++)
                {
                    int idx = rand.Next(0, validchars.Length);
                    char randomChar = validchars[idx];
                    sb.Append(randomChar);
                }
                SP = sb.ToString();
                string Key = "C:\\";
                File.WriteAllText(Path.Combine(Key, "DEXSTERLOOP_Device_ID.txt"), SP);
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
                    standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.manufacturer " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.runtime.firstboot " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.device " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop android.device.id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.model " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.brand " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.name " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.mac_address " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.android_id " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop net.hostname " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.serialno " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell setprop gaid " + SP + "");
                    standardInput.WriteLine("adb -s emulator-5554 shell content insert --uri content://settings/secure --bind name:s:android_id --bind value:s:" + SP + "");
                    standardInput.Flush();
                    standardInput.Close();
                    process.WaitForExit();
                }
            }
        }
        private void StartingCode_V1()
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
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 500 /proc");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Active.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/AgreeIllegalAvatarRule.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/BP_WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Cached.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/iTOPPrefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/SettingConfig_Slot.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Active.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/AgreeIllegalAvatarRule.json");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/BP_WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/Cached.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/iTOPPrefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/SettingConfig_Slot.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/WeakGuidSave.sav");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /default.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/build.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.vbox86.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/hw/gralloc.vbox86.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/xbin/su");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.titan.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /fstab.vbox86");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /default.prop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libhardware.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /ueventd.vbox86.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/hw/gralloc.vbox86.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libbcinfo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /init.superuser.rc");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/bin/androVM_setprop");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /.libcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/lib/libhardware.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/ContactsProvider/ContactsProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DefaultContainerService/DefaultContainerService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DocumentsUI/DocumentsUI.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/DownloadProvider/DownloadProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/ExtServices/ExtServices.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/FusedLocation/FusedLocation.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/GoogleLoginService/GoogleLoginService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/GoogleServicesFramework/GoogleServicesFramework.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/InputDevices/InputDevices.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/MediaProvider/MediaProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/PackageInstaller/PackageInstaller.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Phonesky/Phonesky.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/PlayGames/PlayGames.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Provision/Provision.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Settings/Settings.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/SettingsProvider/SettingsProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/Shell/Shell.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/StatementService/StatementService.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/SystemUI/SystemUI.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /system/priv-app/TelephonyProvider/TelephonyProvider.apk");
                standardInput.WriteLine("adb -s emulator-5554 shell mv /init.vbox86.rc /init.vbox86.rc1");
                standardInput.WriteLine("adb -s emulator-5554 shell mv /system/build.prop /system/build.prop1");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine("adb -s emulator-5554 shell sleep 120");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            Lobby_PORTS();
            LobbyAntiban();
            kill();
            FakeRegistry();
            Registry_CHECKER();
        }
        private void StartingCode_V2()
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
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void kill()
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
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.WriteLine("del /s /f /q %USERPROFILE%\appdata\\local\temp\\*.*");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Registry_CHECKER()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Elapsed += Registry_CHECKER_elapsed;
            timer.Start();
        }
        private void Registry_CHECKER_elapsed(object sender, ElapsedEventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                RegistryDelete();
            }
        }
        private void LobbyAntiban()
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
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libUE4.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libtersafe.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libTDataMaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-2/lib/arm/libgamemaster.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libapp.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libBugly.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libcubehawk.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libhelpshiftlistener.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libigshare.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libijkffmpeg.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libImSDK.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libITOP.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libkk-image.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/liblbs.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libmarsxlog.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libmmkv.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libnpps-jni.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsentry.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsentry-android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libst-engine.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libswappy.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtgpa.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libtprt.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libvlink.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libzip.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libzlib.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libc++_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libdiscord_connect_sdk_android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libflutter.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudarch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudcore.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libGCloudVoice.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libgnustl_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libPandoraVideo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/app/com.tencent.ig-1/lib/arm/libsoundtouch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libapp.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libBugly.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libcubehawk.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libhelpshiftlistener.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libigshare.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libijkffmpeg.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libImSDK.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libITOP.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libkk-image.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/liblbs.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libmarsxlog.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libmmkv.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libnpps-jni.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsentry.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsentry-android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libst-engine.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libswappy.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtgpa.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libtprt.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libvlink.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libzip.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libzlib.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libc++_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libdiscord_connect_sdk_android.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libflutter.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloud.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudarch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgcloudcore.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libGCloudVoice.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libgnustl_shared.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libPandoraVideo.so");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/app/com.tencent.ig-1/lib/arm/libsoundtouch.so");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell chmod -R 000 /data/data/com.tencent.ig/databases/iMSDK.db");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Lobby_PORTS()
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
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY0 protocol=TCP remoteport=8080,8081,8088,8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY1 protocol=UDP remoteport=8080,8081,8088,8086 dir=in action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY2 protocol=TCP remoteport=8080,8081,8088,8086 dir=out action=block enable=yes");
                standardInput.WriteLine("netsh advfirewall firewall add rule name=DEXLOBBY3 protocol=UDP remoteport=8080,8081,8088,8086 dir=out action=block enable=yes");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void release()
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
                standardInput.WriteLine("ipconfig /release");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void renew()
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
                standardInput.WriteLine("ipconfig /renew");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void Random_Device()
        {
            string validchars = "a5b3cd0efg8hij5k9lm6n8op3qr7s2tu6vw5xy4z";
            var sb = new StringBuilder();
            var rand = new Random();
            for (int i = 1; i <= 34; i++)
            {
                int idx = rand.Next(0, validchars.Length);
                char randomChar = validchars[idx];
                sb.Append(randomChar);
            }
            SP = sb.ToString();
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
                standardInput.WriteLine("adb -s emulator-5554 shell settings put secure android_id " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.manufacturer " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.runtime.firstboot " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.device " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop android.device.id " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.model " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.brand " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.product.name " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.mac_address " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.android_id " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop net.hostname " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop ro.serialno " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell setprop gaid " + SP + "");
                standardInput.WriteLine("adb -s emulator-5554 shell content insert --uri content://settings/secure --bind name:s:android_id --bind value:s:" + SP + "");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void SafeShellV_1()
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
                standardInput.WriteLine("adb kill-server");
                standardInput.WriteLine("adb devices");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount");
                standardInput.WriteLine("adb -s emulator-5554 shell mount -o rw,remount /system");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/user/0/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/Logs");
                standardInput.WriteLine("adb -s emulator-5554 shell monkey -p com.tencent.ig -c android.intent.category.LAUNCHER 1");
                standardInput.WriteLine("adb -s emulator-5554 shell am kill com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell am force-stop com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/lib");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/arm/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-1/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/app/com.tencent.ig-2/lib/");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/GA.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/loginInfoFile.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/MailPhoneLogin.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/NewPlayerprefsSwitcher.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /storage/emulated/0/Android/data/com.tencent.ig/files/UE4Game/ShadowTrackerExtra/ShadowTrackerExtra/Saved/SaveGames/playerprefs.json");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_appcache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_bugly");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_databases");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_geolocation");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_pccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_textures");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_tmppccache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_webview");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/code_cache");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/files");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/apk.conf");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/Burimoss");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/app_crashrecord");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_issues-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs__db_support_key_values-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_db_helpshift_users-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/__hs_log_store-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/bugly_db_-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/config.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db");
                standardInput.WriteLine("adb -s emulator-5554 shell rm -rf /data/data/com.tencent.ig/databases/google_app_measurement_local.db-journal");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput/cache");
                standardInput.WriteLine("adb -s emulator-5554 rm -rf /data/data/com.tencent.tinput1/cache");
                standardInput.WriteLine("adb -s emulator-5554 shell pm unhide com.tencent.ig");
                standardInput.WriteLine("adb -s emulator-5554 shell pm hide com.tencent.ig");
                standardInput.WriteLine("adb kill-server");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
            EMU_KILL();
            NET_STOP();
            FOLDER_DEL();
        }
        private void FOLDER_DEL()
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
                standardInput.WriteLine("del C:\\aow_drv.log");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Roaming\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Tencent");
                standardInput.WriteLine("rd /s /q C:\\Users\\%USERNAME%\\AppData\\Local\\Temp");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Windows\\Temp\\*.*");
                standardInput.WriteLine("del /s /f /q C:\\Program Files\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\Program Files (x86)\\Tencent");
                standardInput.WriteLine("del /s /f /q C:\\ProgramData\\Tencent");
                standardInput.WriteLine("del /s /f /q %USERPROFILE%\appdata\\local\temp\\*.*");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }
        private void NET_STOP()
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
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
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
        private void Terminate()
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
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("aow_exe");
            if (localByName.Length > 0)
            {
                Task.Delay(60000);
                Run_Pubg();
                timer1.Enabled = false;
                timer1.Stop();
            }

        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }
        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
            if (localByName.Length > 0)
            {
                MessageBox.Show("Emu Still Runnnig Dont Close!!!");
            }
            else
            {
                Exitkill();
            }
        }
        private async void Exitkill()
        {
            Task.Run(() => kill());
            Task.Run(() => FakeRegistry());
            Task.Run(() => RegistryDelete());
            await Task.Run(() => Forcestop());
        }
        private void Forcestop()
        {
            Environment.Exit(0);
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Auto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Resources_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Normal_Mode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel1_Click_1(object sender, EventArgs e)
        {
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
           await Task.Run(() => IPCONFIG_RUN());
        }
        private void IPCONFIG_RUN()
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
                standardInput.WriteLine("ipconfig /renew");
                standardInput.Flush();
                standardInput.Close();
                process.WaitForExit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Registry_Create();
        }
        private void siticoneLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
