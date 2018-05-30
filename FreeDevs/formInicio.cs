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
        private static ConectorSQL conexion = new ConectorSQL(Endpoints.SERVIDOR, Endpoints.BD, Endpoints.USUARIO, Endpoints.PASS);

        //Variables Globales
        public Notification notificacion = null;
        public static formAjustes ajustes = null;
        public static int estado = Constantes.ESTADO_OCUPADO;
        public static string tarea = "";
        public static NotifyIcon icono = new NotifyIcon();
        private static List<Dev> devs = new List<Dev>();
        public static List<Dev> listado = new List<Dev>();

        private ContextMenu menu = new ContextMenu();
        private Logger log = new Logger();

        //Parametros accesibles desde app y fichero configuracion
        public static string usuario = Properties.Settings.Default.Usuario;
        public static int velocidad = Properties.Settings.Default.Velocidad;
        public static int opacidad = Properties.Settings.Default.Opacidad;
        public static string visualizacion = Properties.Settings.Default.Visualizacion;

        internal static ConectorSQL Conexion { get => conexion; set => conexion = value; }

        public formInicio()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            WindowState = FormWindowState.Minimized;
            Load += new EventHandler(formInicio_Load);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            ResumeLayout(false);
        }

        private void formInicio_Load(object sender, EventArgs e)
        {
            Hide();

            log.escribirLog(Constantes.LOG_INFO, " ************ Inicio Aplicación ************************ ");
            
            //Carga Inicial
            cargarEmpleados();

            //Icono
            icono.Text = "FreeDevs";
            icono.Visible = true;
            icono.Click += new EventHandler(iconoNotificacion_Click);
            icono.Icon = obtenerIcono(usuario);

            //Tarea
            tarea = obtenerTarea(usuario);

            //Estado
            estado = obtenerEstado(usuario);

            //Menu Contextual > Click derecho
            MenuItem mostrar = new MenuItem("Mostrar", Mostrar_Click);
            MenuItem ajustes = new MenuItem("Ajustes", Ajustes_Click);
            MenuItem cerrar = new MenuItem("Cerrar FreeDevs", Cerrar_Click);
            menu.MenuItems.Add(mostrar);
            menu.MenuItems.Add(ajustes);
            menu.MenuItems.Add("-");
            menu.MenuItems.Add(cerrar);
            icono.ContextMenu = menu;

            //Desactivar Ausente en BBDD
            Conexion.establecerAusente(usuario, false);
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
                    if (ajustes != null)
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
            if (!ajustes.Visible) {
                ajustes = new formAjustes();
                ajustes.Show();
            }
        }
        private void Mostrar_Click(object sender, EventArgs e)
        {
            mostrarNotificacion();
        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Evento para capturar el cierre manual de la aplicación (click derecho)
        private void OnApplicationExit(object sender, EventArgs e)
        {
            Conexion.establecerAusente(usuario, true);
            log.escribirLog(Constantes.LOG_INFO, " ************ Cierre Aplicación ************************ ");
        }

        //Evento para capturar el cierre de sesión / apagado (applicationExit no se dispara)
        private static int WM_QUERYENDSESSION = 0x11;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                Conexion.establecerAusente(usuario, true);
                log.escribirLog(Constantes.LOG_INFO, " ************ Cierre Aplicación ************************ ");
            }
            base.WndProc(ref m);
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
            devs = conexion.obtenerEmpleados();
            
            /*
            devs.Clear();

            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Aitor Etxezarraga", "Contratación Digital MC", Constantes.AUSENTE_SI));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Joseba Alonso", "FS R1",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Gorka Barron", "GDPR Alta Prospectos",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_DISPONIBLE, "Goizalde Machin", "#8516",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Alexander Peña", "FSM Francia",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_DISPONIBLE, "Daniel Crego", "#8516",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Asier Cortes", "",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Unai Rabanal", "GDPR Alta Facil",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_LIBRE, "Eneko Soraluze", "", Constantes.AUSENTE_SI));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Gaizka Montero", "Contratación Digital MC",  Constantes.AUSENTE_NO));
            devs.Add(new Dev(Constantes.ESTADO_OCUPADO, "Endika Salgueiro", "Contratación Digital MC",  Constantes.AUSENTE_NO));
            */

            //Carga según estados (evita ordenación automática)
            listado.Clear();
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && !dev.Ausente &&
                    dev.Estado.Equals(Constantes.ESTADO_LIBRE) && 
                    visualizacion.Contains(Constantes.VISUALIZAR_LIBRE))
                        listado.Add(dev);
            }
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && !dev.Ausente &&
                    dev.Estado.Equals(Constantes.ESTADO_DISPONIBLE) && 
                    visualizacion.Contains(Constantes.VISUALIZAR_DISPONIBLE))
                        listado.Add(dev);
            }
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && !dev.Ausente &&
                    dev.Estado.Equals(Constantes.ESTADO_OCUPADO) && 
                    visualizacion.Contains(Constantes.VISUALIZAR_OCUPADO))
                        listado.Add(dev);
            }
            foreach (Dev dev in devs)
            {
                if (dev.Nombre != usuario && dev.Ausente &&
                    visualizacion.Contains(Constantes.VISUALIZAR_AUSENTE))
                    listado.Add(dev);
            }
        }

        private Icon obtenerIcono(string usuario)
        {
            foreach (Dev dev in devs){
                if (dev.Nombre.Equals(usuario)){
                    switch (dev.Estado){
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
                    if (dev.Tarea.Equals(""))
                        return "Introduce aquí tu tarea";
                    else
                        return dev.Tarea;
                }
            }
            return "";
        }

        private int obtenerEstado(string usuario)
        {
            foreach (Dev dev in devs)
            {
                if (dev.Nombre.Equals(usuario))
                {
                    return dev.Estado;
                }
            }
            return Constantes.ESTADO_OCUPADO;
        }

        #endregion
    }
}
