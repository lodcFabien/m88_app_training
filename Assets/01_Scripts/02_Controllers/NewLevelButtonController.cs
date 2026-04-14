using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelButtonController : MonoBehaviour
{
    [SerializeField] string _sceneName;

    public void OpenLevel()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
