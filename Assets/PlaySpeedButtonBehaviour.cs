using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpeedButtonBehaviour : MonoBehaviour
{
    public void OnPauseButtonPressed ()
    {
        Time.timeScale = 0;
    }

    public void OnNormalSpeedPressed()
    {
        Time.timeScale = 1;
    }

    public void OnSpeedupPressed()
    {
        Time.timeScale += 0.1f;
    }
}
