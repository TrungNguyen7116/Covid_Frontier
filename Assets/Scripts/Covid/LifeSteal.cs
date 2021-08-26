using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSteal : Covid
{
    [SerializeField]
    private GameObject effect;
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
        GameObject target = circleRange.target[0];
        if (target != null)
        {
            Instantiate(effect, target.transform.position, Quaternion.identity);
            float temp = target.GetComponent<Player>().TakeDamage(atk);
            HP.CurrentHP += temp * 0.6f;
        }
        source.Play();
    }
}
