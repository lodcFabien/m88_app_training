using UnityEngine;

public class FileManagementView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void SetVisible(bool enabled)
    {
        _canvasGroup.alpha = enabled ? 1 :0;
        SetActive(enabled);
    }

    public void SetActive(bool active)
    {
        _canvasGroup.blocksRaycasts = active;
    }
}
