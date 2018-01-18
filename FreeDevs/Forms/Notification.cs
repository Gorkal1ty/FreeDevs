using FreeDevs.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FreeDevs.Entidades;

namespace FreeDevs
{
    public partial class Notification : Form
    {
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        public Notification(List<Dev> listado, int duration, int speed, int opacity)
        {
            InitializeComponent();

            //Diseño
            Size = new Size(250, 130 + 22 * listado.Count);
            lvDevs.Size = new Size(180 + panelBotones.Height, 22 * listado.Count);
            panelBotones.Location = new Point(Location.X + 4, Location.Y + 55 + lvDevs.Height);
            BackColor = Color.Black;
            lvDevs.Scrollable = false;
            lvDevs.View = View.Details;
            btnEstado1.BackColor = SystemColors.ControlDarkDark;
            btnEstado2.BackColor = SystemColors.ControlDarkDark;
            btnEstado3.BackColor = SystemColors.ControlDarkDark;
            btnAjustes.BackgroundImage = Properties.Resources.parametros;

            //Parametros
            duration = duration * 1000;
            lifeTimer.Interval = duration;
            Opacity = opacity * 0.1;
            _animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 500 / speed);
            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));

            //Imagenes
            ImageList iconos = new ImageList();
            iconos.ImageSize = new Size(20, 20);
            iconos.Images.Add(Properties.Resources.iconoVerde);
            iconos.Images.Add(Properties.Resources.iconoNaranja);
            iconos.Images.Add(Properties.Resources.iconoRojo);
            lvDevs.SmallImageList = iconos;

            //Columna
            lvDevs.Columns.Add("Nombre", 200);
            lvDevs.HeaderStyle = ColumnHeaderStyle.None;
            //Filas
            foreach(Dev dev in listado)
            {
                lvDevs.Items.Add("    " + dev.Nombre, dev.Estado);
            }

            //Nombre & Estado
            lblNombre.Text = formInicio.usuario;
            switch (formInicio.estado)
            {
                case Constantes.ESTADO_LIBRE:
                    pbEstado.BackgroundImage = Properties.Resources.iconoVerde.ToBitmap();
                    btnEstado1.BackColor = SystemColors.Highlight;
                    break;
                case Constantes.ESTADO_DISPONIBLE:
                    pbEstado.BackgroundImage = Properties.Resources.iconoNaranja.ToBitmap();
                    btnEstado2.BackColor = SystemColors.Highlight;
                    break;
                case Constantes.ESTADO_OCUPADO:
                    pbEstado.BackgroundImage = Properties.Resources.iconoRojo.ToBitmap();
                    btnEstado3.BackColor = SystemColors.Highlight;
                    break;
            }
        }

        #region Eventos

        private void lvDevs_ItemSelectionChanged(object sender, EventArgs e)
        {
            //Todo: Investigar selección usuario >> Abrir chat hangouts #PremiumBusinessOverpowerUsers :P
            lvDevs.SelectedItems.Clear();
        }


        private void btnEstados_Click(object sender, EventArgs e)
        {
            //Actualizar Estado

            //TODO: Falta Actualización automática a BBDD
            var boton = (Button)sender;
            switch (boton.Name)
            {
                case "btnEstado1":
                    pbEstado.BackgroundImage = Properties.Resources.iconoVerde.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoVerde;
                    btnEstado1.BackColor = SystemColors.Highlight;
                    btnEstado2.BackColor = SystemColors.ControlDarkDark;
                    btnEstado3.BackColor = SystemColors.ControlDarkDark;
                    break;
                case "btnEstado2":
                    pbEstado.BackgroundImage = Properties.Resources.iconoNaranja.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoNaranja;
                    btnEstado1.BackColor = SystemColors.ControlDarkDark;
                    btnEstado2.BackColor = SystemColors.Highlight;
                    btnEstado3.BackColor = SystemColors.ControlDarkDark;
                    break;
                case "btnEstado3":
                    pbEstado.BackgroundImage = Properties.Resources.iconoRojo.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoRojo;
                    btnEstado1.BackColor = SystemColors.ControlDarkDark;
                    btnEstado2.BackColor = SystemColors.ControlDarkDark;
                    btnEstado3.BackColor = SystemColors.Highlight;
                    break;
            }
            lifeTimer.Interval += 2000;
        }
        private void btnEstado1_Hover(object sender, EventArgs e)
        {

        }
        private void btnEstado2_Hover(object sender, EventArgs e)
        {

        }
        private void btnEstado3_Hover(object sender, EventArgs e)
        {

        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            formAjustes ajustes = new formAjustes();
            Close();
            ajustes.Show();
        }

        private void btnAjustes_Hover(object sender, EventArgs e)
        {
            btnAjustes.BackgroundImage = Properties.Resources.parametros_h;
        }

        private void btnAjustes_Leave(object sender, EventArgs e)
        {
            btnAjustes.BackgroundImage = Properties.Resources.parametros;
        }

        private void Click_Cierre(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Funciones Integradas: No Tocar

        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            //Localization
            Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - Width,
                Screen.PrimaryScreen.WorkingArea.Height - Height);

            lifeTimer.Start();
        }
        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }
        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        #endregion
    }
}