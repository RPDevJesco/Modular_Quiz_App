public class Question
{
    public string QuestionText { get; set; }
    public List<string> Answers { get; set; }
    public List<int> correctAnswerIndex { get; set; }
    public bool IsMultipleChoice => correctAnswerIndex.Count > 1;
    public List<int> UserAnswers { get; set; } = new List<int>();
    public bool? IsCorrect { get; set; } = null;

    public Question()
    {
        Answers = new List<string>();
        correctAnswerIndex = new List<int>();
    }

    public Question(string questionText, List<string> answers, List<int> correctAnswerIndexes, string type)
    {
        QuestionText = questionText;
        Answers = answers;
        correctAnswerIndex = correctAnswerIndexes;
    }
}