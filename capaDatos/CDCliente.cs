<<<<<<< HEAD
﻿using capaEntidad; // Permite acceder a la clase CEClientes (entidad cliente).
using MySql.Data.MySqlClient; // Librería oficial de MySQL para conexión y comandos.
using MySqlConnector; // Conector alternativo, más eficiente para MySQL.
using Mysqlx.Crud; // (No se utiliza en este código, pero pertenece al espacio MySQLX CRUD).
using System;
using System.Data; // Permite manejar estructuras de datos como DataSet y DataTable.
using System.Windows.Forms; // Permite mostrar mensajes en ventanas (MessageBox).

namespace capaDatos // Espacio de nombres de la capa de datos.
{
    // Clase encargada de las operaciones de base de datos para la tabla "clientes".
    public class CDCliente
    {
        // Cadena de conexión a la base de datos MySQL.
        private const string V = "Server=localhost;User=root;Password=1234;database=curso_cs;";
        private string CadenaConexion = V;

        // Prueba la conexión con la base de datos y muestra si fue exitosa o falló.
=======
﻿using capaEntidad;
using MySql.Data.MySqlClient;
using MySqlConnector;
using Mysqlx.Crud;
using System;
using System.Data;
using System.Windows.Forms;

namespace capaDatos
{
    public class CDCliente
    {
        private const string V = "Server=localhost;User=root;Password=1234;database=curso_cs;";
        private string CadenaConexion = V;

>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
        public void PruebaConexion()
        {
            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);

            try
            {
<<<<<<< HEAD
                mySqlConnection.Open(); // Intenta abrir la conexión.
            }
            catch (Exception ex)
            {
                // Si hay un error al conectarse, se muestra un mensaje con la descripción.
                MessageBox.Show("Error al conectarse: " + ex.Message);
                return;
            }

            mySqlConnection.Close(); // Cierra la conexión si fue exitosa.
            MessageBox.Show("Conectado"); // Muestra mensaje de confirmación.
        }

        // Inserta un nuevo cliente en la base de datos.
=======
                mySqlConnection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;

            }
            mySqlConnection.Close();
            MessageBox.Show("Conectado");
        }

>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
        public void Crear(CEClientes cE)
        {
            using var mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            const string query = "INSERT INTO clientes (Nombre, Apellido, Foto) VALUES (@Nombre, @Apellido, @Foto)";
            using var mySqlCommand = new MySqlConnector.MySqlCommand(query, mySqlConnection);

<<<<<<< HEAD
            // Asigna los valores recibidos del objeto CEClientes a los parámetros del SQL.
            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);

            // Si no hay foto, se guarda como NULL.
=======
            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);
>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
            if (string.IsNullOrEmpty(cE.Foto))
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", DBNull.Value);
            }
            else
            {
                mySqlCommand.Parameters.AddWithValue("@foto", cE.Foto);
            }

<<<<<<< HEAD
            mySqlCommand.ExecuteNonQuery(); // Ejecuta la inserción.
            MessageBox.Show("Registro Creado"); // Muestra mensaje de confirmación.
        }

        // Actualiza los datos de un cliente existente.
=======
            mySqlCommand.ExecuteNonQuery();
            MessageBox.Show("Registro Creado");
        }

>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
        public void Editar(CEClientes cE)
        {
            using var mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            const string query = "UPDATE clientes SET Nombre = @Nombre, Apellido = @Apellido, Foto = @Foto WHERE Id = @Id";
            using var mySqlCommand = new MySqlConnector.MySqlCommand(query, mySqlConnection);

<<<<<<< HEAD
            // Se asignan los valores a actualizar.
            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);

=======
            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);
>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
            if (string.IsNullOrEmpty(cE.Foto))
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", DBNull.Value);
            }
            else
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", cE.Foto);
            }
<<<<<<< HEAD

            mySqlCommand.Parameters.AddWithValue("@Id", cE.Id);

            mySqlCommand.ExecuteNonQuery(); // Ejecuta la actualización.
            MessageBox.Show("Registro Actualizado"); // Muestra mensaje de éxito.
        }

        // Elimina un cliente de la base de datos según su Id.
        public void Eliminar(CEClientes cE)
        {
            // Validaciones básicas antes de eliminar.
=======
            mySqlCommand.Parameters.AddWithValue("@Id", cE.Id);

            mySqlCommand.ExecuteNonQuery();
            MessageBox.Show("Registro Actualizado");
        }

        public void Eliminar(CEClientes cE)
        {
>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
            if (cE == null)
            {
                MessageBox.Show("Objeto cliente nulo");
                return;
            }

            if (cE.Id <= 0)
            {
                MessageBox.Show("Id no válido para eliminar");
                return;
            }

            using var mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            const string query = "DELETE FROM clientes WHERE Id = @Id";
            using var mySqlCommand = new MySqlConnector.MySqlCommand(query, mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@Id", cE.Id);

<<<<<<< HEAD
            int rows = mySqlCommand.ExecuteNonQuery(); // Ejecuta la eliminación.

            // Muestra si el registro fue eliminado o no se encontró.
=======
            int rows = mySqlCommand.ExecuteNonQuery();
>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
            if (rows > 0)
                MessageBox.Show("Registro Eliminado");
            else
                MessageBox.Show("No se encontró registro con ese Id");
        }
<<<<<<< HEAD

        // Obtiene los registros de la tabla "clientes" y los devuelve en un DataSet.
        public DataSet Listar()
        {
            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            string Query = "SELECT * FROM `clientes` LIMIT 1000;"; // Consulta SQL.
=======
        public DataSet Listar()
        {

            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes` LIMIT 1000;";
>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
            MySqlConnector.MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlConnector.MySqlDataAdapter(Query, mySqlConnection);
<<<<<<< HEAD
            Adaptador.Fill(dataSet, "tbl"); // Carga los datos en el DataSet.

            return dataSet; // Retorna el conjunto de datos.
        }
    }
}

=======
            Adaptador.Fill(dataSet, "tbl");
            return dataSet;
        }

    }
}







>>>>>>> 61246a6a105bd9b038391f074f85cbb19d887f43
