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

public class FolderItemController_Creation : MonoBehaviour
{
    [SerializeField] private FolderItemView_Creation _view;
    [SerializeField] private ReorderableListElement _listElement;
    [SerializeField] private VerticalLayoutGroup _vbMain;
    [SerializeField] private Transform _subFolderContainer;
    [SerializeField] private ReorderableList _reordarableList;

    private bool _collapsed = false;

    private bool _wasCollapsedOnDrag = false;

    private CourseCreationController _courseMaker;

    private List<string> _files = new List<string>();
    public List<string> Files => _files;

    private UnityEvent<FolderItemController_Creation> _clickEvent = new UnityEvent<FolderItemController_Creation>();
    public UnityEvent<FolderItemController_Creation> ClickEvent => _clickEvent;

    public string Title => _view.GetName();

    public void Init(CourseCreationController courseMaker)
    {
        _courseMaker = courseMaker;
        _reordarableList.DraggableArea = courseMaker.DraggableArea;
    }

    private void Awake()
    {
        _listElement.OnBeginDragEvent.AddListener(OnBeginDrag);
        _listElement.OnEndDragEvent.AddListener(OnEndDrag);
    }

    private void OnBeginDrag()
    {
        _wasCollapsedOnDrag = _collapsed;
        SetCollapsed(true);
        _courseMaker.SetFileManagementActive(false);
    }

    private void OnEndDrag()
    {
        SetCollapsed(_wasCollapsedOnDrag);
        _courseMaker.SetFileManagementActive(true);
    }

    public void SwtichCollapse()
    {
        SetCollapsed(!_collapsed);
    }

    public void SetCollapsed(bool collapsed)
    {
        _collapsed = collapsed;
        _subFolderContainer.gameObject.SetActive(!_collapsed);
    }

    public void AddSubFolderOnButtonClick()
    {
        AddSubFolder();
        _courseMaker.Save();
    }

    public FolderItemController_Creation AddSubFolder()
    {
        FolderItemController_Creation folder = _courseMaker.AddNewFolder(_subFolderContainer);   
        SetCollapsed(false);
        return folder;
    }

    public FolderSavedModel MakeSavedModel()
    {
        FolderSavedModel savedModel = new FolderSavedModel();
        string[] files = new string[_files.Count];
        List<FolderSavedModel> subFolders = new List<FolderSavedModel>();

        for (int i = 0; i < _subFolderContainer.childCount; i++)
        {
            if (_subFolderContainer.GetChild(i).GetComponent<FolderItemController_Creation>() != null)
            {
                subFolders.Add(_subFolderContainer.GetChild(i).GetComponent<FolderItemController_Creation>().MakeSavedModel());
            }
        }

        for (int i = 0; i < _files.Count; i++)
        {
            files[i] = _files[i];
        }

        savedModel.FolderName = _view.GetName();
        savedModel.SubFolders = subFolders.ToArray();
        savedModel.Files = files;
        return savedModel;
    }

    public void MakeItemFromSave(FolderSavedModel folderModel)
    {
        _view.SetName(folderModel.FolderName);

        for(int i=0 ; i<folderModel.SubFolders.Length ; i++)
        {
            AddSubFolder().MakeItemFromSave(folderModel.SubFolders[i]);
        }

        for (int i = 0; i < folderModel.Files.Length; i++)
        {
            _files.Add(folderModel.Files[i]);
        }
    }

    private void Update()
    {
        _vbMain.spacing = _subFolderContainer.transform.childCount > 0 ? 10 : 0;
    }

    public void Destroy()
    {
        _courseMaker.DestroyFolder(this.gameObject);
    }

    public void ClickOnItem()
    {
        ClickEvent.Invoke(this);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            _courseMaker.SetSelectedFolder(this);
        }
        _view.SetSelected(selected);
    }

    public void SetFiles(List<string> files)
    {
        _files = files;
        _courseMaker.Save();
    }

}
