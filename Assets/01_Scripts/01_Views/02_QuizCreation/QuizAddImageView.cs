using TMPro;
using UnityEngine;

public class QuizAddImageView : MonoBehaviour
{
    [SerializeField] private TMP_Text _imageName;

    public void SetImageName(string  imageName)
    {
        _imageName.text = imageName;    
    }
}
