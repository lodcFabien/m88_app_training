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

    private bool _correctCheckState = true;

    public void Init(AnswerSavedModel answerModel)
    {
        SetCorrectCheckState(false);
        _answerModel = answerModel;
        _view.SetAnswer(answerModel);
        SetSelected(false);
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _view.SetSelected(selected);
    }

    public void SwitchSelected()
    {
        if (_correctCheckState)
        {
            return;
        }

        SetSelected(!_selected);
    }

    public void SetCorrectCheckState(bool correctCheckState)
    {
        _correctCheckState = correctCheckState;
        _correctCheckState = correctCheckState;
        _view.SetCorrectVisibility(correctCheckState);
    }
}
