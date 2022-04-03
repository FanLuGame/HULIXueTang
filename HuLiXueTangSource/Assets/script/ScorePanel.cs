using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Transform srParent;
    public GameObject srTemple;
    public Sprite succIcon;
    public Sprite failIcon;
    public Text endScore;
    public Text endFullScore;
    public Text rightRate;

    private void OnEnable()
    {
        int i = 1;
        int fullCount = 0;
        int rightCount = 0;

        foreach (var g in SwitchList.instance.transform.GetComponentsInChildren<Topic>(true))
        {
            Debug.Log(g.Tip() + "," + g.score);
            GameObject go = Instantiate(srTemple);
            ScoreResult sr = go.GetComponent<ScoreResult>();
            //int sc = g.Score();

            fullCount +=1;
            if (g.Right())
            {
                sr.score.color = new Color(52f/255f,199f/255f,89f/255f);
                sr.score.text = "+"+g.Score().ToString();
                sr.scoreImage.sprite = succIcon;
                rightCount++;
            }
            else
            {
                sr.score.color = new Color(255f / 255f, 59f / 255f, 48f / 255f);
                sr.score.text =   g.Score().ToString();
                sr.scoreImage.sprite = failIcon;
            }
            sr.title.text = $"步骤{ ToCN(i.ToString())}({g.FullScore()}分)";
            sr.tip.text = g.Tip();
            go.transform.parent = srParent;
            i++;
        }
        endScore.text = rightCount.ToString();
        endFullScore.text = $"得分";
        rightRate.text = $"正确率{((float)rightCount / fullCount * 100f).ToString("0.0")}%";
    }


    static string ToCN(string n)
    {
        return n.Replace("0", "零").Replace("1", "一").Replace("2", "二").
            Replace("3", "三").Replace("4", "四").Replace("5", "五").Replace("6", "六")
            .Replace("7", "七").Replace("8", "八").Replace("9", "九");
    }
}
