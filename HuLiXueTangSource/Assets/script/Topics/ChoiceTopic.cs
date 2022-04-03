using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTopic : Topic
{
    public GameObject[] trueObjs;
    public GameObject[] falseObjs;
    public override bool Right()
    {
        bool res = true;
        foreach (var t in trueObjs)
        {
            if (!t.active)
            {
                res = false;
            }
        }
        foreach (var t in falseObjs)
        {
            if (t.active)
            {
                res = false;
            }
        }
  



        return res;
    }

}
