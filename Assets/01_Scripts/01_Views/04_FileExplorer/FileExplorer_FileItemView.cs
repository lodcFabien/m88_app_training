using TMPro;
using UnityEngine;

public class FileExplorer_FileItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private GameObject _selectImage;

    public void SetSelected(bool selected)
    {
        _selectImage.SetActive(selected);
    }

    public void SetTitle(string title)
    {
        _title.text = title;
    }
}
