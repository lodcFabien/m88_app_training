using System;
using UnityEngine;

public class CourseListController_Visualization : BaseVisualizationPageConroller
{
    [SerializeField] private CourseButtonController_Visualization _courseButtonPrefab;
    [SerializeField] private Transform _courseButtonsContainer;
    [SerializeField] private CourseController_Visualization _courseController;

    protected override void Awake()
    {
        base.Awake();
        CourseDatabaseManager.Instance.DatabaseLoaded.AddListener(LoadCourseListFromDatabase);
    }

    private void LoadCourseListFromDatabase()
    {
        foreach (CourseSavedModel course in CourseDatabaseManager.Instance.Courses)
        {
            CourseButtonController_Visualization button = Instantiate(_courseButtonPrefab, _courseButtonsContainer);
            button.Init(course);
            button.ClickEvent.AddListener(ActionOnCourseClicked);
        }
    }

    private void ActionOnCourseClicked(CourseButtonController_Visualization clickedButton)
    {
        ChangeState(Enums.VisualizationPageState.Course);
        _courseController.SetActiveCourse(clickedButton.Model);
    }
}
