using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTopic : Topic
{
    public GameObject[] trueObjs;
    public bool falseMode;
    public override bool Right()
    {
        bool res = true;
        if (falseMode)
        {
            res = true;
            foreach (var g in trueObjs)
            {
                if (g.active)
                {
                    res = false;
                }
            }
        }
        else
        {
            foreach (var g in trueObjs)
            {
                if (!g.active) res = false;
            }

        }
        return res;
    }
}
