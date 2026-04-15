using UnityEngine;
using UnityEngine.Events;

public class QuizButtonController_Creation : MonoBehaviour
{
    [SerializeField] private QuizButtonView_Creation _view;

    private QuizSavedModel _model;
    public QuizSavedModel Model => _model;

    private UnityEvent<QuizButtonController_Creation> _selectEvent = new UnityEvent<QuizButtonController_Creation>();
    public UnityEvent<QuizButtonController_Creation> SelectEvent => _selectEvent;

    private UnityEvent<QuizButtonController_Creation> _destroyEvent = new UnityEvent<QuizButtonController_Creation>();
    public UnityEvent<QuizButtonController_Creation> DestroyEvent => _destroyEvent;
    public void Init(QuizSavedModel model)
    {
        _model = model;
        _view.SetTitle(model.QuizTitle);
        Save();
    }

    public void Save()
    {
        if (QuizDatabaseManager.Instance)
        {
            QuizDatabaseManager.Instance.SaveQuiz(_model);

        }
    }

    public void UpdateTitle()
    {
        QuizDatabaseManager.Instance.DeleteQuiz(Model);
        _model.QuizTitle = _view.GetTitle();
        Save();
    }

    public void Destroy()
    {
        _destroyEvent.Invoke(this);
    }

    public void Click()
    {
        SelectEvent.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
    }

    public void SetQuestions(QuizSavedModel.QuestionSavedModel[] questions)
    {
        _model.Questions = questions;
        Save();
    }
}
