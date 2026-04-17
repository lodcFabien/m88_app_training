using System;
using System.Collections;
using UnityEngine;

public class ConfirmPopupController : Singleton<ConfirmPopupController>
{
    [SerializeField] private GameObject _activator;
    [SerializeField] private ConfirmPopupView _view;

    private int _answer = -1;

    private void Awake()
    {
        _activator.SetActive(false);
    }

    public void Activate(string text, Action<bool> callback)
    {
        _answer = -1;
        _activator.SetActive(true);
        _view.Populate(text);

        StartCoroutine(WaitForResponse(x => { callback.Invoke(x); }));
    }

    public IEnumerator WaitForResponse(Action<bool> callback)
    {
        while(_answer < 0)
        {
            yield return new WaitForEndOfFrame();
        }
        callback.Invoke(_answer == 1);
    }

    public void Answer(int answer)
    {
        _answer = answer;
        _activator.SetActive(false);
    }
}
