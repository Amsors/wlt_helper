using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace wlt_helper
{
    public partial class MainForm : Form
    {
        private bool isPasswordVisible = false;
        public MainForm()
        {
            InitializeComponent();
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            string ssid = WltWebFunction.GetCurrentConnection();
            if (ssid != null)
            {
                txt_SSID.Text = ssid;
            }
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
                txt_StatusBox.AppendText(str+Environment.NewLine);
            }
            else
            {
                txt_StatusBox.AppendText(str);
            }
            txt_StatusBox.ScrollToCaret();
        }

        public (string? firstName, string? lastName) GetUserPwd()
        {
            return (txt_UserName.Text, txt_Password.Text);
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            using (var webFunction = new WltWebFunction())
            {
                OutputToStatusBox("尝试登录到网络通", false);
                await webFunction.PostUserPwd(this);
            }
        }
    }
}
