using System.Composition.Hosting;
using System.IO;
using System.Reflection;
using MailingService.ClientExpectations;

namespace MailingService.RestApi
{
    public class MefHelper : IMefHelper
    {
        public IEmailMessageBuilder GetEmailMessageBuilderByName(string assemblyName)
        {
            var executableLocation = Assembly.GetEntryAssembly()?.Location;

            //TODO: Directory path for plugins should be in configuration
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins", "netcoreapp3.1", assemblyName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            var assembly = Assembly.LoadFrom(path);

            var configuration = new ContainerConfiguration()
                .WithAssembly(assembly);

            using var container = configuration.CreateContainer();

            return container.GetExport<IEmailMessageBuilder>();
        }
    }
}