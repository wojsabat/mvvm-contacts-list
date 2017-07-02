using MvvmContactList.Model;

namespace MvvmContactList.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel = new ContactsViewModel();
        private UpdateViewModel _updateViewModel = new UpdateViewModel();
        private AddViewModel _addViewModel = new AddViewModel();
        private BindableBase _currentViewModel;
        
        public MainWindowViewModel()
        {
            _currentViewModel = _contactsViewModel;
            _contactsViewModel.UpdateContactRequested += OpenUpdateView;
            _contactsViewModel.AddContactRequested += OpenAddView;
            _updateViewModel.GoToListRequested += OpenContactsView;
            _addViewModel.GoToListRequested += OpenContactsView;
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

        private void OpenAddView()
        {
            _addViewModel.Contact = new Contact();
            CurrentViewModel = _addViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}