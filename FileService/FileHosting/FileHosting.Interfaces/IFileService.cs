using System;
using System.IO;
using System.ServiceModel;
using FileHosting.Interfaces.DataModels;


namespace FileHosting
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        DateTime GetServiceTime();

        [OperationContract]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);

        [OperationContract]
        int StartProcess(string Path, string Args);

        [OperationContract]
        Department[] GetDep();
    }

}
