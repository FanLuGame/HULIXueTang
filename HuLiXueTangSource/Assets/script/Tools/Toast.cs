using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    public Image img;
    public Text msg;
    public float k = 1;
    float cu_al;
    public static Toast instance;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Color t;
        Color t2;
        t = img.color;
        t2 = msg.color;
        cu_al -= k * Time.deltaTime;
        t.a = cu_al;
        t2.a =cu_al;
        
        if (t.a < 0) t.a = 0;
        img.color = t;
        msg.color = t2;

    }
    public void AlShow()
    {
        cu_al = 2;
        Color t;
        Color t2;
        t = img.color;
        t2 = msg.color;
        t.a = 1;
        t2.a = 1;
        img.color = t;
        msg.color = t2;
    }

    public static void Show(string m,float k=1,float startT=2)
    {
        instance.cu_al = startT;
        instance.gameObject.SetActive(true);
        instance.msg.text = m;
        instance.k = k;
        instance.AlShow();
    }
}
