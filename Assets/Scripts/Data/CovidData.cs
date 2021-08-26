using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidData
{
    public string name;
    public int level;
    public float HP;
    public float speed;
    public float atk;
    public float def;
    public float atkspeed;
    public float range;
    public float value;

    public CovidData(CovidKind kind, int lv)
    {
        switch (kind)
        {
            case CovidKind.BASIC:
                name = "Basic Covid";
                level = lv;
                HP = 320 + 20 * level;
                atk = 40 + 2.2f * level;
                def = 5 + 1.3f * level;
                range = 0.7f;
                speed = 1.6f;
                atkspeed = 0.3f;
                value = 4 + 0.6f * level;
                break;
            case CovidKind.SNIPER:
                name = "Sniper Covid";
                level = lv;
                HP = 210 + 11 * level;
                atk = 55 + 3.5f * level;
                def = 4 + 1.1f * level;
                range = 3f;
                speed = 1.4f;
                atkspeed = 0.5f + 0.01f * level;
                value = 5 + 0.8f * level;
                break;
            case CovidKind.LIFESTEAL:
                name = "Life Steal Covid";
                level = lv;
                HP = 200 + 14 * level;
                atk = 32 + 2.3f * level;
                def = 4.5f + 1.2f * level;
                range = 2f;
                speed = 1.5f;
                atkspeed = 0.4f + 0.015f * level ;
                value = 4 + 1.1f * level;
                break;
            case CovidKind.SUPER:
                name = "Super Covid";
                level = lv;
                HP = 560 + 35 * level;
                atk = 0;
                def = 7 + 2.6f * level;
                range = 0.6f;
                speed = 1.65f;
                atkspeed = 0;
                value = 6 + 0.4f * level;
                break;
            case CovidKind.FLY:
                name = "Fly Covid";
                level = lv;
                HP = 225 + 12 * level;
                atk = 36 + 2.4f * level;
                def = 4.3f + 0.6f * level;
                range = 3.5f;
                speed = 1.6f;
                atkspeed = 0.6f + 0.012f * level;
                value = 7 + 1.1f * level;
                break;
            case CovidKind.MINI:
                name = "Mini Covid";
                level = lv;
                HP = 125 + 8 * level;
                atk = 46 + 4.2f * level;
                def = 2 + 0.4f * level;
                range = 0.8f;
                speed = 2.2f;
                atkspeed = 0.6f + 0.013f * level;
                value = 3 + 0.7f * level;
                break;
        }
    }
}
