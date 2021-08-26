using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    public float waiting = 2f;
    public Stat HP;
    public int level;
    public float speed;
    public float range;
    public float atk;
    public float def;
    public float atkspeed;
    public float value;

    private Rigidbody2D myBody;
    private Animator anim;
    protected AudioSource source;

    public bool acting = false;
    public float time;

    public Canvas canvas;
    public Range circleRange;


    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        RenderSprite();
        SetUp();
    }

    public virtual void SetUp()
    {
        //
    }

    public void InitCovid(CovidData info)
    {
        HP.InitHP(info.HP);
        level = info.level;
        atk = info.atk;
        def = info.def;
        range = info.range;
        speed = info.speed;
        atkspeed = info.atkspeed;
        circleRange.InitRange("Hero", info.range);
        value = info.value;
    }
    void RenderSprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(5000 - transform.position.y * 100);
        canvas.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
    public virtual void Action()
    {
        myBody.velocity = Vector2.zero;
    }
    public void Moverment()
    {
        myBody.velocity = new Vector2(-speed, 0);
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
        float temp = PlayerPrefs.GetFloat("MONEY");
        temp += value;
        PlayerPrefs.SetFloat("MONEY", temp);
        Destroy(gameObject);
    }
    //public bool CheckRange()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), range);
    //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * range);
    //    if (hit.collider != null)
    //    {
    //        if (hit.collider.gameObject.CompareTag("Hero"))
    //        {
    //            Debug.Log("colide");
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
