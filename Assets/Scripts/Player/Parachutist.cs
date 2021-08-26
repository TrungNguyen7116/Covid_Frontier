using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parachutist : Player
{
    [SerializeField]
    private GameObject parasailing;

    [SerializeField]
    private Animator gun;
    [SerializeField]
    private GameObject bullet;
    public override void SetUp()
    {
        gun.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder + 1;
        parasailing.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder - 1;
        transform.position = new Vector2(transform.position.x, transform.position.y + 1.3f);
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
        GameObject target = circleRange.target[0];
        foreach (GameObject element in circleRange.target.ToList())
        {
            if (element.transform.position.y >= 3)
            {
                target = element;
            }
        }
        if (target != null)
        {
            Vector2 dir = target.transform.position - gun.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
            gun.SetTrigger("Action");
            GameObject newBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().SetUp(10f, atk, angle, gun.GetComponent<SpriteRenderer>().sortingOrder - 1, circleRange.target[0]);
        }
        source.Play();
    }
}
