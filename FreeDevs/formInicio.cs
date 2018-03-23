using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FreeDevs.Clases;
using FreeDevs.Controlador;

namespace FreeDevs
{
    public partial class formInicio : Form
    {
        //Conexión BBDD
        private static ConexionSQL conexion = new ConexionSQL(Endpoints.SERVIDOR, Endpoints.BD, Endpoints.USUARIO, Endpoints.PASS);

        //Variables Globales
        public Notification notificacion = null;
        public formAjustes ajustes = null;
        public static int estado = Constantes.ESTADO_OCUPADO;
        public static string tarea = "";
        public static NotifyIcon icono = new NotifyIcon();
        private static List<Dev> devs = new List<Dev>();
        public static List<Dev> listado = new List<Dev>();
        private ContextMenu menu = new ContextMenu();

        //Parametros accesibles desde app y fichero configuracion
        public static string usuario = Properties.Settings.Default.Usuario;
        public static int velocidad = Properties.Settings.Default.Velocidad;
        public static int opacidad = Properties.Settings.Default.Opacidad;
        public static string visualizacion = Properties.Settings.Default.Visualizacion;

        internal static ConexionSQL Conexion { get => conexion; set => conexion = value; }

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

            //Carga Inicial
            cargarEmpleados();

            //Icono
            icono.Text = "FreeDevs";
            icono.Visible = true;
            icono.Click += new EventHandler(iconoNotificacion_Click);
            icono.Icon = obtenerIcono(usuario);

            //Tarea
            tarea = obtenerTarea(usuario);

            //Menu Contextual > Click derecho
            MenuItem mostrar = new MenuItem("Mostrar", Mostrar_Click);
            MenuItem ajustes = new MenuItem("Ajustes", Ajustes_Click);
            MenuItem cerrar = new MenuItem("Cerrar FreeDevs", Cerrar_Click);
            menu.MenuItems.Add(mostrar);
            menu.MenuItems.Add(ajustes);
            menu.MenuItems.Add("-");
            menu.MenuItems.Add(cerrar);
            icono.ContextMenu = menu;
        }

        #region Eventos

        private void iconoNotificacion_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (mouse.Button.Equals(MouseButtons.Left))
            {
                //Evitar duplicar la ventana de notificacion
                if (notificacion == null || !notificacion.Visible)
                {
                    //Esconder la ventana de ajustes en caso de encontrarse abierta
                    if (ajustes != null && ajustes.Visible)
                        ajustes.Close();
                    mostrarNotificacion();
                } 
                else if (notificacion != null)
                    notificacion.Close();
            }
        }

        private void Ajustes_Click(object sender, EventArgs e)
        {
            //Esconder la notificacion si se encuentra visible
            if (notificacion!=null && notificacion.Visible)
                notificacion.Close();
            ajustes = new formAjustes();
            ajustes.Show();
        }
        private void Mostrar_Click(object sender, EventArgs e)
        {
            mostrarNotificacion();
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
                cargarEmpleados();
                //Generar la notificacion
                notificacion = new Notification(listado, velocidad, opacidad);
                notificacion.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la generación de la notificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarEmpleados()
        {
            //Carga de BBDD
            //List<Dev> devs = conexion.ObtenerEmpleados();

            devs.Clear();
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Aitor Etxezarraga", "Contratación Digital MC"));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Joseba Alonso", "FS R1"));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Gorka Barron", "GDPR Alta Prospectos"));
            devs.Add(new Dev(Constantes.ESTADO_DISPONIBLE, "Goizalde Machin", "#8516"));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Alexander Peña", "FSM Francia"));
            devs.Add(new Dev(Constantes.ESTADO_DISPONIBLE, "Daniel Crego", "#8516"));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Asier Cortes", ""));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Unai Rabanal", "GDPR Alta Facil"));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Eneko Soraluze", ""));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Gaizka Montero", "Contratación Digital MC"));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Endika Salgueiro", "Contratación Digital MC"));

            //Carga según estados (evita ordenación automática)
            listado.Clear();
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && dev.Estado.Equals(Constantes.ESTADO_LIBRE) && visualizacion.Contains(Constantes.VISUALIZAR_LIBRE))
                    listado.Add(dev);
            }
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && dev.Estado.Equals(Constantes.ESTADO_DISPONIBLE) && visualizacion.Contains(Constantes.VISUALIZAR_DISPONIBLE))
                    listado.Add(dev);
            }
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && dev.Estado.Equals(Constantes.ESTADO_OCUPADO) && visualizacion.Contains(Constantes.VISUALIZAR_OCUPADO))
                    listado.Add(dev);
            }
        }

        private Icon obtenerIcono(string usuario)
        {
            foreach (Dev dev in devs){
                if (dev.Nombre.Equals(usuario)){
                    estado = dev.Estado;
                    switch (estado){
                        case Constantes.ESTADO_LIBRE:
                            return Properties.Resources.iconoVerde;
                        case Constantes.ESTADO_DISPONIBLE:
                            return Properties.Resources.iconoNaranja;
                        default:
                            return Properties.Resources.iconoRojo;
                    }
                }
            }
            return Properties.Resources.iconoRojo;
        }

        private String obtenerTarea(string usuario)
        {
            foreach (Dev dev in devs){
                if (dev.Nombre.Equals(usuario)){
                    return dev.Tarea;
                }
            }
            return "Introduce aquí tu tarea";
        }

        #endregion
    }
}
