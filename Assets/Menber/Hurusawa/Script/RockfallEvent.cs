using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RockfallEvent : MonoBehaviour
{
    public GameObject RockPrefab;
    public Transform rockSpawnPoint;
    public int RockCount = 3;
    public float SpawamRangeX = 3f;

    private int collapseRisk = 0;  //落石の危険度
    private int pillarProtectionCount = 0; //落石の免除回数
    private bool isGameOver = false;

    void Start()
    {

        collapseRisk = 0;
        pillarProtectionCount = 0;

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

    //落石の判定
    void CheckCollapse()
    {

        if (collapseRisk >= 10 && collapseRisk <= 70)
        {
            int rand = Random.Range(1, 101);
            if (rand <= collapseRisk)
            {
                SpawnFallingRock(collapseRisk);
            }
        }
        else if (collapseRisk >= 80)
        {
            SpawnFallingRock(collapseRisk);
        }
    }

    //落石の生成
    void SpawnFallingRock(int count)
    {
        if (RockPrefab && rockSpawnPoint)
        {
            for (int i = 0; i < RockCount; i++)
            {
                Vector3 spawnPos = rockSpawnPoint.position;
                spawnPos.z += Random.Range(-1f, 1f);
                Instantiate(RockPrefab, rockSpawnPoint.position, Quaternion.identity);
            }
        }
    }

    //ゲームオーバーの処理
    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("Test Scene2");
    }


}
