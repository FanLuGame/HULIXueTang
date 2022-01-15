using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchList : MonoBehaviour
{
    private int index = 0;
    public bool IsInstance = false;
    public int Index { get => index; set
        {
            index = value;
            OnObjChange?.Invoke(index);
        }
    }
    public event Action<int> OnObjChange;
    public static SwitchList instance;

    private void Awake()
    {
        if(IsInstance)
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        Fresh();
    }
    public void Tip()
    {
        Transform tmp = transform.GetChild(index);
        string msg=tmp.GetComponent<TipHelper>().tip;
        FuncHelper.ShowTip(msg);
    }

    void Fresh()
    {
        if (transform.childCount == 0) return;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == Index)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);

            }
        }
    }
    public void SetIndex(int i)
    {
        index = i;
        Fresh();
    }
    public void Previous()
    {
        if (Index - 1 >= 0) Index--;
        Fresh();
    }
    public void Next()
    {
        if (Index + 1 < transform.childCount) Index++;
        Fresh();
    }
}
