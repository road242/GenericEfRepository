namespace GenericEfRepository.Tests.TestData
{
    using System.Data.Entity;

    using GenericEfRepository.Tests.Migrations;

    public class TestContext : DbContext
    {
        static TestContext()
        {
            Database.SetInitializer<TestContext>(new DropCreateFillTestDataInitializer());
        }
        
        public DbSet<TestEntity> TestEntities { get; set; }
    }
}