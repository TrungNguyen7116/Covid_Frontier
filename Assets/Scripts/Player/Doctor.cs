using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Player
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
        if (time >= 7)
        {
            time = 0;
            ActionCoroutine();
        }
    }

    void ActionCoroutine()
    {
        GameObject[] hero = GameObject.FindGameObjectsWithTag("Hero");
        for (int i = 0; i < hero.Length; i++)
        {
            Instantiate(healEffect, hero[i].transform.position, Quaternion.identity, hero[i].transform);
            hero[i].GetComponent<Player>().HP.CurrentHP += atk;
        }
        source.Play();
    }
}
