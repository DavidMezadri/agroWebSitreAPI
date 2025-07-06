using agroWebSitreAPI.Domain.Model.Analysis;
using agroWebSitreAPI.Domain.Model.FarmAggregate;
using agroWebSitreAPI.Domain.Model.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace agroWebSitreAPI.Infra
{
    public class ConnectionContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;"+
                "Port=5432;"+"Database=AgroWebSite;" +
                "User Id=user;"+
                "Password=123;"
                );
        
    }
}
