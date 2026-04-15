using System;
using UnityEngine;

[Serializable]
public class QuizSavedModel
{
    public int Id;
    public string QuizTitle;
    public QuestionSavedModel[] Questions;

    public QuizSavedModel()
    {
        Id= 0;
        QuizTitle = string.Empty;
        Questions = new QuestionSavedModel[0];
    }

    [Serializable]
    public class QuestionSavedModel
    {
        public string Title;
        public string Question;
        public AnswerSavedModel[] Answers;

        public QuestionSavedModel()
        {
            Title = string.Empty;
            Question = string.Empty;
            Answers = new AnswerSavedModel[0];
        }
    }

    [Serializable]
    public class AnswerSavedModel
    {
        public string Answer;
        public bool Correct;

        public AnswerSavedModel()
        {
            Answer = string.Empty;
            Correct = false;
        }
    }
}
