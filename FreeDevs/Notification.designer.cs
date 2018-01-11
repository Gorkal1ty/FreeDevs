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
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.lvDevs = new System.Windows.Forms.ListView();
            this.pbEstado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.Click_Cierre);
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.Color.Black;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.ForeColor = System.Drawing.SystemColors.Window;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(71, 7);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(185, 27);
            this.cbEstado.TabIndex = 2;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            this.cbEstado.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbEstado_Clicked);
            // 
            // lvDevs
            // 
            this.lvDevs.BackColor = System.Drawing.Color.Black;
            this.lvDevs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDevs.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDevs.ForeColor = System.Drawing.SystemColors.Window;
            this.lvDevs.Location = new System.Drawing.Point(12, 48);
            this.lvDevs.Name = "lvDevs";
            this.lvDevs.Size = new System.Drawing.Size(244, 67);
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
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(268, 132);
            this.ControlBox = false;
            this.Controls.Add(this.pbEstado);
            this.Controls.Add(this.lvDevs);
            this.Controls.Add(this.cbEstado);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EDGE Shop Flag Notification";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Click_Cierre);
            ((System.ComponentModel.ISupportInitialize)(this.pbEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ListView lvDevs;
        private System.Windows.Forms.PictureBox pbEstado;
    }
}