using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataBaseTest.Data;
using Organization.ViewModels;
using Organization.Models;

namespace Organization
{
    /// <summary>
    /// Логика взаимодействия для NewDep.xaml
    /// </summary>
    public partial class NewDep : Window
    {
        public NewDep()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OrgDB())
            {
                Department Department = new Department();

                Department.NameDep = TetxDep.Text;
                db.Departments.Add(Department);
                db.SaveChanges();
            }
            MessageBox.Show("Подразделение добавлено");
        }
    }
}
