using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static QuizSavedModel;

public class AnswersController_Creation : MonoBehaviour
{
    [SerializeField] private AnswerItemController_Creation _answerPrefab;
    [SerializeField] private Transform _answersContainer;

    private UnityEvent _answersEdited = new UnityEvent();
    public UnityEvent AnswersEdited => _answersEdited;

    private List<AnswerItemController_Creation> _answers = new List<AnswerItemController_Creation>();

    public void AddAnswerItem(AnswerSavedModel model)
    {
        AnswerItemController_Creation answer = Instantiate(_answerPrefab, _answersContainer);
        answer.Init(model);
        answer.AnswerEdited.AddListener(() => { AnswersEdited.Invoke(); });
        answer.DestroyEvent.AddListener(ActionOnAnswerDestroyed);

        _answers.Add(answer);
    }

    private void ActionOnAnswerDestroyed(AnswerItemController_Creation answer)
    {
        _answers.Remove(answer);
        Destroy(answer.gameObject);
        AnswersEdited.Invoke();
    }

    public void SetAnswersOnLoad(QuestionSavedModel model)
    {
        Clear();

        foreach (AnswerSavedModel answer in model.Answers)
        {
            AddAnswerItem(answer);
        }
    }

    public void AddAnswerOnButtonClicked()
    {
        AnswerSavedModel model = new AnswerSavedModel();
        AddAnswerItem(model);
        AnswersEdited.Invoke();
    }

    public void Clear()
    {
        while (_answersContainer.childCount > 0)
        {
            DestroyImmediate(_answersContainer.GetChild(0).gameObject);
        }
        _answers.Clear();
    }

    public AnswerSavedModel[] GetSaveAnswers()
    {
        AnswerSavedModel[] answers = new AnswerSavedModel[_answers.Count];

        for(int i=0; i<_answers.Count; i++)
        {
            answers[i] = _answers[i].GetSavedModel();
        }

        return answers;
    }

}

