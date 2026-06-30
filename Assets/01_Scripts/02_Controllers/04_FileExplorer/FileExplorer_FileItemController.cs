using System.IO;
using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class FileExplorer_FileItemController : MonoBehaviour
{
    [SerializeField] private FileExplorer_FileItemView _view;
    [SerializeField] private Sprite _presentationSprite;
    [SerializeField] private Sprite _pdfSprite;
    [SerializeField] private Sprite _videoSprite;
    [SerializeField] private Sprite _quizSprite;

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

    public void Init(FileInfo file, FileType fileType)
    {
        _fileInfo = file;
        _view.SetTitle(file.Name);
        _view.SetIcon(GetFileIcon(fileType));
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

    public Sprite GetFileIcon(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.PowerPoint: return _presentationSprite;
            case FileType.Pdf: return _pdfSprite;
            case FileType.Video: return _videoSprite;
            case FileType.Quiz: return _quizSprite;
        }

        return _presentationSprite;
    }
}
