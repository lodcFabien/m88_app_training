using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static QuizSavedModel;

public class AnswerItemController_Creation : MonoBehaviour
{
    [SerializeField] private AnswerItemView_Creation _view;
    [SerializeField] private List<AnswerTypeController> _types = new List<AnswerTypeController>();


    private UnityEvent _answerEdited = new UnityEvent();
    public UnityEvent AnswerEdited => _answerEdited;

    private UnityEvent<AnswerItemController_Creation> _destroyEvent = new UnityEvent<AnswerItemController_Creation>();
    public UnityEvent<AnswerItemController_Creation> DestroyEvent => _destroyEvent;

    private void Awake()
    {
        _types.ForEach(x => x.TypeClickedEvent.AddListener(ActionOnTypeChanged));
    }

    private void ActionOnTypeChanged(AnswerTypeController clickedType)
    {
        _types.ForEach(x => x.SetSelected(x ==clickedType));
        AnswerEdited.Invoke();
    }

    public void ActionOnAnswerTextChanged()
    {
        AnswerEdited.Invoke();
    }

    public void Init(AnswerSavedModel model)
    {
        _view.SetAnswer(model.Answer);
        _types.ForEach(x => x.SetSelected(model.Correct == x.IsCorrectAnswer));
    }

    public void Destroy()
    {
        DestroyEvent.Invoke(this);
    }

    public AnswerSavedModel GetSavedModel()
    {
        AnswerSavedModel model = new AnswerSavedModel();

        model.Answer = _view.GetAnswer();
        model.Correct = _types.Find(x => x.IsCorrectAnswer).Selected;

        return model;
    }
}
