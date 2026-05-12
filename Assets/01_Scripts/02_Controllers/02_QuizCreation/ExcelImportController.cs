using NUnit.Framework;
using SFB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static QuizSavedModel;
using static UnityEngine.Rendering.DebugUI;

public class ExcelImportController : MonoBehaviour
{
    public QuizSavedModel OpenExel()
    {
        ExtensionFilter[] extensions = new[] {
            new ExtensionFilter("Excel", "xlsx" )
        };

        string[] newFile = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);

        if (newFile.Length <= 0)
        {
            return null;
        }

        return ReadExcel(newFile[0]);
    }

    private QuizSavedModel ReadExcel(string fileName)
    {
        QuizSavedModel quiz = new QuizSavedModel();
        quiz.QuizTitle= Path.GetFileNameWithoutExtension(fileName);

        Excel xls = ExcelHelper.LoadExcel(fileName);
        ExcelTable table = xls.Tables[0];

        QuestionSavedModel currentQuestion = new QuestionSavedModel();
        bool newQuestion = true;

        List<QuestionSavedModel> questions = new List<QuestionSavedModel>();
        List<AnswerSavedModel> answers = new List<AnswerSavedModel>();

        for (int i=1; i<=table.NumberOfRows; i++)
        {
            if ((string)table.GetValue(i, 1) == string.Empty) // if row is empty, jump to nextQuestion
            {
                currentQuestion.Answers = answers.ToArray();
                questions.Add(currentQuestion);
                answers.Clear();
                newQuestion = true;
                continue;
            }

            if (newQuestion)
            {
                currentQuestion = new QuestionSavedModel();
                currentQuestion.Title = (string)table.GetValue(i, 1);
                currentQuestion.Question = (string)table.GetValue(i, 2);
                newQuestion = false;
                continue;
            }
            else
            {
                AnswerSavedModel answer = new AnswerSavedModel();
                answer.Answer = (string)table.GetValue(i, 1);
                answer.Correct = string.Equals((string)table.GetValue(i, 2),"TRUE", System.StringComparison.OrdinalIgnoreCase);
                answers.Add(answer);
            }
        }

        currentQuestion.Answers = answers.ToArray();
        questions.Add(currentQuestion);

        quiz.Questions = questions.ToArray();
        return quiz;
    }
}
