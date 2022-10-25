using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart, direction;
    public Camera cam;
    //public Text text;

    public float groundZ = 0f, zoomMin, zoomMax, cameraDistance, scrollSpeed;

    private bool IsPressed = false;
    Vector2 PreviousMousePosition;
    public Vector2 CurrentMousePosition;

    int movementDirection;

    private void Start()
    {
        movementDirection = (StatMoverScript.Instance.LookControlsInverted ? -1 : 1);
    }

   

    private Vector3 GetWorldPosition(float z)
    {
        Ray mousePos = cam.ScreenPointToRay(CurrentMousePosition);
        Plane ground = new Plane(Vector3.down, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

    public void OnClick(InputValue input)
    {
        Debug.Log("LeftClick");

        IsPressed = input.isPressed;
        if (IsPressed)
        {
            touchStart = GetWorldPosition(groundZ);
        }

    }

    public void OnScrollWheel(InputValue input)
    {

        Vector2 Scroll = input.Get<Vector2>();
        //Debug.Log(Scroll);
        if (Scroll.y == 0) return;

        cameraDistance += Scroll.y * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, zoomMin, zoomMax);
        if (Scroll.y <= 0)
            if (cameraDistance != zoomMax && cameraDistance != zoomMin)
                Camera.main.transform.position += Vector3.forward * cameraDistance + Vector3.down * cameraDistance;
        if (Scroll.y >= 0)
            if (cameraDistance != zoomMin && cameraDistance != zoomMax)
                Camera.main.transform.position -= Vector3.forward * cameraDistance + Vector3.down * cameraDistance;

    }

    public void OnPoint(InputValue input)
    {
        CurrentMousePosition = input.Get<Vector2>();

       
        if (IsPressed)
        {
            direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction.normalized * movementDirection;

            float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
            //float clampX = Mathf.Clamp(Camera.main.transform.position.x, -100, 100);
            float clampZ = Mathf.Clamp(Camera.main.transform.position.z, -70, 40);

            Camera.main.transform.position = new Vector3(clampX, Camera.main.transform.position.y, clampZ);

        }

        PreviousMousePosition = CurrentMousePosition;
    }

}
