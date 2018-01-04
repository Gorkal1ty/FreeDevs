using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDevsNotifier
{
    class Dev
    {
        private int estado;
        private string nombre;
        private string especialidad;

        public int Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }

        public Dev(int estado, string nombre, string especialidad)
        {
            Estado = estado;
            Nombre = nombre;
            Especialidad = especialidad;
        }
        
        public string obtenerIcono()
        {
            switch (estado)
            {
                case 1:
                    return "\\Images\\semaforoVerde.png";
                case 2:
                    return "\\Images\\semaforoNaranja.png";
                default:
                    return "\\Images\\semaforoRojo.png";
            }
        }
    }
}
