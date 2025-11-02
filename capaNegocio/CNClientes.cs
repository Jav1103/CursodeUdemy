using System;
using System.Windows.Forms;
using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNClientes
        
     
    {
        public CNClientes()
        {
        }
         CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CEClientes clientes)

        {
            bool Resultado = true;
            if (clientes.Nombre == string.Empty)
            {
                Resultado = false;

                MessageBox.Show("El nombre es obligatorio");
            }
            if (clientes.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Apellido es obligatorio");
            }
            if (clientes.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }


            return Resultado;
        }


        public void PruebaMysql()
        {
            cDCliente.PruebaConexion();
    }

        public void CrearCliente(CEClientes cE)
        {
            cDCliente.Crear(cE);
        }
        public void EditarCliente(CEClientes cE)
        {
            cDCliente.Editar(cE);
        }
        public void EliminarCliente(CEClientes cE)
        {
            cDCliente.Eliminar(cE);
        }
        public DataSet ObtenerDatos()
                    {
            return cDCliente.Listar();
        }
     

        
    }
}