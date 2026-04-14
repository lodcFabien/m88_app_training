using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class FileController_Visualization : MonoBehaviour
{
    [SerializeField] private FileView_Visualization _view;

    private string _filePath;
    public string FilePath => _filePath;

    private UnityEvent<string> _fileClickEvent = new UnityEvent<string>();
    public UnityEvent<string> FileClickEvent => _fileClickEvent;    

    public void Init(string filePath)
    {
        _filePath = filePath;
        FileInfo fileInfo = new FileInfo(filePath);
        _view.SetName($"{fileInfo.Name}");
    }

    public void Click()
    {
        FileClickEvent.Invoke(_filePath);
    }
}
