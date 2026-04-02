using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ListElementController : MonoBehaviour
{
    [SerializeField] private GameObject _childrenContainer;
    [SerializeField] private ReorderableListElement _listElement;
    [SerializeField] private VerticalLayoutGroup _vbMain;

    private bool _collapsed = false;

    private void Awake()
    {
        _listElement.OnBeginDragEvent.AddListener(() => SetCollapsed(true));
    }

    public void SwtichCollapse()
    {
        SetCollapsed(!_collapsed);
    }

    private void SetCollapsed(bool collapsed)
    {
        _collapsed = collapsed;
        _childrenContainer.SetActive(!_collapsed);
    }

    private void Update()
    {
        _vbMain.spacing = _childrenContainer.transform.childCount > 0 ? 10 : 0;
    }

}
