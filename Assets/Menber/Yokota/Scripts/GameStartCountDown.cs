using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountDown : MonoBehaviour
{
    private float _timer = 3;
    private TMP_Text _timerText;

    private void OnEnable()
    {
        _timer = 3;
        _timerText = GetComponent<TMP_Text>();
        _timerText.text = _timer.ToString("0");
    }

    public async UniTask CountDownAsync()
    {
        while (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _timerText.text = Mathf.Ceil(_timer).ToString("0");
            await UniTask.Yield();
        }

        _timer = 0f;
        _timerText.text = _timer.ToString("0");
        gameObject.SetActive(false);
        await UniTask.Yield();
    }
}
