using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 衝突すると、カウントを変更して自分を消す
public class OnCollisionCountChangeDestroyMe2 : MonoBehaviour
{
    //------------------------------------------
    public GameObject targetObject; // [目標オブジェクト]
    public string tagName; // [タグ名]
    public CounterType2 kind = CounterType2.Keys; // [カウンターの種類]
    public int addValue = 1; // [増加量]
    //------------------------------------------

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したものが、目標オブジェクトか、タグ名なら
        if (collision.gameObject == targetObject ||
            collision.gameObject.tag == tagName)
        {
            // カウンターの値を変更する
            GameCounter2.counters[kind] = GameCounter2.counters[kind] + addValue;
            // 自分自身を隠す
            Destroy(gameObject);
        }
    }
}