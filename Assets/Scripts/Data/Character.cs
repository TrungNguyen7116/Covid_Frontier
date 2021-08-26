using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string name;
    public int level;
    public float HP;
    public float speed;
    public float atk;
    public float def;
    public float atkspeed;
    public float range;
    public PlayerKind kind;
    public string description;
    public List<Items> items;
    public float atkAddition;
    public float defAddition;
    public float hpAddition;
    public float spdAddition;
    public float rangeAddition;
    public float atkspdAddition;
    public float atkspeedUpgrade;
    public float price;

    public Character(PlayerKind kind)
    {
        switch (kind)
        {
            case PlayerKind.SOLDIER:
                name = "Soldier";
                this.kind = kind;
                level = 1;
                HP = 537.85f;
                atk = 57.88f;
                def = 27.54f;
                range = 175f;
                speed = 340f;
                atkspeed = 0.625f;
                atkspeedUpgrade = 0.029f;
                description = "I love Vietnam! Viva Vietnam!";
                price = 50;
                break;
            case PlayerKind.POLICE:
                name = "Police";
                this.kind = kind;
                level = 1;
                HP = 524.4f;
                atk = 53.66f;
                def = 22.88f;
                range = 650f;
                speed = 325f;
                atkspeed = 0.568f;
                atkspeedUpgrade = 0.043f;
                description = "Covid? Come on! I will destroy them.";
                price = 50;
                break;
            case PlayerKind.RIOTPOLICE:
                name = "Riot Police";
                this.kind = kind;
                level = 1;
                HP = 662.48f;
                atk = 0f;
                def = 39.21f;
                range = 125f;
                speed = 335f;
                atkspeed = 0f;
                atkspeedUpgrade = 0f;
                description = "Hide behind me!";
                price = 55;
                break;
            case PlayerKind.INVESTOR:
                name = "Investor";
                this.kind = kind;
                level = 1;
                HP = 540f;
                atk = 1.35f;
                def = 29f;
                range = 500f;
                speed = 310f;
                atkspeed = 0.121f;
                atkspeedUpgrade = 0.032f;
                description = "Making money is easy!";
                price = 70;
                break;
            case PlayerKind.NURSE:
                name = "Nurse";
                this.kind = kind;
                level = 1;
                HP = 552.76f;
                atk = 53.44f;
                def = 19.216f;
                range = 550f;
                speed = 330f;
                atkspeed = 0;
                atkspeedUpgrade = 0f;
                description = "With me behind you, don't worry!";
                price = 150;
                break;
            case PlayerKind.DOCTOR:
                name = "Doctor";
                this.kind = kind;
                level = 1;
                HP = 522.44f;
                atk = 20.86f;
                def = 20.38f;
                range = 525f;
                speed = 335f;
                atkspeed = 0;
                atkspeedUpgrade = 0f;
                description = "Covid is not scary at all.";
                price = 250;
                break;
            case PlayerKind.PARACHUTIST:
                name = "Parachutist";
                this.kind = kind;
                level = 1;
                HP = 512.16f;
                atk = 56f;
                def = 23.38f;
                range = 550f;
                speed = 325f;
                atkspeed = 0.625f;
                atkspeedUpgrade = 0.038f;
                description = "Let's fly!";
                price = 250;
                break;
            case PlayerKind.RAMBO:
                name = "Rambo";
                this.kind = kind;
                level = 1;
                HP = 557.76f;
                atk = 76f;
                def = 25.54f;
                range = 550f;
                speed = 330f;
                atkspeed = 0.379f;
                atkspeedUpgrade = 0.021f;
                description = "HEY HEY HEY !!!";
                price = 250;
                break;
            case PlayerKind.GENERAL:
                name = "General";
                this.kind = kind;
                level = 1;
                HP = 540f;
                atk = 56f;
                def = 26f;
                range = 380f;
                speed = 345f;
                atkspeed = 0.651f;
                atkspeedUpgrade = 0.023f;
                description = "Everyone, let's fight the epidemic together!";
                price = 400;
                break;
            default:
                Debug.Log("Can't find hero!");
                break;
        }
        items = new List<Items>();
    }
    public Character(Character target)
    {
        name = target.name;
        level = 1;
        HP = target.HP;
        speed = target.speed;
        atk = target.atk;
        atkspeed = target.atkspeed;
        range = target.range;
        def = target.def;
        atkspeedUpgrade = target.atkspeedUpgrade;
        kind = target.kind;
        description = target.description;
        items = new List<Items>();
        price = target.price;
    }
    public void Upgrade()
    {
        level++;
        switch (kind)
        {
            case PlayerKind.SOLDIER:
                HP += 84f;
                atk += 3.5f;
                def += 3f;
                break;
            case PlayerKind.POLICE:
                HP += 70f;
                atk += 2.8f;
                def += 3.5f;
                break;
            case PlayerKind.RIOTPOLICE:
                HP += 89f;
                def += 4.5f;
                break;
            case PlayerKind.INVESTOR:
                HP += 72f;
                atk += 0.12f;
                def += 3f;
                break;
            case PlayerKind.NURSE:
                HP += 64f;
                atk += 3.3f;
                def += 3.7f;
                break;
            case PlayerKind.DOCTOR:
                HP += 73f;
                atk += 2.6f;
                def += 3.8f;
                break;
            case PlayerKind.PARACHUTIST:
                HP += 72f;
                atk += 3.5f;
                def += 3.5f;
                break;
            case PlayerKind.RAMBO:
                HP += 72f;
                atk += 3.9f;
                def += 3.3f;
                break;
            case PlayerKind.GENERAL:
                HP += 72f;
                atk += 2f;
                def += 3f;
                break;
        }
        GameManager.instance.SaveData();
    }
}
