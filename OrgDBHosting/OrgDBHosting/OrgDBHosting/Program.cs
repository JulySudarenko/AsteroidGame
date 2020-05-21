using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using OrgDBHosting.Services;
using OrgDBHosting.Interface.Data.Entity;
using OrgDBHosting.Interface.Data;
using OrgDBHosting.Interface;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace OrgDBHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //        var host = new ServiceHost(typeof(OrgDBHost),
            //new Uri("http://localhost:8080/OrgDBHosting"), // netsh http add urlacl url=http://+:{номер порта}/ user=\{имя пользователя}
            //new Uri("net.tcp://localhost/OrgDBHosting"),   // netsh advfirewall firewall add rule name=\"{rule_name}\" dir=in action=allow protocol=TCP localport={port}
            //new Uri("net.pipe://localhost/OrgDBHosting")
            //);

            //        host.AddServiceEndpoint(
            //            typeof(OrgDBHost),
            //            new BasicHttpBinding(),
            //            "http://localhost:8080/OrgDBHosting");

            //        host.AddServiceEndpoint(
            //            typeof(OrgDBHost),
            //            new NetTcpBinding(),
            //            "net.tcp://localhost/OrgDBHosting");

            //        host.AddServiceEndpoint(
            //            typeof(OrgDBHost),
            //            new NetNamedPipeBinding(),
            //            "net.pipe://localhost/OrgDBHosting");

            //        host.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });

            //        host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            //        host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            //        host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");

            //        host.Open();
            GetObjectData();

            Console.ReadLine();
        }

        //public static void GetDepartments()
        //{
        //    var xml_serializer = new XmlSerializer(typeof(Department));
        //    List<Department> deplist = new List<Department>();
        //    using (var db = new OrgDB())
        //    {
        //        var alldep = db.Departments;
        //        foreach (var department in alldep)
        //            deplist.Add(department);
        //    }
        //    using (var xml_file = File.Create("department.xml"))
        //    {
        //        foreach (var d in deplist)
        //            xml_serializer.Serialize(xml_file, d);
        //    }
        //}

        
    }
}
