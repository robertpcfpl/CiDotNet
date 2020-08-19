using System;
using System.Windows;
using System.Windows.Controls;

namespace CiDotNet.WpfCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            priceTextBox.Text = 30000.ToString("f2");
            residualValueTextBox.Text = 5000.ToString("f2");
            interestRateTextBox.Text = (7.5).ToString("f4");

            Calculate();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                int duration = int.Parse(((ListBoxItem)durationComboBox.SelectedItem).Content.ToString());
                double interest = double.Parse(interestRateTextBox.Text);
                double presentValue = double.Parse(priceTextBox.Text);
                double residualValue = double.Parse(residualValueTextBox.Text);
                CiDotNet.Calc.Math.Finance.Mode mode = beginnRadioButton.IsChecked.GetValueOrDefault(true) ? CiDotNet.Calc.Math.Finance.Mode.BeginMode : CiDotNet.Calc.Math.Finance.Mode.EndMode;
                paymentTextBox.Text = CiDotNet.Calc.Math.RoundHelper.Round5Rappen((decimal)CiDotNet.Calc.Math.Finance.CalculateRate(duration, 12, interest, presentValue, residualValue, mode)).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in calculation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CiDotNet.Calc.Wibor.WiborProvider wiborProvider = new CiDotNet.Calc.Wibor.WiborProvider(new GpwBenchmarkplWiborService());
            interestRateTextBox.Text = wiborProvider.Wibor3M().ToString();
        }
    }
}
