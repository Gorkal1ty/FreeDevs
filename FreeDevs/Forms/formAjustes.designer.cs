namespace FreeDevs
{
    partial class formAjustes
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblConfOpacidad = new System.Windows.Forms.Label();
            this.sbOpacidad = new System.Windows.Forms.HScrollBar();
            this.gbConfMarco = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbConfEstado3 = new System.Windows.Forms.CheckBox();
            this.cbConfEstado2 = new System.Windows.Forms.CheckBox();
            this.cbConfEstado1 = new System.Windows.Forms.CheckBox();
            this.lblConfDuracion2 = new System.Windows.Forms.Label();
            this.txtConfDuracion = new System.Windows.Forms.NumericUpDown();
            this.cbConfVelocidad = new System.Windows.Forms.ComboBox();
            this.lblConfDuracion = new System.Windows.Forms.Label();
            this.lblConfVelocidad = new System.Windows.Forms.Label();
            this.btnConfGuardar = new System.Windows.Forms.Button();
            this.btnConfCancelar = new System.Windows.Forms.Button();
            this.gbConfMarco.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONFIGURACION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfOpacidad
            // 
            this.lblConfOpacidad.AutoSize = true;
            this.lblConfOpacidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfOpacidad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblConfOpacidad.Location = new System.Drawing.Point(6, 187);
            this.lblConfOpacidad.Name = "lblConfOpacidad";
            this.lblConfOpacidad.Size = new System.Drawing.Size(77, 18);
            this.lblConfOpacidad.TabIndex = 1;
            this.lblConfOpacidad.Text = "Opacidad";
            // 
            // sbOpacidad
            // 
            this.sbOpacidad.LargeChange = 1;
            this.sbOpacidad.Location = new System.Drawing.Point(88, 187);
            this.sbOpacidad.Maximum = 10;
            this.sbOpacidad.Minimum = 2;
            this.sbOpacidad.Name = "sbOpacidad";
            this.sbOpacidad.Size = new System.Drawing.Size(152, 20);
            this.sbOpacidad.TabIndex = 3;
            this.sbOpacidad.Value = 8;
            this.sbOpacidad.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbOpacidad_Scroll);
            // 
            // gbConfMarco
            // 
            this.gbConfMarco.BackColor = System.Drawing.Color.Transparent;
            this.gbConfMarco.Controls.Add(this.groupBox2);
            this.gbConfMarco.Controls.Add(this.lblConfDuracion2);
            this.gbConfMarco.Controls.Add(this.txtConfDuracion);
            this.gbConfMarco.Controls.Add(this.cbConfVelocidad);
            this.gbConfMarco.Controls.Add(this.lblConfDuracion);
            this.gbConfMarco.Controls.Add(this.lblConfVelocidad);
            this.gbConfMarco.Controls.Add(this.sbOpacidad);
            this.gbConfMarco.Controls.Add(this.lblConfOpacidad);
            this.gbConfMarco.Location = new System.Drawing.Point(12, 38);
            this.gbConfMarco.Name = "gbConfMarco";
            this.gbConfMarco.Size = new System.Drawing.Size(246, 226);
            this.gbConfMarco.TabIndex = 4;
            this.gbConfMarco.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbConfEstado3);
            this.groupBox2.Controls.Add(this.cbConfEstado2);
            this.groupBox2.Controls.Add(this.cbConfEstado1);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(9, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 94);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mostrar Desarrolladores";
            // 
            // cbConfEstado3
            // 
            this.cbConfEstado3.AutoSize = true;
            this.cbConfEstado3.Font = new System.Drawing.Font("Arial", 12F);
            this.cbConfEstado3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cbConfEstado3.Location = new System.Drawing.Point(26, 63);
            this.cbConfEstado3.Name = "cbConfEstado3";
            this.cbConfEstado3.Size = new System.Drawing.Size(99, 22);
            this.cbConfEstado3.TabIndex = 2;
            this.cbConfEstado3.Text = "Ocupados";
            this.cbConfEstado3.UseVisualStyleBackColor = true;
            // 
            // cbConfEstado2
            // 
            this.cbConfEstado2.AutoSize = true;
            this.cbConfEstado2.Font = new System.Drawing.Font("Arial", 12F);
            this.cbConfEstado2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cbConfEstado2.Location = new System.Drawing.Point(26, 44);
            this.cbConfEstado2.Name = "cbConfEstado2";
            this.cbConfEstado2.Size = new System.Drawing.Size(110, 22);
            this.cbConfEstado2.TabIndex = 1;
            this.cbConfEstado2.Text = "Disponibles";
            this.cbConfEstado2.UseVisualStyleBackColor = true;
            // 
            // cbConfEstado1
            // 
            this.cbConfEstado1.AutoSize = true;
            this.cbConfEstado1.Font = new System.Drawing.Font("Arial", 12F);
            this.cbConfEstado1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cbConfEstado1.Location = new System.Drawing.Point(26, 25);
            this.cbConfEstado1.Name = "cbConfEstado1";
            this.cbConfEstado1.Size = new System.Drawing.Size(71, 22);
            this.cbConfEstado1.TabIndex = 0;
            this.cbConfEstado1.Text = "Libres";
            this.cbConfEstado1.UseVisualStyleBackColor = true;
            // 
            // lblConfDuracion2
            // 
            this.lblConfDuracion2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfDuracion2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblConfDuracion2.Location = new System.Drawing.Point(163, 22);
            this.lblConfDuracion2.Name = "lblConfDuracion2";
            this.lblConfDuracion2.Size = new System.Drawing.Size(77, 18);
            this.lblConfDuracion2.TabIndex = 10;
            this.lblConfDuracion2.Text = "segundos";
            // 
            // txtConfDuracion
            // 
            this.txtConfDuracion.Font = new System.Drawing.Font("Arial", 12F);
            this.txtConfDuracion.Location = new System.Drawing.Point(89, 20);
            this.txtConfDuracion.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtConfDuracion.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtConfDuracion.Name = "txtConfDuracion";
            this.txtConfDuracion.ReadOnly = true;
            this.txtConfDuracion.Size = new System.Drawing.Size(68, 26);
            this.txtConfDuracion.TabIndex = 9;
            this.txtConfDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfDuracion.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cbConfVelocidad
            // 
            this.cbConfVelocidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConfVelocidad.Font = new System.Drawing.Font("Arial", 12F);
            this.cbConfVelocidad.FormattingEnabled = true;
            this.cbConfVelocidad.Location = new System.Drawing.Point(88, 51);
            this.cbConfVelocidad.Name = "cbConfVelocidad";
            this.cbConfVelocidad.Size = new System.Drawing.Size(152, 26);
            this.cbConfVelocidad.TabIndex = 7;
            // 
            // lblConfDuracion
            // 
            this.lblConfDuracion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfDuracion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblConfDuracion.Location = new System.Drawing.Point(6, 22);
            this.lblConfDuracion.Name = "lblConfDuracion";
            this.lblConfDuracion.Size = new System.Drawing.Size(77, 18);
            this.lblConfDuracion.TabIndex = 5;
            this.lblConfDuracion.Text = "Duracion";
            // 
            // lblConfVelocidad
            // 
            this.lblConfVelocidad.AutoSize = true;
            this.lblConfVelocidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfVelocidad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblConfVelocidad.Location = new System.Drawing.Point(5, 54);
            this.lblConfVelocidad.Name = "lblConfVelocidad";
            this.lblConfVelocidad.Size = new System.Drawing.Size(78, 18);
            this.lblConfVelocidad.TabIndex = 4;
            this.lblConfVelocidad.Text = "Velocidad";
            // 
            // btnConfGuardar
            // 
            this.btnConfGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfGuardar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfGuardar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConfGuardar.Location = new System.Drawing.Point(12, 270);
            this.btnConfGuardar.Name = "btnConfGuardar";
            this.btnConfGuardar.Size = new System.Drawing.Size(123, 65);
            this.btnConfGuardar.TabIndex = 7;
            this.btnConfGuardar.Text = "Guardar";
            this.btnConfGuardar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnConfGuardar.UseVisualStyleBackColor = false;
            this.btnConfGuardar.Click += new System.EventHandler(this.btnConfGuardar_Click_1);
            // 
            // btnConfCancelar
            // 
            this.btnConfCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConfCancelar.Location = new System.Drawing.Point(141, 270);
            this.btnConfCancelar.Name = "btnConfCancelar";
            this.btnConfCancelar.Size = new System.Drawing.Size(117, 65);
            this.btnConfCancelar.TabIndex = 8;
            this.btnConfCancelar.Text = "Cancelar";
            this.btnConfCancelar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnConfCancelar.UseVisualStyleBackColor = false;
            this.btnConfCancelar.Click += new System.EventHandler(this.btnConfCancelar_Click);
            // 
            // formAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(270, 348);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfCancelar);
            this.Controls.Add(this.btnConfGuardar);
            this.Controls.Add(this.gbConfMarco);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAjustes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.gbConfMarco.ResumeLayout(false);
            this.gbConfMarco.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfDuracion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConfOpacidad;
        private System.Windows.Forms.HScrollBar sbOpacidad;
        private System.Windows.Forms.GroupBox gbConfMarco;
        private System.Windows.Forms.ComboBox cbConfVelocidad;
        private System.Windows.Forms.Label lblConfDuracion;
        private System.Windows.Forms.Label lblConfVelocidad;
        private System.Windows.Forms.NumericUpDown txtConfDuracion;
        private System.Windows.Forms.Label lblConfDuracion2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbConfEstado3;
        private System.Windows.Forms.CheckBox cbConfEstado2;
        private System.Windows.Forms.CheckBox cbConfEstado1;
        private System.Windows.Forms.Button btnConfGuardar;
        private System.Windows.Forms.Button btnConfCancelar;
    }
}