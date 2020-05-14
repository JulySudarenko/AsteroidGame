using Organization.ViewModels.Base;
using Organization.Services;
using System.Collections.ObjectModel;

namespace Organization.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Редактор сотрудников";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов к труду и обороне!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }



        public DepartmentViewModel DepartmentViewModel { get; } = new DepartmentViewModel();

        public EmployeesViewModel StudentsModel { get; } = new EmployeesViewModel();

        public AllOrgsViewModel AllOrgsViewModel { get; } = new AllOrgsViewModel();

    }
}
