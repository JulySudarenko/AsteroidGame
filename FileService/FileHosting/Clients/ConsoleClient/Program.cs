﻿using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using FileHosting;
using FileHosting.Interfaces;
using FileHosting.Interfaces.DataModels;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FileServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/FileService"));

            var files = client.GetFiles("C:\\Users");

            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
            }

            client.StartProcess("calc", "");

            var dep = client.GetDep();

            foreach (var d in dep)
                Console.WriteLine(d);

            Console.ReadLine();
        }
    }

    class FileServiceClient : ClientBase<IFileService>, IFileService
    {
        public FileServiceClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint) { }

        public DateTime GetServiceTime() => Channel.GetServiceTime();

        public DriveInfo[] GetDrives() => Channel.GetDrives();

        public FileInfo[] GetFiles(string Path) => Channel.GetFiles(Path);

        public DirectoryInfo[] GetDirectories(string Path) => Channel.GetDirectories(Path);

        public int StartProcess(string Path, string Args) => Channel.StartProcess(Path, Args);

        public Department[] GetDep() => Channel.GetDep();

    }


}
