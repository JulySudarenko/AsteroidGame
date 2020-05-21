using OrgDBHosting.Interface.Data;
using System.Collections.Generic;
using System.ServiceModel;


namespace OrgDBHosting.Interface
{
    [ServiceContract]
    public interface IOrgDB
    {

        //[OperationContract]
        //void GetEmployees();

        [OperationContract]
        Department[] GetDepartments();
    }
}
