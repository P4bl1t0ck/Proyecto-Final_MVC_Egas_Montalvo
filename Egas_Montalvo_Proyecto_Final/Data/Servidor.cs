using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Egas_Montalvo_Proyecto_Final.Models;

    public class Servidor : DbContext
    {
        public Servidor (DbContextOptions<Servidor> options)
            : base(options)
        {
        }

        public DbSet<Egas_Montalvo_Proyecto_Final.Models.Usuario> Usuario { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.Pago> Pago { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.Producto> Producto { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.Resena> Resena { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.Transaccion> Transaccion { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.Soporte> Soporte { get; set; } = default!;

public DbSet<Egas_Montalvo_Proyecto_Final.Models.TrasaccionProducto> TrasaccionProducto { get; set; } = default!;
    }
