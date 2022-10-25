using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonbehaviour : MonoBehaviour
{
    public GameObject PauseCanvas;
    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1.0f;
        GetComponent<AudioSource>().Play();
        PauseCanvas.SetActive(false);
    }
}
