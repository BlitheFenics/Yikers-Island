using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestTarget : MonoBehaviour
{
    [SerializeField]
    int dir = 1;
    [SerializeField]
    int Zdir = 1;
    [SerializeField]
    float XBounds;
    [SerializeField]
    float ZBounds;
    [SerializeField]
    float Speed;
    [SerializeField]
    float ZSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime, 0, Zdir * ZSpeed * Time.deltaTime);
        CheckBounds();
    }

    void CheckBounds()
    {
        if (transform.position.x < -XBounds)
        {
            dir = 1;
        }
        else if (transform.position.x > XBounds)
        {
            dir = -1;
        }

        if (transform.position.z < -ZBounds)
        {
            Zdir = 1;
        }
        else if (transform.position.z > ZBounds)
        {
            Zdir = -1;
        }
    }
}
