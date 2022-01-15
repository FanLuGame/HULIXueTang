using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WuPinZhunBei : MonoBehaviour
{
    public GameObject[] clicks;
    public GameObject[] selecteds;
    // Start is called before the first frame update
    void Start()
    {
        if (clicks.Length != selecteds.Length) {
            Debug.Log("物品准备。代选列表和已选列表长度不一致");
            return;
        }
        for (int i = 0; i < clicks.Length; i++)
        {
            int j = i;//新建内存临时存储
            clicks[i].AddComponent<Button>().onClick.AddListener(()=> {
                selecteds[j].SetActive(true);
                clicks[j].SetActive(false);
                SoundHelp.instance.PlaySound(0.6f);
            });
            selecteds[i].AddComponent<Button>().onClick.AddListener(()=> {
                selecteds[j].SetActive(false);
                clicks[j].SetActive(true);
                SoundHelp.instance.PlaySound(0.6f);

            });

        }
    }


}
