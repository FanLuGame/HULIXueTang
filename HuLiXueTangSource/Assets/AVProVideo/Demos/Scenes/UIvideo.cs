using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIvideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rawImage = this.GetComponent<RawImage>();

        videoPlayer = this.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.texture = videoPlayer.texture;

    }
}
