using System;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.WSA;
using static Enums;

public class CourseController_Visualization : BaseVisualizationPageConroller
{
    [SerializeField] private FolderController_Visualization _folderPrefab;
    [SerializeField] private FileController_Visualization _filePrefab;
    [SerializeField] private Transform _folderContainer;
    [SerializeField] private CourseView_Visualization _view;
    [SerializeField] private FileVisualizationController _fileVisualizationController;


    public void SetActiveCourse(CourseSavedModel model)
    {
        _view.SetTitle(model.CourseTitle);

        Clear();

        for (int i = 0; i < model.Folders.Length; i++)
        {
            AddNewFolder(_folderContainer).LoadFromSave(model.Folders[i]);
        }
    }

    public FolderController_Visualization AddNewFolder(Transform container)
    {
        FolderController_Visualization folder = Instantiate(_folderPrefab, container);
        folder.Init(this);
        return folder;
    }

    public FileController_Visualization AddFile(Transform container)
    {
        FileController_Visualization fileController =  Instantiate(_filePrefab, container);

        fileController.FileClickEvent.AddListener(ActionOnFileClicked);

        return fileController;
    }

    private void ActionOnFileClicked(string filePath)
    {
        ChangeState(VisualizationPageState.FileVisualization);
        _fileVisualizationController.SetCurrentFile(filePath);
    }

    public void Clear()
    {
        while (_folderContainer.childCount > 0)
        {
            DestroyImmediate(_folderContainer.GetChild(0).gameObject);
        }
    }

}
