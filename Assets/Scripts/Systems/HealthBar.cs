using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Color low;
    public Color high;

    public Vector3 offset;

    private void Start()
    {
        //if(gameObject.CompareTag("Enemy"))
        //{
        //    healthSlider.gameObject.SetActive(false);
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        //healthSlider.transform.position = offset;
        offset = transform.position - Camera.main.transform.position;
        healthSlider.transform.rotation = Quaternion.LookRotation(offset);
    }

    public void SetHealth(int health, int maxHealth)
    {
        if(gameObject.CompareTag("Enemy"))
        {
            healthSlider.gameObject.SetActive(health < maxHealth);

        }
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;

        healthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, healthSlider.normalizedValue);
    }
}
