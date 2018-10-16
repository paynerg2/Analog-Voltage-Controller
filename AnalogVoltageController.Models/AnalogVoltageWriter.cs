using System;
using System.ComponentModel;
using NationalInstruments.DAQmx;

namespace AnalogVoltageController.Models
{
    public class AnalogVoltageWriter : IVoltageWriter, INotifyPropertyChanged
    {
        public double Voltage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Task Initialize(string physicalChannelName)
        {
            Task analogWriteTask = null;
            try
            {
                // Note: NationalInstruments.DAQmx.Task
                analogWriteTask = new Task();
                analogWriteTask.AOChannels.CreateVoltageChannel(physicalChannelName,
                                                                nameToAssignChannel: "", 
                                                                minimumValue: -10, 
                                                                maximumValue: 10,
                                                                AOVoltageUnits.Volts);
                analogWriteTask.Control(TaskAction.Verify);
            }
            catch (DaqException ex)
            {
                //Handle exception
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
            catch(DaqException ex)
            {
                //Handle exception
                throw;
            }
            
        }
    }
}
