using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class StationContext
           : DbContext
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Region> Regions { get; set; }

        public StationContext(DbContextOptions options)
            : base(options)
        {
        }

    }
   
}
