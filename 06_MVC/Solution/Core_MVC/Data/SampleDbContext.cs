using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core_MVC.Models.SampleViewModels;

namespace Core_MVC.Models
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext (DbContextOptions<SampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Core_MVC.Models.SampleViewModels.SampleViewModel> SampleViewModel { get; set; }
    }
}
