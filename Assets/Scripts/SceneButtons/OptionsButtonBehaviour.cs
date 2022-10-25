using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtonBehaviour : MonoBehaviour
{
    public AudioSource buttonSound;
    public void OnOptionsButtonPressed()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Options");
    }
}
