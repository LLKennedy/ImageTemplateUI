using NUnit.Framework;
using ImageTemplate.File.Raw;
using Newtonsoft.Json;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseJSON()
        {
            string data = @"{""baseImage"":{""baseColour"":{""R"":""3""}}}";
            TopLevel o = JsonConvert.DeserializeObject<TopLevel>(data);
            var backToJSON = JsonConvert.SerializeObject(o, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,

            });
            Assert.AreEqual(data, backToJSON);
        }
    }
}