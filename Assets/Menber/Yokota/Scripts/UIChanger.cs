using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChanger : MonoBehaviour
{
    [SerializeField]
    private Image _digUi;
    [SerializeField]
    private Image _pillarUi;

    [SerializeField]
    private Color _activeColor;
    [SerializeField]
    private Color _inactiveColor;

    public void ActivateDigUi(bool active)
    {
        if (active) { _digUi.color = _activeColor; }
        else { _digUi.color = _inactiveColor; }
    }

    public void ActivatePillarUi(bool active)
    {
        if (active) 
        {
            _pillarUi.color = _activeColor;
            _pillarUi.fillAmount = 1f;
        }
        else { _pillarUi.color = _inactiveColor; }
    }

    public void FillPillarUi(float f)
    {
        _pillarUi.fillAmount = f;
    }
}
