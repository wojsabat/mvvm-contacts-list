using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp3.Model;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ContactsRepository _contactsRepository;
        private ObservableCollection<Contact> _contactsCollection;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
}