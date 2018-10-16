using AnalogVoltageController.Models;
using System.ComponentModel;

namespace AnalogVoltageController
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private IVoltageWriter writer = new AnalogVoltageWriter();
        private string _physicalChannel;
        private string _displayMessage;

        private double _voltage;
        public double Voltage
        {
            get { return _voltage; }
            set
            {
                if (_voltage != value)
                {
                    _voltage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Voltage"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
