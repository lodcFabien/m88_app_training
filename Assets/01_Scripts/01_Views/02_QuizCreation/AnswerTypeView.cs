using UnityEngine;

public class AnswerTypeView : MonoBehaviour
{
    [SerializeField] private GameObject _checkImage;

    public void SetSelected(bool selected)
    {
        _checkImage.SetActive(selected);
    }
}
