using UnityEngine;
using UnityEngine.UI;

public class TrainingCategoryView : MonoBehaviour
{
    [SerializeField] private Image _selectImage;
    
    public void SetSelected(bool selected)
    {
        _selectImage.gameObject.SetActive(selected);
    }
}
