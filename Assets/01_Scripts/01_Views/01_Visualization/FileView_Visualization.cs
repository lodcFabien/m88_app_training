using TMPro;
using UnityEngine;

public class FileView_Visualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;

    public void SetName(string name)
    {
        _name.text = name;
    }
}
