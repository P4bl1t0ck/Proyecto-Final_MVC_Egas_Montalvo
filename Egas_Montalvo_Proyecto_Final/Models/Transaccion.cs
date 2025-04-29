using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Transaccion
    {

        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } // Pendiente, Completada, Cancelada

        // Relación uno a muchos con Pago
        public Pago Pago { get; set; }

    }
}
