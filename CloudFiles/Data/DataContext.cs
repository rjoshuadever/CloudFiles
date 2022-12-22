using CloudFiles.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudFiles.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<UserFile> UserFiles { get; set; }
    }
}
