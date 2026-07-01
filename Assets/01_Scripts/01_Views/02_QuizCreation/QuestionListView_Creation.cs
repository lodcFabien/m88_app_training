using TMPro;
using UnityEngine;

public class QuestionListView_Creation : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void SetActive(bool active)
    {
        _canvasGroup.alpha = active ? 1 : 0;
        _canvasGroup.blocksRaycasts = active;
    }
}
