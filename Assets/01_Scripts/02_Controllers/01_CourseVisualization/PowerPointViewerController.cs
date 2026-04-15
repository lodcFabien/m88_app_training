using JetBrains.Annotations;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class PowerPointViewerController : FileVisualizatorBaseController
{
    [SerializeField] private CourseVisualizationStateButtonController _backButton;

    public override void PlayFile(string path)
    {
        LoadPres(path);
    }

    async void LoadPres(string path)
    {
        Process p = Process.Start(path);

        await Task.Run(() => p.WaitForExit());

        if (!this.gameObject.activeInHierarchy)
        {
            return;
        }

        _backButton.ChangeState();
    }
}
