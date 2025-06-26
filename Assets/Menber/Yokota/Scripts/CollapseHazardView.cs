using TMPro;
using UnityEngine;

public class CollapseHazardView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _percentageText;

    public void UpdatePercentageText(float percentage)
    {
        _percentageText.text = percentage.ToString("0");
    }
}
