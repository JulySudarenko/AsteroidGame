using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Organization;

//July Sudarenko
/// <summary> Lesson_6
/// Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), 
/// используя связывание данных, ListView, ObservableCollection и INotifyPropertyChanged.
/// 1.	Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
/// 2.	Для списка сотрудников и списка департаментов предусмотреть визуализацию(отображение). 
/// Это можно сделать, например, с использованием ComboBox или ListView.
/// 3.	Предусмотреть редактирование сотрудников и департаментов.
/// Должна быть возможность изменить департамент у сотрудника.
/// Список департаментов для выбора можно выводить в ComboBox, 
/// и все это можно выводить на дополнительной форме.
/// 4.	Предусмотреть возможность создания новых сотрудников и департаментов.
/// Реализовать данную возможность либо на форме редактирования, либо сделать новую форму.
/// </summary>
namespace Organization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }

        public static readonly List<Department> AllDepartments = CreateDepartment("..\\..\\Data\\Department.txt");
        public static readonly List<Employee> AllEmployees = FillDepartment("..\\..\\Data\\Employee.txt", AllDepartments);

        void FillList()
        {
            //for(int i=0; i< AllEmployees.Count; i++)
            //    items.Add(AllEmployees[i]);
            EmployerListBox.ItemsSource = AllEmployees;
            DepatmentListComboBox.ItemsSource = AllDepartments;
        }

        private static List<Department> CreateDepartment(string FileName)
        {
            List<Department> departments = new List<Department>();

            int n = 1;

            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var department = new Department();
                    department.Id = n++;
                    department.NameDep = line;
                    departments.Add(department);
                }
            }
            return departments;
        }


        private static List<Employee> FillDepartment(string FileName, List<Department> departments)
        {
            List<Employee> employees = new List<Employee>();


            var rnd = new Random();
            int n = 1;

            using (var file = File.OpenText(FileName))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var components = line.Split(' ');
                    if (components.Length != 3) continue;

                    var employee = new Employee();
                    employee.Id = n++;
                    employee.Surname = components[0];
                    employee.Name = components[1];
                    employee.Patronymic = components[2];
                    employee.Salary = rnd.Next(20, 300) * 1000;
                    employee.IdDepartment = rnd.Next(1, departments.Count);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        private void NewEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Organization.NewEmploee NewEmploee = new Organization.NewEmploee(AllEmployees, AllDepartments);
            //NewEmploee.ViewModel = "ViewModel";
            NewEmploee.Show();
            //NewEmploee.ShowViewModel();
            NewEmploee.Owner = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Organization.NewDep NewDep = new Organization.NewDep(AllDepartments);
            NewDep.Show();
            NewDep.Owner = this;
        }

        //private void SaveToFile(string FileName, List<Employee> employees, List<Department> departments)
        //{
        //    using (var file_writer = File.CreateText(FileName))
        //        for (int i = 0; i < employees.Count; i++)
        //        {
        //            file_writer.WriteLine(string.Join(",",
        //                employees[i].Id, employees[i].Surname, employees[i].Name, employees[i].Patronymic, employees[i].Salary,
                        
        //                string.Join(";", employees.NameDepForEmployee(departments, employees)));
        //        }
        //}


    }
}
