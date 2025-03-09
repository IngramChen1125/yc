

using Microsoft.EntityFrameworkCore;
using YC.Model;

namespace YC.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
