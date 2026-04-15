using NUnit.Framework;
using SFB;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FileManagementController : MonoBehaviour
{
    [SerializeField] private FileManagementView _view;
    [SerializeField] private FileItemController_Creation _fileItemPrefab;
    [SerializeField] private Transform _fileItemContainer;

    private FolderItemController_Creation _activeFolder;

    public void SetActiveFolder(FolderItemController_Creation currentFolder)
    {
        _view.Init(currentFolder);

        if(currentFolder == null)
        {
            return;
        }

        _activeFolder = currentFolder;

        Clear();

        foreach(string file in currentFolder.Files)
        {
            SpawnFileItem(file);
        }
    }

    public void SpawnFileItem(string fileName)
    {
        FileItemController_Creation fileItem = Instantiate(_fileItemPrefab, _fileItemContainer);
        fileItem.Init(fileName);
        fileItem.EndDragEvent.AddListener(ActionOnFileItemEndDrag);
        fileItem.DeleteEvent.AddListener(ActionOnFileDelete);
    }

    private void ActionOnFileDelete(FileItemController_Creation fileItem)
    {
        DestroyImmediate(fileItem.gameObject);
        SetActiveFolderFileList();
    }

    private void ActionOnFileItemEndDrag()
    {
        SetActiveFolderFileList();
    }

    public void Clear()
    {
        while (_fileItemContainer.childCount > 0)
        {
            DestroyImmediate(_fileItemContainer.GetChild(0).gameObject);
        }
    }

    public void AddNewFile()
    {
        ExtensionFilter[] extensions = new[] {
            new ExtensionFilter("Files", "pdf", "mp4", "ppsx", "quiz" )
        };

        string[] newFile = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);

        if(newFile.Length <= 0)
        {
            return;
        }

        SpawnFileItem(newFile[0]);
        SetActiveFolderFileList();
    }

    public void SetActive(bool enabled)
    {
        _view.SetActive(enabled);
        SetActiveFolderFileList();
    }

    public void SetActiveFolderFileList()
    {
        List<string> fileNames = new List<string>();

        for (int i = 0; i < _fileItemContainer.childCount; i++)
        {
            if(_fileItemContainer.GetChild(i).GetComponent<FileItemController_Creation>() != null)
            {
                fileNames.Add(_fileItemContainer.GetChild(i).GetComponent<FileItemController_Creation>().FileName);
            }
        }
        _activeFolder.SetFiles(fileNames);
    }
}
