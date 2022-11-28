using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APagarReceber.Models;

namespace APagarReceber.Data
{
    public class APRContext : DbContext
    {
        public APRContext (DbContextOptions<APRContext> options)
            : base(options)
        {
        }

        public DbSet<APagarReceber.Models.Lancamento> Lancamento { get; set; } = default!;

        public DbSet<APagarReceber.Models.Conta> Conta { get; set; }
    }
}
