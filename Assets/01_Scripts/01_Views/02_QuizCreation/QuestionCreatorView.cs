using TMPro;
using UnityEngine;

public class QuestionCreatorView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_InputField _questionStatement;

    public void SetActive(bool active)
    {
        _canvasGroup.alpha = active ? 1 : 0;
        _canvasGroup.blocksRaycasts = active;
    }

    public void SetQuestionStatement(string statement)
    {
        _questionStatement.text = statement;
    }

    public string GetQuestionStatement()
    {
        return _questionStatement.text;
    }
}
