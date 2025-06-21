using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CollapseHazard
{
    public class CollapseHazardController : MonoBehaviour
    {

    }
}

namespace CollapseHazard
{
    public class CollapseHazardView : MonoBehaviour
    {
        private TMP_Text _percentageText;

        public void UpdatePercentageText(int percentage)
        {
            _percentageText.text = percentage.ToString();
        }
    }
}

namespace CollapseHazard
{
    public class CollapseHazardModel
    {
    }
}