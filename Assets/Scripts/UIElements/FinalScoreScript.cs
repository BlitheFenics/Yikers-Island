using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{
    private Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
        Score.text = StatMoverScript.Instance.WaveReached.ToString();
        //Score.text = FindObjectOfType<StatMoverScript>().WaveReached.ToString();
    }

    
}
