using System.Windows;
using OrgDBClient.Services;
using System.ServiceModel;

namespace OrgDBClient

{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClientOrgDB client = new ClientOrgDB(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/OrgDBHost"));
            var DepartmentList = client.GetDepartments();
            
        }
    }
}
