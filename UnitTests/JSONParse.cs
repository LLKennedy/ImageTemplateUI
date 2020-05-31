using NUnit.Framework;
using ImageTemplate.File.Raw;
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
            string data = @"{""BaseImage"":{""BaseColour"":{""R"":""3""}}}";
            TopLevel o = new TopLevel(data);
            Assert.AreEqual(new BaseImage() { BaseColour = new BaseImage.RGBA() { R = "3" } }, o.BaseImage);
        }
    }
}