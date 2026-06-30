using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourseTypeView : MonoBehaviour
{
    [SerializeField] private Image _selectImage;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectColor;
    [SerializeField] private TMP_Text _text;

    public void SetSelected(bool selected)
    {
        _selectImage.color = selected ? _selectColor : _defaultColor;
        _text.fontStyle = selected ? FontStyles.Bold : FontStyles.Normal;
    }
}
