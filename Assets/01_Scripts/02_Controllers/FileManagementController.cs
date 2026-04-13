using NUnit.Framework;
using SFB;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FileManagementController : MonoBehaviour
{
    [SerializeField] private FileManagementView _view;
    [SerializeField] private FileItemController _fileItemPrefab;
    [SerializeField] private Transform _fileItemContainer;

    private FolderItemController _activeFolder;

    public void SetActiveFolder(FolderItemController currentFolder)
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
        FileItemController fileItem = Instantiate(_fileItemPrefab, _fileItemContainer);
        fileItem.Init(fileName);
        fileItem.EndDragEvent.AddListener(ActionOnFileItemEndDrag);
        fileItem.DeleteEvent.AddListener(ActionOnFileDelete);
    }

    private void ActionOnFileDelete(FileItemController fileItem)
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
        string newFile = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false)[0];
        SpawnFileItem(newFile);
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
            if(_fileItemContainer.GetChild(i).GetComponent<FileItemController>() != null)
            {
                fileNames.Add(_fileItemContainer.GetChild(i).GetComponent<FileItemController>().FileName);
            }
        }
        _activeFolder.SetFiles(fileNames);
    }
}
