using EntityFrameworkWrapper.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkWrapper.Factories
{
    public interface IDbContextFactory
    {
        DbContext Create();
    }

    namespace Implementation
    {
        public class DbContextFactory : IDbContextFactory
        {
            public DbContext Create()
            {
                string connectionString = "";
                var test = ConfigurationManager.AppSettings[""];
                var test2 = ConfigurationManager.ConnectionStrings[""];

                var context = CreateContext(connectionString);
                context.Configuration.AutoDetectChangesEnabled = true;
                context.Configuration.LazyLoadingEnabled = true;
                context.Configuration.ValidateOnSaveEnabled = true;
                return context;
            }

            private DbContext CreateContext(string connectionString)
            {
                var connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
                connection.ConnectionString = connectionString;

                return new DbContext(connection.ConnectionString);
            }
        }
    }
}
