using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject explosion;

    private GameObject target;

    private Vector2 direction;

    private float speed;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = transform.position;
        temp.x += direction.x * Time.deltaTime * speed;
        temp.y += direction.y * Time.deltaTime * speed;
        transform.position = temp;
    }
    public void SetUp(float speed, float damage, float angle, int layer, GameObject target)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = layer;
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        angle = angle * Mathf.Deg2Rad;
        direction.x = Mathf.Cos(angle);
        direction.y = Mathf.Sin(angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Covid" && target == collision.gameObject)
        {
            collision.gameObject.GetComponent<Covid>().TakeDamage(damage);
            Instantiate(explosion, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Hero" && target == collision.gameObject)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            Instantiate(explosion, collision.transform.position, Quaternion.identity, collision.transform);
            Destroy(gameObject);
        }
    }
}
