using System;
using System.Drawing;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace FreeDevsNotifier
{
    public partial class frmPrincipal : Form
    {
        private NotifyIcon icono = new NotifyIcon();
        Dev[] devs = {
            new Dev(1, "Aitor Echezarraga", "Android"),
            new Dev(2, "Joseba Alonso", "Nada de nada"),
            new Dev(3, "Gorka Barron", ".NET"),
            new Dev(3, "Alexander Peña", "Git"),
            new Dev(1, "Goizalde Machin", "BackOffice"),
            new Dev(2, "Daniel Crego", "BackOffice") };

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, System.EventArgs e)
        {
            Hide();
            ShowInTaskbar = true;

            Text = "Icono Notificacion";

            // Create the NotifyIcon.
            icono.Icon = new Icon("Images/iconoRojo.ico");
            icono.Text = "FreeDevsNotifier";
            icono.Visible = true;

            // Handle the DoubleClick event to activate the form.
            icono.Click += new EventHandler(this.iconoNotificacion_Click);
        }

        private void iconoNotificacion_Click(object Sender, EventArgs e)
        {
            try
            {
                //Crear notificación
                ToastNotification notificacion = new ToastNotification(generarXML());
                //Asignar Tag para evitar repetición en centro de actividades
                notificacion.Tag = "X";
                //Mostrar Notificacion
                ToastNotificationManager.CreateToastNotifier("FreeDevs").Show(notificacion);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en la generación de la notificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private XmlDocument generarXML()
        {
            string listado = "";
            //Concatenar Listado Devs
            foreach (Dev dev in devs)
            {
                if(dev.Estado!=3)
                {
                    listado += $@"
                    <group>
                        <subgroup hint-weight='4'>
                        </subgroup>
                        <subgroup hint-weight='1'>
                            <image src='" + Application.StartupPath + dev.obtenerIcono() + $@"'/>
                        </subgroup>
                        <subgroup hint-weight='7'>
                            <text hint-style = 'base' hint-align = 'left'>" + dev.Nombre + $@"</text>
                            <text hint-style = 'captionSubtle' hint-align = 'left'>" + dev.Especialidad + $@"</text>
                        </subgroup>                        
                    </group>";
                }
            }
            //Crear XML
            XmlDocument xml = new XmlDocument();
            string contenido = $@"
            <toast>
                <visual>
                    <binding template='ToastGeneric'>
                        <text>FreeDevs</text>" +
                        listado + $@"
                    </binding>
                </visual>
                <actions>
                    <input id='estado' type='selection' defaultInput='libre'>
                        <selection 
                            id = 'libre' 
                            content = 'Libre'/>
                        <selection 
                            id = 'disponible' 
                            content = 'Disponible'/>
                        <selection 
                            id = 'ocupado' 
                            content = 'Ocupado'/>
                    </input>
                    <action
                        content = 'Actualizar'
                        hint-inputId= 'estado'
                        arguments = 'action=refrescar'
                        activationType = 'background'/>
                </actions>
            </toast>";
            xml.LoadXml(contenido);
            return xml;
        }
    }
}
