﻿using System.Drawing;

namespace FreeDevs
{
    public class Dev
    {
        private int estado;
        private string nombre;

        public int Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Dev(int estado, string nombre, string especialidad)
        {
            Estado = estado;
            Nombre = nombre;
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
    }
}
