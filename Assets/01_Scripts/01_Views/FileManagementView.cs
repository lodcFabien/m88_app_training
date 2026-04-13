using TMPro;
using UnityEngine;

public class FileManagementView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Init(FolderItemController folder)
    {
        _canvasGroup.alpha = folder != null ? 1 :0;
        SetActive(folder != null);
        _title.text = folder?.Title;

    }

    public void SetActive(bool active)
    {
        _canvasGroup.blocksRaycasts = active;
    }
}
