using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHeroInShopPanel : MonoBehaviour
{
    private Character character;
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

    public void SelectCharacter(Character target)
    {
        character = target;
        Display();
    }
    public void Close()
    {
        this.gameObject.GetComponent<CanvasGroup>().alpha = 0;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    void Display()
    {
        avatar.sprite = Resources.Load<Sprite>("Avatars/" + character.name);
        name.text = character.name;
        level.text = "Lv. " + character.level.ToString();
        HP.text = character.HP.ToString();
        atk.text = character.atk.ToString();
        def.text = character.def.ToString();
        spd.text = character.speed.ToString();
        range.text = character.range.ToString();
        atkspd.text = character.atkspeed.ToString();
        description.text = character.description;
        this.gameObject.GetComponent<CanvasGroup>().alpha = 1;
        this.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Buy()
    {
        //
    }
}
