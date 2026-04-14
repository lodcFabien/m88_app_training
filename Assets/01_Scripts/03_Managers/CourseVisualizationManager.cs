using UnityEngine;
using UnityEngine.Events;
using static Enums;

public class CourseVisualizationManager : Singleton<CourseVisualizationManager>
{
    private VisualizationPageState _currentState;

    private UnityEvent<VisualizationPageState> _newStateEvent = new UnityEvent<VisualizationPageState>();
    public UnityEvent<VisualizationPageState> NewStateEvent => _newStateEvent;

    private void Start()
    {
        SetNewState(VisualizationPageState.CourseList);
    }
    public void SetNewState(VisualizationPageState state)
    {
        _currentState = state;
        NewStateEvent.Invoke(_currentState);    
    }


}
