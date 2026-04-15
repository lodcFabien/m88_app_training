using UnityEngine;
using UnityEngine.Events;

public class AnswerTypeController : MonoBehaviour
{
    [SerializeField] private AnswerTypeView _view;
    [SerializeField] private bool _isCorrectAnswer;
    public bool IsCorrectAnswer => _isCorrectAnswer;

    private bool _selected = false;
    public bool Selected => _selected;

    private UnityEvent<AnswerTypeController> _typeClickedEvent = new UnityEvent<AnswerTypeController>();
    public UnityEvent<AnswerTypeController> TypeClickedEvent => _typeClickedEvent;


    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }

    public void Click()
    {
        TypeClickedEvent?.Invoke(this);
    }
}
