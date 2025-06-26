using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockfallEvent : MonoBehaviour
{
    public GameObject RockPrefab;
    public Transform playerTransform;

    public int RockCount = 3;             // 生成する落石数（常に3個）
    public float SpawnRangeX = 3f;        // 横方向のばらつき範囲

    private int collapseRisk = 0;         // 崩落危険度
    private int pillarProtectionCount = 0;
    private bool isGameOver = false;

    void Start()
    {
        collapseRisk = 0;
        pillarProtectionCount = 0;

        // 自動でプレイヤーを取得（オプション）
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    public void OnDig(bool isPillarPlaced)
    {
        if (isGameOver) return;

        if (isPillarPlaced)
        {
            pillarProtectionCount = 3;
        }

        if (pillarProtectionCount > 0)
        {
            pillarProtectionCount--;
        }
        else
        {
            collapseRisk += 10;
            collapseRisk = Mathf.Clamp(collapseRisk, 0, 1000);
        }

        Debug.Log("現在の崩落危険度: " + collapseRisk + "%");

        CheckCollapse();
    }

    void CheckCollapse()
    {
        if (collapseRisk >= 10 && collapseRisk <= 70)
        {
            int rand = Random.Range(1, 101); // 1〜100
            if (rand <= collapseRisk)
            {
                SpawnFallingRock();
            }
        }
        else if (collapseRisk >= 80)
        {
            SpawnFallingRock(); // 80%以上は常に落石発生
        }
    }

    void SpawnFallingRock()
    {
        if (RockPrefab && playerTransform)
        {
            for (int i = 0; i < RockCount; i++)
            {
                Vector3 spawnPos = playerTransform.position + Vector3.up * 5f;
                spawnPos.x += Random.Range(-SpawnRangeX, SpawnRangeX); 

                Instantiate(RockPrefab, spawnPos, Quaternion.identity);
            }

            Debug.Log($"プレイヤーの頭上に {RockCount} 個の落石を生成");
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("ゲームオーバー！");
            SceneManager.LoadScene("Test Scene2");
        }
    }
}
