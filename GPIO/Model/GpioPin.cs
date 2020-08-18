using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPIO.Model
{
    public class GpioPin : ModelBase
    {
        public int GpioAddress{ get; set; }
        public GpioType Type { get; set; }
        public bool GpioValue
        {
            get { return GetProperty<bool>(); }
            set { SetProperty(value); }
        }

        public GpioPin(int address, GpioType type)
        {
            this.Type = type;
            this.GpioAddress = address;
            this.GpioValue = false;
        }



    }
}
