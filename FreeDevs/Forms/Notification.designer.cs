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
            this.components = new System.ComponentModel.Container();
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.lvDevs = new System.Windows.Forms.ListView();
            this.pbEstado = new System.Windows.Forms.PictureBox();
            this.btnEstado2 = new System.Windows.Forms.Button();
            this.btnEstado1 = new System.Windows.Forms.Button();
            this.btnEstado3 = new System.Windows.Forms.Button();
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.lblLinea = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).BeginInit();
            this.gbEstados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.Click_Cierre);
            // 
            // lvDevs
            // 
            this.lvDevs.BackColor = System.Drawing.Color.Black;
            this.lvDevs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDevs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDevs.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lvDevs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDevs.Location = new System.Drawing.Point(12, 48);
            this.lvDevs.MultiSelect = false;
            this.lvDevs.Name = "lvDevs";
            this.lvDevs.Size = new System.Drawing.Size(226, 67);
            this.lvDevs.TabIndex = 3;
            this.lvDevs.UseCompatibleStateImageBehavior = false;
            this.lvDevs.SelectedIndexChanged += new System.EventHandler(this.lvDevs_SelectedIndexChanged);
            // 
            // pbEstado
            // 
            this.pbEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEstado.Location = new System.Drawing.Point(12, 7);
            this.pbEstado.Name = "pbEstado";
            this.pbEstado.Size = new System.Drawing.Size(27, 26);
            this.pbEstado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEstado.TabIndex = 4;
            this.pbEstado.TabStop = false;
            this.pbEstado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Click_Cierre);
            // 
            // btnEstado2
            // 
            this.btnEstado2.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado2.ForeColor = System.Drawing.Color.Black;
            this.btnEstado2.Location = new System.Drawing.Point(85, 25);
            this.btnEstado2.Name = "btnEstado2";
            this.btnEstado2.Size = new System.Drawing.Size(55, 50);
            this.btnEstado2.TabIndex = 7;
            this.btnEstado2.UseVisualStyleBackColor = false;
            this.btnEstado2.Click += new System.EventHandler(this.btnEstados_Click);
            this.btnEstado2.MouseHover += new System.EventHandler(this.btnEstado2_Hover);
            // 
            // btnEstado1
            // 
            this.btnEstado1.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado1.ForeColor = System.Drawing.Color.Black;
            this.btnEstado1.Location = new System.Drawing.Point(24, 25);
            this.btnEstado1.Name = "btnEstado1";
            this.btnEstado1.Size = new System.Drawing.Size(55, 50);
            this.btnEstado1.TabIndex = 6;
            this.btnEstado1.UseVisualStyleBackColor = false;
            this.btnEstado1.Click += new System.EventHandler(this.btnEstados_Click);
            this.btnEstado1.MouseHover += new System.EventHandler(this.btnEstado1_Hover);
            // 
            // btnEstado3
            // 
            this.btnEstado3.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEstado3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado3.ForeColor = System.Drawing.Color.Black;
            this.btnEstado3.Location = new System.Drawing.Point(146, 25);
            this.btnEstado3.Name = "btnEstado3";
            this.btnEstado3.Size = new System.Drawing.Size(55, 50);
            this.btnEstado3.TabIndex = 8;
            this.btnEstado3.UseVisualStyleBackColor = false;
            this.btnEstado3.Click += new System.EventHandler(this.btnEstados_Click);
            this.btnEstado3.MouseHover += new System.EventHandler(this.btnEstado3_Hover);
            // 
            // gbEstados
            // 
            this.gbEstados.Controls.Add(this.btnEstado1);
            this.gbEstados.Controls.Add(this.btnEstado3);
            this.gbEstados.Controls.Add(this.btnEstado2);
            this.gbEstados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstados.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.gbEstados.Location = new System.Drawing.Point(12, 121);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(226, 86);
            this.gbEstados.TabIndex = 9;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Mi Estado";
            // 
            // lblLinea
            // 
            this.lblLinea.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblLinea.Location = new System.Drawing.Point(9, 38);
            this.lblLinea.Name = "lblLinea";
            this.lblLinea.Size = new System.Drawing.Size(230, 2);
            this.lblLinea.TabIndex = 10;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblNombre.Location = new System.Drawing.Point(45, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(136, 23);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre Apellido";
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 219);
            this.ControlBox = false;
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblLinea);
            this.Controls.Add(this.gbEstados);
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
            this.gbEstados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.ListView lvDevs;
        private System.Windows.Forms.PictureBox pbEstado;
        private System.Windows.Forms.Button btnEstado2;
        private System.Windows.Forms.Button btnEstado1;
        private System.Windows.Forms.Button btnEstado3;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.Label lblLinea;
        private System.Windows.Forms.Label lblNombre;
    }
}