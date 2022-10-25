using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMoverScript : MonoBehaviour
{

    private StatMoverScript() { }

    private static StatMoverScript instance;
    public static StatMoverScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StatMoverScript>();
            }
            return instance;
        }
        private set { }
    }


    public bool LookControlsInverted = false;
    public bool IsRightHanded = true;

    public int WaveReached;

    private bool GameLoaded = false;

    public void SetLoadGame(bool loaded)
    {
        GameLoaded = loaded;
    }

    public bool IsGameLoaded()
    {
        return GameLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        StatMoverScript[] statMovers = FindObjectsOfType<StatMoverScript>();
        foreach (StatMoverScript mover in statMovers)
        {
            if (mover != Instance)
            {
                Destroy(mover.gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    
}
