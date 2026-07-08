using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

// 行ったり来たりする
public class PingPongMovev2 : MonoBehaviour
{
    //-------------------------------------
    public float speed = 1.0f;
    public float moveTime = 2.0f;
    //-------------------------------------
    Rigidbody2D rbody;
    private float timer = 0.0f;

    void Start()
    {
        // 重力や外力の影響を受けずにスプリクトで移動
        rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            speed = -speed;
            timer = 0.0f;
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}