using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 行ったり来たりする
public class PingPongRidableFloor2 : MonoBehaviour
{
    //--------------------------------------
    public float speed = 1.0f;
    public float moveTime = 2.0f;
    //--------------------------------------
    Rigidbody2D robody;
    private float timer = 0.0f;
    private List<GameObject> childObjects = new List<GameObject>();

    void Start()
    {
        // 重力や外力の影響を受けずにスプリクトで移動
        robody = GetComponent<Rigidbody2D>();
        robody.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            speed = -speed; // 方向転換
            timer = 0.0f;
        }
        CheckRemeve(); // 接触しなくなったら、一緒に移動を解除
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // 接触したら、一緒に移動
    private void OnCollisionEnter2D(Collision2D other)
    {
        childObjects.Add(other.gameObject);
        other.gameObject.transform.parent = transform;
    }

    // 接触しなくなったら、一緒に移動を解除
    private void CheckRemeve()
    {
        List<GameObject> removeList = new List<GameObject>();
        foreach (GameObject obj in childObjects)
        {
            Collider2D childCol = obj.GetComponent<Collider2D>();
            Collider2D floorCol = GetComponent<Collider2D>();
            if (!Physics2D.IsTouching(childCol, floorCol))
            {
                obj.transform.parent = null;
                removeList.Add(obj);
            }
        }
        foreach (GameObject obj in removeList)
        {
            childObjects.Remove(obj);
        }
    }
}