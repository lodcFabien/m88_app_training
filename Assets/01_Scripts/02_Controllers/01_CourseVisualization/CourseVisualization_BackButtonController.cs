using UnityEngine;

public class CourseVisualization_BackButtonController : MonoBehaviour
{
    public void Click()
    {
        CourseVisualizationManager.Instance.SetNewState(Enums.VisualizationPageState.Course);
    }
}
