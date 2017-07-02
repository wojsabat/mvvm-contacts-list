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

        public UpdateViewModel(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public event Action GoToListRequested = delegate { };

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