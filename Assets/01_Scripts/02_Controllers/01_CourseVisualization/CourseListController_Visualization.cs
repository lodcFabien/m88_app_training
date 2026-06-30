using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CourseListController_Visualization : BaseVisualizationPageConroller
{
    [SerializeField] private CourseButtonController_Visualization _courseButtonPrefab;
    [SerializeField] private CourseTypeTitleController _courseTypePrefab;
    [SerializeField] private CourseController_Visualization _courseController;
    [SerializeField] private Transform _courseButtonsContainer;
    [SerializeField] private Transform _librariesButtonsContainer;

    protected override void Awake()
    {
        base.Awake();
        CourseDatabaseManager.Instance.DatabaseLoaded.AddListener(LoadCourseListFromDatabase);
    }

    private void LoadCourseListFromDatabase()
    {
        List<CourseSavedModel> courses = CourseDatabaseManager.Instance.Courses;

        for (int i = 0; i < courses.Count; i++)
        {
            Transform container = courses[i].CourseType == Enums.CourseType.Course ? _courseButtonsContainer : _librariesButtonsContainer;

            CourseButtonController_Visualization button = Instantiate(_courseButtonPrefab, container);
            button.Init(courses[i]);
            button.ClickEvent.AddListener(ActionOnCourseClicked);
        }

    }

    private void ActionOnCourseClicked(CourseButtonController_Visualization clickedButton)
    {
        ChangeState(Enums.VisualizationPageState.Course);
        _courseController.SetActiveCourse(clickedButton.Model);
    }
}
