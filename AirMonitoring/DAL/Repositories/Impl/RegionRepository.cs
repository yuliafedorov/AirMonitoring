using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class RegionRepository
          : BaseRepository<Region>, IRegionRepository
    {
        internal RegionRepository(StationContext context)
            : base(context)
        {
        }
    }
  
}
