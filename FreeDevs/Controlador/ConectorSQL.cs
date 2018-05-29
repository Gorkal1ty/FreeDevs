﻿using System;
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

        public List<Dev> ObtenerEmpleados()
        {
            Console.WriteLine("[INFO] ObtenerEmpleados()");

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
                    Console.Write("[ConexionSQL] ObtenerEmpleados: ");
                    Console.Write(developer.Nombre + " - " + developer.Estado + " " + developer.Tarea + " " + developer.Ausente);
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

        public void actualizarEstado(string nombre, int estado)
        {
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
