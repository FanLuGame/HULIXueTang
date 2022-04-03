using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuncHelper : MonoBehaviour
{
    static FuncHelper instance;
    public GameObject tip;
    private void Awake()
    {
        instance = this;
    }
    public void ReloadGame(string scn)
    {
        SceneManager.LoadScene(scn);
    }
    /// <summary>
    /// 展示tip对话框
    /// </summary>
    /// <param name="msg"></param>
    public static void ShowTip(string msg)
    {
        if (instance.tip)
        {
            instance.tip.GetComponentInChildren<Text>().text = msg;
            instance.tip.SetActive(true);

        }


    }
}
