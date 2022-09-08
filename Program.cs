using DEXSTER;
using DEXSTER.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEXSTER_SMART
{
    internal static class Program
    {
        [STAThread]

        static void Main()
        {
            File.Delete("Siticone.UI.dll");
            File.Delete("Bunifu_UI_v1.52.dll");
            File.Delete("Guna.UI2.dll");
            File.WriteAllBytes("Siticone.UI.dll", Resources.Siticone_UI);
            File.WriteAllBytes("Bunifu_UI_v1.52.dll", Resources.Bunifu_UI_v1_52);
            File.WriteAllBytes("Guna.UI2.dll", Resources.Guna_UI2);
            File.SetAttributes("Siticone.UI.dll", FileAttributes.Hidden);
            File.SetAttributes("Bunifu_UI_v1.52.dll", FileAttributes.Hidden);
            File.SetAttributes("Guna.UI2.dll", FileAttributes.Hidden);
            if (File.Exists("DEXSTER_Services_V13.dll"))
            {
                Process[] localByName = Process.GetProcessesByName("AndroidEmulator");
                if (localByName.Length > 0)
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
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
                else
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
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }

            }
            else
            {
                MessageBox.Show("Load Driver Failed");
                Application.Exit();
            }
        }
    }
}
