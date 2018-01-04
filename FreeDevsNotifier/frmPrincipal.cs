using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace FreeDevsNotifier
{
    public partial class frmPrincipal : Form
    {
        private NotifyIcon icono;

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
            icono = new NotifyIcon();
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
                // Create the Toast notification from the previous Toast content
                ToastNotification notificacion = new ToastNotification(cargarContenido());
                // And then send the Toast
                ToastNotificationManager.CreateToastNotifier("New Toast Thing").Show(notificacion);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en la generación de la notificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private XmlDocument cargarContenido()
        {
            ToastContent contenido = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "¡¡ EXTRA EXTRA !!",
                                HintMaxLines = 1
                            },

                            new AdaptiveText()
                            {
                                Text = "Formato Texto Normal"
                            },

                            new AdaptiveText()
                            {
                                Text = "Formato Texto Normal"
                            }
                        },
                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = "https://unsplash.it/64?image=883",
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        },
                        HeroImage = new ToastGenericHeroImage()
                        {
                            Source = "https://unsplash.it/360/180?image=1043"
                        },
                        Attribution = new ToastGenericAttributionText()
                        {
                            Text = "Atributo - Pie de Página"
                        },
                    },
                },
                Actions = new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastSelectionBox("estado")
                        {
                            DefaultSelectionBoxItemId = "libre",
                            Items =
                            {
                                new ToastSelectionBoxItem("libre", "Libre"),
                                new ToastSelectionBoxItem("disponible", "Disponible"),
                                new ToastSelectionBoxItem("ocupado", "Ocupado")
                            }
                        }
                    },
                    Buttons =
                    {
                        new ToastButton("Respuesta 1", "action=reply&threadId=9218")
                        {
                            ActivationType = ToastActivationType.Background
                        },

                        new ToastButton("Respuesta 2", "action=videocall&threadId=9218")
                        {
                            ActivationType = ToastActivationType.Foreground
                        }
                    }
                },
                DisplayTimestamp = new DateTime(2017, 04, 15, 19, 45, 00, DateTimeKind.Utc),
            };
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(contenido.GetContent());
            return xml;
        }
    }
}
