using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topic : MonoBehaviour 
{
    /// <summary>
    /// 该题的名称
    /// </summary>
    public string tpname="test";
    public int score = 0;
    public bool right = true;
    public int fullscore = 10;
    public virtual int Score()
    {
        return score;
    }
    public virtual int FullScore()
    {
        return fullscore;
    }
    public virtual string Tip()
    {
        return tpname;
    }
    public virtual bool Right()
    {
        return right;
    }
}
