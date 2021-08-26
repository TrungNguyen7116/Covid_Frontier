using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Character character;
    public const float waiting = 2f;
    public Stat HP;
    public int level;
    public float speed;
    public float range;
    public float atk;
    public float def;
    public float atkspeed;

    public bool acting = false;
    public float time;

    protected Rigidbody2D myBody;
    protected Animator anim;
    protected AudioSource source;

    public Canvas canvas;
    public Range circleRange;
    public GameObject upgrade;
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        RenderSprite();
        SetUp();
    }
    public virtual void SetUp()
    {
        //Setup at class hero
    }
    void RenderSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(5000 - transform.position.y * 100);
        canvas.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
    public void InitPlayer(Character info)
    {
        character = info;
        HP.InitHP(info.HP + info.hpAddition);
        level = info.level;
        speed = (info.speed + info.spdAddition) / 200;
        range = (info.range + info.rangeAddition) / 200;
        atk = info.atk + info.atkAddition;
        def = info.def + info.defAddition;
        atkspeed = info.atkspeed * (1 + info.atkspeedUpgrade * info.level) + info.atkspdAddition * info.atkspeed;
        circleRange.InitRange("Covid", range);
    }
    public void ReloadIndex(Character info)
    {
        character = info;
        float temp = HP.CurrentHP / HP.MaxHP;
        level = info.level;
        HP.MaxHP = info.HP + info.hpAddition;
        HP.CurrentHP = temp * HP.MaxHP;
        speed = (info.speed + info.spdAddition) / 200;
        range = (info.range + info.rangeAddition) / 200;
        atk = info.atk + info.atkAddition;
        def = info.def + info.defAddition;
        atkspeed = info.atkspeed * (1 + info.atkspeedUpgrade * info.level) + info.atkspdAddition * info.atkspeed;
        circleRange.InitRange("Covid", range);
    }
    public void Upgrade()
    {
        Instantiate(upgrade, transform.position, Quaternion.identity, transform);
    }
    public virtual void Action()
    {
        myBody.velocity = Vector2.zero;
        anim.SetBool("Action", true);
    }
    public void Moverment()
    {
        myBody.velocity = new Vector2(speed, 0);
        if (anim.GetBool("Action"))
        {
            anim.SetBool("Action", false);
        }
    }
    public float TakeDamage(float damage, bool penetration = false)
    {
        float temp = 0;
        if (penetration)
        {
            temp = HP.CurrentHP > damage ? damage : HP.CurrentHP;
            HP.CurrentHP -= damage;
        }
        else
        {
            if (damage < def) return 0;
            temp = HP.CurrentHP > (damage - def) ? (damage - def) : HP.CurrentHP;
            HP.CurrentHP -= (damage - def);
        }
        if (HP.CurrentHP <= 0)
        {
            Die();
        }
        return temp;
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    //public bool CheckRange()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), range);
    //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * range);
    //    if (hit.collider != null)
    //    {
    //        if (hit.collider.gameObject.tag == "Covid")
    //        {
    //            Debug.Log("...");
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    public float GetCurrentHP()
    {
        return HP.CurrentHP;
    }
}
