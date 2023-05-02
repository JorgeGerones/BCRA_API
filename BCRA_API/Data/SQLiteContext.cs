using BCRA_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BCRA_API.Data
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movimientos> Movimientos { get; set; } = default!;
    }
}
