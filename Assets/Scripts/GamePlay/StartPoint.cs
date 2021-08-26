using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public bool isColided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        isColided = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Covid")
        {
            if (!isColided)
            {
                isColided = true;
                GameObject[] hero = GameObject.FindGameObjectsWithTag("Hero");
                foreach (GameObject target in hero)
                {
                    Destroy(target.gameObject);
                }
                GameObject[] covid = GameObject.FindGameObjectsWithTag("Covid");
                foreach (GameObject target in covid)
                {
                    Destroy(target.gameObject);
                }
                GamePlayManager.instance.PreMap();
            }
        }
    }
}
