namespace GenericEfRepository.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    using GenericEfRepository.Tests.TestData;

    public class TestEntityStore
    {
        public TestEntityStore()
        {
            this.Store = new List<TestEntity>();
        }

        private IList<TestEntity> Store { get; set; } 
    }
}