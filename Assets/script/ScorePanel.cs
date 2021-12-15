using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Transform srParent;
    public GameObject srTemple;

    private void OnEnable()
    {
        foreach (var g in SwitchList.instance.transform.GetComponentsInChildren<Topic>(true))
        {
            Debug.Log(g.Tip() + "," + g.score);
            GameObject go = Instantiate(srTemple);
            ScoreResult sr = go.GetComponent<ScoreResult>();
            sr.fullscore.text = g.FullScore().ToString();
            sr.score.text = g.Score().ToString();
            sr.tip.text = g.Tip();
            go.transform.parent = srParent;
        }
    }

}
