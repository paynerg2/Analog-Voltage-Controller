using NationalInstruments.DAQmx;
using System.ComponentModel;

namespace AnalogVoltageController.Models
{
    public class AnalogVoltageWriter : IVoltageWriter, INotifyPropertyChanged
    {
        public double Voltage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Task Initialize(string physicalChannelName)
        {
            // Note: NationalInstruments.DAQmx.Task
            Task analogWriteTask = new Task();
            analogWriteTask.AOChannels.CreateVoltageChannel(physicalChannelName, nameToAssignChannel: "",
                                                            minimumValue: -10, maximumValue: 10, AOVoltageUnits.Volts);
            try
            {
                
                analogWriteTask.Control(TaskAction.Verify);
            }
            catch (DaqException)
            {
                analogWriteTask.Stop();
                throw;
            }
            return analogWriteTask;
        }

        public void Write(DaqStream stream, double voltage)
        {
            try
            {
                var writer = new AnalogSingleChannelWriter(stream);
                writer.WriteSingleSample(true, voltage);
            }
            catch(DaqException)
            {
                throw;
            }
            
        }
    }
}
