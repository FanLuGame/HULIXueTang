using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 循环播放sprite
/// </summary>
public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sps;
    public float delay=0.2f;
    [SerializeField]
    float timer = 0;
    [SerializeField]
    int i = 0;
    // Start is called before the first frame update
    



    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>delay)
        {
            timer = 0;
            GetComponent<Image>().sprite = sps[i];
            i = (i + 1) % sps.Length;
        }
    }
}
