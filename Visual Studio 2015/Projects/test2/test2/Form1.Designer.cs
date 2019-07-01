namespace test2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msgBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portName_cmbbx = new System.Windows.Forms.ComboBox();
            this.baudRate_cmbbx = new System.Windows.Forms.ComboBox();
            this.motor1 = new System.Windows.Forms.Button();
            this.motor2 = new System.Windows.Forms.Button();
            this.motor3 = new System.Windows.Forms.Button();
            this.openPort_btn = new System.Windows.Forms.Button();
            this.closePort_btn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.setAll_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.motor0 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.invertAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.Enabled = false;
            this.msgBox.Location = new System.Drawing.Point(12, 152);
            this.msgBox.Multiline = true;
            this.msgBox.Name = "msgBox";
            this.msgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msgBox.Size = new System.Drawing.Size(547, 210);
            this.msgBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message Box";
            // 
            // portName_cmbbx
            // 
            this.portName_cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portName_cmbbx.FormattingEnabled = true;
            this.portName_cmbbx.Location = new System.Drawing.Point(12, 23);
            this.portName_cmbbx.Name = "portName_cmbbx";
            this.portName_cmbbx.Size = new System.Drawing.Size(121, 21);
            this.portName_cmbbx.TabIndex = 6;
            // 
            // baudRate_cmbbx
            // 
            this.baudRate_cmbbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRate_cmbbx.FormattingEnabled = true;
            this.baudRate_cmbbx.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.baudRate_cmbbx.Location = new System.Drawing.Point(149, 22);
            this.baudRate_cmbbx.Name = "baudRate_cmbbx";
            this.baudRate_cmbbx.Size = new System.Drawing.Size(121, 21);
            this.baudRate_cmbbx.TabIndex = 7;
            // 
            // motor1
            // 
            this.motor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motor1.Location = new System.Drawing.Point(79, 19);
            this.motor1.Name = "motor1";
            this.motor1.Size = new System.Drawing.Size(60, 60);
            this.motor1.TabIndex = 9;
            this.motor1.Text = "0";
            this.motor1.UseVisualStyleBackColor = true;
            this.motor1.Click += new System.EventHandler(this.motorButton_Click);
            // 
            // motor2
            // 
            this.motor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motor2.Location = new System.Drawing.Point(145, 19);
            this.motor2.Name = "motor2";
            this.motor2.Size = new System.Drawing.Size(60, 60);
            this.motor2.TabIndex = 10;
            this.motor2.Text = "0";
            this.motor2.UseVisualStyleBackColor = true;
            this.motor2.Click += new System.EventHandler(this.motorButton_Click);
            // 
            // motor3
            // 
            this.motor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motor3.Location = new System.Drawing.Point(211, 19);
            this.motor3.Name = "motor3";
            this.motor3.Size = new System.Drawing.Size(60, 60);
            this.motor3.TabIndex = 11;
            this.motor3.Text = "0";
            this.motor3.UseVisualStyleBackColor = true;
            this.motor3.Click += new System.EventHandler(this.motorButton_Click);
            // 
            // openPort_btn
            // 
            this.openPort_btn.Location = new System.Drawing.Point(281, 22);
            this.openPort_btn.Name = "openPort_btn";
            this.openPort_btn.Size = new System.Drawing.Size(75, 23);
            this.openPort_btn.TabIndex = 16;
            this.openPort_btn.Text = "Open Port";
            this.openPort_btn.UseVisualStyleBackColor = true;
            this.openPort_btn.Click += new System.EventHandler(this.openPort_btn_Click);
            // 
            // closePort_btn
            // 
            this.closePort_btn.Enabled = false;
            this.closePort_btn.Location = new System.Drawing.Point(363, 21);
            this.closePort_btn.Name = "closePort_btn";
            this.closePort_btn.Size = new System.Drawing.Size(75, 23);
            this.closePort_btn.TabIndex = 17;
            this.closePort_btn.Text = "Close Port";
            this.closePort_btn.UseVisualStyleBackColor = true;
            this.closePort_btn.Click += new System.EventHandler(this.closePort_btn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 368);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(304, 31);
            this.progressBar1.TabIndex = 18;
            // 
            // setAll_btn
            // 
            this.setAll_btn.Enabled = false;
            this.setAll_btn.Location = new System.Drawing.Point(322, 368);
            this.setAll_btn.Name = "setAll_btn";
            this.setAll_btn.Size = new System.Drawing.Size(75, 23);
            this.setAll_btn.TabIndex = 19;
            this.setAll_btn.Text = "Set All";
            this.setAll_btn.UseVisualStyleBackColor = true;
            this.setAll_btn.Click += new System.EventHandler(this.setAll_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Enabled = false;
            this.reset_btn.Location = new System.Drawing.Point(403, 368);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(75, 23);
            this.reset_btn.TabIndex = 20;
            this.reset_btn.Text = "Reset All";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Enabled = false;
            this.save_btn.Location = new System.Drawing.Point(444, 21);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 21;
            this.save_btn.Text = "Save data";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // motor0
            // 
            this.motor0.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motor0.Location = new System.Drawing.Point(13, 18);
            this.motor0.Name = "motor0";
            this.motor0.Size = new System.Drawing.Size(60, 60);
            this.motor0.TabIndex = 8;
            this.motor0.Text = "0";
            this.motor0.UseVisualStyleBackColor = true;
            this.motor0.Click += new System.EventHandler(this.motorButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.motor0);
            this.groupBox1.Controls.Add(this.motor1);
            this.groupBox1.Controls.Add(this.motor2);
            this.groupBox1.Controls.Add(this.motor3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 82);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // invertAll
            // 
            this.invertAll.Enabled = false;
            this.invertAll.Location = new System.Drawing.Point(484, 368);
            this.invertAll.Name = "invertAll";
            this.invertAll.Size = new System.Drawing.Size(75, 23);
            this.invertAll.TabIndex = 23;
            this.invertAll.Text = "Invert All";
            this.invertAll.UseVisualStyleBackColor = true;
            this.invertAll.Click += new System.EventHandler(this.invertAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 414);
            this.Controls.Add(this.invertAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.setAll_btn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.closePort_btn);
            this.Controls.Add(this.openPort_btn);
            this.Controls.Add(this.baudRate_cmbbx);
            this.Controls.Add(this.portName_cmbbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msgBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox portName_cmbbx;
        private System.Windows.Forms.ComboBox baudRate_cmbbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox msgBox;
        private System.Windows.Forms.Button motor1;
        private System.Windows.Forms.Button motor2;
        private System.Windows.Forms.Button motor3;
        private System.Windows.Forms.Button openPort_btn;
        private System.Windows.Forms.Button closePort_btn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button setAll_btn;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button motor0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button invertAll;
    }
}

