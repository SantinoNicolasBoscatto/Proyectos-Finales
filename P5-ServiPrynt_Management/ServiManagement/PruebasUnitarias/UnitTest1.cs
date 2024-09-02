namespace PruebasUnitarias
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Pruebas()
        {
            var service = "dfs";
            if(string.IsNullOrEmpty(service)) Assert.Fail();
        }
    }
}