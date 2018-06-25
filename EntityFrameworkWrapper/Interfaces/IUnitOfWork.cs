﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Interfaces
{
    public interface IUnitOfWork : IRepositoryFactory, IDisposable
    {
        void SaveChanges();
    }
}
