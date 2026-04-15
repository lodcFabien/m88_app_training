using TMPro;
using UnityEngine;

public class QuestionListView_Creation : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _quizName;

    public void SetQuizTitle(string title)
    {
        _quizName.text = title;
    }

    public void SetActive(bool active)
    {
        _canvasGroup.alpha = active ? 1 : 0;
        _canvasGroup.blocksRaycasts = active;
    }
}
