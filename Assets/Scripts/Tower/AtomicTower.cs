using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicTower : Tower
{
    
    private void Awake()
    {
        Type = TowerType.ATOMIC;
    }

    private void Start()
    {
        PayCost();

        updateHealth();
        ResourceSystem.Instance.AtomicTowerSpawned();
    }


}
