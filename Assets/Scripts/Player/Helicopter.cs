using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : Player
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform point;
    public override void Die()
    {
        base.Die();
    }
    public override void SetUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(5000 - (transform.position.y + 1.5f) * 100);
        atk = atk * 0.5f;
        atkspeed = 1.8f;
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
            source.Play();
            Vector2 dir = circleRange.target[0].transform.position - point.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject newBullet = Instantiate(bullet, point.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().SetUp(10f, atk, angle, gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1, circleRange.target[0]);
        }
    }
}
