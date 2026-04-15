using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizAnswerView_Visualization : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TMP_Text _answer;

    public void SetAnswer(string answer)
    {
        _answer.text = answer;
    }

    public void SetSelected(bool selected)
    {
        _backgroundImage.color = selected ? Color.red : Color.white;    
    }
}
