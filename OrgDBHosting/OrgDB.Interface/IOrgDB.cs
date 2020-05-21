﻿using OrgDBHosting.Interface.Data.Entity;
using OrgDBHosting;
using System.ServiceModel;


namespace OrgDBHosting.Interface
{
    [ServiceContract]
    public interface IOrgDB
    {

        [OperationContract]
        void GetEmployees();

        [OperationContract]
        void GetDepartments();
    }
}
