using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class QuizListController_Creation : MonoBehaviour
{
    [SerializeField] private Transform _quizItemContainer;
    [SerializeField] private QuizButtonController_Creation _quizButtonPrefab;
    [SerializeField] private QuestionListController_Creation _questionList;

    private List<QuizButtonController_Creation> _quizButtons = new List<QuizButtonController_Creation>();

    private QuizButtonController_Creation _selectedQuizButton;

    private void Awake()
    {
        QuizDatabaseManager.Instance.DatabaseLoaded.AddListener(ActionOnDatabaseLoaded);
        ActionOnQuizSelected(null);
        _questionList.QuestionsEditedEvent.AddListener(ActionOnQuestionsEdited);
    }

    public QuizButtonController_Creation AddQuizButton(QuizSavedModel model)
    {
        QuizButtonController_Creation quizButton = Instantiate(_quizButtonPrefab, _quizItemContainer);
        quizButton.Init(model);
        quizButton.SelectEvent.AddListener(ActionOnQuizSelected);
        quizButton.DestroyEvent.AddListener(ActionOnQuizDestroyed);
        _quizButtons.Add(quizButton);
        return quizButton;
    }

    private void ActionOnQuizDestroyed(QuizButtonController_Creation deletedQuiz)
    {
        ConfirmPopupController.Instance.Activate("Do you want to delete this quiz", popupAnswer =>
        {
            if (popupAnswer)
            {
                _quizButtons.Remove(deletedQuiz);
                Destroy(deletedQuiz.gameObject);
                QuizDatabaseManager.Instance.DeleteQuiz(deletedQuiz.Model);
                ActionOnQuizSelected(null);
            }
        });
    }

    private void ActionOnQuizSelected(QuizButtonController_Creation quizButton)
    {
        _selectedQuizButton = _quizButtons.Find(x => x==quizButton);
        _quizButtons.ForEach(x => x.SetSelected(x == _selectedQuizButton));
        _questionList.SetActiveQuiz(_selectedQuizButton?.Model);
    }

    public void AddQuizzOnClick()
    {
        QuizSavedModel model = new QuizSavedModel();
        model.Id = GetNewId();
        AddQuizButton(model).Click();
    }

    private void ActionOnDatabaseLoaded()
    {
        foreach (QuizSavedModel quiz in QuizDatabaseManager.Instance.Quizzes)
        {
            AddQuizButton(quiz);
        }
    }

    private int GetNewId()
    {
        for (int i = 0; i < int.MaxValue; i++)
        {
            if(_quizButtons.Find(x => x.Model.Id == i) == null)
            {
                return i;
            }
        }
        return 0;
    }


    private void ActionOnQuestionsEdited(QuizSavedModel.QuestionSavedModel[] questions)
    {
        _selectedQuizButton.SetQuestions(questions);
    }
}
