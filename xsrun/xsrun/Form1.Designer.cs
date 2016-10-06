namespace xsrun
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ftp_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ftp_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.putty_button = new System.Windows.Forms.Button();
            this.putty_input = new System.Windows.Forms.TextBox();
            this.web_button = new System.Windows.Forms.Button();
            this.web_input = new System.Windows.Forms.TextBox();
            this.naviocat_buitton = new System.Windows.Forms.Button();
            this.navicat_input = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitmenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // exitmenu
            // 
            this.exitmenu.Name = "exitmenu";
            this.exitmenu.Size = new System.Drawing.Size(100, 22);
            this.exitmenu.Text = "退出";
            this.exitmenu.Click += new System.EventHandler(this.exitmenu_Click);
            // 
            // ftp_input
            // 
            this.ftp_input.Location = new System.Drawing.Point(20, 52);
            this.ftp_input.Name = "ftp_input";
            this.ftp_input.Size = new System.Drawing.Size(281, 21);
            this.ftp_input.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flash Fxp";
            // 
            // ftp_button
            // 
            this.ftp_button.Location = new System.Drawing.Point(321, 52);
            this.ftp_button.Name = "ftp_button";
            this.ftp_button.Size = new System.Drawing.Size(75, 23);
            this.ftp_button.TabIndex = 3;
            this.ftp_button.Text = "选择";
            this.ftp_button.UseVisualStyleBackColor = true;
            this.ftp_button.Click += new System.EventHandler(this.ftp_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.putty_button);
            this.groupBox1.Controls.Add(this.putty_input);
            this.groupBox1.Controls.Add(this.web_button);
            this.groupBox1.Controls.Add(this.web_input);
            this.groupBox1.Controls.Add(this.naviocat_buitton);
            this.groupBox1.Controls.Add(this.navicat_input);
            this.groupBox1.Controls.Add(this.ftp_button);
            this.groupBox1.Controls.Add(this.ftp_input);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 269);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "程序执行设置";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "putty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "web";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Navicat Premium";
            // 
            // putty_button
            // 
            this.putty_button.Location = new System.Drawing.Point(321, 231);
            this.putty_button.Name = "putty_button";
            this.putty_button.Size = new System.Drawing.Size(75, 23);
            this.putty_button.TabIndex = 3;
            this.putty_button.Text = "选择";
            this.putty_button.UseVisualStyleBackColor = true;
            this.putty_button.Click += new System.EventHandler(this.putty_button_Click);
            // 
            // putty_input
            // 
            this.putty_input.Location = new System.Drawing.Point(20, 231);
            this.putty_input.Name = "putty_input";
            this.putty_input.Size = new System.Drawing.Size(281, 21);
            this.putty_input.TabIndex = 1;
            // 
            // web_button
            // 
            this.web_button.Location = new System.Drawing.Point(321, 170);
            this.web_button.Name = "web_button";
            this.web_button.Size = new System.Drawing.Size(75, 23);
            this.web_button.TabIndex = 3;
            this.web_button.Text = "选择";
            this.web_button.UseVisualStyleBackColor = true;
            this.web_button.Click += new System.EventHandler(this.web_button_Click);
            // 
            // web_input
            // 
            this.web_input.Location = new System.Drawing.Point(20, 170);
            this.web_input.Name = "web_input";
            this.web_input.Size = new System.Drawing.Size(281, 21);
            this.web_input.TabIndex = 1;
            // 
            // naviocat_buitton
            // 
            this.naviocat_buitton.Location = new System.Drawing.Point(321, 111);
            this.naviocat_buitton.Name = "naviocat_buitton";
            this.naviocat_buitton.Size = new System.Drawing.Size(75, 23);
            this.naviocat_buitton.TabIndex = 3;
            this.naviocat_buitton.Text = "选择";
            this.naviocat_buitton.UseVisualStyleBackColor = true;
            this.naviocat_buitton.Click += new System.EventHandler(this.naviocat_buitton_Click);
            // 
            // navicat_input
            // 
            this.navicat_input.Location = new System.Drawing.Point(20, 111);
            this.navicat_input.Name = "navicat_input";
            this.navicat_input.Size = new System.Drawing.Size(281, 21);
            this.navicat_input.TabIndex = 1;
            this.navicat_input.TextChanged += new System.EventHandler(this.navicat_input_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(42, 59);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(354, 24);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(42, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "navicat密码查询";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "站点";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "密码";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "IDC启动器";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitmenu;
        private System.Windows.Forms.TextBox ftp_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ftp_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button putty_button;
        private System.Windows.Forms.TextBox putty_input;
        private System.Windows.Forms.Button web_button;
        private System.Windows.Forms.TextBox web_input;
        private System.Windows.Forms.Button naviocat_buitton;
        private System.Windows.Forms.TextBox navicat_input;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

