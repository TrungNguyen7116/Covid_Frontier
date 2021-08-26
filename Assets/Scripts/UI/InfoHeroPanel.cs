using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHeroPanel : MonoBehaviour
{
    private Character character;
    private SlotHero slot;
    private Player player;
    [SerializeField]
    private Image avatar;
    [SerializeField]
    private Text name;
    [SerializeField]
    private Text level;
    [SerializeField]
    private Text HP;
    [SerializeField]
    private Text atk;
    [SerializeField]
    private Text def;
    [SerializeField]
    private Text spd;
    [SerializeField]
    private Text range;
    [SerializeField]
    private Text atkspd;
    [SerializeField]
    private Text description;
    [SerializeField]
    private List<Image> items;
    
    public void SelectCharacter(ref Character target, SlotHero slot, ref Player player)
    {
        character = target;
        this.slot = slot;
        this.player = player;
        Display();
    }
    public void Close()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (slot != null) slot.ShowItems();
    }
    void Display()
    {
        avatar.sprite = Resources.Load<Sprite>("Avatars/" + character.name);
        name.text = character.name;
        level.text = "Lv. " + character.level.ToString();
        HP.text = Math.Round(character.HP, 2).ToString() + "(+" + Math.Round(character.hpAddition, 2) + ")";
        atk.text = Math.Round(character.atk, 2).ToString() + "(+" + Math.Round(character.atkAddition, 2) + ")";
        def.text = Math.Round(character.def, 2).ToString() + "(+" + Math.Round(character.defAddition, 2) + ")";
        spd.text = Math.Round(character.speed, 2).ToString() + "(+" + Math.Round(character.spdAddition, 2) + ")";
        range.text = Math.Round(character.range, 2).ToString() + "(+" + Math.Round(character.rangeAddition, 2) + ")";
        atkspd.text = Math.Round((character.atkspeed * (1 + character.atkspeedUpgrade * character.level)), 2).ToString() + "(+"  + Math.Round(character.atkspdAddition * character.atkspeed, 2) + ")";
        description.text = character.description;
        ShowItems();
        this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void ReloadPanel()
    {
        character.hpAddition = 0;
        character.atkAddition = 0;
        character.defAddition = 0;
        character.rangeAddition = 0;
        character.spdAddition = 0;
        character.atkspdAddition = 0;
        foreach (Items item in character.items)
        {
            character.hpAddition += item.HP;
            character.atkAddition += item.atk;
            character.defAddition += item.def;
            character.rangeAddition += item.range;
            character.spdAddition += item.speed;
            character.atkspdAddition += item.atkspeed;
        }
        GameManager.instance.SaveData();
        Display();
        if (player != null)
        {
            player.ReloadIndex(character);
        }
    }
    public void ShowItems()
    {
        for (int i = 0; i < character.items.Count; i++)
        {
            this.items[i].sprite = Resources.Load<Sprite>("Items/" + character.items[i].name);
        }
        for (int i = character.items.Count; i < this.items.Count; i++)
        {
            this.items[i].sprite = Resources.Load<Sprite>("Items/null");
        }
    }
    public void AccessShopItem()
    {
        GameObject shop = GameObject.Find("Item Shop Panel");
        Time.timeScale = 0;
        shop.GetComponent<ItemShopManager>().SetItemBought(ref character.items, this);
        shop.GetComponent<CanvasGroup>().alpha = 1;
        shop.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Sell()
    {
        float price = (character.price + (character.level * (character.level + 1) / 2.0f - 1) * 10) * 0.7f;
        Debug.Log(price);
        foreach (Items item in character.items)
        {
            price += item.price * 0.8f;
        }
        PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") + price);
        GameManager.instance.character.Remove(character);
        HeroPanelManager.instance.listSlotHero.Remove(slot.gameObject);
        if (player != null) Destroy(player.gameObject);
        Destroy(slot.gameObject);
        slot = null;
        Close();
        GameManager.instance.SaveData();
    }
}
