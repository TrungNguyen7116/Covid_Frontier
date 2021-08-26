using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : Player
{
    [SerializeField]
    private GameObject healEffect;
    public override void Die()
    {
        base.Die();
    }
    public override void SetUp()
    {
    }
    private void Update()
    {
        if (circleRange.CheckRange())
        {
            base.Action();
        }
        else
        {
            acting = false;
            Moverment();
        }
        time += Time.deltaTime;
        Action();
    }
    public override void Action()
    {
        if (time >= 3)
        {
            time = 0;
            ActionCoroutine();
        }
    }

    void ActionCoroutine()
    {
        GameObject[] hero = GameObject.FindGameObjectsWithTag("Hero");
        float min = hero[0].GetComponent<Player>().HP.CurrentHP / hero[0].GetComponent<Player>().HP.MaxHP;
        int index = 0;
        for (int i = 0; i < hero.Length; i++)
        {
            float temp = hero[i].GetComponent<Player>().HP.CurrentHP / hero[i].GetComponent<Player>().HP.MaxHP;
            if (temp < min)
            {
                min = temp;
                index = i;
            }
        }
        source.Play();
        Instantiate(healEffect, hero[index].transform.position, Quaternion.identity, hero[index].transform);
        hero[index].GetComponent<Player>().HP.CurrentHP += atk;
    }
}
