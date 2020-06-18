using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBL.Services.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<RegionDTO> GetRegions(int stationId, int pageSize);
    }
   
}
