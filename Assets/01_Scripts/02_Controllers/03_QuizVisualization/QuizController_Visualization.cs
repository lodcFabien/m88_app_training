using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static QuizSavedModel;

public class QuizController_Visualization : FileVisualizatorBaseController
{
    [SerializeField] private QuizView_Visualization _view;
    [SerializeField] private QuizAnswerController_Visualization _answerPrefab;
    [SerializeField] private Transform _answersContainer;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private GameObject _validateButton;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private QuizTimelineController _timeline;

    private QuizSavedModel _quizModel;

    private List<QuizAnswerController_Visualization> _answers = new List<QuizAnswerController_Visualization>();

    private int _currentIndex = 0;

    private int _score = 0;

    private Texture2D _loadedTexture;

    public override void PlayFile(string path)
    {
        _timeline.Clear();
        _score = 0;
        _finishScreen.SetActive(false);
        _quizModel = new QuizSavedModel();
        string loadedData = File.ReadAllText(path);
        _quizModel = JsonUtility.FromJson<QuizSavedModel>(loadedData);
        _currentIndex = 0;
        _view.SetQuizTitle(_quizModel.QuizTitle);
        _timeline.Init(_quizModel.Questions.Length);
        SetCurrentQuestion();
    }

    public void SetCurrentQuestion()
    {
        SetCheckState(false);
        QuestionSavedModel question = _quizModel.Questions[_currentIndex];
        _view.SetQuestion(question.Question);
        SetImage(question);
        AddAnswersItem(question);
        _timeline.SetActiveItems(_currentIndex);
    }

    public void SetImage(QuestionSavedModel question)
    {
        if(question.ImagePath == string.Empty)
        {
            _view.SetImage(null);
        }
        else
        {
            string fullpath = Application.streamingAssetsPath + question.ImagePath;

            byte[] fileData;

            if (File.Exists(fullpath))
            {
                if (_loadedTexture != null)
                {
                    Destroy(_loadedTexture);
                    _loadedTexture = null;
                }

                fileData = File.ReadAllBytes(fullpath);
                _loadedTexture = new Texture2D(2, 2);
                _loadedTexture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            _view.SetImage(_loadedTexture);
        }
    }

    public void AddAnswersItem(QuestionSavedModel questionModel)
    {
        Clear();
        int answerIndex = 0;
        foreach (AnswerSavedModel answer in questionModel.Answers)
        {
            QuizAnswerController_Visualization currentAnswer = Instantiate(_answerPrefab, _answersContainer);
            currentAnswer.Init(answer, (char)('a' + answerIndex));
            _answers.Add(currentAnswer);
            answerIndex ++;
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
        _answers.ForEach(x=>x.SetCheckState());
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
    }
}
