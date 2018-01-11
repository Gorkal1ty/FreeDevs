using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FreeDevs
{
    public partial class Notification : Form
    {
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        public Notification(List<Dev> listado, int duration, FormAnimator.AnimationMethod animation, FormAnimator.AnimationDirection direction, int speed, Color color, double opacity)
        {
            InitializeComponent();

            //Diseño
            Size = new Size(250, 80+22*listado.Count);
            lvDevs.Size = new Size(220, 22*listado.Count);
            cbEstado.Location = new Point(Location.X+50, Location.Y+9);

            lvDevs.Scrollable = false;
            lvDevs.View = View.Details;

            //Parametros
            duration = duration * 1000;
            lifeTimer.Interval = duration;
            BackColor = color;
            Opacity = opacity;

            _animator = new FormAnimator(this, animation, direction, speed);
            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));

            //Estados
            cbEstado.Items.Add(" Estoy libre");
            cbEstado.Items.Add(" Estoy disponible");
            cbEstado.Items.Add(" Estoy ocupado");
            cbEstado.SelectedIndex = 0;                             //TODO: Cambiar estado a actual (BD)

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

        }

        #region Methods

        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

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

        private void Click_Cierre(object sender, EventArgs e)
        {
            Close();
        }

        #endregion 

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualizar Estado

            //TODO:...
            switch (cbEstado.SelectedIndex)
            {
                case 0:
                    pbEstado.BackgroundImage = Properties.Resources.iconoVerde.ToBitmap();
                    NotificationLauncher.icono.Icon = Properties.Resources.iconoVerde;
                    break;
                case 1:
                    pbEstado.BackgroundImage = Properties.Resources.iconoNaranja.ToBitmap();
                    NotificationLauncher.icono.Icon = Properties.Resources.iconoNaranja;
                    break;
                default:
                    pbEstado.BackgroundImage = Properties.Resources.iconoRojo.ToBitmap();
                    NotificationLauncher.icono.Icon = Properties.Resources.iconoRojo;
                    break;
            }

            lifeTimer.Start();
            //Refrescar
        }

        private void cbEstado_Clicked(object sender, EventArgs e)
        {
            lifeTimer.Stop();
        }

        private void lvDevs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}