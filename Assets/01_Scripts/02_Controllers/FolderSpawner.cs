using UnityEngine;

public class FolderSpawner : MonoBehaviour
{
    [SerializeField] private FolderItemController _folderPrefab;
    [SerializeField] private Transform _container;

    public void Init(FolderItemController folderPrefab)
    {
        _folderPrefab = folderPrefab;
    }

    public void SpawnFolder()
    {
        FolderItemController folder = Instantiate(_folderPrefab, _container);
        folder.Init(_folderPrefab);
    }
}
