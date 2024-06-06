using UnityEngine;
using UnityEngine.Video;

public class EndVidep : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoObject;

    void Start()
    {
        // Asegurarse de que el VideoPlayer est� asignado
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Suscribirse al evento loopPointReached
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // M�todo que se llama cuando el video termina
    void OnVideoEnd(VideoPlayer vp)
    {
        videoObject.SetActive(false);
    }
}
