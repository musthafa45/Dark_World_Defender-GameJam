using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public PlayerMovements player;
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        float fillValue = player.CurrentHealth;
        slider.value = fillValue;
    }
}
