using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueBackend.models;

namespace VueBackend.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public static object task { get; internal set; }
        public static object item { get; internal set; }
        public DbSet<item> Items { get; set; }
    }
}
