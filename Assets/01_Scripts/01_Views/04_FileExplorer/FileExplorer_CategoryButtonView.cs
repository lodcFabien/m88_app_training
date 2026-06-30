using UnityEngine;

public class FileExplorer_CategoryButtonView : MonoBehaviour
{
    [SerializeField] private GameObject _selectImage;

    public void SetSelected(bool selected)
    {
        _selectImage.SetActive(selected);
    }
}
