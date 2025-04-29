using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Soporte
    {

        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string TipoSolicitud { get; set; } // Técnica, Comercial, etc.
        public string Descripcion { get; set; }
        public string Estado { get; set; } // Abierta, En Proceso, Cerrada
        public DateTime Fecha { get; set; }

    }
}
