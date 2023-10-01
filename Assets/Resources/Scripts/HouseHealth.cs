using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseHealth : MonoBehaviour
{
    public House house;
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

   
    void Update()
    {
        float fillValue = house.CurrentHealth;
        slider.value = fillValue;
    }
}
