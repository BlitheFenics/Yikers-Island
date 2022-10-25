using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : Tower
{

    private void Awake()
    {
        Type = TowerType.WALL;
        //plutoniumCost = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        PayCost();

        updateHealth();
    }

   
}
