using System;
using System.IO;
using System.Linq;

namespace FreeDevs.Clases
{
    class Logger
    {

        private string path = Endpoints.LOG;
        private int maxLong = Constantes.LOG_MAXLONG;
        StreamWriter sw;


        #region METODOS

        public void escribirLog(int tipo, string texto)
        {

            // Comprobar si existe el fichero
            if (!File.Exists(path))
            {
                // Crear el fichero
                sw = File.CreateText(path);

                sw.WriteLine("---------------------------------------------------------------------------------");
                sw.WriteLine("  FREE DEVS LOGGER - " + DateTime.Now);
                sw.WriteLine("---------------------------------------------------------------------------------");
                sw.WriteLine("");

                sw.Close();
            }

            // Agregar línea
            sw = File.AppendText(path);

            Console.WriteLine("LOGGER");
                
            switch (tipo)
            {
                case Constantes.LOG_INFO:
                    sw.WriteLine("[INFO] " + DateTime.Now + ": " + texto);
                    break;
                case Constantes.LOG_ERROR:
                    sw.WriteLine("[ERROR] "+ DateTime.Now + ": " + texto);
                    break;
                case Constantes.LOG_TABULADO:
                    sw.WriteLine(texto);
                    break;
            }

            sw.Close();
                
            //Mantener longitud de fichero
            var lines = File.ReadAllLines(path);
            if (lines.Length > maxLong)
                File.WriteAllLines(path, lines.Skip(lines.Length - maxLong + 4).ToArray());
        }

        #endregion
    }
}