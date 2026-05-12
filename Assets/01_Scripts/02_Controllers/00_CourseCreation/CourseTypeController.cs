using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class CourseTypeController : MonoBehaviour
{
    [SerializeField] private CourseTypeView _view;

    [SerializeField] private CourseType _type;
    public CourseType Type => _type;

    private UnityEvent<CourseTypeController> _typeClicked = new UnityEvent<CourseTypeController>();
    public UnityEvent<CourseTypeController> TypeClicked=> _typeClicked;

    private bool _seleceted = false;
    public bool Selected => _seleceted;

    public void Click()
    {
        _typeClicked.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
        _seleceted = selected;
    }
}
