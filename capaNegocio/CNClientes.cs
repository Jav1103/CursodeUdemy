// Importación de espacios de nombres.
using System;
using System.Windows.Forms; // Permite mostrar mensajes en ventanas emergentes (MessageBox).
using capaEntidad; // Accede a las clases de entidades (como CEClientes).
using capaDatos; // Permite utilizar las clases de la capa de datos (como CDCliente).
using System.Data; // Proporciona acceso a estructuras de datos como DataSet.

namespace capaNegocio // Espacio de nombres correspondiente a la capa de negocio.
{
    // Clase que representa la capa de negocio para la gestión de clientes.
    // Aquí se valida la información y se comunican las capas de presentación y datos.
    public class CNClientes
    {
        // Constructor vacío de la clase (no realiza acciones al crear el objeto).
        public CNClientes()
        {
        }

        // Instancia de la clase CDCliente para acceder a los métodos de la capa de datos.
        CDCliente cDCliente = new CDCliente();

        // MÉTODO: Valida los datos del cliente antes de ser enviados a la base de datos.
        public bool ValidarDatos(CEClientes clientes)
        {
            bool Resultado = true; // Variable para almacenar si la validación es correcta.

            // Verifica que el nombre no esté vacío.
            if (clientes.Nombre == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre es obligatorio");
            }

            // Verifica que el apellido no esté vacío.
            if (clientes.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Apellido es obligatorio");
            }

            // Verifica que la foto no sea nula (no se haya agregado una imagen).
            if (clientes.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }

            // Devuelve true si todo es válido, false si hay errores.
            return Resultado;
        }

        // MÉTODO: Prueba la conexión con la base de datos MySQL.
        public void PruebaMysql()
        {
            cDCliente.PruebaConexion();
        }

        // MÉTODO: Envía la solicitud de creación de un cliente a la capa de datos.
        public void CrearCliente(CEClientes cE)
        {
            cDCliente.Crear(cE);
        }

        // MÉTODO: Envía la solicitud de edición de un cliente a la capa de datos
        public void EditarCliente(CEClientes cE)
        {
            cDCliente.Editar(cE);
        }

        // MÉTODO: Envía la solicitud de eliminación de un cliente a la capa de datos
        public void EliminarCliente(CEClientes cE)
        {
            cDCliente.Eliminar(cE);
        }

        // MÉTODO: Obtiene los datos de los clientes desde la base de datos.
        public DataSet ObtenerDatos()
        {
            return cDCliente.Listar();
        }
    }
}

