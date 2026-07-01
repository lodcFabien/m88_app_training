using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class QuizImageFileController : MonoBehaviour
{
    [SerializeField] private QuizImageFileView _view;

    private UnityEvent<QuizImageFileController> _clickEvent = new UnityEvent<QuizImageFileController> ();
    public UnityEvent<QuizImageFileController> ClickEvent => _clickEvent;

    private FileInfo _fileInfo;
    public FileInfo FileInfo => _fileInfo;

    private Texture2D _loadedTexture;

    public void Init(FileInfo file)
    {
        _fileInfo = file;
        LoadPNG(file.FullName);
        _view.SetTitle(file.Name);
    }

    public void LoadPNG(string filePath)
    {
        byte[] fileData;

        if (File.Exists(filePath))
        {   
            if (_loadedTexture != null)
            {
                Destroy(_loadedTexture);
                _loadedTexture = null;
            }

            fileData = File.ReadAllBytes(filePath);
            _loadedTexture = new Texture2D(2, 2);
            _loadedTexture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        _view.SetThumbnail(_loadedTexture);
        _view.SetRatio((float)_loadedTexture.width/(float)_loadedTexture.height);
    }

    public void SetSelected(bool selected)
    {
        _view.SetSelected(selected);
    }

    public void Click()
    {
        _clickEvent.Invoke(this);
    }
}
