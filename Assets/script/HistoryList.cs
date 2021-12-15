using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryList : MonoBehaviour
{
    public GameObject stepTemple;
    int maxindex = -1;
    private void Start()
    {
        SwitchList.instance.OnObjChange += Fresh;
    }
    public void Fresh(int i)
    {
        if (i>maxindex)
        {
            maxindex = i;
            Topic tp = SwitchList.instance.transform.GetChild(i).GetComponent<Topic>();
            if (tp)
            {
                GameObject go = Instantiate(stepTemple);
                go.transform.parent = transform;
                Text t = go.GetComponentInChildren<Text>();
                t.text= tp.Tip();
            }
        }
    }
}
