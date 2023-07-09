using System.Windows;

namespace Counter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            TextBox_Count.Text = Properties.Settings.Default.Count;
            Menu_Item_EnableDigitGrouping.IsChecked = Properties.Settings.Default.UseDigitGrouping;
        }

        private void Button_Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = int.Parse(TextBox_Count.Text.Replace(",", ""));  // Remove the digit separator(s), if any
                int step  = int.Parse(TextBox_Step.Text);
                count += step;

                // Use digit grouping if enabled in the menu
                TextBox_Count.Text = (Menu_Item_EnableDigitGrouping.IsChecked) ? (count.ToString("N0")) : (count.ToString());
            }
            catch
            {
                TextBox_Step.Text = "1";
            }
        }

        private void Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Count.Text = "0";
        }

        private void Menu_Item_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Menu_Item_About_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Count = TextBox_Count.Text;
            Properties.Settings.Default.UseDigitGrouping = Menu_Item_EnableDigitGrouping.IsChecked;

            Properties.Settings.Default.Save();
        }
    }
}
