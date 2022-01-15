using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTopic : Topic
{
    public GameObject[] trueToggles;
    public GameObject[] falseToggles;
    public override bool Right()
    {
        bool res = true;
        foreach (var t in trueToggles)
        {
            if (!t.active)
            {
                res = false;
            }
        }
        foreach (var t in falseToggles)
        {
            if (t.active)
            {
                res = false;
            }
        }
  



        return res;
    }

}
