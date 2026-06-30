using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileExplorer_FileItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private GameObject _selectImage;
    [SerializeField] private Image _icon;

    public void SetSelected(bool selected)
    {
        _selectImage.SetActive(selected);
    }

    public void SetTitle(string title)
    {
        _title.text = title.Split('.')[0];
    }

    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }
}
