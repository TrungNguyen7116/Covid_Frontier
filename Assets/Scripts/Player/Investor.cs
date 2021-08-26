using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investor : Player
{
    [SerializeField]
    private Animator makeMoney;
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
        if (time >= waiting - atkspeed)
        {
            time = 0;
            ActionCoroutine();
        }
    }

    void ActionCoroutine()
    {
        source.Play();
        makeMoney.SetTrigger("Action");
        PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") + atk);
    }
}

