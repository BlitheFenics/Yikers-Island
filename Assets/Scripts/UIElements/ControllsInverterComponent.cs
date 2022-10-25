using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllsInverterComponent : MonoBehaviour
{
    [SerializeField]
    private Text ButtonText;

    private void Start()
    {
        UpdateButtonText();
    }
    public void ToggleControlls()
    {
        StatMoverScript.Instance.LookControlsInverted = !StatMoverScript.Instance.LookControlsInverted;
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        ButtonText.text = (StatMoverScript.Instance.LookControlsInverted? "Inverted":"Regular");
    }
}
