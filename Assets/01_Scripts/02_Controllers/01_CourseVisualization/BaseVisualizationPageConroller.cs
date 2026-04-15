using System;
using UnityEngine;
using static Enums;

public class BaseVisualizationPageConroller : MonoBehaviour
{
    [SerializeField] private VisualizationPageState _state;
    [SerializeField] private GameObject _activator;

    protected virtual void Awake()
    {
        CourseVisualizationManager.Instance.NewStateEvent.AddListener(ActionOnNewState);
    }

    private void ActionOnNewState(VisualizationPageState newState)
    {
        _activator.SetActive(newState == _state);
    }

    public void ChangeState(VisualizationPageState newState)
    {
        CourseVisualizationManager.Instance.SetNewState(newState);
    }
}
