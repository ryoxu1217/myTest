using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 時間切れになると、自分を削除する
public class OnTimeoutDestroyMe2 : MonoBehaviour
{
    //------------------------------------------
    public float limitSec = 3;
    //------------------------------------------
    void Start()
    {
        Destroy(gameObject, limitSec); // 数秒後に消滅する約束
    }
}
