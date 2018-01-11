using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FreeDevs
{
    public partial class formInicio : Form
    {
        //Info Ficticia
        Dev[] devs = {
            new Dev(0, "Aitor Echezarraga"),
            new Dev(1, "Joseba Alonso"),
            new Dev(0, "Gorka Barron"),
            new Dev(1, "Alexander Peña"),
            new Dev(3, "Goizalde Machin"),
            new Dev(3, "Daniel Crego") };

        //Variables Globales
        public Notification notificacion = null;
        public static NotifyIcon icono = new NotifyIcon();
        public static List<Dev> listado = new List<Dev>();
        private ContextMenu menu = new ContextMenu();

        //Parametros accesibles desde app y fichero configuracion
        public int duracion = Properties.Settings.Default.Duracion;
        public int velocidad = Properties.Settings.Default.Velocidad;
        public float opacidad = Properties.Settings.Default.Opacidad;

        public formInicio()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            WindowState = FormWindowState.Minimized;
            Load += new EventHandler(formInicio_Load);
            ResumeLayout(false);
        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            Hide();

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

        #region Eventos

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
            formAjustes ajustes = new formAjustes();
            ajustes.Show();
        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Metodos

        private void mostrarNotificacion()
        {
            try
            {
                //Actualizar el listado
                listado = cargarListado();
                //Generar la notificacion
                notificacion = new Notification(listado, duracion, velocidad, opacidad);
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

        #endregion
    }
}
