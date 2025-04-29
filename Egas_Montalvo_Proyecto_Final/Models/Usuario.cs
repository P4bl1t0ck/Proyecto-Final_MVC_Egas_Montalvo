using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; } // Identificador único del usuario Asi pueden repetirse losnombres PERO no los ID
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string Direccion { get; set; }
        public string TipoUsuario { get; set; } // Puede ser "Cliente" o "Administrador"

    }
}
