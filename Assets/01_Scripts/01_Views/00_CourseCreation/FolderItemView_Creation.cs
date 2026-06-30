using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FolderItemView_Creation : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Image _background;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;

    public void SetName(string name)
    {
        _nameInputField.text = name;
    }

    public string GetName()
    {
        return _nameInputField.text;    
    }

    public void SetSelected(bool seleceted)
    {
        _background.color = seleceted ? _selectedColor : _defaultColor;
    }
}
