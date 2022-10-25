using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSelectionComponent : MonoBehaviour
{
    public GameObject[] WindowsSceneObjects;
    public GameObject[] MobileSceneObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform ==  RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WebGLPlayer)
        {
            foreach (var sceneObject in MobileSceneObjects)
            {
                sceneObject.SetActive(false);
            }
        }
        else if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            foreach (var sceneObject in WindowsSceneObjects)
            {
                sceneObject.SetActive(false);
            }
        }
    }

    
}
