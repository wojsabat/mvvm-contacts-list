using System.Configuration;
using WpfApp3.Commands;
using WpfApp3.Model;

namespace WpfApp3.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel = new ContactsViewModel();
        private BindableBase _updateViewModel = new UpdateViewModel();
        private BindableBase _currentViewModel;
        
        public MainWindowViewModel()
        {
            _currentViewModel = _contactsViewModel;
            _contactsViewModel.UpdateContactRequested += OpenUpdateView;
        }

        private void OpenUpdateView(Contact contact)
        {
            (_updateViewModel as UpdateViewModel).Contact = contact;
            CurrentViewModel = _updateViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }
    }
}