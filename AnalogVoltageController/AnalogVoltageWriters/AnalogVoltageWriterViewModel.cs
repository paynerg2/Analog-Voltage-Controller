using AnalogVoltageController.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;


namespace AnalogVoltageController.AnalogVoltageWriters
{
    public class AnalogVoltageWriterViewModel : INotifyPropertyChanged
    {
        private IVoltageWriter writer = new AnalogVoltageWriter();

        private double _voltage;
        public double Voltage
        {
            get { return _voltage; }
            set
            {
                if(_voltage != value)
                {
                    _voltage = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Voltage"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
