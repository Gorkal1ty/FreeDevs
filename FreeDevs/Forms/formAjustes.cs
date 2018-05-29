using FreeDevs.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FreeDevs
{

    public partial class formAjustes : Form
    {
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        public formAjustes()
        {
            InitializeComponent();

            //Diseño
            BackColor = Color.Black;
            Opacity = formInicio.opacidad * 0.1;

            btnConfGuardar.BackColor = SystemColors.ControlDarkDark;
            btnConfCancelar.BackColor = SystemColors.ControlDarkDark; 
            btnConfGuardar.Image = Properties.Resources.guardar;
            btnConfCancelar.Image = Properties.Resources.cancelar;

            //Parametros
            _animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 250);
            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));

            //Velocidad
            cbConfVelocidad.Items.Add("Baja");
            cbConfVelocidad.Items.Add("Media");
            cbConfVelocidad.Items.Add("Alta");

            //Cargar config. actual
            cbConfVelocidad.SelectedIndex = formInicio.velocidad-1;
            sbOpacidad.Value = formInicio.opacidad;

            if (formInicio.visualizacion.Contains(Constantes.VISUALIZAR_LIBRE))
                cbConfEstado1.Checked = true;
            else
                cbConfEstado1.Checked = false;
            if (formInicio.visualizacion.Contains(Constantes.VISUALIZAR_DISPONIBLE))
                cbConfEstado2.Checked = true;
            else
                cbConfEstado2.Checked = false;
            if (formInicio.visualizacion.Contains(Constantes.VISUALIZAR_OCUPADO))
                cbConfEstado3.Checked = true;
            else
                cbConfEstado3.Checked = false;
            if (formInicio.visualizacion.Contains(Constantes.VISUALIZAR_AUSENTE))
                cbConfEstado4.Checked = true;
            else
                cbConfEstado4.Checked = false;
        }

        #region Eventos

        private void Notification_Load(object sender, EventArgs e)
        {
            //Localization
            Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - Width,
                Screen.PrimaryScreen.WorkingArea.Height - Height);
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

        private void btnConfGuardar_Click_1(object sender, EventArgs e)
        {
            guardarAjustes();
        }

        private void btnConfCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Metodos

        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        private void guardarAjustes()
        {
            string visualizacionNueva = "";
            //Conversion string visualizacion
            if (cbConfEstado1.Checked)
                visualizacionNueva += Constantes.VISUALIZAR_LIBRE;
            if (cbConfEstado2.Checked)
                visualizacionNueva += Constantes.VISUALIZAR_DISPONIBLE;
            if (cbConfEstado3.Checked)
                visualizacionNueva += Constantes.VISUALIZAR_OCUPADO;
            if (cbConfEstado4.Checked)
                visualizacionNueva += Constantes.VISUALIZAR_AUSENTE;
            //Guardar ajustes actuales
            formInicio.velocidad = cbConfVelocidad.SelectedIndex + 1; 
            formInicio.opacidad = sbOpacidad.Value;
            formInicio.visualizacion = visualizacionNueva;
            //Guardar Settings
            Properties.Settings.Default.Velocidad = cbConfVelocidad.SelectedIndex + 1;
            Properties.Settings.Default.Opacidad = sbOpacidad.Value;
            Properties.Settings.Default.Visualizacion = visualizacionNueva;
            Properties.Settings.Default.Save();

            Close();
        }

        #endregion

        private void sbOpacidad_Scroll(object sender, ScrollEventArgs e)
        {
            Opacity = e.NewValue * 0.1;
        }
    }
}