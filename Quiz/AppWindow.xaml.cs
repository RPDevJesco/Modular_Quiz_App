using Quiz.pages;
using System.Windows;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new start());
        }
    }
}
