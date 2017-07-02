using System;
using MvvmContactList.Model;
using MvvmContactList.Services;

namespace MvvmContactList.ViewModels
{
    public class UpdateViewModel : BindableBase
    {
        private Contact _contact;
        private RelayCommand _updateCommand;
        private IContactsRepository _contactsRepository;

        public event Action GoToListRequested = delegate { };

        public UpdateViewModel()
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

        public RelayCommand UpdateCommand => _updateCommand ?? (_updateCommand = new RelayCommand(UpdateExecute, CanUpdate));

        private async void UpdateExecute()
        {
            await _contactsRepository.UpdateAsync(_contact);
            GoToListRequested();

        }

        private bool CanUpdate()
        {
            return Contact != null;
        }
    }
}