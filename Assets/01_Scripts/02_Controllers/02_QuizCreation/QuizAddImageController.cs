using System.IO;
using UnityEngine;
using UnityEngine.Events;
using static QuizSavedModel;

public class QuizAddImageController : MonoBehaviour
{
    [SerializeField] private QuizAddImageView _view;

    private FileInfo _imageFile;
    public FileInfo ImageFile => _imageFile;

    private UnityEvent _imageEditedEvent = new UnityEvent();
    public UnityEvent ImageEditedEvent => _imageEditedEvent;

    public void InitOnNewQuestion(QuestionSavedModel model)
    {
        if(model.ImagePath != string.Empty)
        {
            _imageFile = new FileInfo(model.ImagePath); 
            _view.SetImageName(_imageFile.Name);
        }
        else
        {
            _view.SetImageName(string.Empty);
        }
    }

    public void SetNewImage(string filePath)
    {
        if (filePath != string.Empty)
        {
            _imageFile = new FileInfo(filePath);
            _view.SetImageName(_imageFile.Name);
        }
        else
        {
            _imageFile = null;
            _view.SetImageName(string.Empty);
        }

        ImageEditedEvent.Invoke();
    }
}
