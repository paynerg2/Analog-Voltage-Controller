using System.Windows;

namespace AnalogVoltageController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VoltageValueScrollbar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            // Invoke the output command if output has been started.
            var viewModel = (DashboardViewModel)DataContext;
            if (viewModel.OutputCommand.CanExecute(null) &&
                PowerButton.IsChecked == true)
                viewModel.OutputCommand.Execute(null);
        }
    }
}
