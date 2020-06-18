using System;
using System.Collections.Generic;
using BBL.DTO;
using BBL.Services.Interfaces;
using Catalog.DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using AutoMapper;
using DAL.Entities;

namespace BBL.Services.Impl
{
    public class RegionService
        : IRegionService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
        
        public RegionService( IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
        
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<RegionDTO> GetRegions(int stationId, int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Worker))
            {
                throw new MethodAccessException();
            }
            
            var regionsEntities =
                _database
                    .Regions
                    .Find(z => z.Station.StationID == stationId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Region, RegionDTO>()
                    ).CreateMapper();
            var regionsDto =
                mapper
                    .Map<IEnumerable<Region>, List<RegionDTO>>(
                        regionsEntities);
            return regionsDto;
        }
    }
}
