using capaEntidad;
using capaNegocio;
namespace capaPresentacion
{
    public partial class ftClientes : Form
    {
        public ftClientes() => InitializeComponent();

        CNClientes cNClientes = new CNClientes();
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }
        private void LimpiarForm()
            {
            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            picFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;

            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }
            ofdFoto.FileName = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado;
            CEClientes cEClientes = new CEClientes();
            cEClientes.Id = (int)txtId.Value;
            cEClientes.Nombre = txtNombre.Text;
            cEClientes.Apellido = txtApellido.Text;
            cEClientes.Foto = picFoto.ImageLocation;

            Resultado = cNClientes.ValidarDatos(cEClientes);
            if (Resultado == false)
            {
                return;

            }

            if (cEClientes.Id == 0)
            {
                cNClientes.CrearCliente(cEClientes);
            }
            else
            {
                cNClientes.EditarCliente(cEClientes);

            }


            CargarDatos();
            LimpiarForm();


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0)
            {
                return;
            }
            if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                CEClientes cE = new CEClientes();
                cE.Id = (int)txtId.Value;
                cNClientes.EliminarCliente(cE); 
                CargarDatos();
                LimpiarForm();
            }
           
        }

        private void ftClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNClientes.ObtenerDatos().Tables["tbl"];
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["Id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["Apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["Foto"].Value.ToString());

        }
    }
}


