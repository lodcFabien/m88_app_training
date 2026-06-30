using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class FileExplorer_FileItemController : MonoBehaviour
{
    [SerializeField] private FileExplorer_FileItemView _view;

    private bool _selected = false;
    public bool Selected => _selected;

    private FileInfo _fileInfo;

    private UnityEvent<FileExplorer_FileItemController> _clickEvent = new UnityEvent<FileExplorer_FileItemController> ();
    public UnityEvent<FileExplorer_FileItemController> ClickEvent => _clickEvent;

    public void SwitchSelected()
    {
        SetSelected(!Selected);
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }

    public void Init(FileInfo file)
    {
        _fileInfo = file;
        _view.SetTitle(file.Name);
        SetSelected(false);
    }

    public string GetSavedPath()
    {
        string fullPath = _fileInfo.FullName;

        return fullPath.Split("StreamingAssets")[1];
    }

    public void Click()
    {
        _clickEvent.Invoke(this);
    }
}
