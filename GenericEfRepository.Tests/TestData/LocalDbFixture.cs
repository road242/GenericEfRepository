namespace GenericEfRepository.Tests.TestData
{
    public class LocalDbFixture
    {
        public LocalDbFixture()
        {
            this.Context = new TestContext();
        }

        public TestContext Context { get; set; }
    }
}