using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class FileExplorer_CategoryButtonController : MonoBehaviour
{
    [SerializeField] private FileExplorer_CategoryButtonView _view;

    [SerializeField] private FileType _fileType;
    public FileType FileType => _fileType;

    private UnityEvent<FileExplorer_CategoryButtonController> _clickEvent = new UnityEvent<FileExplorer_CategoryButtonController>();
    public UnityEvent<FileExplorer_CategoryButtonController> ClickEvent => _clickEvent;


    public void Click()
    {
        ClickEvent.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);    
    }
}
