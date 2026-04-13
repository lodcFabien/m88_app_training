using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CourseSavedModel;

public class CourseCreationController : MonoBehaviour
{
    [SerializeField] private FolderItemController _folderPrefab;
    [SerializeField] private Transform _folderContainer;
    [SerializeField] private CourseCreationView _view;
    [SerializeField] private FileManagementController _fileManagementController;

    [SerializeField] private RectTransform _draggableArea;
    public RectTransform DraggableArea => _draggableArea;

    private CourseItemController _currentCourse;

    private List<FolderItemController> _folders = new List<FolderItemController>();

    public void AddNewFolderOnButtonClick()
    {
        AddNewFolder(_folderContainer).ClickOnItem();
        Save();
    }

    public FolderItemController AddNewFolder(Transform container)
    {
        FolderItemController folder = Instantiate(_folderPrefab, container);
        folder.Init(this);
        _folders.Add(folder);
        folder.ClickEvent.AddListener(ActionOnFolderItemClicked);
        return folder;
    }

    private void ActionOnFolderItemClicked(FolderItemController clickedFolder)
    {
        _folders.ForEach(x => x.SetSelected(x == clickedFolder));
    }

    public void SetCurrentCourse(CourseItemController course)
    {
        _view.Init(course);
        _fileManagementController.SetActiveFolder(null);

        if (course == null)
        {
            return;
        }

        Clear();
        _currentCourse = course;

        for (int i = 0; i < course.CourseModel.Folders.Length; i++)
        {
            AddNewFolder(_folderContainer).MakeItemFromSave(course.CourseModel.Folders[i]);
        }

    }

    public void Save()
    {
        Debug.Log("saved");

        List<FolderSavedModel> folders = new List<FolderSavedModel>();

        for (int i = 0; i < _folderContainer.childCount; i++)
        {
            if(_folderContainer.GetChild(i).GetComponent<FolderItemController>() != null)
            {
                folders.Add(_folderContainer.GetChild(i).GetComponent<FolderItemController>().MakeSavedModel());
            }
        }

        _currentCourse.Save(folders.ToArray());
    }


    public void Clear()
    {
        while (_folderContainer.childCount > 0)
        {
            DestroyImmediate(_folderContainer.GetChild(0).gameObject);
        }
        _folders.Clear();
    }

    public void SetSelectedFolder(FolderItemController folder)
    {
        _fileManagementController.SetActiveFolder(folder);
    }

    public void SetFileManagementActive(bool active)
    {
        _fileManagementController.SetActive(active);
    }
}
