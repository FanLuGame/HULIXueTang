using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncHelper : MonoBehaviour
{
    public void ReloadGame(string scn)
    {
        SceneManager.LoadScene(scn);
    }
}
