using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Models
{
    public class ArgusContext : DbContext
    {
        public ArgusContext (DbContextOptions<ArgusContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication10.Models.ArgusModel> ArgusModel { get; set; }
    }
}
