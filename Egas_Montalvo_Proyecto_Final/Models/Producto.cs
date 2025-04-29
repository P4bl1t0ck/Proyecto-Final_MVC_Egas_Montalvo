using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Producto
    {

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public int CantidadEnInventario { get; set; }



        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Usuario Proveedor { get; set; }

    }
}
