using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RebindingControlls : MonoBehaviour
{

    [SerializeField]
    private InputActionReference RebindingAction = null;
    [SerializeField]
    private PlayerInput PlayerInput = null;
    [SerializeField]
    private Text bindingDisplayNameText = null;
    [SerializeField]
    private GameObject startRebindObject = null;


    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private void Start()
    {
        int bindingIndex = RebindingAction.action.GetBindingIndexForControl(RebindingAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(RebindingAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

    }

    public void StartRebinding()
    {
        startRebindObject.SetActive(false);

        PlayerInput.SwitchCurrentActionMap("Rebind");

        rebindingOperation = RebindingAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>/left")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        int bindingIndex = RebindingAction.action.GetBindingIndexForControl(RebindingAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(RebindingAction.action.bindings[bindingIndex].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();
        startRebindObject.SetActive(true);

        PlayerInput.SwitchCurrentActionMap("TowerDefence");
    }

   
}
