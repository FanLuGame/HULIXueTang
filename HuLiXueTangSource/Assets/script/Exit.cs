using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public bool escapeTimes = false;
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void Update()
    {
        //Debug.Log(OnFont());
        if (Input.GetKeyDown(KeyCode.Escape)&&OnFont())
        {
            //这个地方可以写“再按一次退出”的提示
            Debug.Log("再按一次退出");
            Toast.Show("再按一次退出", 2, 1.2f);
            StartCoroutine(resetTimes());
            if (escapeTimes)
            {
                QuitGame();
            }
            escapeTimes = true;

        }

    }
    IEnumerator resetTimes()
    {
        yield return new WaitForSeconds(1);
        escapeTimes = false;
    }
    bool OnFont()
    {
        bool res = true;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            var g = transform.parent.GetChild(i);
            if (g!=transform&&g.gameObject.active)
            {
                res = false;
            }

        }
        
        return res;
    }
}
