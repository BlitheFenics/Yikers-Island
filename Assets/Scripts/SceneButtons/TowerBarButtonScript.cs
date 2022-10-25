using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBarButtonScript : MonoBehaviour
{
    [SerializeField]
    TowerType tower = TowerType.ATTACKING;
    
    public void OnTowerBarButtonPressed()
    {
        switch (tower)
        {
            case TowerType.ATTACKING:
                Debug.Log("Attack Tower Selected");
                break;
            case TowerType.MINING:
                Debug.Log("Mining Selected");
                break;
            case TowerType.ATOMIC:
                Debug.Log("Atomic Tower Selected");
                break;
            case TowerType.WALL:
                Debug.Log("Wall Selected");
                break;
            default:
                break;
        }
    }
}
