using NUnit.Framework;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static Enums;

public class FileExplorer_ItemContainerController : MonoBehaviour
{
    [SerializeField] private FileType _fileType;
    public FileType FileType => _fileType;


    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private FileExplorer_FileItemController _fileItemPrefab;
    [SerializeField] private Transform _fileItemContainer;

    private string _defaultPath = Application.streamingAssetsPath + "/01_Medias/";

    private List<FileExplorer_FileItemController> _fileItems = new List<FileExplorer_FileItemController>();

    private void Awake()
    {
        Populate();
    }

    public void SetEnabled(bool enabled)
    {
        _canvasGroup.alpha = enabled ? 1 : 0;
        _canvasGroup.blocksRaycasts = enabled;
    }

    public void Populate()
    {
        DirectoryInfo saveDirectory = new DirectoryInfo(GetFilesPath());
        FileInfo[] files = saveDirectory.GetFiles();

        foreach (FileInfo file in files)
        {
            if (file.Extension == GetExtension())
            {
                FileExplorer_FileItemController spawnedItem = Instantiate(_fileItemPrefab, _fileItemContainer);
                spawnedItem.Init(file, _fileType);
                _fileItems.Add(spawnedItem);
                spawnedItem.ClickEvent.AddListener(x => x.SwitchSelected());
            }
        }
    }


    public string GetFilesPath()
    {
        string subPath = string.Empty;

        switch (_fileType)
        {
            case FileType.PowerPoint: subPath = "00_Presentations";break;
            case FileType.Pdf: subPath = "01_PDFs";break;
            case FileType.Video: subPath = "02_Videos";break;
            case FileType.Quiz: subPath = "03_Quizzes";break;
        }
        return _defaultPath + subPath;
    }

    public string GetExtension()
    {
        switch (_fileType)
        {
            case FileType.PowerPoint: return ".ppsx";
            case FileType.Pdf: return ".pdf";
            case FileType.Video: return ".mp4";
            case FileType.Quiz: return ".quiz";
        }

        return string.Empty;
     }

    public void Reset()
    {
        _fileItems.ForEach(x => x.SetSelected(false));
    }

    public List<string> GetFileToImport()
    {
        List<string> files = new List<string>();

        foreach(FileExplorer_FileItemController fileItem in _fileItems)
        {
            if (fileItem.Selected)
            {
                files.Add(fileItem.GetSavedPath());
            }
        }

        return files;
    }

    public void SetSelectedFileOnOpen(List<FileInfo> fileInfos)
    {
        foreach (FileExplorer_FileItemController fileItem in _fileItems)
        {
            if(fileInfos.Any(x => x.Name == fileItem.FileInfo.Name))
            {
                fileItem.Click();
            }
        }
    }
}
