using AnalogVoltageController.Models;
using NationalInstruments.DAQmx;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AnalogVoltageController
{
    public class DashboardViewModel : BindableBase
    {
        private string _displayMessage = string.Empty;
        private ObservableCollection<string> _physicalChannels;
        private string _selectedPhysicalChannel = string.Empty;
        private double _voltage = 0;
        private IVoltageWriter writer = new AnalogVoltageWriter();

        public double Voltage
        {
            get { return _voltage; }
            set { SetProperty(ref _voltage, value); }
        }

        public ObservableCollection<string> PhysicalChannels
        {
            get { return _physicalChannels; }
            set { SetProperty(ref _physicalChannels, value); }
        }

        public string SelectedPhysicalChannel
        {
            get { return _selectedPhysicalChannel; }
            set { SetProperty(ref _selectedPhysicalChannel, value); }
        }

        public string DisplayMessage
        {
            get { return _displayMessage; }
            set { SetProperty(ref _displayMessage, value); }
        }

        public void LoadPhysicalChannels()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            var channels = DaqSystem.Local.GetPhysicalChannels(
                PhysicalChannelTypes.AO, PhysicalChannelAccess.External);
            PhysicalChannels = new ObservableCollection<string>(channels);
        }

        // TODO: Implement CanStart/OnStart command for start
        //       button.

        // TODO: Implement Update behavior when the slider is
        //       changed.
    }
}
