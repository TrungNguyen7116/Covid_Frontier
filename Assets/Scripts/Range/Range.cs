using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private string targetTag;
    private CircleCollider2D circle;
    private bool check;
    public List<GameObject> target = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void InitRange(string target, float value)
    {
        this.gameObject.GetComponent<CircleCollider2D>().radius = value;
        targetTag = target;
    }
    public bool CheckRange()
    {
        return check;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            check = true;
            target.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            target.Remove(collision.gameObject);
            if (target.Count == 0)
            {
                check = false;
            }
        }
    }
}
