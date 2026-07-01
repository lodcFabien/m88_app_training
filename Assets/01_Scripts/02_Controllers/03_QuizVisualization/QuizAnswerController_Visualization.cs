using UnityEngine;
using UnityEngine.UIElements;
using static QuizSavedModel;

public class QuizAnswerController_Visualization : MonoBehaviour
{
    [SerializeField] QuizAnswerView_Visualization _view;
    
    private AnswerSavedModel _answerModel;
    public AnswerSavedModel AnswerModel => _answerModel;

    private bool _selected = false;
    public bool Selected => _selected;

    private bool _checkState = true;

    public void Init(AnswerSavedModel answerModel, char letter)
    {
        _checkState = false;
        _answerModel = answerModel;
        _view.SetAnswer(answerModel, letter);
        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }

    public void SwitchSelected()
    {
        if (_checkState)
        {
            return;
        }

        SetSelected(!_selected);
    }

    public void SetCheckState()
    {
        _checkState = true;
        _view.SetCheckState(_answerModel.Correct, Selected);
    }
}
