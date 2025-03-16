using LifeMakers.Models;
using Microsoft.EntityFrameworkCore;
namespace LifeMakers.dbcontexts
{
    public class DbContexting : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LEVASCH-STD052;Database=lifemakersDB;Integrated Security=True;Trust Server Certificate=True");
        }

       public DbSet<LifeMaker> LifeMaker {  get; set; }

    }
}
