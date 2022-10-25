using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButtonBehaviour : MonoBehaviour
{
    public AudioSource buttonSound;
    public void OnReturnButtonPressed()
    {
        buttonSound.Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
