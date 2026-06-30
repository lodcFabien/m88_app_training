using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;

    public void Init(string name, Sprite icon)
    {
        _name.text = name;
        _icon.sprite = icon;
    }
}
