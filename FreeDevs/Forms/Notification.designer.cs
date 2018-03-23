namespace FreeDevs
{
    partial class Notification
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
            this.lvDevs = new System.Windows.Forms.ListView();
            this.pbEstado = new System.Windows.Forms.PictureBox();
            this.lblLinea = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnEstado2 = new System.Windows.Forms.Button();
            this.btnEstado3 = new System.Windows.Forms.Button();
            this.btnEstado1 = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnAjustes = new System.Windows.Forms.PictureBox();
            this.txtTarea = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).BeginInit();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAjustes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDevs
            // 
            this.lvDevs.BackColor = System.Drawing.Color.Black;
            this.lvDevs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDevs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDevs.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lvDevs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDevs.Location = new System.Drawing.Point(9, 75);
            this.lvDevs.MultiSelect = false;
            this.lvDevs.Name = "lvDevs";
            this.lvDevs.Size = new System.Drawing.Size(257, 67);
            this.lvDevs.TabIndex = 3;
            this.lvDevs.UseCompatibleStateImageBehavior = false;
            this.lvDevs.SelectedIndexChanged += new System.EventHandler(this.Click_Cierre);
            // 
            // pbEstado
            // 
            this.pbEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEstado.Location = new System.Drawing.Point(7, 7);
            this.pbEstado.Name = "pbEstado";
            this.pbEstado.Size = new System.Drawing.Size(30, 28);
            this.pbEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEstado.TabIndex = 4;
            this.pbEstado.TabStop = false;
            this.pbEstado.Click += new System.EventHandler(this.Click_Cierre);
            // 
            // lblLinea
            // 
            this.lblLinea.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblLinea.Location = new System.Drawing.Point(9, 38);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(258, 2);
            this.lblLinea.TabIndex = 10;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNombre.Location = new System.Drawing.Point(40, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(159, 24);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Apellido";
            this.lblNombre.Click += new System.EventHandler(this.Click_Cierre);
            // 
            // btnEstado2
            // 
            this.btnEstado2.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEstado2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstado2.Location = new System.Drawing.Point(88, 2);
            this.btnEstado2.Name = "btnEstado2";
            this.btnEstado2.Size = new System.Drawing.Size(80, 65);
            this.btnEstado2.TabIndex = 7;
            this.btnEstado2.Text = "Disponible";
            this.btnEstado2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEstado2.UseVisualStyleBackColor = false;
            this.btnEstado2.Click += new System.EventHandler(this.btnEstados_Click);
            // 
            // btnEstado3
            // 
            this.btnEstado3.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEstado3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstado3.Location = new System.Drawing.Point(174, 2);
            this.btnEstado3.Name = "btnEstado3";
            this.btnEstado3.Size = new System.Drawing.Size(80, 65);
            this.btnEstado3.TabIndex = 8;
            this.btnEstado3.Text = "Ocupado";
            this.btnEstado3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEstado3.UseVisualStyleBackColor = false;
            this.btnEstado3.Click += new System.EventHandler(this.btnEstados_Click);
            // 
            // btnEstado1
            // 
            this.btnEstado1.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEstado1.Location = new System.Drawing.Point(2, 2);
            this.btnEstado1.Name = "btnEstado1";
            this.btnEstado1.Size = new System.Drawing.Size(80, 65);
            this.btnEstado1.TabIndex = 6;
            this.btnEstado1.Text = "Libre";
            this.btnEstado1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEstado1.UseVisualStyleBackColor = false;
            this.btnEstado1.Click += new System.EventHandler(this.btnEstados_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnEstado1);
            this.panelBotones.Controls.Add(this.btnEstado3);
            this.panelBotones.Controls.Add(this.btnEstado2);
            this.panelBotones.Location = new System.Drawing.Point(7, 185);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(259, 70);
            this.panelBotones.TabIndex = 9;
            // 
            // btnAjustes
            // 
            this.btnAjustes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAjustes.Location = new System.Drawing.Point(239, 7);
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.Size = new System.Drawing.Size(27, 26);
            this.btnAjustes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAjustes.TabIndex = 12;
            this.btnAjustes.TabStop = false;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);
            this.btnAjustes.MouseLeave += new System.EventHandler(this.btnAjustes_Leave);
            this.btnAjustes.MouseHover += new System.EventHandler(this.btnAjustes_Hover);
            // 
            // txtTarea
            // 
            this.txtTarea.BackColor = System.Drawing.Color.Black;
            this.txtTarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarea.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarea.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtTarea.Location = new System.Drawing.Point(35, 3);
            this.txtTarea.MaxLength = 30;
            this.txtTarea.Name = "txtTarea";
            this.txtTarea.Size = new System.Drawing.Size(221, 19);
            this.txtTarea.TabIndex = 14;
            this.txtTarea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.presionarEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.txtTarea);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(9, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 26);
            this.panel1.TabIndex = 15;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(275, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAjustes);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.pbEstado);
            this.Controls.Add(this.lvDevs);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Click_Cierre);
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).EndInit();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAjustes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvDevs;
        private System.Windows.Forms.PictureBox pbEstado;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnEstado2;
        private System.Windows.Forms.Button btnEstado3;
        private System.Windows.Forms.Button btnEstado1;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.PictureBox btnAjustes;
        private System.Windows.Forms.TextBox txtTarea;
        private System.Windows.Forms.Panel panel1;
    }
}