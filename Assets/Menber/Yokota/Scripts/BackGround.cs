using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private BackGroundManager _manager;

    private void Awake()
    {
        _manager = GetComponentInParent<BackGroundManager>();
    }

    private void Update()
    {
        if (Camera.main.transform.position.x - transform.position.x > 20)
        {
            _manager.ReplaceBackGround(this);
        }   
    }
}
