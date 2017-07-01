using System.Configuration;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel = new ContactsViewModel();
        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}