using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CourseSavedModel;

public class CourseMakerController : MonoBehaviour
{
    [SerializeField] private FolderItemController _folderPrefab;
    [SerializeField] private Transform _container;


    public void AddNewFolderOnButtonClick()
    {
        AddNewFolder(_container);
    }

    public FolderItemController AddNewFolder(Transform container)
    {
        FolderItemController folder = Instantiate(_folderPrefab, container);
        folder.Init(this);
        return folder;
    }

    public void Save()
    {
        CourseSavedModel course = new CourseSavedModel();
        string name = "course1";
        course.Folders = new FolderSavedModel[_container.childCount];

        for (int i = 0; i < _container.childCount; i++)
        {
            course.Folders[i] = _container.GetChild(i).GetComponent<FolderItemController>().GetSavedModel();
        }

        CourseSaveManager.Instance.SaveCourse(course, name);
    }

    public void Load()
    {
        Clear();
        CourseSavedModel course = new CourseSavedModel();
        string name = "course1";
        course = CourseSaveManager.Instance.LoadCourse(name);

        for(int i=0 ; i<course.Folders.Length ; i++)
        {
            AddNewFolder(_container).Load(course.Folders[i]);
        }
    }

    public void Clear()
    {
        while (_container.childCount > 0)
        {
            DestroyImmediate(_container.GetChild(0).gameObject);
        }
    }
}
