Modular Quiz App Documentation
Overview

This document provides a comprehensive guide for a Quiz Application developed using C# for the backend logic and XAML for the graphical user interface. The application is designed to facilitate users in taking multiple-choice quizzes, navigating through questions, and viewing their results upon completion.
Components

The application comprises three main parts, each represented by a page within the application:

    Start Page
    Quiz Page
    Results Page

Start Page (Quiz.pages.start)

This is the entry point of the application where users can select the type of quiz they wish to take, specify the number of questions, and initiate the quiz. Key elements include:

    ComboBox (cmbQuizType): Allows users to select the type of quiz. The options for the quiz types are dynamically loaded from the backend or a configuration file.
    TextBox (txtNumberOfQuestions): Users can enter the desired number of questions for the quiz. Placeholder text guides users on what to enter.
    Button (btnStartQuiz): Starts the quiz with the selected parameters.

Quiz Page (Quiz.pages.quiz)

This page is displayed during the quiz, showing one question at a time alongside possible answers. It includes:

    RichTextBox (txtQuestion): Displays the question text. It is read-only to prevent editing by the user.
    StackPanel (answersPanel): Dynamically populated with RadioButtons corresponding to the answer choices for the current question.
    Button (btnPrevious and btnNext): Navigates between questions. The 'Next' button also serves to submit the user's answer before moving to the next question.

Results Page (Quiz.pages.results)

After completing the quiz, users are directed to this page, which shows their performance. Features include:

    ScrollViewer: Contains a StackPanel (resultsPanel) where the results of the quiz are dynamically added, displaying the questions, selected answers, and indicating correctness.
    Button (btnBackToMain): Allows users to return to the Start Page to begin a new quiz session.

Backend Logic
Question Class

Central to the application's logic is the Question class, which models quiz questions. It includes:

    Properties:
        QuestionText: The text of the question.
        Answers: A list of answer choices.
        correctAnswerIndex: Indices of the correct answer(s) in the Answers list. Supports multiple correct answers for a single question.
        IsMultipleChoice: Boolean value indicating whether the question has multiple correct answers.
        UserAnswers: Indices of the answers selected by the user.
        IsCorrect: Nullable boolean value indicating whether the user's answer(s) are correct. It remains null until evaluated.

    Constructors:
        A parameterless constructor initializes the Answers and correctAnswerIndex lists.
        An overloaded constructor accepts questionText, answers, correctAnswerIndexes, and an unused type parameter for future enhancements.

Quizzes Folder
Overview

The Quizzes folder plays a pivotal role in the Quiz Application by serving as a repository for the quiz data. This data is stored in .json format, facilitating easy modification, extension, and maintenance of the quiz content.
JSON Structure

Each .json file within the Quizzes folder is structured as an array of objects, where each object represents a single quiz question along with its answer choices and the index(es) of the correct answer(s). This format allows for straightforward parsing and utilization within the application.
Example

Below is a sample structure of a .json file containing quiz questions:

[
  {
    "questionText": "What is the primary use of Salesforce Profiles?",
    "answers": [
      "To track user activities and performance metrics",
      "To define user roles within the organization",
      "To control access to data and applications based on the user's role",
      "To customize the Salesforce UI for individual users"
    ],
    "correctAnswerIndex": [ 2 ]
  }
]

Key Elements

    questionText: A string that holds the question to be displayed to the user.
    answers: An array of strings, each representing a possible answer choice.
    correctAnswerIndex: An array of integers, each pointing to the index of the correct answer within the answers array. This supports both single-choice and multiple-choice questions.

Integration with Application

The application dynamically loads questions and their corresponding answer choices from the .json files at runtime. This design choice decouples the quiz content from the application code, offering the flexibility to update the quiz without modifying the application itself.
Advantages

    Ease of Update: Quiz content can be updated, added, or removed simply by modifying the .json files without the need for code changes.
    Flexibility: Supports a wide range of quiz topics and structures, including single-choice and multiple-choice questions.
    Scalability: New quizzes can be added by creating additional .json files, allowing the quiz library to grow over time.

Conclusion

The Quizzes folder is a fundamental component of the Quiz Application, providing a scalable and maintainable method for managing quiz content. Its use of .json format for storing quiz data ensures that the application can easily adapt to new requirements and content updates.

Functionality

    Quiz Flow: The application flow starts at the Start Page, transitions to the Quiz Page as users take the quiz, and finally moves to the Results Page to display the outcome.
    Answer Selection: Users can select answers for each question. The application supports both single-choice and multiple-choice questions.
    Results Evaluation: Upon completing the quiz, the application evaluates the user's responses against the correct answers and presents a summary on the Results Page.

Conclusion

The Quiz Application offers a straightforward and user-friendly platform for taking quizzes. Its modular design allows for easy maintenance and future enhancements, such as adding new question types or integrating with external data sources for quiz content.


