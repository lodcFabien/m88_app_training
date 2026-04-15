using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItemView_Creation : MonoBehaviour
{
    [SerializeField] private TMP_InputField _title;
    [SerializeField] private Image _backgroundImage;

    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public string GetTitle()
    {
        return _title.text;
    }

    public void SetSelected(bool selected)
    {
        _backgroundImage.color = selected ? Color.red : Color.white;
    }
}
