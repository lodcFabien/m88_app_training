using UnityEngine;
using UnityEngine.Events;
using static CourseSavedModel;
using static Enums;

public class CourseItemController_Creation : MonoBehaviour
{
    [SerializeField] private CourseItemView_Creation _view;

    private UnityEvent<CourseItemController_Creation> _clickEvent = new UnityEvent<CourseItemController_Creation>();
    public UnityEvent<CourseItemController_Creation> ClickEvent => _clickEvent;

    private UnityEvent<CourseItemController_Creation> _duplicateEvent = new UnityEvent<CourseItemController_Creation>();
    public UnityEvent<CourseItemController_Creation> DuplicateEvent => _duplicateEvent;

    private UnityEvent<CourseItemController_Creation> _deleteEvent = new UnityEvent<CourseItemController_Creation>();
    public UnityEvent<CourseItemController_Creation> DeleteEvent => _deleteEvent;

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

    public void Save(FolderSavedModel[] folders, TrainingCategory[] categories)
    {
        _courseModel.Categories = categories;
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
