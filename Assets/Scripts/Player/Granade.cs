using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private LayerMask covidLayer;

    private float damage;

    private float startPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position.y;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = (int)(5000 - (startPoint - 1.5f) * 100);
    }
    public void SetDamage(float value)
    {
        damage = value;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= (startPoint - 1.5f))
        {
            Explosion();
        }
    }
    void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Covid")
        {
            collision.gameObject.GetComponent<Covid>().TakeDamage(100);
        }
    }
}
