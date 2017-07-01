using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp3.Commands;
using WpfApp3.Model;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private readonly IContactsRepository _contactsRepository;
        private ObservableCollection<Contact> _contactsCollection;
        private Contact _selectedContact;
        private RelayCommand _deleteCommand;

        public ContactsViewModel()
        {
            _contactsRepository = new ContactsRepository();
            _contactsCollection = new ObservableCollection<Contact>(_contactsRepository.GetAllAsync().Result);
        }

        public ObservableCollection<Contact> ContactsCollection
        {
            get => _contactsCollection;
            set
            {
                _contactsCollection = value;
                OnPropertyChanged();
            }
        }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private async void DeleteExecute()
        {
            await _contactsRepository.DeleteAsync(_selectedContact.Id);
            UpdateContactsCollection();
        }

        private void UpdateContactsCollection()
        {
            ContactsCollection = new ObservableCollection<Contact>(_contactsRepository.GetAllAsync().Result);
        }

        private bool CanDelete()
        {
            return SelectedContact != null;
        }

        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteExecute, CanDelete));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}