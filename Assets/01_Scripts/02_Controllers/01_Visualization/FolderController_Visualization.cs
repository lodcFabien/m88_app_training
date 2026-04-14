using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using static CourseSavedModel;

public class FolderController_Visualization : MonoBehaviour
{
    [SerializeField] private FolderView_Visualization _view;
    [SerializeField] private VerticalLayoutGroup _vbMain;
    [SerializeField] private Transform _subFolderContainer;
    [SerializeField] private FileController_Visualization _filePrefab;

    private bool _collapsed = false;

    private CourseController_Visualization _courseController;

    public void SwtichCollapse()
    {
        SetCollapsed(!_collapsed);
    }

    public void Init(CourseController_Visualization courseController)
    {
        _courseController = courseController;
    }

    public void SetCollapsed(bool collapsed)
    {
        _collapsed = collapsed;
        _subFolderContainer.gameObject.SetActive(!_collapsed);
    }

    public void LoadFromSave(FolderSavedModel folderModel)
    {
        _view.SetName(folderModel.FolderName);

        for(int i=0 ; i<folderModel.SubFolders.Length ; i++)
        {
            AddSubFolder().LoadFromSave(folderModel.SubFolders[i]);
        }
        for (int i = 0; i < folderModel.Files.Length; i++)
        {
            AddFile(folderModel.Files[i]);
        }
    }


    public FolderController_Visualization AddSubFolder()
    {
        FolderController_Visualization folder = _courseController.AddNewFolder(_subFolderContainer);
        SetCollapsed(false);
        return folder;
    }

    public void AddFile(string path)
    {
        _courseController.AddFile(_subFolderContainer).Init(path);
    }


    private void Update()
    {
        _vbMain.spacing = _subFolderContainer.transform.childCount > 0 ? 10 : 0;
    }

}
