using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class FileController_Visualization : MonoBehaviour
{
    [SerializeField] private FileView_Visualization _view;
    [SerializeField] private Sprite _presentationIcon;
    [SerializeField] private Sprite _videoIcon;
    [SerializeField] private Sprite _pdfIcon;
    [SerializeField] private Sprite _quizIcon;

    private string _filePath;
    public string FilePath => _filePath;

    private UnityEvent<string> _fileClickEvent = new UnityEvent<string>();
    public UnityEvent<string> FileClickEvent => _fileClickEvent;    

    public void Init(string filePath)
    {
        _filePath = Application.streamingAssetsPath + filePath;
        FileInfo fileInfo = new FileInfo(_filePath);
        _view.Init($"{fileInfo.Name}", GetFileIcon(filePath));
    }

    public void Click()
    {
        FileClickEvent.Invoke(_filePath);
    }

    private Sprite GetFileIcon(string path)
    {
        FileInfo fileInfo = new FileInfo(path);

        if (fileInfo.Extension == ".mp4")
        {
            return _videoIcon;
        }
        else if (fileInfo.Extension == ".pdf")
        {
            return _pdfIcon;
        }
        else if (fileInfo.Extension == ".ppsx")
        {
            return _presentationIcon;
        }
        else if (fileInfo.Extension == ".quiz")
        {
            return _quizIcon;
        }
        return _videoIcon;
    }
}
