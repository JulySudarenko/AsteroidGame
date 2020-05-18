using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataBaseTest.Data;
using Organization.Services;
using Organization;
using Organization.Models;

namespace Organization
{
    /// <summary>
    /// Логика взаимодействия для NewEmploee.xaml
    /// </summary>
    public partial class NewEmploee : Window
    {

        public NewEmploee()
        {
            InitializeComponent();
        }

        //void FillComboDox(List<string> AllDepartments)
        //{
        //    DepComboBox.ItemsSource = AllDepartments;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OrgDB())
            {
                Employee Employee = new Employee();

                Employee.Surname = TextSurname.Text;
                Employee.Name = TextName.Text;
                Employee.Patronymic = TextSurname.Text;
                //Employee.Salary = double.TryParse($"{TextSalary.Text}");
                //Employee.Department = DepComboBox.Text;
                db.Employees.Add(Employee);
                db.SaveChanges();
            }
            MessageBox.Show("Сотрудник добавлен");
        }
    }
}
