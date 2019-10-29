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
    }
}