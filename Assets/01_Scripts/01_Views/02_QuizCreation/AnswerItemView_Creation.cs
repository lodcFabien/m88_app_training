using TMPro;
using UnityEngine;

public class AnswerItemView_Creation : MonoBehaviour
{
    [SerializeField] private TMP_InputField _answer;

    public void SetAnswer(string answer)
    {
        _answer.text = answer;
    }

    public string GetAnswer()
    {
        return _answer.text; 
    }
}
