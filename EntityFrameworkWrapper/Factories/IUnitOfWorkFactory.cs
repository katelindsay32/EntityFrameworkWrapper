using EntityFrameworkWrapper.Implementations;
using EntityFrameworkWrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
    namespace Implementation
    {
        public class UnitOfWorkFactoryImpl : IUnitOfWorkFactory
        {
            private readonly IDbContextFactory DbContextFactory;
            public UnitOfWorkFactoryImpl(IDbContextFactory factory)
            {
                DbContextFactory = factory;
            }
            public IUnitOfWork GetUnitOfWork()
            {
                return new UnitOfWork(DbContextFactory.Create());
            }
        }
    }
}
