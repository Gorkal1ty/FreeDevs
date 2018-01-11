using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FreeDevs
{
    public partial class NotificationLauncher : Form
    {
        //Info Ficticia
        Dev[] devs = {
            new Dev(0, "Aitor Echezarraga", "Android"),
            new Dev(1, "Joseba Alonso", "DBS"),
            new Dev(0, "Gorka Barron", ".NET"),
            new Dev(1, "Alexander Peña", "Git"),
            new Dev(3, "Goizalde Machin", "BackOffice"),
            new Dev(3, "Daniel Crego", "BackOffice") };

        //Variables Globales
        public Notification notificacion = null;
        public static NotifyIcon icono = new NotifyIcon();
        public static List<Dev> listado = new List<Dev>();
        private ContextMenu menu = new ContextMenu();

        //Parametros


        public NotificationLauncher()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            WindowState = FormWindowState.Minimized;
            Load += new EventHandler(NotificationLauncher_Load);
        }

        private void NotificationLauncher_Load(object sender, EventArgs e)
        {
            Hide();
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

        //Eventos
        private void iconoNotificacion_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (mouse.Button.Equals(MouseButtons.Left))
            {
                if (notificacion == null || !notificacion.lifeTimer.Enabled)
                    mostrarNotificacion();
                else if (notificacion != null)
                    notificacion.Close();
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

        //Metodos
        private void mostrarNotificacion()
        {
            try
            {
                int duracion = 5;
                int velocidad = 250;
                var animacion = FormAnimator.AnimationMethod.Slide;
                var direccion = FormAnimator.AnimationDirection.Up;
                Color color = Color.Black;
                var opacidad = .80;
                listado = cargarListado();

                notificacion = new Notification(listado, duracion, animacion, direccion, velocidad, color, opacidad);
                notificacion.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la generación de la notificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
