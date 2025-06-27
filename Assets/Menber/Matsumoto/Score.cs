using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;

    public int Score_m =  0;

    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GetComponent<TextMeshProUGUI>();
        Score_Text.text = $"Score : {Score_m} m";
    }

    public void IncreaseScore()
    {
        Score_m += 1;
        Score_Text.text = $"Score : {Score_m} m";
    }
}
