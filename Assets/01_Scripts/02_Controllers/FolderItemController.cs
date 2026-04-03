using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using static CourseSavedModel;

public class FolderItemController : MonoBehaviour
{
    [SerializeField] private GameObject _childrenContainer;
    [SerializeField] private ReorderableListElement _listElement;
    [SerializeField] private VerticalLayoutGroup _vbMain;
    [SerializeField] private Transform _subFolderContainer;
    [SerializeField] private TMP_InputField _nameInputField;

    private bool _collapsed = false;

    private bool _wasCollapsedOnDrag = false;

    private CourseMakerController _courseMaker;

    public void Init(CourseMakerController courseMaker)
    {
        _courseMaker = courseMaker;
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
    }

    private void OnEndDrag()
    {
        SetCollapsed(_wasCollapsedOnDrag);
    }

    public void SwtichCollapse()
    {
        SetCollapsed(!_collapsed);
    }

    public void SetCollapsed(bool collapsed)
    {
        _collapsed = collapsed;
        _childrenContainer.SetActive(!_collapsed);
    }

    public void AddSubFolderOnButtonClick()
    {
        AddSubFolder();
    }

    public FolderItemController AddSubFolder()
    {
        FolderItemController folder = _courseMaker.AddNewFolder(_subFolderContainer);   
        SetCollapsed(false);
        return folder;
    }

    public FolderSavedModel GetSavedModel()
    {
        FolderSavedModel savedModel = new FolderSavedModel();
        FolderSavedModel[] subFolders = new FolderSavedModel[_subFolderContainer.childCount];


        for(int i=0 ; i< _subFolderContainer.childCount; i++)
        {
            subFolders[i] = _subFolderContainer.GetChild(i).GetComponent<FolderItemController>().GetSavedModel();
        }

        savedModel.Name = _nameInputField.text;
        savedModel.SubFolders = subFolders;
        return savedModel;
    }

    public void Load(FolderSavedModel folderModel)
    {
        _nameInputField.text = folderModel.Name;

        for(int i=0 ; i<folderModel.SubFolders.Length ; i++)
        {
            AddSubFolder().Load(folderModel.SubFolders[i]);
        }
    }

    private void Update()
    {
        _vbMain.spacing = _childrenContainer.transform.childCount > 0 ? 10 : 0;
    }
}
