using capaEntidad;
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

        public void PruebaConexion()
        {
            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);

            try
            {
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

        public void Crear(CEClientes cE)
        {
            using var mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            const string query = "INSERT INTO clientes (Nombre, Apellido, Foto) VALUES (@Nombre, @Apellido, @Foto)";
            using var mySqlCommand = new MySqlConnector.MySqlCommand(query, mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);
            if (string.IsNullOrEmpty(cE.Foto))
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", DBNull.Value);
            }
            else
            {
                mySqlCommand.Parameters.AddWithValue("@foto", cE.Foto);
            }

            mySqlCommand.ExecuteNonQuery();
            MessageBox.Show("Registro Creado");
        }

        public void Editar(CEClientes cE)
        {
            using var mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();

            const string query = "UPDATE clientes SET Nombre = @Nombre, Apellido = @Apellido, Foto = @Foto WHERE Id = @Id";
            using var mySqlCommand = new MySqlConnector.MySqlCommand(query, mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@Nombre", cE.Nombre ?? string.Empty);
            mySqlCommand.Parameters.AddWithValue("@Apellido", cE.Apellido ?? string.Empty);
            if (string.IsNullOrEmpty(cE.Foto))
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", DBNull.Value);
            }
            else
            {
                mySqlCommand.Parameters.AddWithValue("@Foto", cE.Foto);
            }
            mySqlCommand.Parameters.AddWithValue("@Id", cE.Id);

            mySqlCommand.ExecuteNonQuery();
            MessageBox.Show("Registro Actualizado");
        }

        public void Eliminar(CEClientes cE)
        {
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

            int rows = mySqlCommand.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Registro Eliminado");
            else
                MessageBox.Show("No se encontró registro con ese Id");
        }
        public DataSet Listar()
        {

            MySqlConnector.MySqlConnection mySqlConnection = new MySqlConnector.MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes` LIMIT 1000;";
            MySqlConnector.MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlConnector.MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");
            return dataSet;
        }

    }
}







