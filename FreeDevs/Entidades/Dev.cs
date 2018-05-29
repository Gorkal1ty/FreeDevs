using System.Drawing;
using FreeDevs.Clases;

namespace FreeDevs
{
    public class Dev
    {
        private int estado;
        private string nombre;
        private string tarea;
        private bool ausente;

        public int Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Tarea { get => tarea; set => tarea = value; }
        public bool Ausente { get => ausente; set => ausente = value; }

        public Dev(int estado, string nombre, string tarea, int ausente)
        {
            Estado = estado;
            Nombre = nombre;
            Tarea = tarea;
            if (ausente == Constantes.AUSENTE_SI)
                Ausente = true;
            else
                Ausente = false;
        }

        public Icon obtenerIcono()
        {
            switch (estado)
            {
                case 1:
                    return Properties.Resources.iconoVerde;
                case 2:
                    return Properties.Resources.iconoNaranja;
                default:
                    return Properties.Resources.iconoRojo;
            }
        }

        public int obtenerEstado()
        {
            //Devuelve el estado teniendo en cuenta que "ausente" debe desactivar el icono
            if (ausente)
                return int.Parse(Constantes.VISUALIZAR_AUSENTE);
            else
                return Estado;
        }
    }
}
