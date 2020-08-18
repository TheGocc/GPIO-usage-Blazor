using GPIO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;

namespace GPIO
{
    public class GpioManager : IGpioManager
    {
        public ObservableCollection<GpioPin> GpioPins { get; set; }

        public GpioManager()
        {
            GpioPins = new ObservableCollection<GpioPin>();
            GpioPins.CollectionChanged += GpioPins_CollectionChanged;
        }

        private void GpioPins_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                var pin = item as GpioPin;
                pin.PropertyChanged += Pin_PropertyChanged;
            }
        }
        private void Pin_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var pin = sender as GpioPin;
            if (pin.Type == GpioType.Output)
            {
                //TODO: write to GPIO
            }
        }


        public void ReadPin()
        {
            //TODO: Read from one pin


        }
    }
}
