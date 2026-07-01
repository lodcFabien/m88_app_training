using UnityEngine;
using UnityEngine.UI;

public class QuizTimelineItemView : MonoBehaviour
{
    [SerializeField] private Image _disk; 
    [SerializeField] private Color _defaultColor; 
    [SerializeField] private Color _activeColor;
    
    public void SetActive(bool active)
    {
        _disk.color = active ? _activeColor: _defaultColor ;
    }
}
