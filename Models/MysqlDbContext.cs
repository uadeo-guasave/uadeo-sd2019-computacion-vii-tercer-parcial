using Microsoft.EntityFrameworkCore;

namespace Tercer_Parcial.Models
{
    public class MysqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=admin_library;password=123;port=3306;database=uadeo_library");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(autor =>
            {
                autor.ToTable("autores");
                autor.Property(a => a.Id).HasColumnName("id");
                autor.Property(a => a.Nombres).HasColumnName("nombres");
                autor.Property(a => a.Apellidos).HasColumnName("apellidos");

                autor.HasMany(a => a.LibrosAutores).WithOne(la => la.Autor);
            });

            modelBuilder.Entity<Editorial>(editorial =>
            {
                editorial.ToTable("editoriales");
                editorial.Property(e => e.Nombre).HasColumnName("nombre");
                editorial.Property(e => e.Telefono).HasColumnName("telefono");
                editorial.Property(e => e.Domicilio).HasColumnName("domicilio");
                editorial.Property(e => e.PaisDeOrigen).HasColumnName("pais_de_origen");

                editorial.HasMany(e => e.Libros).WithOne(l => l.Editorial);
            });

            modelBuilder.Entity<Libro>(libro =>
            {
                libro.ToTable("libros");
                libro.Property(l => l.Isbn).HasColumnName("isbn");
                libro.Property(l => l.Titulo).HasColumnName("titulo");
                libro.Property(l => l.Volumen).HasColumnName("volumen");
                libro.Property(l => l.Precio).HasColumnName("precio");

                libro.HasOne(l => l.Editorial).WithMany(e => e.Libros);
                libro.HasMany(l => l.LibrosAutores).WithOne(la => la.Libro);
            });

            modelBuilder.Entity<LibroAutor>(libroAutor =>
            {
                libroAutor.ToTable("libros_tiene_autores");
                libroAutor.Property(la => la.LibroId).HasColumnName("libro_id");
                libroAutor.Property(la => la.AutorId).HasColumnName("autor_id");
                libroAutor.HasKey(la => new { la.LibroId, la.AutorId });

                libroAutor.HasOne(la => la.Libro).WithMany(l => l.LibrosAutores);
                libroAutor.HasOne(la => la.Autor).WithMany(a => a.LibrosAutores);
            });

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.ToTable("usuarios");
                usuario.Property(u => u.Nombre).HasColumnName("nombre");
                usuario.Property(u => u.Contraseña).HasColumnName("contrasena");
                usuario.Property(u => u.CorreoElectronico).HasColumnName("correo_electronico");
                usuario.Property(u => u.Nombres).HasColumnName("nombres");
                usuario.Property(u => u.Apellidos).HasColumnName("apellidos");
                usuario.Property(u => u.RecordatorioDeContraseña).HasColumnName("recordatorio_de_contrasena");
                usuario.Property(u => u.Estado).HasColumnName("estado");
                usuario.Property(u => u.RolId).HasColumnName("rol_id");

                usuario.HasIndex(u => u.Nombre).IsUnique();
                usuario.HasIndex(u => u.CorreoElectronico).IsUnique();

                usuario.HasOne(u => u.Rol).WithMany(r => r.Usuarios);
            });

            modelBuilder.Entity<Rol>(rol =>
            {
                rol.ToTable("roles");
                rol.Property(r => r.Nombre).HasColumnName("nombre");

                rol.HasMany(r => r.Usuarios).WithOne(u => u.Rol);
                rol.HasMany(r => r.RolesPermisos).WithOne(rp => rp.Rol);
            });

            modelBuilder.Entity<Permiso>(permiso =>
            {
                permiso.ToTable("permisos");
                permiso.Property(p => p.Nombre).HasColumnName("nombre");
                permiso.Property(p => p.Descripcion).HasColumnName("descripcion");

                permiso.HasMany(p => p.RolesPermisos).WithOne(rp => rp.Permiso);
            });

            modelBuilder.Entity<RolPermiso>(rolPermiso =>
            {
                rolPermiso.ToTable("roles_tiene_permisos");
                rolPermiso.Property(rp => rp.RolId).HasColumnName("rol_id");
                rolPermiso.Property(rp => rp.PermisoId).HasColumnName("permiso_id");
                rolPermiso.HasKey(rp => new { rp.RolId, rp.PermisoId });

                rolPermiso.HasOne(rp => rp.Rol).WithMany(r => r.RolesPermisos);
                rolPermiso.HasOne(rp => rp.Permiso).WithMany(p => p.RolesPermisos);
            });

            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.ToTable("clientes");
                cliente.Property(c => c.Nombre).HasColumnName("nombre");
                cliente.Property(c => c.Apellidos).HasColumnName("apellidos");
                cliente.Property(c => c.Domicilio).HasColumnName("domicilio");
                cliente.Property(c => c.Telefono).HasColumnName("telefono");
                cliente.Property(c => c.CorreoElectronico).HasColumnName("correo_electronico");

                cliente.HasMany(c => c.Prestamos).WithOne(p => p.Cliente);
            });

            modelBuilder.Entity<Jornada>(jornada =>
            {
                jornada.ToTable("jornadas");
                jornada.Property(j => j.FechaDeApertura).HasColumnName("fecha_de_apertura");
                jornada.Property(j => j.FechaDeCierre).HasColumnName("fecha_de_cierre");
                jornada.Property(j => j.UsuarioId).HasColumnName("usuario_id");

                jornada.HasMany(j => j.Prestamos).WithOne(p => p.Jornada);
                jornada.HasOne(j => j.Usuario).WithMany(u => u.Jornadas);
            });

            modelBuilder.Entity<Prestamo>(prestamo =>
            {
                prestamo.ToTable("prestamos");
                prestamo.Property(p => p.FechaDeSalida).HasColumnName("fecha_de_salida");
                prestamo.Property(p => p.FechaDeRegreso).HasColumnName("fecha_de_regreso");
                prestamo.Property(p => p.ClienteId).HasColumnName("cliente_id");
                prestamo.Property(p => p.JornadaId).HasColumnName("jornada_id");

                prestamo.HasOne(p => p.Cliente).WithMany(c => c.Prestamos);
                prestamo.HasOne(p => p.Jornada).WithMany(j => j.Prestamos);
            });

            modelBuilder.Entity<PrestamoLibro>(prestamoLibro =>
            {
                prestamoLibro.ToTable("prestamos_tiene_libros");
                prestamoLibro.Property(pl => pl.PrestamoId).HasColumnName("prestamo_id");
                prestamoLibro.Property(pl => pl.LibroId).HasColumnName("libro_id");
                prestamoLibro.Property(pl => pl.Cantidad).HasColumnName("cantidad");
                prestamoLibro.HasKey(pl => new { pl.PrestamoId, pl.LibroId });

                prestamoLibro.HasOne(pl => pl.Prestamo).WithMany(p => p.PrestamosLibros);
                prestamoLibro.HasOne(pl => pl.Libro).WithMany(l => l.PrestamosLibros);
            });
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}