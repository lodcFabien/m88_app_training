using UnityEngine;
using UnityEngine.Events;

public class CourseButtonController_Visualization : MonoBehaviour
{
    [SerializeField] private CourseButtonView_Visualization _view;

    private CourseSavedModel _model;
    public CourseSavedModel Model => _model;

    private UnityEvent<CourseButtonController_Visualization> _clickEvent = new UnityEvent<CourseButtonController_Visualization>();
    public UnityEvent<CourseButtonController_Visualization> ClickEvent => _clickEvent;

    public void Init(CourseSavedModel model)
    {
        _model = model;
        _view.Populate(model);
    }

    public void Click()
    {
        ClickEvent.Invoke(this);    
    }
}
