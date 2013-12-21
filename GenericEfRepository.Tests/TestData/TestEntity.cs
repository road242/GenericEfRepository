namespace GenericEfRepository.Tests.TestData
{
    using System.ComponentModel.DataAnnotations;

    public class TestEntity
    {
        [Key]
        public long Id { get; set; }

        public string Property1 { get; set; }
        
        public string Property2 { get; set; }

        public TestEntity()
        {
            Id = 0;
        }
    }
}