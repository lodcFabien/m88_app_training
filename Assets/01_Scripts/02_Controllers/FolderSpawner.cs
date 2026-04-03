using UnityEngine;

public class FolderSpawner : MonoBehaviour
{
    [SerializeField] private FolderItemController _folderPrefab;
    [SerializeField] private Transform _container;

    public void Init(FolderItemController folderPrefab)
    {
        _folderPrefab = folderPrefab;
    }

}
