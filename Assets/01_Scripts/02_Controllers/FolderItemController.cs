using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class FolderItemController : MonoBehaviour
{
    [SerializeField] private GameObject _childrenContainer;
    [SerializeField] private ReorderableListElement _listElement;
    [SerializeField] private VerticalLayoutGroup _vbMain;
    [SerializeField] private FolderSpawner _spawner;

    private bool _collapsed = false;

    private bool _wasCollapsedOnDrag = false;

    public void Init(FolderItemController folderPrefab)
    {
        _spawner.Init(folderPrefab);
    }

    private void Awake()
    {
        _listElement.OnBeginDragEvent.AddListener(OnBeginDrag);
        _listElement.OnEndDragEvent.AddListener(OnEndDrag);
    }

    private void OnBeginDrag()
    {
        _wasCollapsedOnDrag = _collapsed;
        SetCollapsed(true);
    }

    private void OnEndDrag()
    {
        SetCollapsed(_wasCollapsedOnDrag);
    }

    public void SwtichCollapse()
    {
        SetCollapsed(!_collapsed);
    }

    public void SetCollapsed(bool collapsed)
    {
        _collapsed = collapsed;
        _childrenContainer.SetActive(!_collapsed);
    }

    private void Update()
    {
        _vbMain.spacing = _childrenContainer.transform.childCount > 0 ? 10 : 0;
    }

}
