using System.Configuration;
using WpfApp3.Commands;
using WpfApp3.Model;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel = new ContactsViewModel();
        private UpdateViewModel _updateViewModel = new UpdateViewModel();
        private BindableBase _currentViewModel;
        
        public MainWindowViewModel()
        {
            _currentViewModel = _contactsViewModel;
            _contactsViewModel.UpdateContactRequested += OpenUpdateView;
            _updateViewModel.GoToListRequested += OpenContactsView;
        }

        private void OpenUpdateView(Contact contact)
        {
            _updateViewModel.Contact = contact;
            CurrentViewModel = _updateViewModel;
        }

        private void OpenContactsView()
        {
            _contactsViewModel.Refresh();
            CurrentViewModel = _contactsViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}