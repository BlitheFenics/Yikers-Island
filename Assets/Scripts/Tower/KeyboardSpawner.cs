using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSpawner : MonoBehaviour
{
    public GameObject TowerTransparent;
    public GameObject MiningTransparent;
    public GameObject AtomicTransparent;
    public GameObject WallTransparent;

    public GameObject CurrentlySelectedTower = null;

    

    void ClearHolos()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("holo"))
        {
            Destroy(obj);
        }
    }

    public void OnSelectTower1()
    {
        ClearHolos();
        CurrentlySelectedTower = Instantiate(TowerTransparent);
        CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
    }

    public void OnSelectTower2()
    {
        ClearHolos();
        CurrentlySelectedTower = Instantiate(MiningTransparent);
        CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
    }

    public void OnSelectTower3()
    {
        ClearHolos();
        CurrentlySelectedTower = Instantiate(AtomicTransparent);
        CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
    }

    public void OnSelectTower4()
    {
        ClearHolos();
        CurrentlySelectedTower = Instantiate(WallTransparent);
        CurrentlySelectedTower.GetComponent<Placement>().Spawner = this;
    }
}
