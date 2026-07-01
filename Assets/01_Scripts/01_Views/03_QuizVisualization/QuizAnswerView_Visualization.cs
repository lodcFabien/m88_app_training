using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static QuizSavedModel;

public class QuizAnswerView_Visualization : MonoBehaviour
{
    [SerializeField] private GameObject _selectFrame;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private CanvasGroup _selectCircle;
    [SerializeField] private TMP_Text _answer;
    [SerializeField] private TMP_Text _letter;
    [SerializeField] private Color _wrongColor;
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _defaultTextColor;


    public void SetAnswer(AnswerSavedModel answer, char letter)
    {
        _letter.text = letter.ToString().ToUpper();
        _answer.text = answer.Answer;
        Reset();
    }

    public void SetSelected(bool selected)
    {
        _selectFrame.SetActive(selected);
        _selectCircle.alpha = selected ? 1 : 0;
        _letter.color = selected ? Color.white : _defaultTextColor;
        _answer.color = _defaultTextColor;
    }

    public void SetCheckState(bool correct, bool selected)
    {
        if(correct)
        {
            _backgroundImage.color = _correctColor;
            _answer.color = Color.white;
            _letter.color = Color.white;
        }
        else if (!correct && selected)
        {
            _backgroundImage.color = _wrongColor;
            _letter.color = Color.white;
        }
    }

    public void Reset()
    {
        SetSelected(false);
        _backgroundImage.color = Color.white;
    }
}
