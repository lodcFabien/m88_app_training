using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuizFileExplorer : MonoBehaviour
{
    [SerializeField] private GameObject _activator;
    [SerializeField] private Transform _fileItemContainer;
    [SerializeField] private QuizImageFileController _filePrefab;
    [SerializeField] private QuizAddImageController _quizAddImageController;

    private string _defaultPath = Application.streamingAssetsPath + "/01_Medias/04_Images";

    private List<QuizImageFileController> _files = new List<QuizImageFileController>();

    private QuizImageFileController _selectedFile;

    public void SetActivated(bool activated)
    {
        _activator.SetActive(activated);
        ActionOnFileClicked(null);
        SetSelectedFileOnOpen();

    }

    private void Awake()
    {
        Populate();
    }

    public void Populate()
    {
        DirectoryInfo saveDirectory = new DirectoryInfo(_defaultPath);
        FileInfo[] files = saveDirectory.GetFiles();

        foreach (FileInfo file in files)
        {
            if (file.Extension == ".png")
            {
                QuizImageFileController spawnedItem = Instantiate(_filePrefab, _fileItemContainer);
                spawnedItem.Init(file);
                _files.Add(spawnedItem);
                spawnedItem.ClickEvent.AddListener(ActionOnFileClicked);
            }
        }
    }

    private void ActionOnFileClicked(QuizImageFileController clickedFile)
    {
        if(clickedFile == _selectedFile || clickedFile == null)
        {
            _files.ForEach(x => x.SetSelected(false));
            _selectedFile = null;
        }
        else
        {
            _selectedFile = clickedFile;
            _files.ForEach(x => x.SetSelected(x == clickedFile));
        }
    }

    public void SetQuestionImage()
    {
        _quizAddImageController.SetNewImage(_selectedFile == null ? string.Empty : _selectedFile.FileInfo.FullName.Split("StreamingAssets")[1]);
        SetActivated(false);
    }

    public void SetSelectedFileOnOpen()
    {
        if(_quizAddImageController.ImageFile != null)
        {
            QuizImageFileController selectedFile = _files.Find(x => x.FileInfo.Name == _quizAddImageController.ImageFile.Name);
            ActionOnFileClicked(selectedFile);
        }
    }
}
