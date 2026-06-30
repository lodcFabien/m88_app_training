using UnityEngine;

public class FileExplorer_FileItemController : MonoBehaviour
{
    [SerializeField] private FileExplorer_FileItemView _view;

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
    }

    public void Init(string title)
    {
        _view.SetTitle(title);
        SetSelected(false);
    }
}
