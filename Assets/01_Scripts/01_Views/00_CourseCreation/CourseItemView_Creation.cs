using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class CourseItemView_Creation : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _selectColor;

    public void SetSelected(bool selected)
    {
        _backgroundImage.color = selected ? _selectColor : _normalColor;
    }

    public void SetTitle(string title)
    {
        _inputField.text = title;
    }

    public string GetTitle()
    {
        return _inputField.text;
    }
}
