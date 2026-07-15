using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 時々、範囲内にランダムにプレハブを作る
public class SometimeRandomCreatePrefab2 : MonoBehaviour
{
    //----------------------------------------------
    public GameObject newPrefab;
    public float intervalSec = 1;
    public int newZ = -5;
    //----------------------------------------------

    void Start()
    {
        // 指定秒ごとに、CreatePrefabを繰り返し実行する予約
        InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
    }

    void CreatePrefab()
    {
        // このオブジェクトの範囲内にランダムに
        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;
        Vector3 newPos = transform.position;
        newPos.x += Random.Range(-area.x / 2, area.x / 2);
        newPos.y += Random.Range(-area.y / 2, area.y / 2);
        newPos.z = newZ;
        // プレハブを作ってその手前の位置に表示する
        GameObject newGameObject = Instantiate(newPrefab) as GameObject;
        newGameObject.transform.position = newPos;
    }
}