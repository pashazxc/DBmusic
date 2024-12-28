using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace musicDB.data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MusicDbContext>
    {
        public MusicDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicDb;Trusted_Connection=True;MultipleActiveResultSets=true"); 

            return new MusicDbContext(optionsBuilder.Options);
        }
    }
}
