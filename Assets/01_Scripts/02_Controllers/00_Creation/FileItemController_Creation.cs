using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public class FileItemController_Creation : MonoBehaviour
{
    [SerializeField] private FileItemView_Creation _view;
    [SerializeField] private ReorderableListElement _reorderableListElement;

    private UnityEvent<FileItemController_Creation> _deleteEvent = new UnityEvent<FileItemController_Creation>();
    public UnityEvent<FileItemController_Creation> DeleteEvent => _deleteEvent;

    private string _fileName = string.Empty;
    public string FileName => _fileName;

    private UnityEvent _endDravEvent = new UnityEvent();
    public UnityEvent EndDragEvent => _endDravEvent;

    private void Awake()
    {
        _reorderableListElement.OnEndDragEvent.AddListener(ActionOnDragEnd);
    }

    private void ActionOnDragEnd()
    {
        EndDragEvent.Invoke();
    }

    public void Init(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        _view.SetName($"../{fileInfo.Name}");
        _fileName = fileName;
    }

    public void Delete()
    {
        DeleteEvent.Invoke(this);
    }

}
