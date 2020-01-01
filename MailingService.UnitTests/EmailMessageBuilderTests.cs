using System.Threading.Tasks;
using FluentAssertions;
using MailingService.ClientExpectations;
using MailingService.ExternalLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailingService.UnitTests
{
    [TestClass]
    public class EmailMessageBuilderTests
    {
        [TestMethod]
        public async Task PrepareEmailMessageTest()
        {
            //Arrange
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

            var base64String = await sampleModel.SerializeAndEncode();

            var sut = new EmailMessageBuilder();

            //Act
            var result = await sut.PrepareEmailMessage(base64String);

            //Assert
            result.Content.Should().Be("Hello, Fake description.. Welcome to RazorLight repository");
        }

    }
}