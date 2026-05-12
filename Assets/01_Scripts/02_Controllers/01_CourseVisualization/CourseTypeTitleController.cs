using UnityEngine;
using static Enums;

public class CourseTypeTitleController : MonoBehaviour
{
    [SerializeField] private CourseTypeTitleView _view;

    public void Init(CourseType courseType)
    {
        _view.SetTitle(courseType == CourseType.Course ? "COURSES" : "LIBRARIES");
    }
}
