using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Sample.Models
{
    public class EF_SampleContext : DbContext
    {
        public EF_SampleContext (DbContextOptions<EF_SampleContext> options)
            : base(options)
        {
        }

        public DbSet<EF_Sample.Models.SampleModel> SampleModel { get; set; }
    }
}
