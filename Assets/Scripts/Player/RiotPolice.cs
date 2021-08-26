using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiotPolice : Player
{
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject heal;
    public override void SetUp()
    {
        shield.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder + 1;
        myBody.AddForce(Vector2.right * 500);
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
        if (time >= 5)
        {
            time = 0;
            ActionCoroutine();
        }
    }

    void ActionCoroutine()
    {
        source.Play();
        Instantiate(heal, transform.position, Quaternion.identity, transform);
        HP.CurrentHP += 0.05f * HP.MaxHP;
    }
}
