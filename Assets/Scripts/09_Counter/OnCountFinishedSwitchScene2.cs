using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// カウントが最終値なら、シーンを切り替える
public class OnCountFinishedSwitchScene2 : MonoBehaviour
{
    //----------------------------------------
    public CounterType2 kind = CounterType2.Keys; // [カウンターの種類]
    public int lastCount = 3; // [最終値]
    public string sceneName; // [シーン名]
    //----------------------------------------

    void Update()
    {
        if (GameCounter2.counters[kind] == lastCount) // カウンターが最終値になったら
        {
            SceneManager.LoadScene (sceneName); // シーンを切り替える
        }
    }
}