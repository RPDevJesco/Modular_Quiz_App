using System.Windows;
using System.Windows.Controls;

namespace Quiz.pages
{
    /// <summary>
    /// Interaction logic for results.xaml
    /// </summary>
    public partial class results : Page
    {
        public results(string report)
        {
            InitializeComponent();
            DisplayReport(report);
        }

        private void DisplayReport(string report)
        {
            // Assuming report is plain text. For more complex data, you might need to parse and display differently
            var textBlock = new TextBlock
            {
                Text = report,
                TextWrapping = TextWrapping.Wrap
            };
            resultsPanel.Children.Add(textBlock);
        }

        private void BtnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main page
            this.NavigationService.Navigate(new start());
        }

    }
}
