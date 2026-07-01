using UnityEngine;

public class QuizTimelineItemController : MonoBehaviour
{
    [SerializeField] private QuizTimelineItemView _view;

    private int _index;
    public int Index => _index;

    public void Init(int index)
    {
        _index = index;
        SetActive(false);
    }

    public void SetActive(bool active)
    {
        _view.SetActive(active);
    }
}
