using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizImageFileView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private GameObject _selectImage;
    [SerializeField] private RawImage _thumbnail;
    [SerializeField] private AspectRatioFitter _ratioFitter;

    public void SetSelected(bool selected)
    {
        _selectImage.SetActive(selected);
    }

    public void SetTitle(string title)
    {
        _title.text = title.Split('.')[0];
    }

    public void SetThumbnail(Texture2D image)
    {
        _thumbnail.texture = image;
    }

    public void SetRatio(float ratio)
    {
        _ratioFitter.aspectRatio = ratio;
    }
}
