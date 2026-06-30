using TMPro;
using UnityEngine;

public class CourseCreationView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Init(CourseItemController_Creation course)
    {
        _canvasGroup.alpha = course != null ? 1 :0;
        _canvasGroup.blocksRaycasts = course != null;
    }

}
