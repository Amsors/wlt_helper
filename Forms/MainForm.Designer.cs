namespace wlt_helper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txt_UserName = new TextBox();
            btn_Submit = new Button();
            txt_Password = new TextBox();
            btn_TogglePassword = new Button();
            lbl_UserName = new Label();
            lbl_Password = new Label();
            btn_TestURL = new Button();
            lbl_SSID = new Label();
            txt_SSID = new TextBox();
            lbl_Title = new Label();
            txt_StatusBox = new TextBox();
            ckb_LaunchOnBoot = new CheckBox();
            btn_Login = new Button();
            notifyIcon = new NotifyIcon(components);
            btn_ExitApp = new Button();
            ckb_HideOnLaunch = new CheckBox();
            SuspendLayout();
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(176, 172);
            txt_UserName.MaxLength = 128;
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(300, 27);
            txt_UserName.TabIndex = 0;
            txt_UserName.TextChanged += txt_UserName_TextChanged;
            // 
            // btn_Submit
            // 
            btn_Submit.Location = new Point(524, 170);
            btn_Submit.Name = "btn_Submit";
            btn_Submit.Size = new Size(150, 30);
            btn_Submit.TabIndex = 1;
            btn_Submit.Text = "button1";
            btn_Submit.UseVisualStyleBackColor = true;
            btn_Submit.Click += btn_Submit_Click;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(176, 238);
            txt_Password.MaxLength = 128;
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(300, 27);
            txt_Password.TabIndex = 2;
            txt_Password.TextChanged += txt_Password_TextChanged;
            // 
            // btn_TogglePassword
            // 
            btn_TogglePassword.Location = new Point(524, 236);
            btn_TogglePassword.Name = "btn_TogglePassword";
            btn_TogglePassword.Size = new Size(150, 30);
            btn_TogglePassword.TabIndex = 3;
            btn_TogglePassword.Text = "button2";
            btn_TogglePassword.UseVisualStyleBackColor = true;
            btn_TogglePassword.Click += btn_TogglePassword_Click;
            // 
            // lbl_UserName
            // 
            lbl_UserName.AutoSize = true;
            lbl_UserName.Location = new Point(176, 149);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(53, 20);
            lbl_UserName.TabIndex = 4;
            lbl_UserName.Text = "label1";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(176, 215);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(53, 20);
            lbl_Password.TabIndex = 5;
            lbl_Password.Text = "label2";
            // 
            // btn_TestURL
            // 
            btn_TestURL.Location = new Point(376, 319);
            btn_TestURL.Name = "btn_TestURL";
            btn_TestURL.Size = new Size(100, 29);
            btn_TestURL.TabIndex = 6;
            btn_TestURL.Text = "button1";
            btn_TestURL.UseVisualStyleBackColor = true;
            btn_TestURL.Click += btn_TestURL_Click;
            // 
            // lbl_SSID
            // 
            lbl_SSID.AutoSize = true;
            lbl_SSID.Location = new Point(176, 297);
            lbl_SSID.Name = "lbl_SSID";
            lbl_SSID.Size = new Size(53, 20);
            lbl_SSID.TabIndex = 7;
            lbl_SSID.Text = "label1";
            // 
            // txt_SSID
            // 
            txt_SSID.Location = new Point(176, 320);
            txt_SSID.Name = "txt_SSID";
            txt_SSID.ReadOnly = true;
            txt_SSID.Size = new Size(167, 27);
            txt_SSID.TabIndex = 8;
            txt_SSID.TextChanged += textBox1_TextChanged;
            // 
            // lbl_Title
            // 
            lbl_Title.Font = new Font("楷体", 50F);
            lbl_Title.Location = new Point(133, 33);
            lbl_Title.Name = "lbl_Title";
            lbl_Title.Size = new Size(607, 93);
            lbl_Title.TabIndex = 9;
            lbl_Title.Text = "label1";
            lbl_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_StatusBox
            // 
            txt_StatusBox.Location = new Point(89, 422);
            txt_StatusBox.Multiline = true;
            txt_StatusBox.Name = "txt_StatusBox";
            txt_StatusBox.ReadOnly = true;
            txt_StatusBox.Size = new Size(691, 135);
            txt_StatusBox.TabIndex = 10;
            // 
            // ckb_LaunchOnBoot
            // 
            ckb_LaunchOnBoot.AutoSize = true;
            ckb_LaunchOnBoot.Location = new Point(565, 319);
            ckb_LaunchOnBoot.Name = "ckb_LaunchOnBoot";
            ckb_LaunchOnBoot.Size = new Size(109, 24);
            ckb_LaunchOnBoot.TabIndex = 11;
            ckb_LaunchOnBoot.Text = "checkBox1";
            ckb_LaunchOnBoot.UseVisualStyleBackColor = true;
            ckb_LaunchOnBoot.CheckedChanged += ckb_LaunchOnBoot_CheckedChanged;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(376, 364);
            btn_Login.Margin = new Padding(2, 2, 2, 2);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(100, 29);
            btn_Login.TabIndex = 12;
            btn_Login.Text = "button1";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "notifyIcon1";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // btn_ExitApp
            // 
            btn_ExitApp.Location = new Point(757, 24);
            btn_ExitApp.Margin = new Padding(2, 2, 2, 2);
            btn_ExitApp.Name = "btn_ExitApp";
            btn_ExitApp.Size = new Size(100, 29);
            btn_ExitApp.TabIndex = 13;
            btn_ExitApp.Text = "button1";
            btn_ExitApp.UseVisualStyleBackColor = true;
            btn_ExitApp.Click += btn_ExitApp_Click;
            // 
            // ckb_HideOnLaunch
            // 
            ckb_HideOnLaunch.AutoSize = true;
            ckb_HideOnLaunch.Location = new Point(565, 366);
            ckb_HideOnLaunch.Name = "ckb_HideOnLaunch";
            ckb_HideOnLaunch.Size = new Size(109, 24);
            ckb_HideOnLaunch.TabIndex = 14;
            ckb_HideOnLaunch.Text = "checkBox1";
            ckb_HideOnLaunch.UseVisualStyleBackColor = true;
            ckb_HideOnLaunch.CheckedChanged += ckb_HideOnLaunch_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 565);
            Controls.Add(ckb_HideOnLaunch);
            Controls.Add(btn_ExitApp);
            Controls.Add(btn_Login);
            Controls.Add(ckb_LaunchOnBoot);
            Controls.Add(txt_StatusBox);
            Controls.Add(lbl_Title);
            Controls.Add(txt_SSID);
            Controls.Add(lbl_SSID);
            Controls.Add(btn_TestURL);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_UserName);
            Controls.Add(btn_TogglePassword);
            Controls.Add(txt_Password);
            Controls.Add(btn_Submit);
            Controls.Add(txt_UserName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_UserName;
        private Button btn_Submit;
        private TextBox txt_Password;
        private Button btn_TogglePassword;
        private Label lbl_UserName;
        private Label lbl_Password;
        private Button btn_TestURL;
        private Label lbl_SSID;
        private TextBox txt_SSID;
        private Label lbl_Title;
        private TextBox txt_StatusBox;
        private CheckBox ckb_LaunchOnBoot;
        private Button btn_Login;
        private NotifyIcon notifyIcon;
        private Button btn_ExitApp;
        private CheckBox ckb_HideOnLaunch;
    }
}
