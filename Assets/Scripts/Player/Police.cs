using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Police : Player
{
    [SerializeField]
    private Animator gun;
    [SerializeField]
    private GameObject bullet;
    public override void SetUp()
    {
        gun.GetComponent<SpriteRenderer>().sortingOrder = this.GetComponent<SpriteRenderer>().sortingOrder - 1;
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
        if (circleRange.target[0] != null)
        {
            Vector2 dir = circleRange.target[0].transform.position - gun.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
            gun.SetTrigger("Action");
            source.Play();
            GameObject newBullet = Instantiate(bullet, gun.transform.position, Quaternion.identity);
            newBullet.GetComponent<Bullet>().SetUp(10f, atk, angle, gun.GetComponent<SpriteRenderer>().sortingOrder - 1, circleRange.target[0]);
        }
    }
}
