using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Organization;


namespace Organization
{
    /// <summary>
    /// Логика взаимодействия для NewEmploee.xaml
    /// </summary>
    public partial class NewEmploee : Window
    {

        public NewEmploee(List<Employee> AllEmployees, List<Department> AllDepartments)
        {
            InitializeComponent();
            FillComboDox(AllDepartments);
        }


        void FillComboDox(List<Department> AllDepartments)
        {
            DepComboBox.ItemsSource = AllDepartments;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            //AllEmployees.Add(new Employee());
            MessageBox.Show("Сотрудник добавлен");
        }
    }
}
