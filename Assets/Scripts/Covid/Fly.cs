using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Covid
{
    [SerializeField]
    private GameObject bullet;

    public override void Die()
    {
        base.Die();
    }
    public override void SetUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 1.3f);
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
        if (circleRange.target[0] != null)
        {
            Vector2 dir = circleRange.target[0].transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().SetUp(10f, atk, angle, gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1, circleRange.target[0]);
        }
        source.Play();
    }
}
