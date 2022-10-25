using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadButtonScript : MonoBehaviour
{
    public void OnSaveButtonPressed()
    {
        GameObject.FindGameObjectWithTag("SaveLoadManager").GetComponent<SaveLoadManager>().Save();
    }
    public void OnLoadButtonPressed()
    {
        GameObject.FindGameObjectWithTag("SaveLoadManager").GetComponent<SaveLoadManager>().Load();
    }
}
