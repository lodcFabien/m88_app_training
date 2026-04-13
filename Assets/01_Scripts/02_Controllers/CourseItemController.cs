using UnityEngine;
using UnityEngine.Events;
using static CourseSavedModel;

public class CourseItemController : MonoBehaviour
{
    [SerializeField] private CourseItemView _view;

    private UnityEvent<CourseItemController> _clickEvent = new UnityEvent<CourseItemController>();
    public UnityEvent<CourseItemController> ClickEvent => _clickEvent;

    private UnityEvent<CourseItemController> _duplicateEvent = new UnityEvent<CourseItemController>();
    public UnityEvent<CourseItemController> DuplicateEvent => _duplicateEvent;

    private UnityEvent<CourseItemController> _deleteEvent = new UnityEvent<CourseItemController>();
    public UnityEvent<CourseItemController> DeleteEvent => _deleteEvent;

    private UnityEvent _nameEditedEvent = new UnityEvent();
    public UnityEvent NameEdiedtEvent => _nameEditedEvent;

    private CourseSavedModel _courseModel;
    public CourseSavedModel CourseModel => _courseModel;

    private bool _selected;
    public bool Selected => _selected;

    public void Init(CourseSavedModel courseModel)
    {
        _courseModel = courseModel;
        _view.SetTitle(courseModel.CourseTitle);
    }

    public void ActionOnClick()
    {
        ClickEvent.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
    }

    public void Save(FolderSavedModel[] folders)
    {
        _courseModel.Folders = folders;
        _courseModel.CourseTitle = _view.GetTitle();
        CourseDatabaseManager.Instance.SaveCourse(_courseModel);
    }

    public void Duplicate()
    {
        DuplicateEvent.Invoke(this);
    }

    public void Delete()
    {
        DeleteEvent.Invoke(this);
    }

    public void SetNameEdited()
    {
        NameEdiedtEvent.Invoke();
    }
}
