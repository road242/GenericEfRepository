namespace GenericEfRepository.Tests
{
    using System.Collections.Generic;

    using GenericEfRepository.Tests.TestData;

    using Xunit;

    public class ObjectDataFixture
    {
        public ObjectDataFixture()
        {
            
        }

        public IList<TestEntity> ObjectStore { get; set; }
    }
}