using System.Collections.Generic;
using System.Windows;
using Organization.ViewModels;

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
            MessageBox.Show("Подразделение добавлено");
        }
    }
}
