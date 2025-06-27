using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public float DestroyTime = 3f;

    void Start()
    {
        // 指定時間後に自動で削除
        Destroy(gameObject, DestroyTime);
    }
}
