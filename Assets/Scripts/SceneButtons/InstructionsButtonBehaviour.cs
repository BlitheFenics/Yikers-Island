using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonBehaviour : MonoBehaviour
{
    public AudioSource buttonSound;
    public void OnInstructionsButtonPressed()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Instructions");
    }
}
