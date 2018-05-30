using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FreeDevs.Clases;

namespace FreeDevs.Controlador
{
    class ConectorSQL
    {
        //Parametros
        private string servidor;
        private string bbdd;
        private string usuario;
        private string pass;

        //Variables
        private MySqlConnection conexion;
        private Logger log = new Logger();

        public ConectorSQL(string server, string db, string user, string password)
        {
            servidor = server;
            bbdd = db;
            usuario = user;
            pass = password;
            Initialize();
        }

        private void Initialize()
        {
            String paramsConexion = "Server=" + servidor + "; database=" + bbdd + "; UID=" + usuario + "; password=" + pass + "; SslMode = none";
            conexion = new MySqlConnection(paramsConexion);
        }

        #region Metodos

        public List<Dev> obtenerEmpleados()
        {
            log.escribirLog(Constantes.LOG_INFO, "[ConectorSQL] obtenerEmpleados()");

            string query = "SELECT estado, nombre, tarea, ausente FROM empleados";

            List<Dev> empleados = new List<Dev>();

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    int estado      = dataReader.GetInt32("estado");
                    string nombre   = dataReader["nombre"] + "";
                    string tarea    = dataReader["tarea"] + "";
                    int ausente     = dataReader.GetInt32("ausente");

                    Dev developer = new Dev(estado, nombre, tarea, ausente);
                    //log.escribirLog(Constantes.LOG_TABULADO, developer.Nombre + ": " + developer.Estado + " (" + developer.Tarea + ") = " + developer.Ausente);
                    empleados.Add(developer);
                }

                dataReader.Close();
                cerrarConexion();
            }

            return empleados;
        }

        public void actualizarEstado(string nombre, int estado)
        {
            log.escribirLog(Constantes.LOG_INFO, "[ConectorSQL] actualizarEstado (" + nombre + ", " + estado + ")");

            String query = "UPDATE empleados SET estado = '" + estado + "' WHERE nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        public void actualizarTarea(string nombre, string tarea)
        {
            log.escribirLog(Constantes.LOG_INFO, "[ConectorSQL] actualizarTarea (" + nombre + ", " + tarea + ")");

            String query = "UPDATE empleados SET tarea = '" + tarea + "' WHERE nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        public void establecerAusente(string nombre, bool ausente)
        {
            log.escribirLog(Constantes.LOG_INFO, "[ConectorSQL] establecerAusente (" + nombre + ", " + ausente.ToString() + ")");

            String query = "";
            if (ausente)
                query = "UPDATE empleados SET ausente = " + Constantes.AUSENTE_SI + " WHERE nombre = '" + nombre + "'";
            else
                query = "UPDATE empleados SET ausente = " + Constantes.AUSENTE_NO + " WHERE nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        /*
        public void insertarEmpleado(string nombre)
        {
            String query = "insert into empleados (nombre) values ('" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }
        */

        #endregion

        #region Utilidades

        private bool abrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Imposible conectar con la BBDD", "Error Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.escribirLog(Constantes.LOG_ERROR, "[ConectorSQL] No ha sido posible conectarse con la base de datos.");

                switch (e.Number)
                {
                    case 0:
                    case 1042:
                        log.escribirLog(Constantes.LOG_TABULADO, "1042: Invalid username/password");
                        break;
                    case 1045:
                        log.escribirLog(Constantes.LOG_TABULADO, "1045: Invalid username/password");
                        break;
                }

                Application.Exit();
                return false;
            }
        }

        private bool cerrarConexion()
            {
                bool con = false;
                try
                {
                    conexion.Close();
                    con = true;
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                    con = false;
                }
                return con;
            }

        #endregion
    }
}
