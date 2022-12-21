using Microsoft.EntityFrameworkCore;

namespace CloudFiles.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        DbSet<UserFile> _usersFiles { get; set; }
    }
}
