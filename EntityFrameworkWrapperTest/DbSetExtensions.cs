using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace EntityFrameworkWrapperTest
{
    public static class DbSetExtensions
    {
        public static Mock<DbSet<T>> ToMockSet<T>(this List<T> list) where T : class
        {
            var data = list.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            return mockSet;
        }
    }
}
