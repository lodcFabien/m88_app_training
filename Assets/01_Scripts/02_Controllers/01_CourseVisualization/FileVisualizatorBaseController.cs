using UnityEngine;
using static Enums;

public class FileVisualizatorBaseController : MonoBehaviour
{
    [SerializeField] private FileType _associatedFile;
    public FileType AssociatedFile => _associatedFile;

    public virtual void PlayFile(string path)
    {

    }
}
