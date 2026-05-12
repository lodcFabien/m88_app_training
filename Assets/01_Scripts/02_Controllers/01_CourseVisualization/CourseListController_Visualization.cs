using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CourseListController_Visualization : BaseVisualizationPageConroller
{
    [SerializeField] private CourseButtonController_Visualization _courseButtonPrefab;
    [SerializeField] private CourseTypeTitleController _courseTypePrefab;
    [SerializeField] private Transform _courseButtonsContainer;
    [SerializeField] private CourseController_Visualization _courseController;

    protected override void Awake()
    {
        base.Awake();
        CourseDatabaseManager.Instance.DatabaseLoaded.AddListener(LoadCourseListFromDatabase);
    }

    private void LoadCourseListFromDatabase()
    {
        List<CourseSavedModel> courses = CourseDatabaseManager.Instance.Courses.OrderBy(x=>x.CourseType).ToList();

        for (int i = 0; i < courses.Count; i++)
        {
            if(i==0 || courses[i].CourseType != courses[i - 1].CourseType)
            {
                CourseTypeTitleController type = Instantiate(_courseTypePrefab, _courseButtonsContainer);
                type.Init(courses[i].CourseType);
            }

            CourseButtonController_Visualization button = Instantiate(_courseButtonPrefab, _courseButtonsContainer);
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
