using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DeleteTower : MonoBehaviour
{
    public GameObject button;

    public bool clicked = false;
    public bool clickedTower = false;

    private CameraController CameraController;

    public LayerMask RaycastMask;


    // Start is called before the first frame update
    void Start()
    {

        CameraController = FindObjectOfType<CameraController>();

    }

    public GameObject objectToDestroy;

    public void DestroyGameObject()
    {
        if (objectToDestroy == null)
            return;
        if(objectToDestroy.CompareTag("Tower"))
        {
            ResourceSystem.Instance.AddOre(15);
            ResourceSystem.Instance.AddEnergy(-1);
        }
        if (objectToDestroy.CompareTag("Energy"))
        {
            ResourceSystem.Instance.AddPlutonium(15);
            ResourceSystem.Instance.EnergyMax -= 1;
        }
        if (objectToDestroy.CompareTag("Resource"))
        {
            //ResourceSystem.Instance.AddOre();
            ResourceSystem.Instance.AddEnergy(-1);
        }
        Destroy(objectToDestroy);
        button.SetActive(false);
    }

    public void OnTargetTower(InputValue input)
    {
        clicked = input.isPressed;
        if (!clicked)
            return;
        //clickedTower = true;

        StartCoroutine(TryDestroyTower());


        Debug.Log("Clicked Tower!");
    }

    IEnumerator TryDestroyTower()
    {
        yield return new WaitForSeconds(0.2f);

        var ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, RaycastMask))
        {
            /*objTransform = hit.transform;
            hit.transform.gameObject.CompareTag("Tower")
            var obj = objTransform.gameObject.name;*/
            if (!hit.transform.gameObject.CompareTag("UI"))
            { 
                if (hit.transform.gameObject.CompareTag("Tower") || hit.transform.gameObject.CompareTag("Energy") || hit.transform.gameObject.CompareTag("Resource") || hit.transform.gameObject.CompareTag("Wall"))
                {

                    button.SetActive(true);
                    objectToDestroy = hit.transform.gameObject;

                }
                else
                {
                    objectToDestroy = null;
                    button.SetActive(false);
                }
            }
        }
        else
        {
            button.SetActive(false);

        }
    }
}
