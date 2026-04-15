using UnityEngine;
using UnityPdfViewer;

public class PdfViewerController : FileVisualizatorBaseController
{
    [SerializeField] private PdfViewerUI _viewer;

    public override void PlayFile(string path)
    {
        _viewer.LoadPDF(path);
    }
}
