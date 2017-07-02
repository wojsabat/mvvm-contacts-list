using System;
using WpfApp3.Commands;
using WpfApp3.Model;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class AddViewModel : BindableBase
    {
        private Contact _contact;
        private RelayCommand _addCommand;
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

        private async void AddExecute()
        {
            Contact.Id = Guid.NewGuid();
            await _contactsRepository.AddAsync(Contact);
            GoToListRequested();

        }

        private bool CanAdd()
        {
            return Contact != null;
        }
    }
}