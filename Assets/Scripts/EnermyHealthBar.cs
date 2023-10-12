using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyHealthBar : MonoBehaviour
{

    public Slider slider;

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setHealth(int health, GameObject obj)
    {
        slider.value = health;
        if(health <= 0)
        {
            Destroy(obj);
            this.gameObject.SetActive(false);
        }
    }
}
