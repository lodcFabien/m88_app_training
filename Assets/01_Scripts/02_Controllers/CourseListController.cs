using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CourseListController : MonoBehaviour
{
    [SerializeField] private CourseItemController _courseItemPrefab;
    [SerializeField] private Transform _courseItemContainer;
    [SerializeField] private CourseCreationController _courseCreationController;

    private List<CourseItemController> _coursesList = new List<CourseItemController>();

    private void Awake()
    {
        if (CourseDatabaseManager.Instance.Loaded)
        {
            LoadCourseFromDatabase();
        }
        else
        {
            CourseDatabaseManager.Instance.DatabaseLoaded.AddListener(LoadCourseFromDatabase);
        }
    }

    public void CreateNewCourse()
    {
        CourseSavedModel newCourse = new CourseSavedModel(GetNewCourseName());
        newCourse.Id = GetCourseId();
        AddCourseToList(newCourse);
        _courseCreationController.Save();
    }

    private void AddCourseToList(CourseSavedModel courseModel)
    {
        CourseItemController newCourse = Instantiate(_courseItemPrefab, _courseItemContainer);
        _coursesList.Add(newCourse);
        newCourse.Init(courseModel);
        newCourse.ClickEvent.AddListener(ActionOnCourseClicked);
        newCourse.DuplicateEvent.AddListener(ActionOnCourseDuplicated);
        newCourse.DeleteEvent.AddListener(ActionOnCourseDeleted);
        newCourse.NameEdiedtEvent.AddListener(ActionOnCourseNameEdited);
        newCourse.ActionOnClick();
    }

    private void ActionOnCourseNameEdited()
    {
        _courseCreationController.Save();
    }

    private void ActionOnCourseClicked(CourseItemController clickedCourse)
    {
        _coursesList.ForEach(x => x.SetSelected(x == clickedCourse));
        _courseCreationController.SetCurrentCourse(clickedCourse);
    }

    private void ActionOnCourseDeleted(CourseItemController clickedCourse)
    {
        CourseDatabaseManager.Instance.DeleteCourse(clickedCourse.CourseModel);
        _coursesList.Remove(clickedCourse);
        Destroy(clickedCourse.gameObject);
        ActionOnCourseClicked(null);
    }

    private void ActionOnCourseDuplicated(CourseItemController clickedCourse)
    {
        CourseSavedModel model = (CourseSavedModel)(clickedCourse.CourseModel.Clone());
        model.CourseTitle = GetNewCourseName();
        AddCourseToList(model);
    }

    public void LoadCourseFromDatabase()
    {
        foreach (CourseSavedModel course in CourseDatabaseManager.Instance.Courses)
        {
            AddCourseToList(course);
        }
        ActionOnCourseClicked(null);
    }

    private string GetNewCourseName()
    {
        int untitledCount = _coursesList.FindAll(x => x.CourseModel.CourseTitle.Contains("New course")).Count;

        return untitledCount > 0 ? $"New course {untitledCount}" : "New course";
    }

    private int GetCourseId()
    {
        for(int i=0; i<int.MaxValue; i++)
        {
            if (_coursesList.Find(x => x.CourseModel.Id == i) == null)
            {
                return i;
            }
        }
        return 0;
    }
}
