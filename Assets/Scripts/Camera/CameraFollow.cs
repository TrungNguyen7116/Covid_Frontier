using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    private bool playing = false;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            transform.position = new Vector3(-3, 0, -10);
        }
        else
        {
            if (target != null)
            {
                if (target.transform.position.x < -4) return;
                transform.position = new Vector3(target.transform.position.x + direction, 0, -10);
            }
            else
            {
                FindHero();
            }
        }
    }
    public void StartGame()
    {
        playing = true;
        FindHero();
    }
    public void EndGame()
    {
        playing = false;
    }
    public void FindHero()
    {
        direction = 1;
        float max = 0;
        GameObject[] hero = GameObject.FindGameObjectsWithTag("Hero");
        if (hero.Length == 0)
        {
            FindCovid();
            return;
        }
        for (int i = 0; i < hero.Length; i++)
        {
            if (max < hero[i].GetComponent<Player>().speed)
            {
                max = hero[i].GetComponent<Player>().speed;
                target = hero[i];
            }
        }
    }
    public void FindCovid()
    {
        direction = -1;
        float max = 0;
        GameObject[] covid = GameObject.FindGameObjectsWithTag("Covid");
        for (int i = 0; i < covid.Length; i++)
        {
            if (max < covid[i].GetComponent<Covid>().speed)
            {
                max = covid[i].GetComponent<Covid>().speed;
                target = covid[i];
            }
        }
    }
}
