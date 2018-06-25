﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> RepositoryOf<TEntity>() where TEntity : class;
    }
}
