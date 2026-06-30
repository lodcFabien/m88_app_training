using UnityEngine;
using UnityEngine.UI;

public class FileExplorer_CategoryButtonView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;

    public void SetSelected(bool selected)
    {
        _background.color = selected ? _selectedColor : _defaultColor;
    }
}
