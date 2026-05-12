using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class CourseTypesController : MonoBehaviour
{
    [SerializeField] private List<CourseTypeController> _types = new List<CourseTypeController>();

    private UnityEvent _newTypeSelected = new UnityEvent();
    public UnityEvent NewTypeSelected => _newTypeSelected;

    public CourseType SelectedType => (_types.Find(x => x.Selected)).Type;

    private void Awake()
    {
        _types.ForEach(x => x.TypeClicked.AddListener(ActionOnNewType));
    }

    public void ActionOnNewType(CourseTypeController type)
    {
        _types.ForEach(x => x.SetSelected(x == type));
        _newTypeSelected.Invoke();
    }

    public void SetSelectedTypeOnLoad(CourseType type)
    {
        ActionOnNewType(_types.Find(x => x.Type == type));
    }
}
