using NationalInstruments.DAQmx;

namespace AnalogVoltageController.Models
{
    public interface IVoltageWriter
    {
        double Voltage { get; set; }

        NationalInstruments.DAQmx.Task Initialize(string physicalChannelName);
        void Write(DaqStream stream, double voltage);
    }
}