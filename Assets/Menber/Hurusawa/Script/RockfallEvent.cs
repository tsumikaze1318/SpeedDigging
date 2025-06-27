using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockfallEvent : MonoBehaviour
{
    public GameObject RockPrefab;

    public int RockCount = 3;             // 生成する落石数（常に3個）
    public float SpawnRangeX = 3f;        // 横方向のばらつき範囲

    private int collapseRisk = 0;         // 崩落危険度
    private int pillarProtectionCount = 0;
    private bool isGameOver = false;

    void Start()
    {
        collapseRisk = 0;
        pillarProtectionCount = 0;
    }

    public void OnDig(bool isPillarPlaced)
    {
        SpawnFallingRock();

        //if (isGameOver) return;

        //if (isPillarPlaced)
        //{
        //    pillarProtectionCount = 3;
        //}

        //if (pillarProtectionCount > 0)
        //{
        //    pillarProtectionCount--;
        //}
        //else
        //{
        //    collapseRisk += 10;
        //    collapseRisk = Mathf.Clamp(collapseRisk, 0, 1000);
        //}

        //Debug.Log("現在の崩落危険度: " + collapseRisk + "%");

        //CheckCollapse();
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
        if (RockPrefab)
        {
            for (int i = 0; i < RockCount; i++)
            {
                Vector3 spawnPos = transform.position + Vector3.up * 5f;
                spawnPos.x += Random.Range(-SpawnRangeX, SpawnRangeX); 

                Instantiate(RockPrefab, spawnPos, Quaternion.identity);
            }
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            
        }
    }
}
