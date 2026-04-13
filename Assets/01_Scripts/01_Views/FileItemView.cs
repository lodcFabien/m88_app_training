using TMPro;
using UnityEngine;

public class FileItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text _fileName;

    public void SetName(string name)
    {
        _fileName.text = name;
    }
}
