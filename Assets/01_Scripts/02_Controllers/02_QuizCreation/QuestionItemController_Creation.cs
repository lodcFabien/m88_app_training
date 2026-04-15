using System.Windows.Forms;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI.Extensions;
using static QuizSavedModel;

public class QuestionItemController_Creation : MonoBehaviour
{
    [SerializeField] private QuestionItemView_Creation _view;
    [SerializeField] private ReorderableListElement _reorderableListElement;

    private QuestionSavedModel _model;
    public QuestionSavedModel Model => _model;

    private UnityEvent<QuestionItemController_Creation> _questionDestroyed = new UnityEvent<QuestionItemController_Creation>();
    public UnityEvent<QuestionItemController_Creation> QuestionDestroyed => _questionDestroyed;

    private UnityEvent<QuestionItemController_Creation> _questionClicked = new UnityEvent<QuestionItemController_Creation>();
    public UnityEvent<QuestionItemController_Creation> QuestionClicked => _questionClicked;

    private UnityEvent _questionEditedEvent = new UnityEvent();
    public UnityEvent QuestionEditedEvent => _questionEditedEvent;

    private void Awake()
    {
        _reorderableListElement.OnEndDragEvent.AddListener(() => { QuestionEditedEvent.Invoke(); });
    }

    public void Init(QuestionSavedModel model)
    {
        _view.SetTitle(model.Title);
        _model = model;
    }

    public void TitleEdited()
    {
        _model.Title = _view.GetTitle();
        QuestionEditedEvent.Invoke();
    }

    public void Click()
    {
        QuestionClicked.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
    }

    public void Destroy()
    {
        QuestionDestroyed.Invoke(this);
    }

    public void QuestionEdited(QuestionSavedModel model)
    {
        _model.Question = model.Question;
        _model.Answers = model.Answers;
        QuestionEditedEvent.Invoke();
    }
}
