using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandControlSchemeComponent : MonoBehaviour
{
    [SerializeField]
    private Text ButtonText;

    private void Start()
    {
        UpdateButtonText();
    }
    public void ToggleControlls()
    {
        StatMoverScript.Instance.IsRightHanded = !StatMoverScript.Instance.IsRightHanded;
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        ButtonText.text = (StatMoverScript.Instance.IsRightHanded ? "Right Handed" : "Left Handed   ");
    }
}
