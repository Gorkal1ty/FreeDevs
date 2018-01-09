using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FreeDevs
{
    public partial class NotificationLauncher : Form
    {
        public static NotifyIcon icono = new NotifyIcon();
        public static List<Dev> listado = new List<Dev>();
        private ContextMenu menu = new ContextMenu();
        private Button btnTest;
        Dev[] devs = {
            new Dev(0, "Aitor Echezarraga", "Android"),
            new Dev(1, "Joseba Alonso", "DBS"),
            new Dev(0, "Gorka Barron", ".NET"),
            new Dev(1, "Alexander Peña", "Git"),
            new Dev(3, "Goizalde Machin", "BackOffice"),
            new Dev(3, "Daniel Crego", "BackOffice") };

        public NotificationLauncher()
        {
            InitializeComponent();
        }

        private void ShowNotification()
        {
            int duracion = 5;
            int velocidad = 250;
            var animacion = FormAnimator.AnimationMethod.Slide;
            var direccion = FormAnimator.AnimationDirection.Up;
            Color color = Color.Black;
            var opacidad = .80;
            listado = cargarListado();

            var notificacion = new Notification(listado, duracion, animacion, direccion, velocidad, color, opacidad);
            notificacion.Show();
        }

        private void NotificationLauncher_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            Text = "Icono Notificacion";

            //Icono
            icono.Icon = Properties.Resources.iconoVerde;
            icono.Text = "FreeDevs";
            icono.Visible = true;
            icono.Click += new EventHandler(iconoNotificacion_Click);

            //Menu Contextual > Click derecho
            MenuItem ajustes = new MenuItem("Ajustes", Ajustes_Click);
            MenuItem cerrar = new MenuItem("Cerrar FreeDevs", Cerrar_Click);
            menu.MenuItems.Add(ajustes);
            menu.MenuItems.Add(cerrar);
            icono.ContextMenu = menu;
        }

        private void iconoNotificacion_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (mouse.Button.Equals(MouseButtons.Left))
            {
                try
                {
                    ShowNotification();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la generación de la notificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Ajustes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ajustes");
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private List<Dev> cargarListado()
        {
            List<Dev> listado = new List<Dev>();

            //Concatenar Listado Devs (eliminar aquellos que estén ya ocupados)
            foreach (Dev dev in devs)
            {
                if (dev.Estado != 3)
                {
                    listado.Add(dev);
                }
            }

            //Ordenar por ocupación (Libres > Disponibles)
            listado.Sort(delegate (Dev x, Dev y)
            {
                return x.Estado.CompareTo(y.Estado);
            });

            return listado;
        }

        private void InitializeComponent()
        {
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(92, 101);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(112, 51);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // NotificationLauncher
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.NotificationLauncher_Load);
            this.ResumeLayout(false);

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ShowNotification();
        }
    }
}
