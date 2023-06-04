using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public static object? task { get; internal set; }
        public static object? item { get; internal set; }
        public DbSet<Item> Items { get; set; }
        public object Cars { get; internal set; }
    }
}
