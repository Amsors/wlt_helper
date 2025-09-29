using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Drawing;
using wlt_helper.Services;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace wlt_helper
{
    public partial class MainForm : Form
    {
        private bool isPasswordVisible = false;
        private bool isMainFormVisible = true;

        public MainForm()
        {
            InitializeComponent();
            ConfigInitialize();
            MainFormInitialize();
            NotifyIconInitialize();
            LaunchCronJobs();
        }

        private void ConfigInitialize()
        {
            if (AppSettings.ExistConfigFile() == false)
            {
                UserConfig.LaunchOnBoot = false;
                UserConfig.HideOnLaunch = false;

                AppSettings.SetConfigFile();
            }
            else
            {
                string conf = AppSettings.ReadConfigFile();
                using JsonDocument document = JsonDocument.Parse(conf);
                JsonElement root = document.RootElement;

                bool launchOnBoot = root.GetProperty("_launchOnBoot").GetBoolean();
                bool hideOnLaunch = root.GetProperty("_hideOnLaunch").GetBoolean();

                UserConfig.LaunchOnBoot = launchOnBoot;
                UserConfig.HideOnLaunch = hideOnLaunch;

                ckb_LaunchOnBoot.Checked = launchOnBoot;
                AppSettings.SetAutoStart();

                ckb_HideOnLaunch.Checked = hideOnLaunch;
            }
        }

        private void MainFormInitialize()
        {
            byte[] iconBytes = AppSettings.GetIconBytes();
            Icon myIcon = AppSettings.BytesToIcon(iconBytes);
            this.Icon = myIcon;
            this.Text = "wlt_helper";
            btn_Submit.Text = "确认";
            btn_TogglePassword.Text = "显示密码";
            txt_Password.PasswordChar = '*';
            lbl_Password.Text = "密码";
            lbl_UserName.Text = "用户名";
            btn_TestURL.Text = "测试网络";
            lbl_SSID.Text = "当前WLAN的SSID";
            lbl_Title.Text = "网络通助手";
            ckb_LaunchOnBoot.Text = "开机自启动";
            btn_Login.Text = "尝试登录";
            btn_ExitApp.Text = "退出程序";
            ckb_HideOnLaunch.Text = "启动自动托盘";
            txt_SSID.Text = "N/A"; //TODO 待删除

            this.FormClosing += MainForm_FormClosing;
            //this.Shown += MainForm_Hide;
        }

        private void NotifyIconInitialize()
        {
            byte[] iconBytes = AppSettings.GetIconBytes();
            Icon myIcon = AppSettings.BytesToIcon(iconBytes);
            this.notifyIcon.Icon = myIcon;
            notifyIcon.Text = "wlt_helper";
            notifyIcon.Visible = true;
        }

        private void LaunchCronJobs()
        {
            CronJob job1 = new();
            TimerTask Task1 = new TimerTask(job1.ConnectToWlt, AppConfig.time_ScanNetworkAvaidability);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (UserConfig.HideOnLaunch)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.isMainFormVisible = false;
            }
            string? user_pwd = DataStorage.LoadSavedCredentials();
            if (user_pwd != null)
            {
                string[] parts = user_pwd.Split('|');
                if (parts.Length == 2)
                {
                    txt_UserName.Text = parts[0];
                    txt_Password.Text = parts[1];
                }
            }

            //string ssid = WltWebFunction.GetCurrentConnection();
            //if (ssid != null)
            //{
            //    txt_SSID.Text = ssid;
            //}
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.isMainFormVisible = false;
                this.Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isMainFormVisible) return;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string userInput = txt_UserName.Text;
            string pwdInput = txt_Password.Text;

            if (string.IsNullOrEmpty(userInput) || string.IsNullOrEmpty(pwdInput))
            {
                MessageBox.Show("请检查输入内容！");
            }
            else
            {
                DataStorage.SaveCredentials(userInput, pwdInput);
                MessageBox.Show($"已保存");
            }
        }

        private void btn_TogglePassword_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                txt_Password.PasswordChar = '*';
                btn_TogglePassword.Text = "显示密码";
                isPasswordVisible = false;
            }
            else
            {
                txt_Password.PasswordChar = '\0';
                btn_TogglePassword.Text = "隐藏密码";
                isPasswordVisible = true;
            }
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btn_TestURL_Click(object sender, EventArgs e)
        {
            using (var webFunction = new WltWebFunction())
            {
                string testUrl = "https://www.baidu.com";
                bool isAccessible = await webFunction.TestWebsiteAccessAsync(testUrl);
                string content = $"网站 {testUrl} 可访问性：{(isAccessible ? "可访问" : "不可访问")}";
                OutputToStatusBox(content);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void OutputToStatusBox(string str, bool newline = true)
        {
            if (newline)
            {
                txt_StatusBox.AppendText(str + Environment.NewLine);
            }
            else
            {
                txt_StatusBox.AppendText(str);
            }
            txt_StatusBox.ScrollToCaret();
        }

        //public (string? firstName, string? lastName) GetUserPwd()
        //{
        //    return (txt_UserName.Text, txt_Password.Text);
        //}

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            using (var webFunction = new WltWebFunction())
            {
                OutputToStatusBox("尝试登录到网络通", false);
                await webFunction.LoginToWlt();
            }
        }

        private void ckb_LaunchOnBoot_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"now is {ckb_LaunchOnBoot.Checked}");
            Debug.WriteLine("正在更改开机自启动");
            UserConfig.LaunchOnBoot = ckb_LaunchOnBoot.Checked;
            if (ckb_LaunchOnBoot.Checked)
            {
                UserConfig.LaunchOnBoot = true;
                if (AppSettings.SetAutoStart())
                {
                    Debug.WriteLine("成功");
                }
                else
                {
                    Debug.WriteLine("失败");
                    Debug.WriteLine($"请检查" +
                        @"C:\Users\[你的用户名称]\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup" +
                        "并手动删除APP快捷方式");
                }
            }
            else
            {
                UserConfig.HideOnLaunch = false;
                if (AppSettings.SetAutoStart())
                {
                    Debug.WriteLine("成功");
                }
                else
                {
                    Debug.WriteLine("失败");
                }
            }
        }

        private void btn_ExitApp_Click(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
            Application.Exit();
        }

        private void ckb_HideOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_HideOnLaunch.Checked)
            {
                UserConfig.HideOnLaunch = true;
            }
            else
            {
                UserConfig.HideOnLaunch = false;
            }
        }
    }
}
