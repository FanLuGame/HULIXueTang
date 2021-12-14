using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchList : MonoBehaviour
{
    private int index = 0;
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
        instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        Fresh();
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
