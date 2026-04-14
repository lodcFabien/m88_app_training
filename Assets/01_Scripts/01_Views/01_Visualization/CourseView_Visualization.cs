using TMPro;
using UnityEngine;

public class CourseView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _courseTitle;

    public void SetTitle(string title)
    {
        _courseTitle.text = title;
    }
}
