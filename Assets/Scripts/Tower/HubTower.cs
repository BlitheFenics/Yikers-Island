using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubTower : Tower
{
    [SerializeField]
    private bool InMenu = false;
    private void Awake()
    {
        Type = TowerType.HUB;
        energyCost = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(currentHP, maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (InMenu) return;
        healthBar.SetHealth(currentHP, maxHP);
    }

    public void OnDestroy()
    {
        if (InMenu) return;


        if (currentHP <= 0)
        {

            PlayerPrefs.SetString("SaveSlot", "null");
            SceneManager.LoadScene("GameOver");
        }
    }
}
