using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollapseHazardView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _percentageText;
    [SerializeField]
    private Image _pillarImage;

    public void UpdatePercentageText(float percentage)
    {
        _percentageText.text = percentage.ToString("0");
    }

    public void DisplayPillarIcon(bool onDisplay)
    {
        _pillarImage.enabled = onDisplay;
    }
}
