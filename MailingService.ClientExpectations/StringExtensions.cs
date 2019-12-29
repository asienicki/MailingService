using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace MailingService.ClientExpectations
{
    public static class StringExtensions
    {
        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static async Task<string> SerializeToJsonString(this object model)
        {
            await using var output = new StringWriter();

            JSON.Serialize(model, output);

            return output.ToString();
        }

        public static async Task<string> SerializeAndEncode(this object model)
        {
            return Base64Encode(await SerializeToJsonString(model));
        }
    }
}