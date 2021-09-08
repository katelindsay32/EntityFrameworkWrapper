using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace EntityFrameworkWrapperTest
{
    [TestClass]
    public class WorkerTest
    {
        private Mock<IDbContextFactory> contextFactory;

        [TestInitialize]
        public void Setup()
        {
            contextFactory = new Mock<IDbContextFactory>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Worker worker = new Worker(contextFactory.Object);
            Mock<EntityContext> dbContext = new Mock<EntityContext>();
            contextFactory.Setup(f => f.GetDbContext()).Returns(dbContext.Object);

            Entity2 entity2 = new Entity2()
            {
                Entity3 = new Entity3()
                {
                    Entity3Name = "kate"
                },
                Entity2Id = 10,
                Entity2Name = "entity2"
            };

            dbContext.Setup(f => f.Entity2).Returns(new List<Entity2>() { entity2 }.ToMockSet().Object);
            var test2 = dbContext.Object.Entity2.Include(f => f.Entity3);
            var test3 = dbContext.Object.Entity2;
            var test = worker.Work();
            Assert.IsNotNull(test);
            Assert.AreEqual("kate", test.Entity3.Entity3Name);
        }


        [TestMethod]
        public void TestMethod2()
        {
            IDbContext fakeContext = (IDbContext) new FakeDbContext();
            contextFactory.Setup(f => f.GetDbContext()).Returns(fakeContext);
            var worker2 = new Worker(contextFactory.Object);

            Entity2 entity2 = new Entity2()
            {
                Entity3 = new Entity3()
                {
                    Entity3Name = "kate"
                },
                Entity2Id = 10,
                Entity2Name = "entity2"
            };
            fakeContext.Entity2.Add(entity2);
            var test = worker2.Work();
            Assert.IsNotNull(test);
            Assert.AreEqual("kate", test.Entity3.Entity3Name);
        }

        [TestMethod]
        public void TestMethod3()
        {
            IDbContext fakeContext = (IDbContext)new FakeDbContext();
            contextFactory.Setup(f => f.GetDbContext()).Returns(fakeContext);
            var worker2 = new Worker(contextFactory.Object);

            Entity2 entity2 = new Entity2()
            {
                Entity3Id = 11,
                Entity2Id = 10,
                Entity2Name = "entity2"
            };

            Entity3 entity3 = new Entity3()
            {
                Entity3Id = 11,
                Entity3Name = "kate"
            };
            fakeContext.Entity2.Add(entity2);
            fakeContext.Entity3.Add(entity3);
            var test = worker2.Work();
            Assert.IsNotNull(test);
            Assert.AreEqual("kate", test.Entity3.Entity3Name);
        }
    }
}
