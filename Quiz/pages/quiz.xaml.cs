using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Quiz.pages
{
    /// <summary>
    /// Interaction logic for quiz.xaml
    /// </summary>
    public partial class quiz : Page
    {
        private List<Question> questions = new List<Question>();
        private int currentQuestionIndex = 0;
        private string quizType;
        private int numberOfQuestions;

        public quiz(string quizType, int numberOfQuestions)
        {
            InitializeComponent();
            this.quizType = quizType;
            this.numberOfQuestions = numberOfQuestions;
            LoadQuestionsFromJson();
            DisplayCurrentQuestion();
        }

        private void LoadQuestionsFromJson()
        {
            string baseDir = Environment.CurrentDirectory;
            string filePath = System.IO.Path.Combine(baseDir, "Quizzes/questions.json");

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                var allQuestions = JsonConvert.DeserializeObject<List<Question>>(jsonData);

                // limit the number based on numberOfQuestions
                questions = allQuestions
                    .Take(numberOfQuestions)
                    .ToList();

                ShuffleQuestions(questions);
            }
            else
            {
                MessageBox.Show($"The file {filePath} was not found.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShuffleQuestions(List<Question> questions)
        {
            Random rng = new Random();
            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (questions.Count == 0) return;

            var question = questions[currentQuestionIndex];
            txtQuestion.Document.Blocks.Clear();
            txtQuestion.Document.Blocks.Add(new Paragraph(new Run(question.QuestionText)));

            answersPanel.Children.Clear();

            if (question.IsMultipleChoice)
            {
                foreach (var answer in question.Answers)
                {
                    var checkBox = new CheckBox { Content = answer, Margin = new Thickness(2) };
                    answersPanel.Children.Add(checkBox);
                }
            }
            else
            {
                foreach (var answer in question.Answers)
                {
                    var radioButton = new RadioButton { Content = answer, GroupName = "Answers", Margin = new Thickness(2) };
                    answersPanel.Children.Add(radioButton);
                }
            }
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                DisplayCurrentQuestion();
            }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            SubmitAnswer();

            if (currentQuestionIndex < questions.Count - 1)
            {
                currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
            else
            {
                GenerateScoreReport();
            }
        }

        private void SubmitAnswer()
        {
            var currentQuestion = questions[currentQuestionIndex];
            currentQuestion.UserAnswers.Clear(); // Clear previous selections

            foreach (var child in answersPanel.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    int index = answersPanel.Children.IndexOf(checkBox);
                    currentQuestion.UserAnswers.Add(index);
                }
                else if (child is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    int index = answersPanel.Children.IndexOf(radioButton);
                    currentQuestion.UserAnswers.Add(index);
                }
            }

            // Call this before moving to the next question or finishing the quiz
            EvaluateAnswer(currentQuestion);
        }

        private void EvaluateAnswer(Question question)
        {
            if (question.IsMultipleChoice)
            {
                question.IsCorrect = question.UserAnswers.OrderBy(a => a).SequenceEqual(question.correctAnswerIndex.OrderBy(a => a));
            }
            else
            {
                question.IsCorrect = question.UserAnswers.Count == 1 && question.correctAnswerIndex.Contains(question.UserAnswers.First());
            }
        }

        private void GenerateScoreReport()
        {
            // Assuming ResultsPage has a constructor that accepts the report string
            StringBuilder report = new StringBuilder();

            int totalQuestions = questions.Count;
            int correctAnswers = questions.Count(q => q.IsCorrect == true);
            int incorrectAnswers = totalQuestions - correctAnswers;

            report.AppendLine($"Total Questions: {totalQuestions}");
            report.AppendLine($"Correct Answers: {correctAnswers}");
            report.AppendLine($"Incorrect Answers: {incorrectAnswers}");

            foreach (var question in questions.Where(q => q.IsCorrect == false))
            {
                report.AppendLine($"Question: {question.QuestionText}");
                report.AppendLine("Correct Answer(s): " + string.Join(", ", question.correctAnswerIndex.Select(index => question.Answers[index])));
                if (question.UserAnswers.Any())
                {
                    report.AppendLine("Your Answer(s): " + string.Join(", ", question.UserAnswers.Select(index => question.Answers[index])));
                }
                else
                {
                    report.AppendLine("You did not answer this question.");
                }
                report.AppendLine();
            }

            this.NavigationService.Navigate(new results(report.ToString()));
        }
    }
}