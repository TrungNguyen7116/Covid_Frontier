using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private float maxHP;
    private float currentHP;
    [SerializeField]
    private Image bar;

    public float CurrentHP { get => currentHP; set { currentHP = value; if (currentHP > maxHP) currentHP = maxHP; } }
    public float MaxHP { get => maxHP; set => maxHP = value; }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = currentHP / MaxHP;
    }

    public void InitHP(float value)
    {
        MaxHP = value;
        CurrentHP = value;
    }
}
