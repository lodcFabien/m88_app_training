using UnityEngine;
using UnityEngine.Events;
using static QuizSavedModel;

public class QuestionCreatorController : MonoBehaviour
{
    [SerializeField] private QuestionCreatorView _view;
    [SerializeField] private AnswersController_Creation _answersController;
    [SerializeField] private QuizAddImageController _addImageController;

    private UnityEvent<QuestionSavedModel> _questionEditedEvent = new UnityEvent<QuestionSavedModel>();
    public UnityEvent<QuestionSavedModel> QuestionEditedEvent => _questionEditedEvent;

    private void Awake()
    {
        _answersController.AnswersEdited.AddListener(QuestionEdited);
        _addImageController.ImageEditedEvent.AddListener(QuestionEdited);
    }

    public void SetActiveQuestion(QuestionSavedModel model)
    {
        _view.SetActive(model != null);

        if(model == null)
        {
            return;
        }

        _view.SetQuestionStatement(model.Question);
        _addImageController.InitOnNewQuestion(model);
        _answersController.SetAnswersOnLoad(model);
    }

    public void QuestionEdited()
    {
        QuestionSavedModel model = new QuestionSavedModel();
        model.Question = _view.GetQuestionStatement();
        model.Answers = _answersController.GetSaveAnswers();

        if(_addImageController.ImageFile != null)
        {
            model.ImagePath = _addImageController.ImageFile.ToString();
        }
        else
        {
            model.ImagePath = string.Empty;

        }
        QuestionEditedEvent.Invoke(model);  
    }

}
