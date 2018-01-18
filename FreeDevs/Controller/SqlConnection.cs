using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using FreeDevs.Entidades;

namespace FreeDevs.Controller
{
    class SqlConnection
    {

        private MySqlConnection connection;

        private string server;

        public string Server { get => server; set => server = value; }        

        public SqlConnection(string server)
        {
            Server = server;
            Initialize(Server);
        }

        private void Initialize(string server)
        {
            String conString = "Server=" +server+ "; database=ntsdev; UID=root; password=root; SslMode = none";

            connection = new MySqlConnection(conString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
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

        private bool CloseConnection()
        {
            bool con = false;
            try
            {
                connection.Close();
                con = true;
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                con = false;
            }
            return con;
        }


        public void InsertUser(string userName)
        {
            String query = "insert into empleados (nombre) values ('" + userName + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void UpdateUser(string userName, bool condition)
        {
            String query = "update empleados set estado = '" + condition + "' where nombre = '" + userName + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


        public List<Dev> Select()
        {
            string query = "SELECT estado, nombre FROM empleados";

            List<string>[] list = new List<string>[2];
            list[0] = new List<string>();
            list[1] = new List<string>();
            List<Dev> empleados = new List<Dev>();


            if (this.OpenConnection() == true)
            {                
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["estado"] + "");
                    list[1].Add(dataReader["nombre"] + "");

                    string nombre = dataReader["nombre"] + "";
                    int estado = dataReader.GetInt32("estado");

                    Dev developer = new Dev(estado, nombre);

                    empleados.Add(developer);                    
                }

                dataReader.Close();
                this.CloseConnection();

                return empleados;
            }
            else
            {
                Console.WriteLine("No ha sido posible conectarse con la base de datos.");
                return empleados;
            }
        }
    }
}
