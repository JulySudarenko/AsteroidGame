using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using OrgDBHosting.Services;
using OrgDBHosting.Interface;


namespace OrgDBHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(OrgDBHost),
                new Uri("http://localhost:8080/OrgDBHost"), // netsh http add urlacl url=http://+:{номер порта}/ user=\{имя пользователя}
                new Uri("net.tcp://localhost/OrgDBHost"),   // netsh advfirewall firewall add rule name=\"{rule_name}\" dir=in action=allow protocol=TCP localport={port}
                new Uri("net.pipe://localhost/OrgDBHost")
                );

            host.AddServiceEndpoint(
                typeof(IOrgDB),
                new BasicHttpBinding(),
                "http://localhost:8080/OrgDBHost");

            host.AddServiceEndpoint(
                typeof(IOrgDB),
                new NetTcpBinding(),
                "net.tcp://localhost/OrgDBHost");

            host.AddServiceEndpoint(
                typeof(IOrgDB),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/OrgDBHost");

            host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");

            host.Open();

            Console.WriteLine("Хост запущен успешно!");
            Console.ReadLine();
        }
    }
}
