using System;
using System.Collections.Generic;
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

            string query = "SELECT estado, nombre FROM empleados";

            List<Dev> empleados = new List<Dev>();

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string nombre = dataReader["nombre"] + "";
                    int estado = dataReader.GetInt32("estado");
                                        
                    Dev developer = new Dev(estado, nombre);
                    Console.Write("[ConexionSQL] ObtenerEmpleados: ");
                    Console.Write(developer.Nombre + " - " + developer.Estado);
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

        public void nsertarEmpleado(string nombre)
        {
            String query = "insert into empleados (nombre) values ('" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

        public void actualizarEmpleado(string nombre, bool estado)
        {
            String query = "update empleados set estado = '" + estado + "' where nombre = '" + nombre + "'";

            if (abrirConexion() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
                cerrarConexion();
            }
        }

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
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (e.Number)
                    {
                        case 0:
                            Console.Write("Cannot connect to server.  Contact administrator");
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
