using EntityFrameworkWrapper.Entities;
using EntityFrameworkWrapper.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper
{
    public class Worker
    {
        private readonly IEntityContextWrapper _contextWrapper;
        private readonly IUnitOfWorkFactory _uowFactory;
        public Worker(IEntityContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        public Worker(IUnitOfWorkFactory uowFactory)
        {
            _uowFactory = uowFactory;
        }


        public void DoWork()
        {
            using (var uow = _uowFactory.GetUnitOfWork())
            {
                var test = uow.RepositoryOf<Entity1>().FindAll().Where(f => f.EntityId == 1);
            }
        }

        public void DoWork2()
        {
            using (var context = _contextWrapper.GetDbContext())
            {
                var test = context.Entity1.Where(f => f.EntityId == 1);
            }
        }
    }
}
