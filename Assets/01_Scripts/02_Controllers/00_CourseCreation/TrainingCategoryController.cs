using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class TrainingCategoryController : MonoBehaviour
{
    [SerializeField] private TrainingCategoryView _view;
    [SerializeField] private TrainingCategory _category;
    public TrainingCategory Category => _category;

    private bool _selected = false;
    public bool Selected => _selected;

    private UnityEvent _valueChanged = new UnityEvent();
    public UnityEvent ValueChanged => _valueChanged;

    public void SwitchSelected()
    {
        SetSelected(!_selected);
        ValueChanged.Invoke();
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }
}
