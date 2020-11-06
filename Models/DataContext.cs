using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieCsvApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base()
        { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Metadata> Metadata { get; set; }
        public DbSet<Stats> Stats { get; set; }
    }
}
