using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FileExplorer_MainController : MonoBehaviour
{
    [SerializeField] private GameObject _activator;
    [SerializeField] private FileManagementController _fileManagement;
    [SerializeField] private List<FileExplorer_CategoryButtonController> _headerButtons = new List<FileExplorer_CategoryButtonController> ();
    [SerializeField] private List<FileExplorer_ItemContainerController> _containers = new List<FileExplorer_ItemContainerController> ();

    private void Awake()
    {
        _headerButtons.ForEach(x => x.ClickEvent.AddListener(ActionOnHeaderButtonClicked));
        SetActivated(false);
    }

    private void ActionOnHeaderButtonClicked(FileExplorer_CategoryButtonController clickedButton)
    {
        _headerButtons.ForEach(x => x.SetSelected(x == clickedButton));
        _containers.ForEach(x => x.SetEnabled(x.FileType == clickedButton.FileType));
    }

    public void SetActivated(bool activated)
    {
        _activator.SetActive(activated);
        ActionOnHeaderButtonClicked(_headerButtons.Find(x => x.FileType == Enums.FileType.PowerPoint));
    }

    public void Import()
    {
        List<string> files = new List<string> ();

        foreach (FileExplorer_ItemContainerController container in _containers)
        {
            files.AddRange(container.GetFileToImport());
        }

        _fileManagement.AddNewFile(files);
    }
}
