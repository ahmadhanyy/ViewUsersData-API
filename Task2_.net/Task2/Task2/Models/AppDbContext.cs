using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Task2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> UsersTable { get; set; }
    }
}
