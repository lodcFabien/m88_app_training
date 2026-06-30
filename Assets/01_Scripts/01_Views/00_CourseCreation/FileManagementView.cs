using TMPro;
using UnityEngine;

public class FileManagementView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Init(FolderItemController_Creation folder)
    {
        _canvasGroup.alpha = folder != null ? 1 :0;
        SetActive(folder != null);
    }

    public void SetActive(bool active)
    {
        _canvasGroup.blocksRaycasts = active;
    }
}
