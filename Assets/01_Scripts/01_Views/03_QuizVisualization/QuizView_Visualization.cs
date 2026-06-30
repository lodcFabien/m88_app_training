using TMPro;
using UnityEngine;

public class QuizView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _quizTitle;
    [SerializeField] private TMP_Text _question;
    [SerializeField] private TMP_Text _score;

    public void SetQuizTitle(string quizTitle)
    {
        _quizTitle.text = quizTitle;
    }


    public void SetQuestion(string question)
    {
        _question.text = question;
    }
    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}
