using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pointofsale_Terminal.Models;

namespace Pointofsale_Terminal.Data
{
    public class Pointofsale_TerminalContext : DbContext
    {
		public Pointofsale_TerminalContext (DbContextOptions<Pointofsale_TerminalContext> options)
            : base(options)
        {
        }

        public DbSet<Pointofsale_Terminal.Models.ProductModel> ProductModel { get; set; } = default!;
    }
}
