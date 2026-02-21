using Microsoft.EntityFrameworkCore;

namespace ERP_Demo.Models.DATABASEFOLDER
{
    public class SchoolDB : DbContext
    {
        public SchoolDB(DbContextOptions<SchoolDB> options) : base(options)
        {

        }

        public DbSet<Student> student { get; set; }
    }
}
