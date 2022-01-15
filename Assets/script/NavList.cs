using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavList : MonoBehaviour
{
    public Transform swtObj;
    public GameObject btnTemplet;
    public Color highLight = Color.red;
    public Color normalLight = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < swtObj.childCount; i++)
        {
            int tmp = i;
            GameObject go = Instantiate(btnTemplet);
            go.transform.parent = transform;
            go.GetComponentInChildren<Text>().text = swtObj.GetChild(i).name;
            go.AddComponent<Button>().onClick.AddListener(()=> {
                SwitchList.instance.SetIndex(tmp);
                Fresh();
            });
        }
        Fresh();
    }
    public void Fresh()
    {
        int index = SwitchList.instance.Index;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (index==i)
            {
                transform.GetChild(i).GetComponent<Image>().color = highLight;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color = normalLight;

            }
        }
    }
}
