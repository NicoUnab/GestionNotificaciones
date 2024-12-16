using GestionNotificaciones.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionNotificaciones.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vecino> Vecinos { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<EstadoReporte> EstadosReporte { get; set; }
        public DbSet<TipoReporte> TiposReporte { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Vecino y su relación con Usuario
            modelBuilder.Entity<Vecino>()
                .HasOne(v => v.Usuario)
                .WithOne()
                .HasForeignKey<Vecino>(v => v.id); // FK = PK
            modelBuilder.Entity<Notificacion>()
                .HasOne(n => n.Reporte)
                .WithMany()
                .HasForeignKey(n => n.idReporte);
            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.HasOne(r => r.Vecino)
                      .WithMany()
                      .HasForeignKey(r => r.idVecino); // Define clave foránea

                entity.HasOne(r => r.Estado)
                      .WithMany()
                      .HasForeignKey(r => r.idEstado);

                entity.HasOne(r => r.Tipo)
                      .WithMany()
                      .HasForeignKey(r => r.idTipo);

            });
            //modelBuilder.Entity<Notificacion>()
            //    .HasOne(n => n.Destinatario)
            //    .WithMany()
            //    .HasForeignKey(n => n.idVecino);
        }
    }
}
