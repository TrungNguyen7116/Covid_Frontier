using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SlotHero : MonoBehaviour
{
    private Character character;
    private Player player;
    [SerializeField]
    private Image avatar;
    [SerializeField]
    private Text level;
    [SerializeField]
    private Text HP;
    [SerializeField]
    private Text atk;
    [SerializeField]
    private Text def;
    [SerializeField]
    private Image HPfill;
    [SerializeField]
    private List<Image> items;
    [SerializeField]
    private Image canUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }
    public void SetCharacter(Character character)
    {
        this.character = character;
        avatar.sprite = Resources.Load<Sprite>("Avatars/" + character.name);
        ShowItems();
    }
    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    void Display()
    {
        if (character != null)
        {
            level.text = character.level.ToString();
            HP.text = Math.Round(character.HP + character.hpAddition, 2).ToString();
            atk.text = Math.Round(character.atk + character.atkAddition, 2).ToString();
            def.text = Math.Round(character.def + character.defAddition, 2).ToString();
            if (PlayerPrefs.GetFloat("MONEY") >= (character.level + 1) * 30)
            {
                canUpgrade.color = new Color(1, 0.76f, 0);
            }
            else
            {
                canUpgrade.color = new Color(0.247f, 0.247f, 0.24f);
            }
        }
        if (player != null)
        {
            HPfill.fillAmount = player.GetCurrentHP() / character.HP;
        }
        else
        {
            HPfill.fillAmount = 1;
        }
    }
    public void Upgrade()
    {
        if (character != null)
        {
            if (character.level >= 30) return;
            float price = (character.level + 1) * 30;
            if (PlayerPrefs.GetFloat("MONEY") < price) return;
            character.Upgrade();
            PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") - price);
            if (player != null)
            {
                player.Upgrade();
                player.ReloadIndex(character);
            }
        }
    }
    public void SelectPlayer()
    {
        GameObject InfoPanel = GameObject.Find("Info Hero Panel");
        InfoPanel.GetComponent<InfoHeroPanel>().SelectCharacter(ref character, this, ref player);
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
}
