using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : FileVisualizatorBaseController
{
    [SerializeField] private VideoPlayer _videoPlayer;

    public override void PlayFile(string path)
    {
        _videoPlayer.url = path;
        _videoPlayer.Play();
    }
}
