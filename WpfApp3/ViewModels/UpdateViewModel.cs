using WpfApp3.Model;

namespace WpfApp3.ViewModels
{
    public class UpdateViewModel : BindableBase
    {
        private Contact _contact;

        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }
    }
}