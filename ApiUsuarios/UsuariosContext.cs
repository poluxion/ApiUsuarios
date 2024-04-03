using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ApiUsuarios.Models
{
    public partial class UsuariosContext : IdentityDbContext
    {
        public UsuariosContext()
        {
        }

        public UsuariosContext(DbContextOptions<UsuariosContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Personas> Personas { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                   .HasName("PK_Personas");

                entity.Property(e => e.Identificador)
                    .HasColumnName("Identificador")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.ToTable("Personas");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .HasColumnName("Nombres");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .HasColumnName("Apellidos");

                entity.Property(e => e.NumeroIdentificacion)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(11)
                    .HasColumnName("NumeroIdentificacion");

                entity.Property(e => e.Email)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(50)
                    .HasColumnName("Email");

                entity.Property(e => e.TipoIdentificacion)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(20)
                    .HasColumnName("TipoIdentificacion");

                entity.Property(e => e.FechaCrecion)
                    .HasColumnType("nvarchar")                    
                    .HasColumnName("FechaCreacion");

            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                   .HasName("PK_Usuario")
                   .IsClustered(false);

                entity.Property(e => e.Identificador)
                    .HasColumnName("Identificador")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.ToTable("Usuario");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(25)
                    .HasColumnName("Usuario");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnType("varbinary")
                    .HasMaxLength(15)
                    .HasColumnName("Pass");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("nvarchar")
                    .HasColumnName("FechaCreacion");
            });
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
