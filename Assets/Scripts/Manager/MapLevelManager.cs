using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelManager : MonoBehaviour
{
    public static MapLevelManager instance;

    [SerializeField]
    private Transform endPoint;
    //Covid 
    [SerializeField]
    private GameObject basic;
    [SerializeField]
    private GameObject sniper;
    [SerializeField]
    private GameObject lifesteal;
    [SerializeField]
    private GameObject super;
    [SerializeField]
    private GameObject fly;
    [SerializeField]
    private GameObject mini;
    private void Start()
    {
        if (instance == null) instance = this;
    }
    // basic - sniper - lifesteal - super - fly - mini
    private int[,] map = new int[,]
    {
        {3, 0, 0, 0, 0, 0}, //0
        {3, 2, 0, 0, 0, 0},
        {5, 3, 0, 0, 1, 0},
        {5, 4, 0, 0, 1, 0},
        {7, 3, 0, 0, 2, 0},
        {8, 3, 0, 2, 2, 0}, //5
        {2, 5, 0, 3, 0, 0},
        {0, 4, 0, 4, 2, 0},
        {7, 4, 2, 0, 2, 0},
        {10, 0, 0, 2, 0, 0},
        {0, 0, 3, 0, 0, 20}, //10
        {4, 0, 5, 2, 1, 10},
        {4, 4, 4, 3, 1, 2},
        {5, 6, 2, 4, 4, 10},
        {5, 5, 2, 2, 4, 15},
        {10, 6, 1, 2, 6, 0}, //15
        {10, 5, 6, 2, 4, 2},
        {4, 12, 0, 2, 1, 1},
        {6, 10, 5, 2, 1, 3},
        {4, 4, 9, 3, 10, 10},
        {6, 8, 5, 2, 5, 5}, //20
        {8, 10, 5, 4, 7, 5},
        {9, 12, 6, 4, 5, 9},
        {12, 12, 6, 6, 8, 25},
        {0, 15, 10, 6, 12, 0},
        {3, 20, 0, 5, 10, 0}, //25
        {8, 10, 0, 6, 5, 0},
        {12, 12, 0, 4, 4, 4},
        {13, 11, 4, 4, 5, 10},
        {10, 15, 5, 5, 5, 30}, 
        {10, 16, 4, 4, 5, 10}, //30
        {11, 16, 5, 5, 5, 0},
        {11, 10, 10, 5, 10, 0},
        {4, 25, 10, 7, 10, 2},
        {16, 16, 0, 0, 20, 30},
        {0, 0, 0, 10, 20, 0}, //35
        {10, 0, 0, 6, 12, 10},
        {0, 6, 7, 6, 18, 20},
        {5, 5, 10, 3, 15, 20},
        {10, 12, 10, 3, 12, 10},
        {10, 5, 12, 4, 10, 10}, //40
        {4, 12, 12, 3, 12, 25},
        {15, 3, 0, 0, 3, 30},
        {0, 15, 0, 2, 15, 40},
        {4, 17, 4, 3, 15, 20},
        {5, 6, 0, 8, 5, 20}, //45
        {10, 10, 10, 3, 10, 20},
        {12, 10, 14, 4, 12, 25},
        {13, 12, 15, 5, 15, 25},
        {15, 15, 15, 5, 15, 30},
        {15, 15, 15, 5, 15, 30}, //50
    };
    public void SetLevel(int lv)
    {
        for (int i = 0; i < 6; i++)
        {
            if (map[lv, i] != 0 )
            {
                for (int j = 0; j < map[lv, i]; j++)
                {
                    GameObject covid = CreateCovid((CovidKind)i);
                    covid.GetComponent<Covid>().InitCovid(new CovidData((CovidKind)i, lv));
                    RandomPosition(covid);
                }
            }
        }
    }
    public int LengthMap()
    {
        return map.Length;
    }
    GameObject CreateCovid(CovidKind covidKind)
    {
        GameObject covid = null;
        switch (covidKind)
        {
            case CovidKind.BASIC:
                covid = Instantiate(basic, endPoint.transform.position, Quaternion.identity);
                break;
            case CovidKind.SNIPER:
                covid = Instantiate(sniper, endPoint.transform.position, Quaternion.identity);
                break;
            case CovidKind.LIFESTEAL:
                covid = Instantiate(lifesteal, endPoint.transform.position, Quaternion.identity);
                break;
            case CovidKind.SUPER:
                covid = Instantiate(super, endPoint.transform.position, Quaternion.identity);
                break;
            case CovidKind.FLY:
                covid = Instantiate(fly, endPoint.transform.position, Quaternion.identity);
                break;
            case CovidKind.MINI:
                covid = Instantiate(mini, endPoint.transform.position, Quaternion.identity);
                break;
        }
        return covid;
    }
    void RandomPosition(GameObject target)
    {
        float x = x = UnityEngine.Random.Range(-0.5f, 0.5f);
        float y = UnityEngine.Random.Range(-0.3f, 0.3f);
        target.transform.position = new Vector2(target.transform.position.x + x, target.transform.position.y + y);
    }
}
