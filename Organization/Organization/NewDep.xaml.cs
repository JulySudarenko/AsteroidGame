using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Organization
{
    /// <summary>
    /// Логика взаимодействия для NewDep.xaml
    /// </summary>
    public partial class NewDep : Window
    {
        public NewDep(List<Department> AllDepartments)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AllDepartments.Add(new Department(AllDepartments.Count, ))
            MessageBox.Show("Подразделение добавлено");
        }
    }
}
