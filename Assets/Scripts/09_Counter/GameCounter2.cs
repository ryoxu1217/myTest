using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カウンター本体
public class GameCounter2 : MonoBehaviour
{
    //-------------------------------------
    public CounterType2 kind = CounterType2.Keys; // [カウンターの種類]
    public int startCount = 0; // [初期値] 
    //-------------------------------------
    public static Dictionary<CounterType2, int> counters = new Dictionary<CounterType2, int>();

    void Start()
    {
        counters[kind] = startCount;
    }
}
public enum CounterType2 { // カウンターの種類
    Keys, Hearts, Miss, Score, Gold, ItemA, ItemB, ItemC
}