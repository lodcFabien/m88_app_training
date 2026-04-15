using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static QuizSavedModel;

public class QuizAnswerView_Visualization : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TMP_Text _answer;
    [SerializeField] private TMP_Text _correctText;

    public void SetAnswer(AnswerSavedModel answer)
    {
        _answer.text = answer.Answer;
        _correctText.text = answer.Correct ? "CORRECT" : "INCORRECT";
        SetCorrectVisibility(false);
    }

    public void SetSelected(bool selected)
    {
        _backgroundImage.color = selected ? Color.red : Color.white;    
    }

    public void SetCorrectVisibility(bool visible)
    {
        _correctText.gameObject.SetActive(visible); 
    }
}
