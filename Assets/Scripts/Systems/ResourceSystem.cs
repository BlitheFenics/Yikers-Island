using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResourceSystem : MonoBehaviour
{
    private static ResourceSystem _instance;

    public static ResourceSystem Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ResourceSystem>();
            }
            return _instance;
        }
    }

    // Resources
    [SerializeField]
    private int Plutonium;
    [SerializeField]
    private int Ore;
    [SerializeField]
    private int Energy;
    public int EnergyMax;
    // UI elements
    public Text plutoniumText;
    public Text oreText;
    public Text energyText;

    public int EarnedOre = 0;
    public int EarnedPlutonium = 0;

    public UnityEvent EnergyAdded;

    [SerializeField]
    private int EnergyGainedPerTower = 5;
    [SerializeField]
    private int StartingEnergy = 4;

    public int GetPlutonium()
    {
        return Plutonium;
    }
	
    public void SetPlutonium(int _Plutonium)
    {
        Plutonium = _Plutonium;

    }

    public void AddPlutonium( int _Plutonium)
    {
        Plutonium += _Plutonium;
        if (_Plutonium > 0)
            EarnedPlutonium += _Plutonium;
    }

    public int GetOre()
    {
        return Ore;
    }
    public void SetOre(int _ore)
    {
        Ore = _ore;
    }

    public void AddOre(int _ore)
    {
        Ore += _ore;
        if (_ore > 0)
            EarnedOre += _ore;
    }

    public int GetEnergy()
    {
        return Energy;
    }
    public void SetEnergy(int _energy)
    {
        Energy = _energy;
    }

    public void AddEnergy(int _energy)
    {
        Energy += _energy;
    }

    private void Start() // our starting resources
    {
        Plutonium = 50;
        Ore = 150;
        Energy = 0;
        //EnergyMax = GameObject.FindGameObjectsWithTag("Resource").Length;
    }

    private void FixedUpdate()
    {
        EnergyMax = (GameObject.FindGameObjectsWithTag("Energy").Length * EnergyGainedPerTower) + StartingEnergy;
        Energy = GameObject.FindGameObjectsWithTag("Tower").Length + GameObject.FindGameObjectsWithTag("Resource").Length;
        plutoniumText.text = /*"Plutonium: " +*/ Plutonium.ToString();
        oreText.text = /*"Ore: " +*/ Ore.ToString();
        energyText.text = /*"Energy: " +*/ Energy.ToString() + "/" + EnergyMax.ToString();
    }

    private void OnDestroy()
    {
        EnergyAdded.RemoveAllListeners();
    }

    public void AtomicTowerSpawned()
    {
        EnergyAdded.Invoke();
    }
}
