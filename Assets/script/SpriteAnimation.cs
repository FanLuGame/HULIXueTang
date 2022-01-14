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
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true)
        for (int i = 0; i < sps.Length; i++)
        {
            GetComponent<Image>().sprite = sps[i];
            yield return new WaitForSeconds(delay);
        }
    }


}
