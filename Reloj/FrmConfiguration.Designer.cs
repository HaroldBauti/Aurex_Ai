namespace Aurex
{
    partial class FrmConfiguration
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
            this.components = new System.ComponentModel.Container();
            this.cbxGender = new System.Windows.Forms.ComboBox();
            this.txtPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.cbxVoiceAssistant = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBattery = new System.Windows.Forms.NumericUpDown();
            this.txtAssistantName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnClosed = new FontAwesome.Sharp.IconButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtZipCode = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtCity = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPort = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBattery)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxGender
            // 
            this.cbxGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.cbxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGender.FormattingEnabled = true;
            this.cbxGender.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbxGender.Location = new System.Drawing.Point(295, 20);
            this.cbxGender.Name = "cbxGender";
            this.cbxGender.Size = new System.Drawing.Size(145, 21);
            this.cbxGender.TabIndex = 3;
            this.cbxGender.SelectedIndexChanged += new System.EventHandler(this.cbxGender_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.HintForeColor = System.Drawing.Color.Cyan;
            this.txtPassword.HintText = "Contraseña correo";
            this.txtPassword.isPassword = false;
            this.txtPassword.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPassword.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPassword.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPassword.LineThickness = 3;
            this.txtPassword.Location = new System.Drawing.Point(12, 60);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(203, 33);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.HintForeColor = System.Drawing.Color.Cyan;
            this.txtEmail.HintText = "Correo@gmail.com";
            this.txtEmail.isPassword = false;
            this.txtEmail.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.txtEmail.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtEmail.LineThickness = 3;
            this.txtEmail.Location = new System.Drawing.Point(12, 101);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(256, 33);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cbxVoiceAssistant
            // 
            this.cbxVoiceAssistant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVoiceAssistant.FormattingEnabled = true;
            this.cbxVoiceAssistant.Location = new System.Drawing.Point(330, 42);
            this.cbxVoiceAssistant.Name = "cbxVoiceAssistant";
            this.cbxVoiceAssistant.Size = new System.Drawing.Size(121, 24);
            this.cbxVoiceAssistant.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.groupBox2.Controls.Add(this.cbxVoiceAssistant);
            this.groupBox2.Controls.Add(this.txtBattery);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAssistantName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox2.Location = new System.Drawing.Point(27, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración Asistente";
            // 
            // txtBattery
            // 
            this.txtBattery.Location = new System.Drawing.Point(224, 43);
            this.txtBattery.Name = "txtBattery";
            this.txtBattery.Size = new System.Drawing.Size(81, 22);
            this.txtBattery.TabIndex = 5;
            this.txtBattery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBattery.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtAssistantName
            // 
            this.txtAssistantName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAssistantName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAssistantName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAssistantName.HintForeColor = System.Drawing.Color.Cyan;
            this.txtAssistantName.HintText = "Nombre Asistente";
            this.txtAssistantName.isPassword = false;
            this.txtAssistantName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtAssistantName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAssistantName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtAssistantName.LineThickness = 3;
            this.txtAssistantName.Location = new System.Drawing.Point(7, 33);
            this.txtAssistantName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAssistantName.Name = "txtAssistantName";
            this.txtAssistantName.Size = new System.Drawing.Size(203, 33);
            this.txtAssistantName.TabIndex = 4;
            this.txtAssistantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClosed.FlatAppearance.BorderSize = 0;
            this.btnClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosed.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            this.btnClosed.IconColor = System.Drawing.Color.Red;
            this.btnClosed.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClosed.IconSize = 38;
            this.btnClosed.Location = new System.Drawing.Point(799, 0);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(43, 35);
            this.btnClosed.TabIndex = 6;
            this.btnClosed.UseVisualStyleBackColor = false;
            this.btnClosed.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.groupBox3.Controls.Add(this.txtZipCode);
            this.groupBox3.Controls.Add(this.txtCity);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox3.Location = new System.Drawing.Point(495, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 148);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuración del clima";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtZipCode.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtZipCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtZipCode.HintForeColor = System.Drawing.Color.Cyan;
            this.txtZipCode.HintText = "Codigo Postal";
            this.txtZipCode.isPassword = false;
            this.txtZipCode.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtZipCode.LineIdleColor = System.Drawing.Color.Gray;
            this.txtZipCode.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtZipCode.LineThickness = 3;
            this.txtZipCode.Location = new System.Drawing.Point(7, 84);
            this.txtZipCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(203, 33);
            this.txtZipCode.TabIndex = 8;
            this.txtZipCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtCity
            // 
            this.txtCity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCity.HintForeColor = System.Drawing.Color.Cyan;
            this.txtCity.HintText = "Ciudad";
            this.txtCity.isPassword = false;
            this.txtCity.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtCity.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCity.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtCity.LineThickness = 3;
            this.txtCity.Location = new System.Drawing.Point(7, 30);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(203, 33);
            this.txtCity.TabIndex = 7;
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.groupBox4.Controls.Add(this.txtPort);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Cyan;
            this.groupBox4.Location = new System.Drawing.Point(502, 226);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 74);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuración Bluetooth";
            // 
            // txtPort
            // 
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPort.HintForeColor = System.Drawing.Color.Cyan;
            this.txtPort.HintText = "Puerto COM5";
            this.txtPort.isPassword = false;
            this.txtPort.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPort.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPort.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPort.LineThickness = 3;
            this.txtPort.Location = new System.Drawing.Point(7, 21);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(153, 33);
            this.txtPort.TabIndex = 9;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSave.ForeColor = System.Drawing.Color.Cyan;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnSave.IconColor = System.Drawing.Color.White;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 38;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(374, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.HintForeColor = System.Drawing.Color.Cyan;
            this.txtName.HintText = "Nombre";
            this.txtName.isPassword = false;
            this.txtName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtName.LineThickness = 3;
            this.txtName.Location = new System.Drawing.Point(12, 8);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 33);
            this.txtName.TabIndex = 0;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(60)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.cbxGender);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.ForeColor = System.Drawing.Color.DarkCyan;
            this.panel1.Location = new System.Drawing.Point(27, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 148);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(870, 42);
            this.label4.TabIndex = 78;
            this.label4.Text = "Configuración";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(217, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 53);
            this.label1.TabIndex = 79;
            this.label1.Text = "Alerta Bateria";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(323, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 53);
            this.label2.TabIndex = 80;
            this.label2.Text = "Voz Asistente";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(26)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(870, 363);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConfiguration";
            this.Text = "Aurex";
            this.Load += new System.EventHandler(this.FrmConfiguration_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBattery)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxGender;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPassword;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
        private System.Windows.Forms.ComboBox cbxVoiceAssistant;
        private System.Windows.Forms.GroupBox groupBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAssistantName;
        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton btnClosed;
        private System.Windows.Forms.NumericUpDown txtBattery;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtZipCode;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCity;
        private System.Windows.Forms.GroupBox groupBox4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPort;
        private FontAwesome.Sharp.IconButton btnSave;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}