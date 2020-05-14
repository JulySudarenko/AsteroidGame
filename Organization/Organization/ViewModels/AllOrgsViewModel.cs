using System;
using System.Collections.ObjectModel;
using Organization.Services;
using Organization.ViewModels.Base;

namespace Organization.ViewModels
{
    internal class AllOrgsViewModel : ViewModel
    {
        public ObservableCollection<DataManager> AllOrgs { get; } = new ObservableCollection<DataManager>();
    }
}
