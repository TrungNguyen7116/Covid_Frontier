using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    public string name;
    public float HP;
    public float atk;
    public float def;
    public float speed;
    public float range;
    public float atkspeed;
    public float price;
    public string description;

    public Items(Items target)
    {
        name = target.name;
        HP = target.HP;
        atk = target.atk;
        def = target.def;
        speed = target.speed;
        range = target.range;
        atkspeed = target.atkspeed;
        price = target.price;
        description = target.description;
    }
    public Items(ItemKind kind)
    {
        switch (kind)
        {
            case ItemKind.MEDICALMASK:
                name = "Medical Mask";
                price = 750;
                HP = 85;
                def = 5;
                description = "+85 HP\n+5 DEF";
                break;
            case ItemKind.NORMAL_ANTIBACTERIAL:
                name = "Normal Antibacterial";
                price = 875;
                HP = 80;
                def = 7;
                description = "+80 HP\n+7 DEF";
                break;
            case ItemKind.SUPER_ANTIBACTERIAL:
                name = "Super Antibacterial";
                price = 1250;
                HP = 150;
                def = 10;
                description = "+150 HP\n+10 DEF";
                break;
            case ItemKind.BLOOD_BAG:
                name = "Blood Bag";
                price = 1000;
                HP = 200;
                description = "+200 HP";
                break;
            case ItemKind.SHIELD:
                name = "Shield";
                price = 1550;
                def = 15;
                description = "+15 DEF";
                break;
            case ItemKind.BACKPACK:
                name = "Backpack";
                price = 2000;
                HP = 50;
                atk = 25;
                def = 5;
                description = "+50 HP\n+25 ATK\n+5 DEF";
                break;
            case ItemKind.HELMET:
                name = "Helmet";
                price = 1925;
                atk = 20;
                def = 10;
                description = "+20 ATK\n+10 DEF";
                break;
            case ItemKind.BINOCULARS:
                name = "Binoculars";
                price = 2250;
                range = 100;
                description = "+100 RANGE";
                break;
            case ItemKind.KNIFE:
                name = "Knife";
                price = 2375;
                atk = 35;
                range = 20;
                atkspeed = 0.1f;
                description = "+35 ATK\n+20 RANGE\n+10% ATKSPEED";
                break;
            case ItemKind.GAS_MASK:
                name = "Gas Mask";
                price = 2150;
                HP = 200;
                def = 10;
                description = "+200 HP\n+10 DEF";
                break;
            case ItemKind.RADIO:
                name = "Radio";
                price = 2400;
                atk = 22;
                def = 12;
                range = 40;
                description = "+22 ATK\n+12 DEF\n+40 RANGE";
                break;
            case ItemKind.MEDAL:
                name = "Medal";
                price = 3000;
                HP = 300;
                atk = 30;
                def = 15;
                range = 35;
                atkspeed = 0.2f;
                description = "+300 HP    +20% ATKSPEED\n+30 ATK\n+15 DEF\n+35 RANGE";
                break;
        }
    }
}
