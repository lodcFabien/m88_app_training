using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CourseSavedModel;
using static Enums;

public class CourseCreationController : MonoBehaviour
{
    [SerializeField] private FolderItemController_Creation _folderPrefab;
    [SerializeField] private Transform _folderContainer;
    [SerializeField] private CourseCreationView _view;
    [SerializeField] private FileManagementController _fileManagementController;
    [SerializeField] private List<TrainingCategoryController> _trainingCategories = new List<TrainingCategoryController>();

    [SerializeField] private RectTransform _draggableArea;
    public RectTransform DraggableArea => _draggableArea;


    private CourseItemController_Creation _currentCourse;

    private List<FolderItemController_Creation> _folders = new List<FolderItemController_Creation>();

    private void Awake()
    {
        _trainingCategories.ForEach(x => x.ValueChanged.AddListener(Save));
    }

    public void AddNewFolderOnButtonClick()
    {
        AddNewFolder(_folderContainer).ClickOnItem();
        Save();
    }

    public FolderItemController_Creation AddNewFolder(Transform container)
    {
        FolderItemController_Creation folder = Instantiate(_folderPrefab, container);
        folder.Init(this);
        _folders.Add(folder);
        folder.ClickEvent.AddListener(ActionOnFolderItemClicked);
        return folder;
    }

    private void ActionOnFolderItemClicked(FolderItemController_Creation clickedFolder)
    {
        _folders.ForEach(x => x.SetSelected(x == clickedFolder));
    }

    public void SetCurrentCourse(CourseItemController_Creation course)
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

        foreach (TrainingCategoryController categoryController in _trainingCategories)
        {
            categoryController.SetSelected(course.CourseModel.Categories.ToList<TrainingCategory>().Contains(categoryController.Category));
        }
    }

    public void Save()
    {
        Debug.Log("saved");

        List<FolderSavedModel> folders = new List<FolderSavedModel>();

        // Set folders
        for (int i = 0; i < _folderContainer.childCount; i++)
        {
            if(_folderContainer.GetChild(i).GetComponent<FolderItemController_Creation>() != null)
            {
                folders.Add(_folderContainer.GetChild(i).GetComponent<FolderItemController_Creation>().MakeSavedModel());
            }
        }

        // Set category
        List<TrainingCategory> categories = new List<TrainingCategory>();
        foreach (TrainingCategoryController categoryController in _trainingCategories)
        {
            if (categoryController.Selected)
            {
                categories.Add(categoryController.Category);
            }
        }

        _currentCourse.Save(folders.ToArray(), categories.ToArray());
    }


    public void Clear()
    {
        while (_folderContainer.childCount > 0)
        {
            DestroyImmediate(_folderContainer.GetChild(0).gameObject);
        }
        _folders.Clear();
    }

    public void SetSelectedFolder(FolderItemController_Creation folder)
    {
        _fileManagementController.SetActiveFolder(folder);
    }

    public void SetFileManagementActive(bool active)
    {
        _fileManagementController.SetActive(active);
    }

    public void DestroyFolder(GameObject folder)
    {
        ConfirmPopupController.Instance.Activate("Do you want to delete this folder", answer =>
        {
            if (answer)
            {
                DestroyImmediate(folder);
                Save();
            }
        });
    }
}
