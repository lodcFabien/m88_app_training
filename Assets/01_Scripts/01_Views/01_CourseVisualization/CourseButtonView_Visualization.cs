using TMPro;
using UnityEngine;

public class CourseButtonView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;

    public void Populate(CourseSavedModel model)
    {
        _name.text = model.CourseTitle;
    }
}
