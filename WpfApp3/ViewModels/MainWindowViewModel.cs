using System.Configuration;
using WpfApp3.Model;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel = new ContactsViewModel();
        private BindableBase _currentViewModel;

        MainWindowViewModel()
        {
            _contactsViewModel.UpdateContactRequested += OpenUpdateView;
        }

        private void OpenUpdateView(Contact contact)
        {

        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}