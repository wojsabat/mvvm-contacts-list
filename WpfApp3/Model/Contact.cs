using System;
using System.ComponentModel.DataAnnotations;

namespace WpfApp3.Model
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}