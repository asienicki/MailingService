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
            //Arrange
            var @string = "test";

            //Act
            var base64String = @string.Base64Encode();

            //Assert
            base64String.Should().Be("dGVzdA==");
        }

        [TestMethod]
        public void Base64DecodeTest()
        {
            //Arrange
            var @string = "dGVzdA==";

            var base64String = @string.Base64Decode();

            //Assert
            base64String.Should().Be("test");
        }

        [TestMethod]
        public async Task SerializeToJsonStringTest()
        {
<<<<<<< HEAD
            //Arrange
=======
>>>>>>> master
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

<<<<<<< HEAD
            var expected = "{\"Description\":\"Fake description.\"}";

            //Act
            var jsonString = await sampleModel.SerializeToJsonString();

            //Assert
=======
            var jsonString = await sampleModel.SerializeToJsonString();

            var expected = "{\"Description\":\"Fake description.\"}";

>>>>>>> master
            jsonString.Should().Be(expected);
        }

        [TestMethod]
        public async Task SerializeAndEncodeTest()
        {
<<<<<<< HEAD
            //Arrange
=======
>>>>>>> master
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

<<<<<<< HEAD
            //Act
            var base64String = await sampleModel.SerializeAndEncode();

            //Assert
=======
            var base64String = await sampleModel.SerializeAndEncode();

>>>>>>> master
            base64String.Should().Be("eyJEZXNjcmlwdGlvbiI6IkZha2UgZGVzY3JpcHRpb24uIn0=");
        }
    }
}