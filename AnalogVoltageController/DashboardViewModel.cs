using AnalogVoltageController.Models;
using NationalInstruments.DAQmx;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DaqTask = NationalInstruments.DAQmx.Task;

namespace AnalogVoltageController
{
    public class DashboardViewModel : BindableBase
    {
        private string _displayMessage = string.Empty;
        private ObservableCollection<string> _physicalChannels;
        private string _selectedPhysicalChannel = string.Empty;
        private double _voltage = 0;
        private IVoltageWriter writer = new AnalogVoltageWriter();
        private DaqTask daqTask = null;

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
            set
            {
                SetProperty(ref _selectedPhysicalChannel, value);
                if (daqTask != null) daqTask.Stop();
                daqTask = writer.Initialize(_selectedPhysicalChannel);
            }
        }

        public string DisplayMessage
        {
            get { return _displayMessage; }
            set { SetProperty(ref _displayMessage, value); }
        }

        public RelayCommand OutputCommand { get; private set; }

        public DashboardViewModel()
        {
            OutputCommand = new RelayCommand(OnOutput, CanOutput);
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

        private bool CanOutput()
        {
            return _selectedPhysicalChannel != string.Empty;
        }

        private void OnOutput()
        {
            // Output voltage
        }

        
    }
}
