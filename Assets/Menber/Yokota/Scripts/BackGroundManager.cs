using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    private bool _animation = true;
    [SerializeField]
    private List<BackGround> _backGrounds;

    private void Start()
    {
        BackGroundAnimation();
    }

    public async void BackGroundAnimation()
    {
        Vector3[] vector3s = new Vector3[2];
        float deltaTime = 0f;

        while (_animation)
        {
            deltaTime = Time.deltaTime * 3;
            for (int i = 0; i < _backGrounds.Count; i++)
            {
                vector3s[i] = _backGrounds[i].transform.position;
                vector3s[i].x -= deltaTime;
                _backGrounds[i].transform.position = vector3s[i];
            }
            await UniTask.Yield();
        }
    }

    public void ReplaceBackGround(BackGround backGround)
    {
        backGround.transform.position = _backGrounds[^1].transform.position + Vector3.right * 20;
        var tmp = _backGrounds[0];
        _backGrounds[0] = _backGrounds[1];
        _backGrounds[1] = tmp;
    }

    public void SetAnimation(bool onAnimation)
    {
        _animation = onAnimation;
    }
}
