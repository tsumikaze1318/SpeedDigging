using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public float DestroyTime = 5f;

    void Start()
    {
        // 指定時間後に自動で削除
        Destroy(gameObject, DestroyTime);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに当たった！"); // これが出なければ衝突が発生してない

            RockfallEvent rockfallEvent = FindObjectOfType<RockfallEvent>();
            if (rockfallEvent != null)
            {
                rockfallEvent.GameOver();
            }
        }
    }
}
