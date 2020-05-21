using OrgDBHosting.Interface;
using OrgDBHosting.Interface.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace OrgDBClient.Services
{
    public class ClientOrgDB : ClientBase<IOrgDB>, IOrgDB
    {
        public ClientOrgDB(Binding binding, EndpointAddress endpoint) : base (binding, endpoint) { }
        public Department[] GetDepartments() => Channel.GetDepartments();

        //public Employee[] GetEmployees() => Channel.GetEmployees();
    }

}


