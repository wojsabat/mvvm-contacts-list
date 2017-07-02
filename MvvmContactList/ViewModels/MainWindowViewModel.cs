using Autofac;
using Autofac.Core;
using MvvmContactList.Model;
using MvvmContactList.Services;

namespace MvvmContactList.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ContactsViewModel _contactsViewModel;
        private UpdateViewModel _updateViewModel;
        private AddViewModel _addViewModel;
        private BindableBase _currentViewModel;
        
        public MainWindowViewModel()
        {
            InitializeSubViewModels();
            _currentViewModel = _contactsViewModel;
            SubscribeToEvents();
        }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        private void InitializeSubViewModels()
        {
            _contactsViewModel = DiContainer.Container.Resolve<ContactsViewModel>();
            _updateViewModel = DiContainer.Container.Resolve<UpdateViewModel>();
            _addViewModel = DiContainer.Container.Resolve<AddViewModel>();
        }

        private void SubscribeToEvents()
        {
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
    }
}