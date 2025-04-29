using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class TrasaccionProducto
    {

        [Key]
        public int Id { get; set; }
        public int TransaccionId { get; set; }
        public Transaccion Transaccion { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
