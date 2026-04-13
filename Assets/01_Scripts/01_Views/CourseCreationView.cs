using UnityEngine;

public class CourseCreationView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void SetVisible(bool enabled)
    {
        _canvasGroup.alpha = enabled ? 1 :0;
        _canvasGroup.blocksRaycasts = enabled;
    }
}
