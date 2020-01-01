namespace MailingService.RestApi
{
    using Domains.Impl;
    using System.Composition.Hosting;
    using System.IO;
    using System.Reflection;
    using ClientExpectations;
    using System.Diagnostics.CodeAnalysis;
    using Domains;

    [ExcludeFromCodeCoverage]
    public class MefHelper : IMefHelper
    {
        private readonly IMefConfiguration _mefConfiguration;

        public MefHelper(IMefConfiguration mefConfiguration)
        {
            _mefConfiguration = mefConfiguration;
        }

        public IEmailMessageBuilder GetEmailMessageBuilderByName(string assemblyName)
        {
            if (!File.Exists(_mefConfiguration.Path))
            {
                throw new FileNotFoundException(_mefConfiguration.Path);
            }

            var assembly = Assembly.Load(_mefConfiguration.Path);

            var configuration = new ContainerConfiguration()
                .WithAssembly(assembly);

            using var container = configuration.CreateContainer();

            return container.GetExport<IEmailMessageBuilder>();
        }
    }
}