using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GPIO.Model
{
    public abstract class ModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Dictionary<string, object> _backingFieldValues = new Dictionary<string, object>();

        protected void SetProperty<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(GetProperty<T>(propertyName), newValue))
            {
                _backingFieldValues[propertyName] = newValue;
                OnPropertyChanged(propertyName);
            }
        }

        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            object value;
            if (_backingFieldValues.TryGetValue(propertyName, out value))
                return value == null ? default : (T)value;
            return default;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
