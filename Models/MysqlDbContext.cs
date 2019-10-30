using Microsoft.EntityFrameworkCore;

namespace Tercer_Parcial.Models
{
    public class MysqlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=admin_library;password=123;port=3306;dbname=uadeo_library");
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
        }
    }
}