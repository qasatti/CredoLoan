using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using CredoLoan.Core.SharedKernel;

namespace CredoLoan.Data.Entities
{
    public class Client : IdentityUser, IBaseEntity
    {
        private HashSet<string> _properties = new HashSet<string>();

        public Client()
        {
            PropertyChanged += BaseEntity_PropertyChanged;
        }

        public string Name { get; set; }        
        public string SurName { get; set; }        
        public string PersonalNumber { get; set; }        
        public DateTime DateOfBirth { get; set; }
        public ICollection<LoanApplication> LoanApplications { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public HashSet<string> GetProperties()
        {
            return _properties;
        }

        private void BaseEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _properties.Add(e.PropertyName);
        }
    }
}
