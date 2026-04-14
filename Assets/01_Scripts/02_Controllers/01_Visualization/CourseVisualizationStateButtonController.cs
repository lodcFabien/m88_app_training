using UnityEngine;
using static Enums;

public class CourseVisualizationStateButtonController : MonoBehaviour
{
    [SerializeField] private VisualizationPageState _newState;

    public void ChangeState()
    {
        CourseVisualizationManager.Instance.SetNewState(_newState);
    }
}
