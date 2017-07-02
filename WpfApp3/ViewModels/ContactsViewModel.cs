﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp3.Commands;
using WpfApp3.Model;
using WpfApp3.Services;

namespace WpfApp3.ViewModels
{
    public class ContactsViewModel : BindableBase
    {
        private readonly IContactsRepository _contactsRepository;
        private ObservableCollection<Contact> _contactsCollection;
        private Contact _selectedContact;
        private RelayCommand _deleteCommand;
        private RelayCommand _updateCommand;

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
                OpenUpdateViewCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteExecute));
        public RelayCommand OpenUpdateViewCommand => _updateCommand ?? (_updateCommand = new RelayCommand(UpdateExecute, CanUpdate));

        public void Refresh()
        {
            UpdateContactsCollection();
            SelectedContact = null;
        }

        private async void DeleteExecute()
        {
            await _contactsRepository.DeleteAsync(_selectedContact.Id);
            UpdateContactsCollection();
        }

        public event Action<Contact> UpdateContactRequested = delegate { };

        private void UpdateExecute()
        {
            UpdateContactRequested(SelectedContact);
        }

        private bool CanUpdate()
        {
            return SelectedContact != null;
        }


        private void UpdateContactsCollection()
        {
            var contacts = _contactsRepository.GetAllAsync().Result;
            ContactsCollection = new ObservableCollection<Contact>(contacts);
        }
    }
}