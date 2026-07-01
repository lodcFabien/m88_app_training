using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _quizTitle;
    [SerializeField] private TMP_Text _question;
    [SerializeField] private TMP_Text _score;


    [Header("Image")]
    [SerializeField] private GameObject _imageContainer;
    [SerializeField] private AspectRatioFitter _ratioFitter;
    [SerializeField] private RawImage _image;

    public void SetQuizTitle(string quizTitle)
    {
        _quizTitle.text = quizTitle;
    }


    public void SetQuestion(string question)
    {
        _question.text = question;
    }

    public void SetImage(Texture2D image)
    {
        if (image != null)
        {
            _imageContainer.SetActive(true);
            _ratioFitter.aspectRatio = (float)image.width / (float)image.height;
            _image.texture = image;
        }
        else
        {
            _imageContainer.SetActive(false);
        }
    }
}
