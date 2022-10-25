using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningTower : Tower
{
    [SerializeField]
    float startTime = 0f;
    [SerializeField]
    float endTime = 5f;

    public AudioSource MiningSound;

    [SerializeField]
    private int OreGained = 5;

    public bool EffectWorking = true;
    private void Awake()
    {
        Type = TowerType.MINING;
        energyCost = 1;
    }

    private void Start()
    {
        PayCost();

        updateHealth();
    }
    private void Update()
    {
        if (!EffectWorking) return;


        if (startTime >= endTime)
        {
            //ResourceSystem.Instance.SetOre(ResourceSystem.Instance.GetOre() + 1); // some bug, adding 2 ore for some reason.
            ResourceSystem.Instance.AddOre(OreGained);
            MiningSound.Play();
            startTime = 0f;
        }
        startTime += Time.deltaTime;
    }
}
