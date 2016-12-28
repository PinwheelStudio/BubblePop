using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //public Slider slider;
    public float hp;
    public static HealthManager instance;

    public void Awake()
    {
        instance = this;
        //slider.value = hp;
    }

    public void Subtract(float amount)
    {
        hp -= amount;
        //slider.value = hp;
        if (hp <= 0)
            GameManager.instance.GameOver();
    }

}
