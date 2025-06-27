using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;

    int Score_m =  0;

    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GetComponent<TextMeshProUGUI>();
        Score_Text.text = "Score:" + Score_m;
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score : " + Score_m;
    }
}
