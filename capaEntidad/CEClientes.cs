// Espacio de nombres donde se agrupan las clases de la capa de entidad (modelo de datos).
namespace capaEntidad
{
    // Clase que representa la entidad "Cliente" dentro del sistema.
    // Sirve como modelo para transferir datos entre las capas de la aplicación.
    public class CEClientes
    {
        // Propiedad que almacena el identificador único del cliente (clave primaria en la base de datos).
        public int Id { get; set; }

        // Propiedad que almacena el nombre del cliente.
        // El signo '?' indica que puede aceptar valores nulos.
        public string? Nombre { get; set; }

        // Propiedad que almacena el apellido del cliente.
        public string? Apellido { get; set; }

        // Propiedad que almacena la ruta o referencia de la foto del cliente.
        public string? Foto { get; set; }
    }
}
