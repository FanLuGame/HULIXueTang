using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnima : MonoBehaviour
{
    public float v = 0.1f;
    int dir = 1;

    // Update is called once per frame
    void Update()
    {
        Image im = GetComponent<Image>();
        if (im)
        {
            Color c = im.color;
            c.a += Time.deltaTime * v * dir;
            im.color = c;
            if (c.a>1||c.a<0)
            {
                dir = -dir;
            }
        }
    }
}
