using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchList : MonoBehaviour
{
    public int index = 0;
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
            if (i == index)
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
        if (index - 1 >= 0) index--;
        Fresh();
    }
    public void Next()
    {
        if (index + 1 < transform.childCount) index++;
        Fresh();
    }
}
