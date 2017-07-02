using System;
using MvvmContactList.Model;
using MvvmContactList.Services;

namespace MvvmContactList.ViewModels
{
    public class AddViewModel : BindableBase
    {
        private Contact _contact;
        private RelayCommand _addCommand;
        private RelayCommand _cancelCommand;
        private IContactsRepository _contactsRepository;

        public event Action GoToListRequested = delegate { };

        public AddViewModel()
        {
            _contactsRepository = new ContactsRepository();
        }

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand => _addCommand ?? (_addCommand = new RelayCommand(AddExecute, CanAdd));
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(CancelExecute));

        private async void AddExecute()
        {
            Contact.Id = Guid.NewGuid();
            await _contactsRepository.AddAsync(Contact);
            GoToListRequested();
        }

        public void CancelExecute()
        {
            GoToListRequested();
        }

        private bool CanAdd()
        {
            return Contact != null;
        }
    }
}