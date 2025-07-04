using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SchoolManagementSystem.Data
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();

            
            optionsBuilder.UseSqlServer("Server=.;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}
