using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static Enums;

public class FileVisualizationController : BaseVisualizationPageConroller
{
    [SerializeField] private List<FileVisualizatorBaseController> _visualizators = new List<FileVisualizatorBaseController> ();

    public void SetCurrentFile(string path)
    {
        FileType fileType = GetFileType(path);

        _visualizators.ForEach(x => x.gameObject.SetActive(x.AssociatedFile == fileType));

        _visualizators.Find(x => x.AssociatedFile == fileType).PlayFile(path);
    }

    private FileType GetFileType(string path)
    {
        FileInfo fileInfo = new FileInfo(path);

        if(fileInfo.Extension == ".mp4")
        {
            return FileType.Video;
        }
        else if (fileInfo.Extension == ".pdf")
        {
            return FileType.Pdf;
        }
        else
        {
            return FileType.PowerPoint;
        }

    }
}
