using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Soldier : Player
{
    [SerializeField]
    private Animator punch;
    public override void SetUp()
    {
        punch.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder + 1;
    }
    public override void Die()
    {
        base.Die();
    }
    private void Update()
    {
        if (circleRange.CheckRange())
        {
            base.Action();
            Action();
        }
        else
        {
            acting = false;
            Moverment();
        }
        time += Time.deltaTime;
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

        foreach (GameObject target in circleRange.target.ToList())
        {
            if (target != null) target.GetComponent<Covid>().TakeDamage(atk);
        }
        source.Play();
        punch.SetTrigger("Action");
    }
}
