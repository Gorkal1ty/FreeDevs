using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FreeDevs.Controlador
{
    class ConexionSQL
    {
        //Parametros
        private string servidor;
        private string bbdd;
        private string usuario;
        private string pass;

        //Variables
        private MySqlConnection conexion;

        public ConexionSQL(string server, string db, string user, string password)
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

        public List<Dev> ObtenerEmpleados()
        {
            Console.WriteLine("[INFO] ObtenerEmpleados()");

            string query = "SELECT estado, nombre, tarea FROM empleados";

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

                    Dev developer = new Dev(estado, nombre, tarea);
                    Console.Write("[ConexionSQL] ObtenerEmpleados: ");
                    Console.Write(developer.Nombre + " - " + developer.Estado + " " + developer.Tarea);
                    empleados.Add(developer);
                }

                dataReader.Close();
                cerrarConexion();

                return empleados;
            }
            else
            {
                Console.WriteLine("No ha sido posible conectarse con la base de datos.");
                return empleados;
            }
        }

        public void actualizarEmpleado(string nombre, string tarea, bool estado)
        {
            String query = "UPDATE empleados SET estado = '" + estado + ", tarea = '" + tarea + " WHERE nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        public void actualizarTarea(string nombre, string tarea)
        {
            String query = "UPDATE empleados SET tarea = '" + tarea + " WHERE nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        /*
        public void InsertarEmpleado(string nombre)
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
                    switch (e.Number)
                    {
                        case 0:
                        case 1042:
                            Console.Write("Invalid username/password, please try again");
                            break;
                        case 1045:
                            Console.Write("Invalid username/password, please try again");
                            break;
                    }
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
