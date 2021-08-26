using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotShop : MonoBehaviour
{
    private Character character;
    [SerializeField]
    private Image avatar;
    [SerializeField]
    private Text name;
    [SerializeField]
    private Text HP;
    [SerializeField]
    private Text atk;
    [SerializeField]
    private Text def;
    [SerializeField]
    private TextMeshProUGUI price;


    // Update is called once per frame
    void Update()
    {
        Display();
    }
    public void SetCharacter(Character character)
    {
        this.character = character;
        avatar.sprite = Resources.Load<Sprite>("Avatars/" + character.name);
        name.text = character.name;
    }
    void Display()
    {
        if (character != null)
        {
            HP.text = character.HP.ToString();
            atk.text = character.atk.ToString();
            def.text = character.def.ToString();
            price.text = character.price.ToString();
        }
    }
    public void SelectPlayer()
    {
        GameObject InfoPanel = GameObject.Find("Info Hero In Shop Panel");
        InfoPanel.GetComponent<InfoHeroInShopPanel>().SelectCharacter(character);
    }
    public void Buy()
    {
        if (GameManager.instance.character.Count >= 10) return;
        if (PlayerPrefs.GetFloat("MONEY") < character.price) return;
        GameManager.instance.character.Add(new Character(character));
        GameObject heropanel = GameObject.Find("Heroes Background");
        heropanel.GetComponent<HeroPanelManager>().BuyHero();
        GameManager.instance.SaveData();
        PlayerPrefs.SetFloat("MONEY", PlayerPrefs.GetFloat("MONEY") - character.price);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
