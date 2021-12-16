using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTopic : Topic
{
    public Toggle[] trueToggles;
    public Toggle[] falseToggles;
    [Tooltip("严格模式错一题不得分。非严格模式错一项减onescore分")]
    public bool strictMod = false;
    public int oneScore = 1;
    public override int Score()
    {
        int res = fullscore;
        foreach (var t in trueToggles)
        {
            if (!t.isOn)
            {
                res-=oneScore;
            }
        }
        foreach (var t in falseToggles)
        {
            if (t.isOn)
            {
                res -= oneScore;
            }
        }
        if (res < 0) res = 0;

        if (strictMod)
        {
            if (res<fullscore)
            {
                return 0;
            }
            else
            {
                return fullscore;
            }
        }

        return res;
    }

}
