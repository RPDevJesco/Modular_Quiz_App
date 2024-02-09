using Newtonsoft.Json;

using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Quiz.pages
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Page
    {
        public start()
        {
            InitializeComponent();
            LoadQuizTypesFromFileNames();
        }

        // Assuming you have access to the MainFrame from MainWindow
        private void BtnStartQuiz_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve quiz type and number of questions from user input
            var selectedQuizType = cmbQuizType.SelectedItem as ComboBoxItem;
            var numberOfQuestions = int.Parse(txtNumberOfQuestions.Text); // Add error handling for non-integer inputs

            // Initialize the quiz window with the selected options
            // Navigate to the quiz page
            this.NavigationService.Navigate(new quiz(selectedQuizType.Content.ToString(), numberOfQuestions));
        }

        private void LoadQuizTypesFromFileNames()
        {
            string baseDir = Environment.CurrentDirectory;
            // Get all .json files in the directory
            string[] filePaths = Directory.GetFiles(baseDir, "Quizzes/*.json");

            cmbQuizType.Items.Clear();
            foreach (var filePath in filePaths)
            {
                // Extract file name without extension
                var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);

                cmbQuizType.Items.Add(new ComboBoxItem { Content = fileName });
            }

            // Optionally, select the first item if you want to have a default selection
            if (cmbQuizType.Items.Count > 0)
            {
                cmbQuizType.SelectedIndex = 0;
            }
        }

        private void CmbQuizType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedComboBoxItem = cmbQuizType.SelectedItem as ComboBoxItem;
            if (selectedComboBoxItem != null)
            {
                string selectedQuizName = selectedComboBoxItem.Content.ToString();
                UpdateNumberOfQuestionsTextBox(selectedQuizName);
            }
        }

        private void TxtNumberOfQuestions_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Number of Questions")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black; // Change text color to default
            }
        }

        private void TxtNumberOfQuestions_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Number of Questions";
                textBox.Foreground = System.Windows.Media.Brushes.Gray; // Change text color to gray
            }
        }

        private void UpdateNumberOfQuestionsTextBox(string quizName)
        {
            string baseDir = Environment.CurrentDirectory;
            string filePath = System.IO.Path.Combine(baseDir, $"Quizzes/{quizName}.json");

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(filePath);
                    var questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
                    if (questions != null)
                    {
                        txtNumberOfQuestions.Text = $"{questions.Count}"; // Update TextBox with the count
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load quiz questions: {ex.Message}");
                }
            }
        }
    }
}
