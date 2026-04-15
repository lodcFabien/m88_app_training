using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.WSA;
using static QuizSavedModel;

public class QuestionListController_Creation : MonoBehaviour
{
    [SerializeField] private QuestionListView_Creation _view;
    [SerializeField] private QuestionItemController_Creation _questionPrefab;
    [SerializeField] private Transform _questionsContainer;
    [SerializeField] private QuestionCreatorController _questionCreator;

    private List<QuestionItemController_Creation> _questions = new List<QuestionItemController_Creation>();

    private UnityEvent<QuestionSavedModel[]> _questionsEditedEvent = new UnityEvent<QuestionSavedModel[]>();
    public UnityEvent<QuestionSavedModel[]> QuestionsEditedEvent => _questionsEditedEvent;

    private QuestionItemController_Creation _selectedQuestion;

    private void Awake()
    {
        _questionCreator.QuestionEditedEvent.AddListener(QuestionCreatorEdited);
    }

    public void SetActiveQuiz(QuizSavedModel quiz)
    {
        Clear();
        _view.SetActive(quiz != null);
        ActionOnQuestionClicked(null);
        if (quiz == null)
        {
            return;
        }

        _view.SetQuizTitle(quiz.QuizTitle);

        foreach(QuestionSavedModel question in quiz.Questions)
        {
            AddQuestionItem(question);
        }
    }

    public void AddQuestionOnButtonClicked()
    {
        QuestionSavedModel model = new QuestionSavedModel();
        AddQuestionItem(model).Click();
        ActionOnQuestionsEdited();
    }

    public QuestionItemController_Creation AddQuestionItem(QuestionSavedModel model)
    {
        QuestionItemController_Creation question = Instantiate(_questionPrefab, _questionsContainer);
        question.Init(model);
        question.QuestionEditedEvent.AddListener(ActionOnQuestionsEdited);
        question.QuestionDestroyed.AddListener(ActionOnQuestionDestroyed);
        question.QuestionClicked.AddListener(ActionOnQuestionClicked);
        _questions.Add(question);
        return question;
    }

    private void ActionOnQuestionsEdited()
    {
        List<QuestionSavedModel> questions = new List<QuestionSavedModel>();

        for (int i = 0; i < _questionsContainer.childCount; i++)
        {
            if(_questionsContainer.GetChild(i).GetComponent<QuestionItemController_Creation>() != null)
            {
                questions.Add(_questionsContainer.GetChild(i).GetComponent<QuestionItemController_Creation>().Model);
            }
        }

        QuestionsEditedEvent.Invoke(questions.ToArray());  
    }

    public void Clear()
    {
        while (_questionsContainer.childCount > 0)
        {
            DestroyImmediate(_questionsContainer.GetChild(0).gameObject);
        }
        _questions.Clear();
    }

    private void ActionOnQuestionDestroyed(QuestionItemController_Creation questionItem)
    {
        _questions.Remove(questionItem);
        DestroyImmediate(questionItem.gameObject);
        ActionOnQuestionsEdited();
        ActionOnQuestionClicked(null);
    }


    private void ActionOnQuestionClicked(QuestionItemController_Creation questionItem)
    {
        _selectedQuestion = _questions.Find(x => x== questionItem);
        _questions.ForEach(x=> x.SetSelected(x== _selectedQuestion));
        _questionCreator.SetActiveQuestion(_selectedQuestion?.Model);
    }

    private void QuestionCreatorEdited(QuestionSavedModel questionSavedModel)
    {
        _selectedQuestion.QuestionEdited(questionSavedModel);
    }
}
