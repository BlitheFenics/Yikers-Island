using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum InventoryState
{
    Open,
    Closed
}

public class InventoryButtonBehavior : MonoBehaviour
{
    RectTransform parentRectTransform;
    InventoryState state = InventoryState.Open;
    [SerializeField]
    RawImage rawImage;
    [SerializeField]
    List<Texture> Images;
    private float Offset = 0;
    private void Awake()
    {
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        if (StatMoverScript.Instance.IsRightHanded)
        {
            Offset = 0;
        }
        else
        {
            Offset = -1100;
        }
        transform.position += new Vector3(Offset, 0, 0);
    }

    public void OnInventoryButtonClicked()
    {
        switch (state)
        {
            case InventoryState.Open:
                state = InventoryState.Closed;
                rawImage.texture = Images[0];
                break;
            case InventoryState.Closed:
                state = InventoryState.Open;
                rawImage.texture = Images[1];
                break;
        }
    }

    private void Update()
    {
        switch(state)
        {
            case InventoryState.Open:
                parentRectTransform.position = new Vector3(parentRectTransform.position.x, Mathf.Lerp(parentRectTransform.position.y, 0 ,Time.deltaTime), parentRectTransform.position.z);
                break;
            case InventoryState.Closed:
                parentRectTransform.position = new Vector3(parentRectTransform.position.x, Mathf.Lerp(parentRectTransform.position.y, -300, Time.deltaTime), parentRectTransform.position.z);
                break;
        }
    }
}
