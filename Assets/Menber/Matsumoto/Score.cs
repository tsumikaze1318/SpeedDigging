using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;

    int Score_m =  0;

    // Start is called before the first frame update
    void Start()
    {
        Score_Text.text = "Score:" + Score_m;
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score:" + Score_m;
        if (Input.GetKey(KeyCode.Space))
        {
            Score_m++;
        }
    }
}
