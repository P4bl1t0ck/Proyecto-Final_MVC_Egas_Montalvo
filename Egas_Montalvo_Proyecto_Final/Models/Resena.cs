using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Resena
    {

        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Calificacion { get; set; } 
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

    }
}
