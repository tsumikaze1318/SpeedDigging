using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;

    public int ScoreValue =  0;

    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GetComponent<TextMeshProUGUI>();
        Score_Text.text = $"Score : {ScoreValue} m";
    }

    public void IncreaseScore()
    {
        ScoreValue += 5;
        Score_Text.text = $"Score : {ScoreValue} m";
    }
}
