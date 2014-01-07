namespace GenericEfRepository.Tests
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.Remoting.Proxies;

    using GenericEfRepository.Tests.Helper;
    using GenericEfRepository.Tests.TestData;

    using Xunit;

    public class RepositoryTests : IUseFixture<LocalDbFixture>
    {
        #region Public Properties

        public TestContext Context { get; set; }

        private IRepository<TestEntity> Repository { get; set; }
        #endregion

        public RepositoryTests()
        {
            
        }

        [Fact]
        public void Add()
        {
            var entity = this.AddTestEntity();
            Assert.True(entity.Id != 0);

            entity.DebugPrint();
        }

        private TestEntity AddTestEntity()
        {
            var entity = new TestEntity() { Property1 = "Custom Property 1", Property2 = "Custom Property 2" };
            this.Repository.Add(entity);
            this.Context.SaveChanges();
            return entity;
        }

        [Fact]
        public void AddAndDelete()
        {
            var entity = this.AddTestEntity();
            Assert.True(entity.Id != 0);

            entity.DebugPrint();

            this.Repository.Delete(entity);
            this.Context.SaveChanges();

            entity = this.Repository.GetById(entity.Id);
            Assert.Null(entity);
        }

        [Fact]
        public void AddAndDeleteById()
        {
            var entity = this.AddTestEntity();
            Assert.True(entity.Id != 0);

            entity.DebugPrint();

            this.Repository.Delete(entity.Id);
            this.Context.SaveChanges();

            entity = this.Repository.GetById(entity.Id);
            Assert.Null(entity);
        }

        [Fact]
        public void GetById()
        {
            var entity = this.Repository.GetById(1);
            Assert.NotNull(entity);
            Assert.False(string.IsNullOrEmpty(entity.Property1));
            Assert.False(string.IsNullOrEmpty(entity.Property2));

            entity.DebugPrint();
        }
        
        [Fact]
        public void GetAll()
        {
            var entities = this.Repository.GetAll();
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);

            foreach (var entity in entities)
            {
                Assert.False(string.IsNullOrEmpty(entity.Property1));
                Assert.False(string.IsNullOrEmpty(entity.Property2));
                entity.DebugPrint();
            }
        }

        public void SetFixture(LocalDbFixture data)
        {
            this.Context = data.Context;
            this.Repository = new Repository<TestEntity>(this.Context);
        }
    }
}