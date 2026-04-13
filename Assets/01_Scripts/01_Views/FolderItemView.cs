using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FolderItemView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Image _background;

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
        _background.color = seleceted ? Color.red : Color.white;
    }
}
