using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButtonBehaviour : MonoBehaviour
{
    public AudioSource buttonSound;
    public void OnPlayButtonPressed()
    {
        buttonSound.Play();
        StatMoverScript.Instance.SetLoadGame(false);
        SceneManager.LoadScene("NavMesh Test");

    }

    public void LoadGame()
    {
       if(! PlayerPrefs.HasKey("SaveSlot")) return;
       if (PlayerPrefs.GetString("SaveSlot") == "null") return;

        StatMoverScript.Instance.SetLoadGame(true);
        buttonSound.Play();
        SceneManager.LoadScene("NavMesh Test");
    }

    
}
