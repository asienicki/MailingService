using System.Threading.Tasks;
using FluentAssertions;
using MailingService.ClientExpectations;
using MailingService.ExternalLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailingService.UnitTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Base64EncodeTest()
        {
            var @string = "test";

            var base64String = @string.Base64Encode();

            base64String.Should().Be("dGVzdA==");
        }

        [TestMethod]
        public void Base64DecodeTest()
        {
            var @string = "dGVzdA==";

            var base64String = @string.Base64Decode();

            base64String.Should().Be("test");
        }

        [TestMethod]
        public async Task SerializeToJsonStringTest()
        {
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

            var jsonString = await sampleModel.SerializeToJsonString();

            var expected = "{\"Description\":\"Fake description.\"}";

            jsonString.Should().Be(expected);
        }

        [TestMethod]
        public async Task SerializeAndEncodeTest()
        {
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

            var base64String = await sampleModel.SerializeAndEncode();

            base64String.Should().Be("eyJEZXNjcmlwdGlvbiI6IkZha2UgZGVzY3JpcHRpb24uIn0=");
        }
    }
}