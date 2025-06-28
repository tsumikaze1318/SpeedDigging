using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TimerText;
    [SerializeField]
    private Score _score;

    float limitTime = 60;


    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGame) return;

        limitTime -= Time.deltaTime;

        if (limitTime < 0 )
        {
            limitTime = 0;
            GameManager.Instance.Score = _score.ScoreValue;
            GameManager.Instance.ChangeScene(SceneType.Result);
        }

        TimerText.text = limitTime.ToString("F0");
    }
}
