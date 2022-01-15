using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuYinTopic : Topic
{
    public MicrophoneManager mm;
    public override int Score()
    {
        if (mm.audioClip)
            return fullscore;
        return 0;
    }
    public override bool Right()
    {
        if (mm.audioClip)
            return true;
        return false;
    }
}
