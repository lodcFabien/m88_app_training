using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ContentSizeFitterRefresher : MonoBehaviour
{
    private ContentSizeFitter _contentSizeFitter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _contentSizeFitter = this.GetComponent<ContentSizeFitter>();   
    }

    private void OnEnable()
    {
        StartCoroutine(Refresh());
    }

    private IEnumerator Refresh()
    {
        while (true)
        {
            _contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            yield return new WaitForEndOfFrame();
            _contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            yield return new WaitForEndOfFrame();
        }
    }
}
