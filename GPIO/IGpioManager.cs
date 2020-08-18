using GPIO.Model;
using System.Collections.ObjectModel;

namespace GPIO
{
    public interface IGpioManager
    {
        ObservableCollection<GpioPin> GpioPins { get; set; }
    }
}