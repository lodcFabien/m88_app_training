using TMPro;
using UnityEngine;

public class CourseTypeTitleView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;

    public void SetTitle(string title)
    {
        _title.text = title;    
    }
}
