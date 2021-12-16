using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuYinTopic : Topic
{
    public override int Score()
    {
        if (GetComponent<MicrophoneManager>().audioClip)
            return fullscore;
        return 0;
    }

}
