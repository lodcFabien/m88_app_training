using System.Collections.Generic;
using UnityEngine;

public class QuizTimelineController : MonoBehaviour
{
    [SerializeField] private QuizTimelineItemController _prefab;
    [SerializeField] private Transform _container;

    private List<QuizTimelineItemController> _itemList = new List<QuizTimelineItemController>();

    public void Init(int number)
    {
        for (int i = 0; i < number; i++)
        {
            QuizTimelineItemController currentItem = Instantiate(_prefab, _container);  
            currentItem.Init(i);
            _itemList.Add(currentItem);
        }
    }

    public void SetActiveItems(int index)
    {
        _itemList.ForEach(x => x.SetActive(x.Index <= index));
    }

    public void Clear()
    {
        while (_itemList.Count > 0)
        {
            Destroy(_itemList[0].gameObject);
            _itemList.RemoveAt(0);
        }
    }
}
