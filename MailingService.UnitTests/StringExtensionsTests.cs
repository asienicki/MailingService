using FluentAssertions;
using MailingService.ClientExpectations;
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
    }
}