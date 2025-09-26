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
            textBox1 = new TextBox();
            ckb_LaunchOnBoot = new CheckBox();
            SuspendLayout();
            // 
            // txt_UserName
            // 
            txt_UserName.Location = new Point(190, 187);
            txt_UserName.MaxLength = 128;
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(300, 27);
            txt_UserName.TabIndex = 0;
            txt_UserName.TextChanged += txt_UserName_TextChanged;
            // 
            // btn_Submit
            // 
            btn_Submit.Location = new Point(528, 185);
            btn_Submit.Name = "btn_Submit";
            btn_Submit.Size = new Size(150, 30);
            btn_Submit.TabIndex = 1;
            btn_Submit.Text = "button1";
            btn_Submit.UseVisualStyleBackColor = true;
            btn_Submit.Click += btn_Submit_Click;
            // 
            // txt_Password
            // 
            txt_Password.Location = new Point(190, 253);
            txt_Password.MaxLength = 128;
            txt_Password.Name = "txt_Password";
            txt_Password.Size = new Size(300, 27);
            txt_Password.TabIndex = 2;
            txt_Password.TextChanged += txt_Password_TextChanged;
            // 
            // btn_TogglePassword
            // 
            btn_TogglePassword.Location = new Point(528, 251);
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
            lbl_UserName.Location = new Point(190, 164);
            lbl_UserName.Name = "lbl_UserName";
            lbl_UserName.Size = new Size(53, 20);
            lbl_UserName.TabIndex = 4;
            lbl_UserName.Text = "label1";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new Point(190, 230);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(53, 20);
            lbl_Password.TabIndex = 5;
            lbl_Password.Text = "label2";
            // 
            // btn_TestURL
            // 
            btn_TestURL.Location = new Point(584, 365);
            btn_TestURL.Name = "btn_TestURL";
            btn_TestURL.Size = new Size(94, 29);
            btn_TestURL.TabIndex = 6;
            btn_TestURL.Text = "button1";
            btn_TestURL.UseVisualStyleBackColor = true;
            btn_TestURL.Click += btn_TestURL_Click;
            // 
            // lbl_SSID
            // 
            lbl_SSID.AutoSize = true;
            lbl_SSID.Location = new Point(190, 327);
            lbl_SSID.Name = "lbl_SSID";
            lbl_SSID.Size = new Size(53, 20);
            lbl_SSID.TabIndex = 7;
            lbl_SSID.Text = "label1";
            // 
            // txt_SSID
            // 
            txt_SSID.Location = new Point(190, 350);
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
            // textBox1
            // 
            textBox1.Location = new Point(89, 418);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(691, 135);
            textBox1.TabIndex = 10;
            // 
            // ckb_LaunchOnBoot
            // 
            ckb_LaunchOnBoot.AutoSize = true;
            ckb_LaunchOnBoot.Location = new Point(569, 326);
            ckb_LaunchOnBoot.Name = "ckb_LaunchOnBoot";
            ckb_LaunchOnBoot.Size = new Size(109, 24);
            ckb_LaunchOnBoot.TabIndex = 11;
            ckb_LaunchOnBoot.Text = "checkBox1";
            ckb_LaunchOnBoot.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 565);
            Controls.Add(ckb_LaunchOnBoot);
            Controls.Add(textBox1);
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
            Load += Form1_Load;
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
        private TextBox textBox1;
        private CheckBox ckb_LaunchOnBoot;
    }
}
