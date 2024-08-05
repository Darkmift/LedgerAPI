using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LedgerAPI.Models;

namespace LedgerAPI.Data
{
    public class LedgerAPIContext : DbContext
    {
        public LedgerAPIContext (DbContextOptions<LedgerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LedgerAPI.Models.User> User { get; set; } = default!;
    }
}
