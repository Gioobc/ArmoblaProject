using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ArmoblaProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Taller> Talleres { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Mueble> Muebles { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<MuebleTipo> MuebleTipos { get; set; }
        public DbSet<MuebleMat> MuebleMats { get; set; }
        public DbSet<Zona> Zonas { get; set; }
    }
}
