using TMPro;
using UnityEngine;

public class ConfirmPopupView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;

    public void Populate(string text)
    {
        _title.text = text;
    }
}
