using System.ComponentModel.DataAnnotations;

namespace Egas_Montalvo_Proyecto_Final.Models
{
    public class Pago
    {

        [Key]
        public int Id { get; set; }
        public int TransaccionId { get; set; }
        public Transaccion Transaccion { get; set; }
        public string MetodoPago { get; set; } // Tarjeta, PayPal, etc.
        public string Estado { get; set; } // Procesando, Completado, Reembolsado
        public DateTime Fecha { get; set; }

    }
}
