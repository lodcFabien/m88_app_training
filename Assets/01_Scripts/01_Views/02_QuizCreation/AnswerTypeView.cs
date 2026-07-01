using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerTypeView : MonoBehaviour
{
    [SerializeField] private Image _checkImage;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectColor;

    public void SetSelected(bool selected)
    {
        _checkImage.color = selected ? _selectColor: _defaultColor;
        _text.fontStyle = selected ? FontStyles.Bold : FontStyles.Normal;
    }
}
