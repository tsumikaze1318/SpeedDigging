using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private RockfallEvent rockfallEvent;
    [SerializeField] private bool isPillarPlaced = false; // テスト用に柱を立てるかどうか

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rockfallEvent != null)
            {
                Debug.Log("Eキーが押された -> 採掘実行");
               rockfallEvent.OnDig(isPillarPlaced);
            }
        }
    }
}
