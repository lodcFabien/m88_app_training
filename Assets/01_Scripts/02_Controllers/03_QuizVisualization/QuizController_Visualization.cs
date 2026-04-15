using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static QuizSavedModel;

public class QuizController_Visualization : FileVisualizatorBaseController
{
    [SerializeField] private QuizView_Visualization _view;
    [SerializeField] private QuizAnswerController_Visualization _answerPrefab;
    [SerializeField] private Transform _answersContainer;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private GameObject _validateButton;
    [SerializeField] private GameObject _nextButton;

    private QuizSavedModel _quizModel;

    private List<QuizAnswerController_Visualization> _answers = new List<QuizAnswerController_Visualization>();

    private int _currentIndex = 0;

    private int _score = 0;

    public override void PlayFile(string path)
    {
        _score = 0;
        _finishScreen.SetActive(false);
        _quizModel = new QuizSavedModel();
        string loadedData = File.ReadAllText(path);
        _quizModel = JsonUtility.FromJson<QuizSavedModel>(loadedData);
        _currentIndex = 0;
        _view.SetQuizTitle(_quizModel.QuizTitle);
        SetCurrentQuestion();
    }

    public void SetCurrentQuestion()
    {
        SetCheckState(false);
        QuestionSavedModel question = _quizModel.Questions[_currentIndex];
        _view.SetQuestion(question.Question);
        AddAnswersItem(question);
    }

    public void AddAnswersItem(QuestionSavedModel questionModel)
    {
        Clear();

        foreach (AnswerSavedModel answer in questionModel.Answers)
        {
            QuizAnswerController_Visualization currentAnswer = Instantiate(_answerPrefab, _answersContainer);
            currentAnswer.Init(answer);
            _answers.Add(currentAnswer);
        }
    }

    public void Clear()
    {
        while (_answersContainer.childCount > 0)
        {
            DestroyImmediate(_answersContainer.GetChild(0).gameObject);
        }
        _answers.Clear();
    }

    public void ValidateAnswers()
    {
        SetCheckState(true);
        CheckAnswers();
    }

    public void NextQuestion() 
    {
        _currentIndex++;

        if(_currentIndex > _quizModel.Questions.Length - 1)
        {
            _finishScreen.SetActive(true);
            return;
        }

        SetCurrentQuestion();
    }

    public void SetCheckState(bool checkState)
    {
        _validateButton.SetActive(!checkState);
        _nextButton.SetActive(checkState);
        _answers.ForEach(x=>x.SetCorrectCheckState(checkState));
    }

    public void CheckAnswers()
    {
        bool correct = true;
 
        foreach(QuizAnswerController_Visualization answer in _answers)
        {
            if(answer.Selected != answer.AnswerModel.Correct)
            {
                correct = false;
            }
        }

        if (correct)
        {
            _score++;
        }

        _view.SetScore(_score);
    }
}
