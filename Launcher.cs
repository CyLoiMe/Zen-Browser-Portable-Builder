using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ZenLauncher {
    class Program {
        static void Main(string[] args) {
            try {
                // 获取路径
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string appDir = Path.Combine(baseDir, @"App\ZenBrowser");
                string exePath = Path.Combine(appDir, "zen.exe");
                string profileDir = Path.Combine(baseDir, @"Data\profile");

                // 检查程序是否存在
                if (!File.Exists(exePath)) {
                    MessageBox.Show("Error: zen.exe not found in\n" + appDir, "Zen Portable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 确保配置文件夹存在
                if (!Directory.Exists(profileDir)) Directory.CreateDirectory(profileDir);

                // 启动参数
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = exePath;
                psi.Arguments = "-profile \"" + profileDir + "\" -no-remote " + string.Join(" ", args);
                psi.UseShellExecute = false;

                Process.Start(psi);
            } catch (Exception ex) {
                MessageBox.Show("Launch Error: " + ex.Message, "Zen Portable");
            }
        }
    }
}
