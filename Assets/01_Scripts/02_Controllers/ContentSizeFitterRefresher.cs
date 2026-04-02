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

    private IEnumerator Refresh()
    {
        while (true)
        {
            _contentSizeFitter.enabled = false;
            yield return new WaitForEndOfFrame();
            _contentSizeFitter.enabled = true;
            yield return new WaitForEndOfFrame();
        }
    }
}
