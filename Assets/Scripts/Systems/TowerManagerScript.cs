using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManagerScript : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> ActiveTowers;


    private void Start()
    {
        ResourceSystem.Instance.EnergyAdded.AddListener(ActivateTowers);
    }

    public void AddNewTower(GameObject NewTower)
    {
        ActiveTowers.Add(NewTower);

        NewTower.GetComponent<Tower>().DeathEvent.AddListener(RemoveTowerOnDeath);
    }

    private void RemoveTowerOnDeath(GameObject DeadTower)
    {
        ActiveTowers.Remove(DeadTower);
    }

    // Update is called once per frame
    void Update()
    {

        if (ResourceSystem.Instance.EnergyMax < ActiveTowers.Count)
        {
            for (int i = ResourceSystem.Instance.EnergyMax; i < ActiveTowers.Count; i++)
            {
                if (ActiveTowers[i].CompareTag("Energy"))
                {
                    MiningTower tower = ActiveTowers[i].GetComponent<MiningTower>();
                    tower.EffectWorking = false;
                }
                else if (ActiveTowers[i].CompareTag("Tower"))
                {
                    TowerTargeting tower = ActiveTowers[i].GetComponent<TowerTargeting>();
                    tower.EffectWorking = false;
                }
                
            }

            Debug.Log("Too many towers");
        }
    }

    private void ActivateTowers()
    {
        //activate all of the towers that are within the active energy range
        for (int i = 0; i < ResourceSystem.Instance.GetEnergy(); i++)
        {
            if (i > ActiveTowers.Count -1)
            {
                break;
            }
            if (ActiveTowers[i].CompareTag("Energy"))
            {
                MiningTower tower = ActiveTowers[i].GetComponent<MiningTower>();
                tower.EffectWorking = true;
            }
            else if (ActiveTowers[i].CompareTag("Tower"))
            {
                TowerTargeting tower = ActiveTowers[i].GetComponent<TowerTargeting>();
                tower.EffectWorking = true;
            }

        }
    }

    
}
