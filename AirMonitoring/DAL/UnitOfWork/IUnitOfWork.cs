using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Interfaces;

namespace Catalog.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStationRepository Stations { get; }
        IRegionRepository Regions { get; }
        void Save();
    }
}
