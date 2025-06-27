using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    [SerializeField]
    private BackGroundManager _backGroundManager;

    public void OnAnyButton(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            GameManager.Instance.ChangeScene(SceneType.Game);
        }
    }

    public void StopBackGroundAnimation()
    {
        _backGroundManager.SetAnimation(false);
    }
}
