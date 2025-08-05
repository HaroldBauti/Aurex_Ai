namespace Aurex
{
    partial class FrmHome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblLunes = new System.Windows.Forms.Label();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.picicono = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblViernes = new System.Windows.Forms.Label();
            this.lblJueves = new System.Windows.Forms.Label();
            this.lblMiercoles = new System.Windows.Forms.Label();
            this.lblMartes = new System.Windows.Forms.Label();
            this.lblSabado = new System.Windows.Forms.Label();
            this.lblDomingo = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnConfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.btnIA = new FontAwesome.Sharp.IconMenuItem();
            this.btnSalir = new FontAwesome.Sharp.IconMenuItem();
            this.BatteryControl = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnBluetooth = new FontAwesome.Sharp.IconButton();
            this.btnCommands = new FontAwesome.Sharp.IconMenuItem();
            this.btnEmail = new FontAwesome.Sharp.IconMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picicono)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cyan;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "12:12";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.label2.Location = new System.Drawing.Point(107, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = ":12AM";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 100;
            this.bunifuElipse1.TargetControl = this;
            // 
            // lblLunes
            // 
            this.lblLunes.AutoSize = true;
            this.lblLunes.BackColor = System.Drawing.Color.Transparent;
            this.lblLunes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunes.ForeColor = System.Drawing.Color.Cyan;
            this.lblLunes.Location = new System.Drawing.Point(173, 12);
            this.lblLunes.Name = "lblLunes";
            this.lblLunes.Size = new System.Drawing.Size(35, 15);
            this.lblLunes.TabIndex = 2;
            this.lblLunes.Text = "Lun.";
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.label4.Location = new System.Drawing.Point(94, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "HBA";
            // 
            // picicono
            // 
            this.picicono.BackColor = System.Drawing.Color.Transparent;
            this.picicono.Location = new System.Drawing.Point(16, 37);
            this.picicono.Name = "picicono";
            this.picicono.Size = new System.Drawing.Size(50, 50);
            this.picicono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picicono.TabIndex = 20;
            this.picicono.TabStop = false;
            this.picicono.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(13, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "label5";
            // 
            // lblViernes
            // 
            this.lblViernes.AutoSize = true;
            this.lblViernes.BackColor = System.Drawing.Color.Transparent;
            this.lblViernes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViernes.ForeColor = System.Drawing.Color.Cyan;
            this.lblViernes.Location = new System.Drawing.Point(173, 64);
            this.lblViernes.Name = "lblViernes";
            this.lblViernes.Size = new System.Drawing.Size(35, 15);
            this.lblViernes.TabIndex = 22;
            this.lblViernes.Text = "Vie.";
            // 
            // lblJueves
            // 
            this.lblJueves.AutoSize = true;
            this.lblJueves.BackColor = System.Drawing.Color.Transparent;
            this.lblJueves.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJueves.ForeColor = System.Drawing.Color.Cyan;
            this.lblJueves.Location = new System.Drawing.Point(173, 51);
            this.lblJueves.Name = "lblJueves";
            this.lblJueves.Size = new System.Drawing.Size(35, 15);
            this.lblJueves.TabIndex = 23;
            this.lblJueves.Text = "Jue.";
            // 
            // lblMiercoles
            // 
            this.lblMiercoles.AutoSize = true;
            this.lblMiercoles.BackColor = System.Drawing.Color.Transparent;
            this.lblMiercoles.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiercoles.ForeColor = System.Drawing.Color.Cyan;
            this.lblMiercoles.Location = new System.Drawing.Point(173, 38);
            this.lblMiercoles.Name = "lblMiercoles";
            this.lblMiercoles.Size = new System.Drawing.Size(35, 15);
            this.lblMiercoles.TabIndex = 24;
            this.lblMiercoles.Text = "Mie.";
            // 
            // lblMartes
            // 
            this.lblMartes.AutoSize = true;
            this.lblMartes.BackColor = System.Drawing.Color.Transparent;
            this.lblMartes.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMartes.ForeColor = System.Drawing.Color.Cyan;
            this.lblMartes.Location = new System.Drawing.Point(173, 25);
            this.lblMartes.Name = "lblMartes";
            this.lblMartes.Size = new System.Drawing.Size(35, 15);
            this.lblMartes.TabIndex = 25;
            this.lblMartes.Text = "Mar.";
            // 
            // lblSabado
            // 
            this.lblSabado.AutoSize = true;
            this.lblSabado.BackColor = System.Drawing.Color.Transparent;
            this.lblSabado.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSabado.ForeColor = System.Drawing.Color.Cyan;
            this.lblSabado.Location = new System.Drawing.Point(173, 77);
            this.lblSabado.Name = "lblSabado";
            this.lblSabado.Size = new System.Drawing.Size(35, 15);
            this.lblSabado.TabIndex = 26;
            this.lblSabado.Text = "Sab.";
            // 
            // lblDomingo
            // 
            this.lblDomingo.AutoSize = true;
            this.lblDomingo.BackColor = System.Drawing.Color.Transparent;
            this.lblDomingo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomingo.ForeColor = System.Drawing.Color.Cyan;
            this.lblDomingo.Location = new System.Drawing.Point(173, 90);
            this.lblDomingo.Name = "lblDomingo";
            this.lblDomingo.Size = new System.Drawing.Size(35, 15);
            this.lblDomingo.TabIndex = 27;
            this.lblDomingo.Text = "Dom.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfiguracion,
            this.btnCommands,
            this.btnEmail,
            this.btnIA,
            this.btnSalir});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 156);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Cyan;
            this.btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnConfiguracion.IconColor = System.Drawing.Color.Blue;
            this.btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(184, 26);
            this.btnConfiguracion.Text = "Configuracion";
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnIA
            // 
            this.btnIA.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnIA.ForeColor = System.Drawing.Color.Cyan;
            this.btnIA.IconChar = FontAwesome.Sharp.IconChar.Microchip;
            this.btnIA.IconColor = System.Drawing.Color.Blue;
            this.btnIA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIA.Name = "btnIA";
            this.btnIA.Size = new System.Drawing.Size(184, 26);
            this.btnIA.Text = "IA";
            this.btnIA.Click += new System.EventHandler(this.btnIA_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnSalir.ForeColor = System.Drawing.Color.Cyan;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            this.btnSalir.IconColor = System.Drawing.Color.Blue;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(184, 26);
            this.btnSalir.Text = "Salir";
            // 
            // BatteryControl
            // 
            this.BatteryControl.Enabled = true;
            this.BatteryControl.Tick += new System.EventHandler(this.BatteryControl_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // btnBluetooth
            // 
            this.btnBluetooth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(16)))), ((int)(((byte)(21)))));
            this.btnBluetooth.FlatAppearance.BorderSize = 0;
            this.btnBluetooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBluetooth.IconChar = FontAwesome.Sharp.IconChar.Bluetooth;
            this.btnBluetooth.IconColor = System.Drawing.Color.Red;
            this.btnBluetooth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBluetooth.IconSize = 25;
            this.btnBluetooth.Location = new System.Drawing.Point(204, 38);
            this.btnBluetooth.Name = "btnBluetooth";
            this.btnBluetooth.Size = new System.Drawing.Size(32, 30);
            this.btnBluetooth.TabIndex = 28;
            this.btnBluetooth.UseVisualStyleBackColor = false;
            this.btnBluetooth.Click += new System.EventHandler(this.btnBluetooth_Click);
            this.btnBluetooth.MouseEnter += new System.EventHandler(this.btnBluetooth_MouseEnter);
            // 
            // btnCommands
            // 
            this.btnCommands.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCommands.IconColor = System.Drawing.Color.Black;
            this.btnCommands.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCommands.Name = "btnCommands";
            this.btnCommands.Size = new System.Drawing.Size(184, 26);
            this.btnCommands.Text = "Comandos";
            this.btnCommands.Click += new System.EventHandler(this.btnCommands_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEmail.IconColor = System.Drawing.Color.Black;
            this.btnEmail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(184, 26);
            this.btnEmail.Text = "Correo";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.BackgroundImage = global::Aurex.Properties.Resources.Aurex_ai;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(242, 200);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btnBluetooth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDomingo);
            this.Controls.Add(this.lblSabado);
            this.Controls.Add(this.lblMartes);
            this.Controls.Add(this.lblMiercoles);
            this.Controls.Add(this.lblJueves);
            this.Controls.Add(this.lblViernes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLunes);
            this.Controls.Add(this.picicono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picicono)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lblLunes;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picicono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDomingo;
        private System.Windows.Forms.Label lblSabado;
        private System.Windows.Forms.Label lblMartes;
        private System.Windows.Forms.Label lblMiercoles;
        private System.Windows.Forms.Label lblJueves;
        private System.Windows.Forms.Label lblViernes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnConfiguracion;
        private FontAwesome.Sharp.IconMenuItem btnIA;
        private FontAwesome.Sharp.IconMenuItem btnSalir;
        private System.Windows.Forms.Timer BatteryControl;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private FontAwesome.Sharp.IconButton btnBluetooth;
        private FontAwesome.Sharp.IconMenuItem btnCommands;
        private FontAwesome.Sharp.IconMenuItem btnEmail;
    }
}

