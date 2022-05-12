using PropertyChanged;
using System.ComponentModel;

namespace CredoLoan.Core.SharedKernel
{
    public class BaseEntity : IBaseEntity
    {
        private HashSet<string> _properties = new HashSet<string>();

        public BaseEntity()
        {
            PropertyChanged += BaseEntity_PropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [DoNotNotify]
        public string Id { get; set; } = Guid.NewGuid().ToString();

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
