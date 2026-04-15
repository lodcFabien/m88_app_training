using UnityEngine;
using static QuizSavedModel;

public class QuizAnswerController_Visualization : MonoBehaviour
{
    [SerializeField] QuizAnswerView_Visualization _view;
    
    AnswerSavedModel _answerModel;

    private bool _selected = false;

    public void Init(AnswerSavedModel answerModel)
    {
        _answerModel = answerModel;
        _view.SetAnswer(answerModel.Answer);
        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }

    public void SwitchSelected()
    {
        SetSelected(!_selected);
    }
}
