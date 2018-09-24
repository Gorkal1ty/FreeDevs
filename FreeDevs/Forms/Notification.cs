using FreeDevs.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FreeDevs
{
    public partial class Notification : Form
    {
        public int PANEL_ANCHO              = 275;
        public int PANEL_ALTO               = 160;
        public int TAMA�O_LOGOS             = 22;
        public int ALTURA_ITEM              = 24;
        public int TAMA�O_COLUMNA_NOMBRE    = 400;
        public int MARGEN_PANEL_X           = 4;
        public int MARGEN_PANEL_Y           = 80;

        public Font FUENTE_NOMBRES = new Font("Arial", 14, FontStyle.Regular);
        public Font FUENTE_TAREAS = new Font("Arial", 12, FontStyle.Italic);

        public Color COLOR_AUSENTE = Color.Gray;

        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        public Notification(List<Dev> listado, int speed, int opacity)
        {
            InitializeComponent();

            //Dise�o
            BackColor = Color.Black;
            lvDevs.Scrollable = false;
            lvDevs.View = View.Details;
            btnEstado1.BackColor = SystemColors.ControlDarkDark;
            btnEstado2.BackColor = SystemColors.ControlDarkDark;
            btnEstado3.BackColor = SystemColors.ControlDarkDark;
            btnAjustes.BackgroundImage = Properties.Resources.parametros;

            //Parametros
            Opacity = opacity * 0.1;
            _animator = new FormAnimator(this, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up, 500 / speed);
            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 0, 0));

            //Imagenes
            ImageList iconos = new ImageList();
            iconos.ImageSize = new Size(TAMA�O_LOGOS, TAMA�O_LOGOS);
            iconos.Images.Add(Properties.Resources.iconoVerde);
            iconos.Images.Add(Properties.Resources.iconoNaranja);
            iconos.Images.Add(Properties.Resources.iconoRojo);
            iconos.Images.Add(Properties.Resources.iconoAusente);
            lvDevs.SmallImageList = iconos;

            //Columnas
            lvDevs.Columns.Add("Nombre", TAMA�O_COLUMNA_NOMBRE);
            lvDevs.HeaderStyle = ColumnHeaderStyle.None;

            //Filas
            foreach(Dev dev in listado)
            {
                ListViewItem Nombre = new ListViewItem("  " + dev.Nombre, dev.obtenerEstado());
                Nombre.Font = FUENTE_NOMBRES;
                if (dev.Ausente)
                    Nombre.ForeColor = COLOR_AUSENTE;
                lvDevs.Items.Add(Nombre);
                if (!dev.Tarea.Equals(""))
                {
                    ListViewItem Tarea = new ListViewItem("  " + dev.Tarea);
                    Tarea.Font = FUENTE_TAREAS;
                    if (dev.Ausente)
                        Tarea.ForeColor = COLOR_AUSENTE;
                    lvDevs.Items.Add(Tarea);
                }
            }

            //Datos Usuario
            lblNombre.Text = formInicio.usuario;
            txtTarea.Text = formInicio.tarea;
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

            //Ajustes Din�micos
            Size = new Size(PANEL_ANCHO, PANEL_ALTO + ALTURA_ITEM * lvDevs.Items.Count);
            lvDevs.Size = new Size(180 + panelBotones.Height, ALTURA_ITEM * lvDevs.Items.Count);
            panelBotones.Location = new Point(Location.X + MARGEN_PANEL_X, Location.Y + MARGEN_PANEL_Y + lvDevs.Height);

        }

        #region Eventos

        private void presionarEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Constantes.MODO_PRUEBAS)
                    formInicio.Conexion.actualizarTarea(formInicio.usuario, txtTarea.Text);
                if (txtTarea.Text.Equals(""))
                {
                    txtTarea.Text = "Introduce aqu� tu tarea";
                    panelBotones.Focus();
                }
                else
                {
                    formInicio.tarea = txtTarea.Text;
                }
            }
        }

        private void clickTarea(object sender, EventArgs e)
        {
            if (txtTarea.Text.Equals("Introduce aqu� tu tarea"))
            {
                txtTarea.Clear();
            }
        }

        private void btnEstados_Click(object sender, EventArgs e)
        {
            //Actualizar Estado
            var boton = (Button)sender;
            switch (boton.Name)
            {
                case "btnEstado1":
                    pbEstado.BackgroundImage = Properties.Resources.iconoVerde.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoVerde;
                    btnEstado1.BackColor = SystemColors.Highlight;
                    btnEstado2.BackColor = SystemColors.ControlDarkDark;
                    btnEstado3.BackColor = SystemColors.ControlDarkDark;
                    formInicio.estado = Constantes.ESTADO_LIBRE;
                    break;
                case "btnEstado2":
                    pbEstado.BackgroundImage = Properties.Resources.iconoNaranja.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoNaranja;
                    btnEstado1.BackColor = SystemColors.ControlDarkDark;
                    btnEstado2.BackColor = SystemColors.Highlight;
                    btnEstado3.BackColor = SystemColors.ControlDarkDark;
                    formInicio.estado = Constantes.ESTADO_DISPONIBLE;
                    break;
                case "btnEstado3":
                    pbEstado.BackgroundImage = Properties.Resources.iconoRojo.ToBitmap();
                    formInicio.icono.Icon = Properties.Resources.iconoRojo;
                    btnEstado1.BackColor = SystemColors.ControlDarkDark;
                    btnEstado2.BackColor = SystemColors.ControlDarkDark;
                    btnEstado3.BackColor = SystemColors.Highlight;
                    formInicio.estado = Constantes.ESTADO_OCUPADO;
                    break;
            }
            //Actualizar BBDD
            if (!Constantes.MODO_PRUEBAS)
                formInicio.Conexion.actualizarEstado(formInicio.usuario, formInicio.estado);
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            formInicio.ajustes = new formAjustes();
            Close();
            formInicio.ajustes.Show();
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