using Catalog.DAL.UnitOfWork;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StationContext db;
        private StationRepository stationRepository;
        private RegionRepository regionRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new StationContext(options);
        }


        public IStationRepository Stations
        {
            get
            {
                if (stationRepository == null)
                    stationRepository = new StationRepository(db);
                return stationRepository;
            }
        }

        public IRegionRepository Regions
        {
            get
            {
                if (regionRepository == null)
                    regionRepository = new RegionRepository(db);
                return regionRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}