namespace GenericEfRepository.Tests.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    using GenericEfRepository.Tests.TestData;

    internal sealed class DropCreateFillTestDataInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            context.TestEntities.AddOrUpdate(
                p => p.Id,
                new TestEntity()
                    {
                        Property1 = "Seeded obj 1 - Test Property 1", 
                        Property2 = "Seeded obj 1 - Test Property 2"
                    },
                new TestEntity()
                    {
                        Property1 = "Seeded obj 2 - Test Property 1", 
                        Property2 = "Seeded obj 2 - Test Property 2"
                    });
        }
    }
}
