using NationalInstruments.DAQmx;

namespace AnalogVoltageController.Models
{
    public interface IVoltageWriter
    {
        VoltageOutput Voltage { get; set; }

        NationalInstruments.DAQmx.Task Initialize(string physicalChannelName);
        void Write(DaqStream stream, VoltageOutput voltage);
    }
}